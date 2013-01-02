/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.records
{

	using TRADE_OPERATION_CODE = pl.xtb.api.message.codes.TRADE_OPERATION_CODE;
	using TRADE_TRANSACTION_TYPE = pl.xtb.api.message.codes.TRADE_TRANSACTION_TYPE;
	using JSONObject = Newtonsoft.Json.Linq.JObject;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class TradeTransInfoRecord
	{
		private TRADE_OPERATION_CODE cmd;
		private TRADE_TRANSACTION_TYPE type;
		private double? price;
		private double? sl;
		private double? tp;
		private string symbol;
		private double? volume;
		private long? ie_deviation;
		private long? order;
		private string comment;
		private long? expiration;

		public TradeTransInfoRecord(TRADE_OPERATION_CODE cmd, TRADE_TRANSACTION_TYPE type, double? price, double? sl, double? tp, string symbol, double? volume, long? ie_deviation, long? order, string comment, long? expiration)
		{
			this.cmd = cmd;
			this.type = type;
			this.price = price;
			this.sl = sl;
			this.tp = tp;
			this.symbol = symbol;
			this.volume = volume;
			this.ie_deviation = ie_deviation;
			this.order = order;
			this.comment = comment;
			this.expiration = expiration;
		}



		public virtual JSONObject toJSONObject()
		{
			JSONObject obj = new JSONObject();
			obj.Add("cmd", (long)cmd.longValue());
			obj.Add("type", (long)type.longValue());
			obj.Add("price", price);
			obj.Add("sl", sl);
			obj.Add("tp", tp);
			obj.Add("symbol", symbol);
			obj.Add("volume", volume);
			obj.Add("ie_deviation", ie_deviation);
			obj.Add("order", order);
			obj.Add("comment", comment);
			obj.Add("expiration", expiration);
			return obj;
		}
	}

}