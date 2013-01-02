using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pl.xtb.api.sync;
using pl.xtb.api.message.command;
using pl.xtb.api.message.response;
using pl.xtb.api.message.error;
using SyncAPIConnector.streaming;
using pl.xtb.api.message.records; 
using pl.xtb.api.streaming;
using pl.xtb.api.message.codes;
using System.Threading;

namespace SyncAPIConnectorTest
{
    class StrList : StreamingListener
    {
        void StreamingListener.receiveTradeRecord(TradeRecord tradeRecord)
        {
            Console.WriteLine(tradeRecord.ToString());
        }
        void StreamingListener.receiveTickRecord(TickRecord tickRecord)
        {
            Console.WriteLine(tickRecord.ToString());
            foreach (KeyValuePair<long?, double?> i in tickRecord.Profits)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                SyncAPIConnect connector = new SyncAPIConnect(ServerData.ProductionServers["CONTEST"]);

                /* Enter your registration credentials (login & pass) here.	   LOGIN     PASSWORD			*/
                BaseCommand loginCmd = APICommandFactory.createLoginCommand( 00000000, "your_password", false);
                Console.Error.WriteLine("SENDING LoginCommand   :  " + loginCmd.toJSONString());
                string responseJSON = connector.executeCommand(loginCmd.toJSONString());
                Console.Error.WriteLine("RECEIVED LoginResponse   : " + responseJSON);
                LoginResponse resp = new LoginResponse(responseJSON);
                Console.Error.WriteLine(resp.Status);
                
                StrList xyz = new StrList();
               StreamingAPIConnect scnn = new StreamingAPIConnect(xyz, ServerData.ProductionServers["REAL"], resp);
                
                scnn.subscribeTrades();
                LinkedList<string> symbols = new LinkedList<string>();
                symbols.AddLast("EURUSD.");
                symbols.AddLast("EURJPY.");
                symbols.AddLast("USDPLN.");
                symbols.AddLast("EURGBP.");
                scnn.subscribePricesL(symbols);

                CurrentUserDataResponse data = APICommandFactory.executeCurrentUserDataCommand(connector, false);
                Console.WriteLine(data.Currency + " " + data.Leverage);
                ProfitCalculationResponse resp_calc = APICommandFactory.executeProfitCalculationCommand(connector, "EURUSD", 0.1, TRADE_OPERATION_CODE.BUY, 1.001, 1.0003, false);
                Console.WriteLine(resp_calc.Profit);
                MarginTradeResponse mtrade = APICommandFactory.executeMarginTradeCommand(connector, "EURUSD", 0.1, TRADE_OPERATION_CODE.BUY, false);
                Console.WriteLine(mtrade.Margin);
                mtrade = APICommandFactory.executeMarginTradeCommand(connector, "EURUSD", 0.1, false);
                Console.WriteLine(mtrade.Margin);
                mtrade = APICommandFactory.executeMarginTradeCommand(connector, "EURUSD", 0.1, TRADE_OPERATION_CODE.SELL, false);
                Console.WriteLine(mtrade.Margin);
                mtrade = APICommandFactory.executeMarginTradeCommand(connector, "EURUSD", 0.1, TRADE_OPERATION_CODE.BUY_LIMIT, false);
                Console.WriteLine(mtrade.Margin);

                SymbolResponse sresp = APICommandFactory.executeSymbolCommand(connector, "EURUSD", false);
                SymbolRecord s = sresp.Symbol;
                Console.WriteLine(s.Ask + " " + s.Bid +" " + s.ContractSize + " " + s.SwapLong);

                    Console.Read();
                connector.close();
            }
            catch (APICommandConstructionException ex)
            {
                Console.Error.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write(ex.StackTrace);
                Console.Read();
            }
            
        }
        

    }
}
