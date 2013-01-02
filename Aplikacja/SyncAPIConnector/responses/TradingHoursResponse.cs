using System.Collections;
using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.response
{
	using JSONArray = Newtonsoft.Json.Linq.JArray;
	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;
	using HoursRecord = pl.xtb.api.message.records.HoursRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class TradingHoursResponse : BaseResponse
	{

		private string symbol;
		private LinkedList<HoursRecord> quotes = (LinkedList<HoursRecord>) new LinkedList<HoursRecord>();
        private LinkedList<HoursRecord> trading = (LinkedList<HoursRecord>) new LinkedList<HoursRecord>();



		public TradingHoursResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.symbol = (string) ob["symbol"];
			JSONArray qHR = (JSONArray) ob["quotes"];
            foreach (JSONObject e in qHR)
            {
                HoursRecord rec = new HoursRecord();
                rec.FieldsFromJSONObject(e);
                quotes.AddLast(rec);
            }
			
			JSONArray tHR = (JSONArray) ob["trading"];
            foreach (JSONObject e in tHR)
            {
                HoursRecord rec = new HoursRecord();
                rec.FieldsFromJSONObject(e);
                trading.AddLast(rec);
            }
		}

		public virtual string Symbol
		{
			get
			{
				return symbol;
			}
		}

		public virtual LinkedList<HoursRecord> Quotes
		{
			get
			{
				return quotes;
			}
		}

		public virtual LinkedList<HoursRecord> Trading
		{
			get
			{
				return trading;
			}
		}

	}

}