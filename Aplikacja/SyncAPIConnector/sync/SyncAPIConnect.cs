using System;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Json;
/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.sync
{

	using APICommunicationException = pl.xtb.api.message.error.APICommunicationException;
	using APICommandConstructionException = pl.xtb.api.message.error.APICommandConstructionException;
	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using APICommandFactory = pl.xtb.api.message.command.APICommandFactory;
	using BaseCommand = pl.xtb.api.message.command.BaseCommand;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;
	using APIErrorResponse = pl.xtb.api.message.response.APIErrorResponse;
	using LoginResponse = pl.xtb.api.message.response.LoginResponse;
	using SymbolResponse = pl.xtb.api.message.response.SymbolResponse;
	using TickPricesResponse = pl.xtb.api.message.response.TickPricesResponse;
	using System.Net.Sockets;
    using System.Net.Security;
	using System.IO;
    using pl.xtb.api.message.command;
    using System.Security.Cryptography.X509Certificates;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class SyncAPIConnect : IDisposable
	{


		private const long COMMAND_TIME_SPACE = 1010;
		private System.Net.Sockets.TcpClient apiSocket = null;
        

		private StreamWriter apiWriteStream = null;
		private StreamReader apiBufferedReader;
		

		public SyncAPIConnect(string ip, int port, bool secure)
		{
			apiSocket = new System.Net.Sockets.TcpClient(ip, port);
            
            if (secure)
            {
                SslStream sl = new SslStream(apiSocket.GetStream());
                sl.AuthenticateAsClient("xtb.com");//hardcoded domain, because we use ip-version of the address
                
                
                apiWriteStream = new StreamWriter(sl);
                apiBufferedReader = new StreamReader(sl);
            }
            else
            {
                NetworkStream ns = apiSocket.GetStream();
                apiWriteStream = new StreamWriter(ns);
                apiBufferedReader = new StreamReader(ns);
            }
            
			
		}

        public SyncAPIConnect(string ip, int port): this(ip,port,false)
        {
            
        }

        public SyncAPIConnect(ServerData dt)
            : this(dt.address, dt.mainPort, dt.secure)
        {
        }

		
		public virtual JSONObject executeCommand(BaseCommand cmd)
		{
			try
			{
				return (JSONObject)JSONObject.Parse(this.executeCommand(cmd.toJSONString()));
			}
			catch (Exception ex)
			{
                Console.Error.WriteLine("PRZY EGZEKUCJI");
				throw new APICommunicationException("JSON PARSE ERROR: " + ex.Message);
			}
		}

		
		
		public virtual string executeCommand(string message)
		{
			this.writeMessage(message);
			long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			string response = this.readMessage();
			long currTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			long elapsedTime = currTime - startTime;
			if (elapsedTime < COMMAND_TIME_SPACE)
			{
				Thread.Sleep((int)(COMMAND_TIME_SPACE - elapsedTime));
			}
			return response;
		}

		
		
		public virtual void writeMessage(string message)
		{
			if (checkSocketState(APISocketOperation.WRITE))
			{
				apiWriteStream.WriteLine(message);
				apiWriteStream.Flush();
			}
			else
			{
				throw new APICommunicationException("Write error. Socket state invalid.");
			}
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
				while (!readDone && (sockOK = this.checkSocketState(APISocketOperation.READ)) && ((newline = apiBufferedReader.ReadLine()) != null))
				{
					if ("\n".Equals(newline) || "".Equals(newline))
					{
						messageString = sb.ToString();
						sb.Length = 0;
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
				throw new APICommunicationException(ex.Message);
			}
			return messageString;
		}

		
		
		public virtual void close()
		{

			try
			{
				this.apiSocket.Close();
			}
			catch (Exception ex)
			{
				throw new APICommunicationException(ex.Message);
			}
		}

		/// <param name="args"> the command line arguments </param>
		
		
		
		private bool checkSocketState(APISocketOperation op)
		{
			switch (op)
			{
				case APISocketOperation.CLOSE:
					if (this.apiSocket.Connected)
					{
						return true;
					}
					else
					{
						Console.Error.WriteLine("CANNOT CLOSE SOCKET: Socket is not connected.");
						return false;
					}
				case APISocketOperation.READ:
					if (!this.apiSocket.Connected)
					{
						Console.Error.WriteLine("CANNOT READ SOCKET: Socket is closed.");
						return false;
					}
					else return true;
				case APISocketOperation.WRITE:
					if (!this.apiSocket.Connected)
					{
						Console.Error.WriteLine("CANNOT WRITE SOCKET: Socket is closed.");
						return false;
					}
					else return true;
			}
			return false;
		}

        public void Dispose()
        {
            this.apiBufferedReader.Close();
            this.apiWriteStream.Close();
            this.apiSocket.Close();
        }
    }

}