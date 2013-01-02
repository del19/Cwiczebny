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
	public class LoginResponse : BaseResponse
	{
        private string streamingSessionId;


		public LoginResponse(string body) : base(body)
		{
            JSONObject ob = (JSONObject)JSONObject.Parse(body);
            this.streamingSessionId = (string)ob["streamSessionId"];
		}


        public virtual string StreamingSessionId
        {
            get
            {
                return streamingSessionId;
            }
        }
	}

}