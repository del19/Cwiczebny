using System.IO;
using SyncAPIConnector.streaming;
using System;
using pl.xtb.api.message.response;
using System.Net.Sockets;
using pl.xtb.api.message.records;
using JSONObject = Newtonsoft.Json.Linq.JObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICommunicationException = pl.xtb.api.message.error.APICommunicationException;
using System.Threading;
using System.Net.Security;
using pl.xtb.api.sync;
using System.Security.Cryptography.X509Certificates;

namespace pl.xtb.api.streaming
{




    /// 
    /// <summary>
    /// @author jdabrowski
    /// </summary>
    public class StreamingAPIConnect : IDisposable
    {


        private System.Net.Sockets.TcpClient apiSocket = null;
        private StreamWriter apiWriteStream = null;
        private StreamReader apiBufferedReader;
        private StreamingListener sl;
        private string streamingSessionId;
        public bool running = true;

        public StreamingAPIConnect(StreamingListener sl, string ip, int port, LoginResponse lr, bool secure)
        {

            this.sl = sl;
            this.streamingSessionId = lr.StreamingSessionId;
            apiSocket = new System.Net.Sockets.TcpClient(ip, port);
            if (secure)
            {
                SslStream ssl = new SslStream(apiSocket.GetStream());
                ssl.AuthenticateAsClient("xtb.com"); //hardcoded domain, because we use ip-version of the address
                apiWriteStream = new StreamWriter(ssl);
                apiBufferedReader = new StreamReader(ssl);
            }
            else
            {
                NetworkStream ns = apiSocket.GetStream();
                apiWriteStream = new StreamWriter(ns);
                apiBufferedReader = new StreamReader(ns);
            }
            

            Thread t = new Thread(delegate()
            {
                while (running)
                {
                    readStreamMessage();
                    Thread.Sleep(50);
                }
            });
            t.Start();
            //System.Threading.Timer t = new System.Threading.Timer(o => readStreamMessage(), null, 0, 10);
        }

        public StreamingAPIConnect(StreamingListener sl, string ip, int port, LoginResponse lr)
            : this(sl, ip, port, lr, false)
        {
        }

        public StreamingAPIConnect(StreamingListener sl, ServerData dt, LoginResponse lr)
            : this(sl, dt.address, dt.streamingPort, lr, dt.secure)
        {
        }

        private void readStreamMessage()
        {
            try
            {
                String message;
                TickRecord tickRecord = null;
                TradeRecord tradeRecord = null;



                if ((message = readMessage()) != null)
                {
                                        
                    try
                    {
                        
                        JSONObject ob = (JSONObject)JSONObject.Parse(message);
                        if ("tickPrices".Equals(ob["command"].ToString())){

                            tickRecord = new TickRecord();
                            tickRecord.FieldsFromJSONObject((JSONObject)ob["data"], null);
                            sl.receiveTickRecord(tickRecord);
                        }
                        if ("trade".Equals(ob["command"].ToString())){
                            tradeRecord = new TradeRecord();
                            tradeRecord.FieldsFromJSONObject((JSONObject)ob["data"], null);
                            sl.receiveTradeRecord(tradeRecord);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.Error.Write(ex.StackTrace);
                    }
                    

                }


            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.StackTrace);
            }
        }

        

        public virtual void writeMessage(string message)
        {
            apiWriteStream.WriteLine(message);
            apiWriteStream.Flush();
        }

        public virtual string readMessage()
        {
            StringBuilder sb = new StringBuilder();
            string newline = null;
            string messageString = null;
            bool readDone = false;
            bool sockOK = true;
            try
            {
                while (!readDone && ((newline = apiBufferedReader.ReadLine()) != null))
                {
                    if ("".Equals(newline.Trim()) && sb.Length>0)
                    {
                        messageString = sb.ToString();
                        sb.Clear();
                        readDone = true;
                    }
                    else
                    {
                        sb.Append(newline);
                    }
                    newline = null;
                }
                if (!sockOK)
                {
                    throw new APICommunicationException("Read error. Socket state invalid.");
                }
            }
            catch (Exception ex)
            {
                if (running) throw new APICommunicationException(ex.Message);
                if (!running) return null;
            }
            return messageString;
        }

        public void subscribePrices(List<String> symbols)
        {
            foreach (String symbol in symbols)
            {
                subscribePrice(symbol);
            }
        }

        public void subscribePrice(String symbol)
        {
            JSONObject ob = new JSONObject();
            ob.Add("command", "getTickPrices");
            ob.Add("symbol", symbol);
            ob.Add("streamSessionId", streamingSessionId);
            writeMessage(ob.ToString());
        }

        public void unsubscribePrice(String symbol)
        {
            JSONObject ob = new JSONObject();
            ob.Add("command", "stopTickPrices");
            ob.Add("symbol", symbol);
            writeMessage(ob.ToString());
        }

        public void unsubscribePrices(LinkedList<String> symbols)
        {
            foreach (String symbol in symbols)
            {
                unsubscribePrice(symbol);
            }
        }

        public void subscribeTrades()
        {
            JSONObject ob = new JSONObject();
            ob.Add("command", "getTrades");
            ob.Add("streamSessionId", streamingSessionId);
            writeMessage(ob.ToString());
        }

        public void unsubscribeTrades()
        {
            JSONObject ob = new JSONObject();
            ob.Add("command", "stopTrades");
            writeMessage(ob.ToString());
        }

        public virtual void close()
        {
            try
            {
                this.running = false;
                this.apiSocket.Close();
            }
            catch (Exception ex)
            {
                throw new APICommunicationException(ex.Message);
            }
        }

        public void Dispose()
        {
            this.apiBufferedReader.Close();
            this.apiWriteStream.Close();
            this.apiSocket.Close();
        }

        public void subscribePricesL(LinkedList<string> symbols)
        {
            foreach (String symbol in symbols)
            {
                subscribePrice(symbol);
            }
        }
    }

}