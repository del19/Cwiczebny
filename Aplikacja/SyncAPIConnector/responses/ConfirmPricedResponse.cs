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
	public class ConfirmPricedResponse : BaseResponse
	{
		private long? newRequestId;


		public ConfirmPricedResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.newRequestId = (long?) ob["requestId"];
		}

		public virtual long? NewRequestId
		{
			get
			{
				return newRequestId;
			}
		}

	}

}