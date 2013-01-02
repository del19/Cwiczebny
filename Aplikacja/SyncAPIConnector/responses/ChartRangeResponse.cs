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
	using EXECUTION_CODE = pl.xtb.api.message.codes.EXECUTION_CODE;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;
	using RateInfoRecord = pl.xtb.api.message.records.RateInfoRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class ChartRangeResponse : BaseResponse
	{

		private long? digits;
		private EXECUTION_CODE exemode;
		private LinkedList<RateInfoRecord> rateInfos = (LinkedList<RateInfoRecord>) new LinkedList<RateInfoRecord>();



		public ChartRangeResponse(string body) : base(body)
		{
			JSONObject rd = (JSONObject) this.ReturnData;
			this.digits = (long?) rd["digits"];
			this.exemode = new EXECUTION_CODE((long?)rd["exemode"]);
			JSONArray arr = (JSONArray) rd["rateInfos"];
            foreach (JSONObject e in arr)
            {
                RateInfoRecord record = new RateInfoRecord();
                record.FieldsFromJSONObject(e);
                this.rateInfos.AddLast(record);
            }
            
		}

		public virtual long? Digits
		{
			get
			{
				return digits;
			}
		}

		public virtual EXECUTION_CODE Exemode
		{
			get
			{
				return exemode;
			}
		}

		public virtual LinkedList<RateInfoRecord> RateInfos
		{
			get
			{
				return rateInfos;
			}
		}

	}

}