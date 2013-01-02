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
	using SymbolGroupRecord = pl.xtb.api.message.records.SymbolGroupRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class SymbolGroupsResponse : BaseResponse
	{

		private LinkedList<SymbolGroupRecord> symbolGroupRecords = (LinkedList<SymbolGroupRecord>)new LinkedList<SymbolGroupRecord>();


		public SymbolGroupsResponse(string body) : base(body)
		{
			JSONArray arr = (JSONArray) this.ReturnData;
            foreach (JSONObject e in arr)
            {
                SymbolGroupRecord record = new SymbolGroupRecord();
                record.FieldsFromJSONObject(e);
                symbolGroupRecords.AddLast(record);
            }
			
		}

		public virtual LinkedList<SymbolGroupRecord> SymbolGroupRecords
		{
			get
			{
				return symbolGroupRecords;
			}
		}


	}

}