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
	public class TradeTransactionResponse : BaseResponse
	{

		private long? requestId;


		public TradeTransactionResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.requestId = (long?) ob["requestId"];
		}

		public virtual long? RequestId
		{
			get
			{
				return requestId;
			}
		}



	}

}