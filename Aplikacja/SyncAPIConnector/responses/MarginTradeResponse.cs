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
	public class MarginTradeResponse : BaseResponse
	{

		private double? margin;



		public MarginTradeResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.margin = (double?) ob["margin"];
		}

		public virtual double? Margin
		{
			get
			{
				return margin;
			}
		}



	}

}