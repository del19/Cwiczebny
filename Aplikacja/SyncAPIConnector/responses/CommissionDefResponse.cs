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
	public class CommissionDefResponse : BaseResponse
	{

		private double? commission;
		private double? rateOfExchange;
		private bool? showComDef;



		public CommissionDefResponse(string body) : base(body)
		{
			JSONObject rd = (JSONObject) this.ReturnData;
			this.commission = (double?) rd["commission"];
			this.rateOfExchange = (double?) rd["rateOfExchange"];
			this.showComDef = (bool?) rd["showComDef"];
		}

		public virtual double? Commission
		{
			get
			{
				return commission;
			}
		}

		public virtual double? RateOfExchange
		{
			get
			{
				return rateOfExchange;
			}
		}

		public virtual bool? ShowComDef
		{
			get
			{
				return showComDef;
			}
		}

	}

}