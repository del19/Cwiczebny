using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.command
{

    using JSONArray = Newtonsoft.Json.Linq.JArray;
    using JSONObject = Newtonsoft.Json.Linq.JObject;
    using ChartLastInfoRecord = pl.xtb.api.message.records.ChartLastInfoRecord;
    using ChartRangeInfoRecord = pl.xtb.api.message.records.ChartRangeInfoRecord;
    using PERIOD_CODE = pl.xtb.api.message.codes.PERIOD_CODE;
    using TRADE_OPERATION_CODE = pl.xtb.api.message.codes.TRADE_OPERATION_CODE;
    using TRADE_TRANSACTION_TYPE = pl.xtb.api.message.codes.TRADE_TRANSACTION_TYPE;
    using TradeTransInfoRecord = pl.xtb.api.message.records.TradeTransInfoRecord;
    using APICommandConstructionException = pl.xtb.api.message.error.APICommandConstructionException;
    using APICommunicationException = pl.xtb.api.message.error.APICommunicationException;
    using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;
    using APIErrorResponse = pl.xtb.api.message.response.APIErrorResponse;
    using AllSymbolsResponse = pl.xtb.api.message.response.AllSymbolsResponse;
    using ChartLastResponse = pl.xtb.api.message.response.ChartLastResponse;
    using ChartRangeResponse = pl.xtb.api.message.response.ChartRangeResponse;
    using CommissionDefResponse = pl.xtb.api.message.response.CommissionDefResponse;
    using ConfirmPricedResponse = pl.xtb.api.message.response.ConfirmPricedResponse;
    using ConfirmRequotedResponse = pl.xtb.api.message.response.ConfirmRequotedResponse;
    using LoginResponse = pl.xtb.api.message.response.LoginResponse;
    using LogoutResponse = pl.xtb.api.message.response.LogoutResponse;
    using MarginLevelResponse = pl.xtb.api.message.response.MarginLevelResponse;
    using MarginTradeResponse = pl.xtb.api.message.response.MarginTradeResponse;
    using NewsResponse = pl.xtb.api.message.response.NewsResponse;
    using ServerTimeResponse = pl.xtb.api.message.response.ServerTimeResponse;
    using SymbolGroupsResponse = pl.xtb.api.message.response.SymbolGroupsResponse;
    using SymbolResponse = pl.xtb.api.message.response.SymbolResponse;
    using TickPricesResponse = pl.xtb.api.message.response.TickPricesResponse;
    using TradeRecordsResponse = pl.xtb.api.message.response.TradeRecordsResponse;
    using TradeTransactionResponse = pl.xtb.api.message.response.TradeTransactionResponse;
    using TradeTransactionStatusResponse = pl.xtb.api.message.response.TradeTransactionStatusResponse;
    using TradesHistoryResponse = pl.xtb.api.message.response.TradesHistoryResponse;
    using TradesResponse = pl.xtb.api.message.response.TradesResponse;
    using TradingHoursResponse = pl.xtb.api.message.response.TradingHoursResponse;
    using SyncAPIConnector = pl.xtb.api.sync.SyncAPIConnect;
    using pl.xtb.api.message.response;

    /// 
    /// <summary>
    /// @author jdabrowski
    /// </summary>
    public class APICommandFactory
    {

        public static LoginCommand createLoginCommand(long? userId, string password, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("userId", userId);
            args.Add("password", password);
            return new LoginCommand(args, prettyPrint);
        }

        public static LoginResponse executeLoginCommand(SyncAPIConnector connector, long? userId, string password, bool prettyPrint)
        {
            return new LoginResponse(connector.executeCommand(createLoginCommand(userId, password, prettyPrint)).ToString());
        }

        public static ChartLastCommand createChartLastCommand(ChartLastInfoRecord info, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("info", info.toJSONObject());
            return new ChartLastCommand(args, prettyPrint);
        }

        
        
        public static ChartLastResponse executeChartLastCommand(SyncAPIConnector connector, ChartLastInfoRecord info, bool prettyPrint)
        {
            return new ChartLastResponse(connector.executeCommand(createChartLastCommand(info, prettyPrint)).ToString());
        }

        
        
        public static ChartLastCommand createChartLastCommand(string symbol, PERIOD_CODE period, long? start, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("info", (new ChartLastInfoRecord(symbol, period, start)).toJSONObject());
            return new ChartLastCommand(args, prettyPrint);
        }

        
        
        public static ChartRangeCommand createChartRangeCommand(ChartRangeInfoRecord info, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("info", info.toJSONObject());
            return new ChartRangeCommand(args, prettyPrint);

        }

        
        
        public static ChartRangeCommand createChartRangeCommand(string symbol, PERIOD_CODE period, long? start, long? end, long? ticks, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("info", (new ChartRangeInfoRecord(symbol, period, start, end, ticks)).toJSONObject());
            return new ChartRangeCommand(args, prettyPrint);
        }

        
        
        public static CommissionDefCommand createCommissionDefCommand(string symbol, double? volume, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("symbol", symbol);
            args.Add("volume", volume);
            return new CommissionDefCommand(args, prettyPrint);
        }

        
        
        public static ConfirmPricedCommand createConfirmPricedCommand(long? requestId, TradeTransInfoRecord tradeTransInfo, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("requestId", requestId);
            args.Add("tradeTransInfo", tradeTransInfo.toJSONObject());
            return new ConfirmPricedCommand(args, prettyPrint);
        }

        
        
        public static ConfirmPricedCommand createConfirmPricedCommand(long? requestId, TRADE_OPERATION_CODE cmd, TRADE_TRANSACTION_TYPE type, double? price, double? sl, double? tp, string symbol, double? volume, long? ie_deviation, long? order, string comment, long? expiration, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("requestId", requestId);
            args.Add("tradeTransInfo", (new TradeTransInfoRecord(cmd, type, price, sl, tp, symbol, volume, ie_deviation, order, comment, expiration)).toJSONObject());
            return new ConfirmPricedCommand(args, prettyPrint);
        }

        
        
        public static ConfirmRequotedCommand createConfirmRequotedCommand(long? requestId, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("requestId", requestId);
            return new ConfirmRequotedCommand(args, prettyPrint);
        }

        
        
        public static LogoutCommand createLogoutCommand()
        {
            return new LogoutCommand();
        }

        
        
        public static MarginLevelCommand createMarginLevelCommand(bool prettyPrint)
        {
            return new MarginLevelCommand(prettyPrint);
        }

        
        
        public static MarginTradeCommand createMarginTradeCommand(string symbol, double? volume, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("symbol", symbol);
            args.Add("volume", volume);
            return new MarginTradeCommand(args, prettyPrint);
        }

        public static MarginTradeCommand createMarginTradeCommand(string symbol, double? volume, TRADE_OPERATION_CODE cmd, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("symbol", symbol);
            args.Add("volume", volume);
            args.Add("cmd", (long)cmd.longValue());
            return new MarginTradeCommand(args, prettyPrint);
        }

        
        
        public static NewsCommand createNewsCommand(long? start, long? end, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("start", start);
            args.Add("end", end);
            return new NewsCommand(args, prettyPrint);
        }

        
        
        public static ServerTimeCommand createServerTimeCommand(bool prettyPrint)
        {
            return new ServerTimeCommand(prettyPrint);
        }

        public static CurrentUserDataCommand createCurrentUserDataCommand(bool prettyPrint)
        {
            return new CurrentUserDataCommand(prettyPrint);
        }

        public static ProfitCalculationCommand createProfitCalculationCommand(string symbol, double? volume, TRADE_OPERATION_CODE cmd, double? openPrice, double? closePrice ,bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("symbol", symbol);
            args.Add("volume", volume);
            args.Add("cmd", cmd.longValue());
            args.Add("openPrice", openPrice);
            args.Add("closePrice", closePrice);
            return new ProfitCalculationCommand(args,prettyPrint);
        }
        
        public static SymbolGroupsCommand createSymbolGroupsCommand(bool prettyPrint)
        {
            return new SymbolGroupsCommand(prettyPrint);
        }

        
        
        public static AllSymbolsCommand createAllSymbolsCommand(bool prettyPrint)
        {
            return new AllSymbolsCommand(prettyPrint);
        }

        
        
        public static SymbolCommand createSymbolCommand(string symbol, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("symbol", symbol);
            return new SymbolCommand(args, prettyPrint);
        }

        
        
        public static TickPricesCommand createTickPricesCommand(LinkedList<string> symbols, long? timestamp, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            JSONArray arr = new JSONArray();
            foreach (string symbol in symbols)
            {
                arr.Add(symbol);
            }

            args.Add("symbols", arr);
            args.Add("timestamp", timestamp);
            return new TickPricesCommand(args, prettyPrint);
        }

        
        
        public static TradeRecordsCommand createTradeRecordsCommand(LinkedList<long?> orders, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            JSONArray arr = new JSONArray();
            foreach (long? order in orders)
            {
                arr.Add(order);
            }
            args.Add("orders", arr);
            return new TradeRecordsCommand(args, prettyPrint);
        }

        
        
        public static TradeTransactionCommand createTradeTransactionCommand(TradeTransInfoRecord tradeTransInfo, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("tradeTransInfo", tradeTransInfo.toJSONObject());
            return new TradeTransactionCommand(args, prettyPrint);
        }

        
        
        public static TradeTransactionCommand createTradeTransactionCommand(TRADE_OPERATION_CODE cmd, TRADE_TRANSACTION_TYPE type, double? price, double? sl, double? tp, string symbol, double? volume, long? ie_deviation, long? order, string comment, long? expiration, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("tradeTransInfo", (new TradeTransInfoRecord(cmd, type, price, sl, tp, symbol, volume, ie_deviation, order, comment, expiration)).toJSONObject());
            return new TradeTransactionCommand(args, prettyPrint);
        }

        
        
        public static TradeTransactionStatusCommand createTradeTransactionStatusCommand(long? requestId, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("requestId", requestId);
            return new TradeTransactionStatusCommand(args, prettyPrint);
        }

        
        
        public static TradesCommand createTradesCommand(bool openedOnly, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("openedOnly", openedOnly);
            return new TradesCommand(args, prettyPrint);
        }

        
        
        public static TradesHistoryCommand createTradesHistoryCommand(long? start, long? end, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            args.Add("start", start);
            args.Add("end", end);
            return new TradesHistoryCommand(args, prettyPrint);
        }

        
        
        public static TradingHoursCommand createTradingHoursCommand(LinkedList<string> symbols, bool prettyPrint)
        {
            JSONObject args = new JSONObject();
            JSONArray arr = new JSONArray();
            foreach (string symbol in symbols)
            {
                arr.Add(symbol);
            }
            args.Add("symbols", arr);
            return new TradingHoursCommand(args, prettyPrint);
        }

        
        
        public static ChartLastResponse executeChartLastCommand(SyncAPIConnector connector, string symbol, PERIOD_CODE period, long? start, bool prettyPrint)
        {
            return new ChartLastResponse(connector.executeCommand(createChartLastCommand(symbol, period, start, prettyPrint)).ToString());
        }

        
        
        public static ChartRangeResponse executeChartRangeCommand(SyncAPIConnector connector, ChartRangeInfoRecord info, bool prettyPrint)
        {
            return new ChartRangeResponse(connector.executeCommand(createChartRangeCommand(info, prettyPrint)).ToString());
        }

        
        
        public static ChartRangeResponse executeChartRangeCommand(SyncAPIConnector connector, string symbol, PERIOD_CODE period, long? start, long? end, long? ticks, bool prettyPrint)
        {
            return new ChartRangeResponse(connector.executeCommand(createChartRangeCommand(symbol, period, start, end, ticks, prettyPrint)).ToString());
        }

        
        
        public static CommissionDefResponse executeCommissionDefCommand(SyncAPIConnector connector, string symbol, double? volume, bool prettyPrint)
        {
            return new CommissionDefResponse(connector.executeCommand(createCommissionDefCommand(symbol, volume, prettyPrint)).ToString());
        }

        
        
        public static ConfirmPricedResponse executeConfirmPricedCommand(SyncAPIConnector connector, long? requestId, TradeTransInfoRecord tradeTransInfo, bool prettyPrint)
        {
            return new ConfirmPricedResponse(connector.executeCommand(createConfirmPricedCommand(requestId, tradeTransInfo, prettyPrint)).ToString());
        }

        
        
        public static ConfirmPricedResponse executeConfirmPricedCommand(SyncAPIConnector connector, long? requestId, TRADE_OPERATION_CODE cmd, TRADE_TRANSACTION_TYPE type, double? price, double? sl, double? tp, string symbol, double? volume, long? ie_deviation, long? order, string comment, long? expiration, bool prettyPrint)
        {
            return new ConfirmPricedResponse(connector.executeCommand(createConfirmPricedCommand(requestId, cmd, type, price, sl, tp, symbol, volume, ie_deviation, order, comment, expiration, prettyPrint)).ToString());
        }

        
        
        public static ConfirmRequotedResponse executeConfirmRequotedCommand(SyncAPIConnector connector, long? requestId, bool prettyPrint)
        {
            return new ConfirmRequotedResponse(connector.executeCommand(createConfirmRequotedCommand(requestId, prettyPrint)).ToString());
        }

        
        
        public static LogoutResponse executeLogoutCommand(SyncAPIConnector connector)
        {
            return new LogoutResponse(connector.executeCommand(createLogoutCommand()).ToString());
        }

        
        
        public static MarginLevelResponse executeMarginLevelCommand(SyncAPIConnector connector, bool prettyPrint)
        {
            return new MarginLevelResponse(connector.executeCommand(createMarginLevelCommand(prettyPrint)).ToString());
        }

        
        
        public static MarginTradeResponse executeMarginTradeCommand(SyncAPIConnector connector, string symbol, double? volume, bool prettyPrint)
        {
            return new MarginTradeResponse(connector.executeCommand(createMarginTradeCommand(symbol, volume, prettyPrint)).ToString());
        }

        public static MarginTradeResponse executeMarginTradeCommand(SyncAPIConnector connector, string symbol, double? volume, TRADE_OPERATION_CODE cmd, bool prettyPrint)
        {
            return new MarginTradeResponse(connector.executeCommand(createMarginTradeCommand(symbol, volume, cmd,prettyPrint)).ToString());
        }
        
        
        public static NewsResponse executeNewsCommand(SyncAPIConnector connector, long? start, long? end, bool prettyPrint)
        {
            return new NewsResponse(connector.executeCommand(createNewsCommand(start, end, prettyPrint)).ToString());
        }



        public static ServerTimeResponse executeServerTimeCommand(SyncAPIConnector connector, bool prettyPrint)
        {
            return new ServerTimeResponse(connector.executeCommand(createServerTimeCommand(prettyPrint)).ToString());
        }

        public static CurrentUserDataResponse executeCurrentUserDataCommand(SyncAPIConnector connector, bool prettyPrint)
        {
            return new CurrentUserDataResponse(connector.executeCommand(createCurrentUserDataCommand(prettyPrint)).ToString());
        }

        public static ProfitCalculationResponse executeProfitCalculationCommand(SyncAPIConnector connector, string symbol, double? volume, TRADE_OPERATION_CODE cmd, double? openPrice, double? closePrice , bool prettyPrint)
        {
            return new ProfitCalculationResponse(connector.executeCommand(createProfitCalculationCommand(symbol, volume, cmd, openPrice, closePrice, prettyPrint)).ToString());
        }
        
        
        public static SymbolGroupsResponse executeSymbolGroupsCommand(SyncAPIConnector connector, bool prettyPrint)
        {
            return new SymbolGroupsResponse(connector.executeCommand(createSymbolGroupsCommand(prettyPrint)).ToString());
        }

        
        
        public static AllSymbolsResponse executeAllSymbolsCommand(SyncAPIConnector connector, bool prettyPrint)
        {
            return new AllSymbolsResponse(connector.executeCommand(createAllSymbolsCommand(prettyPrint)).ToString());
        }

        
        
        public static SymbolResponse executeSymbolCommand(SyncAPIConnector connector, string symbol, bool prettyPrint)
        {
            return new SymbolResponse(connector.executeCommand(createSymbolCommand(symbol, prettyPrint)).ToString());
        }

        
        
        public static TickPricesResponse executeTickPricesCommand(SyncAPIConnector connector, LinkedList<string> symbols, long? timestamp, bool prettyPrint)
        {
            return new TickPricesResponse(connector.executeCommand(createTickPricesCommand(symbols, timestamp, prettyPrint)).ToString());
        }

        
        
        public static TradeRecordsResponse executeTradeRecordsCommand(SyncAPIConnector connector, LinkedList<long?> orders, bool prettyPrint)
        {
            return new TradeRecordsResponse(connector.executeCommand(createTradeRecordsCommand(orders, prettyPrint)).ToString());
        }

        
        
        public static TradeTransactionResponse executeTradeTransactionCommand(SyncAPIConnector connector, TradeTransInfoRecord tradeTransInfo, bool prettyPrint)
        {
            return new TradeTransactionResponse(connector.executeCommand(createTradeTransactionCommand(tradeTransInfo, prettyPrint)).ToString());
        }

        
        
        public static TradeTransactionResponse executeTradeTransactionCommand(SyncAPIConnector connector, TRADE_OPERATION_CODE cmd, TRADE_TRANSACTION_TYPE type, double? price, double? sl, double? tp, string symbol, double? volume, long? ie_deviation, long? order, string comment, long? expiration, bool prettyPrint)
        {
            return new TradeTransactionResponse(connector.executeCommand(createTradeTransactionCommand(cmd, type, price, sl, tp, symbol, volume, ie_deviation, order, comment, expiration, prettyPrint)).ToString());
        }

        
        
        public static TradeTransactionStatusResponse executeTradeTransactionStatusCommand(SyncAPIConnector connector, long? requestId, bool prettyPrint)
        {
            return new TradeTransactionStatusResponse(connector.executeCommand(createTradeTransactionStatusCommand(requestId, prettyPrint)).ToString());
        }

        
        
        public static TradesResponse executeTradesCommand(SyncAPIConnector connector, bool openedOnly, bool prettyPrint)
        {
            return new TradesResponse(connector.executeCommand(createTradesCommand(openedOnly, prettyPrint)).ToString());
        }

        
        
        public static TradesHistoryResponse executeTradesHistoryCommand(SyncAPIConnector connector, long? start, long? end, bool prettyPrint)
        {
            return new TradesHistoryResponse(connector.executeCommand(createTradesHistoryCommand(start, end, prettyPrint)).ToString());
        }

        
        
        public static TradingHoursResponse executeTradingHoursCommand(SyncAPIConnector connector, LinkedList<string> symbols, bool prettyPrint)
        {
            return new TradingHoursResponse(connector.executeCommand(createTradingHoursCommand(symbols, prettyPrint)).ToString());
        }
    }

}