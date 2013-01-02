/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.response
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class ServerTimeResponse : BaseResponse
	{

		private long? time;


		public ServerTimeResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.time = (long?) ob["time"];
		}

		public virtual long? Time
		{
			get
			{
				return time;
			}
		}

	}

}