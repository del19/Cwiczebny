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
	using TradeRecord = pl.xtb.api.message.records.TradeRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class TradesResponse : BaseResponse
	{

		private LinkedList<TradeRecord> tradeRecords = (LinkedList<TradeRecord>) new LinkedList<TradeRecord>();



		public TradesResponse(string body) : base(body)
		{
			JSONArray arr = (JSONArray) this.ReturnData;
            foreach (JSONObject e in arr)
            {
                TradeRecord record = new TradeRecord();
                record.FieldsFromJSONObject(e);
                tradeRecords.AddLast(record);
            }
			
		}

		public virtual LinkedList<TradeRecord> TradeRecords
		{
			get
			{
				return tradeRecords;
			}
		}
	}

}