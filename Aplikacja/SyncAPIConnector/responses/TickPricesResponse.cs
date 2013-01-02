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
	using TickRecord = pl.xtb.api.message.records.TickRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class TickPricesResponse : BaseResponse
	{
		private long? timestamp;
		private LinkedList<TickRecord> ticks = (LinkedList<TickRecord>) new LinkedList<TickRecord>();


		public TickPricesResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.timestamp = (long?) ob["timestamp"];
			JSONArray arr = (JSONArray) ob["quotations"];
			foreach (JSONObject e in arr)
			{
				TickRecord record = new TickRecord();
				record.FieldsFromJSONObject(e);
                ticks.AddLast(record);
			}
		}

		public virtual long? Timestamp
		{
			get
			{
				return timestamp;
			}
		}

		public virtual LinkedList<TickRecord> Ticks
		{
			get
			{
				return ticks;
			}
		}


	}

}