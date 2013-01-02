using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.records
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class NewsTopicRecord : BaseResponseRecord
	{

		private string key;
		private long? time;
		private string topic;
		private string category;
		private LinkedList<string> keywords;
		private string body;
		private long? bodylen;
		private long? priority;

		public NewsTopicRecord()
		{
		}



		public virtual string Key
		{
			get
			{
				return key;
			}
		}

		public virtual long? Time
		{
			get
			{
				return time;
			}
		}

		public virtual string Topic
		{
			get
			{
				return topic;
			}
		}

		public virtual string Category
		{
			get
			{
				return category;
			}
		}

		public virtual LinkedList<string> Keywords
		{
			get
			{
				return keywords;
			}
		}

		public virtual string Body
		{
			get
			{
				return body;
			}
		}

		public virtual long? Bodylen
		{
			get
			{
				return bodylen;
			}
		}

		public virtual long? Priority
		{
			get
			{
				return priority;
			}
		}

        public void FieldsFromJSONObject(JSONObject value)
        {
            this.key = (string)value["key"];
            this.time = (long?)value["time"];
            this.topic = (string)value["topic"];
            this.category = (string)value["category"];
            this.body = (string)value["body"];
            this.bodylen = (long?)value["bodylen"];
            this.priority = (long?)value["priority"];

            this.keywords = (LinkedList<string>)new LinkedList<string>();
            string keywordString = (string)value["keywords"];
            if (keywordString != null)
            {
                keywordString = keywordString.Replace(", ", ",");
                while (keywordString.Contains("  "))
                {
                    keywordString = keywordString.Replace("  ", " ");
                }
                string[] keys = StringHelperClass.StringSplit(keywordString, ",", true);
                foreach (string key in keys)
                {
                    this.keywords.AddLast(key);
                }
            }
        }
    }

}