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
	using NewsTopicRecord = pl.xtb.api.message.records.NewsTopicRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class NewsResponse : BaseResponse
	{

		private LinkedList<NewsTopicRecord> newsTopicRecords = (LinkedList<NewsTopicRecord>) new LinkedList<NewsTopicRecord>();


		public NewsResponse(string body) : base(body)
		{
			JSONArray arr = (JSONArray) this.ReturnData;
			foreach (JSONObject e in arr)
			{
				NewsTopicRecord record = new NewsTopicRecord();
				record.FieldsFromJSONObject(e);
                newsTopicRecords.AddLast(record);
			}
		}

		public virtual LinkedList<NewsTopicRecord> NewsTopicRecords
		{
			get
			{
				return newsTopicRecords;
			}
		}


	}

}