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
	using SymbolRecord = pl.xtb.api.message.records.SymbolRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class AllSymbolsResponse : BaseResponse
	{

		private LinkedList<SymbolRecord> symbolRecords = (LinkedList<SymbolRecord>)new LinkedList<SymbolRecord>();



		public AllSymbolsResponse(string body) : base(body)
		{
			JSONArray symbolRecords = (JSONArray) this.ReturnData;
            foreach (JSONObject e in symbolRecords)
            {
                SymbolRecord symbolRecord = new SymbolRecord();
				symbolRecord.FieldsFromJSONObject(e);
                this.symbolRecords.AddLast(symbolRecord);
            }
		}

		public virtual LinkedList<SymbolRecord> SymbolRecords
		{
			get
			{
				return symbolRecords;
			}
		}
	}

}