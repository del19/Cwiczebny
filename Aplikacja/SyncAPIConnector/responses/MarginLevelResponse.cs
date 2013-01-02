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
	public class MarginLevelResponse : BaseResponse
	{

		private double? balance;
		private double? equity;
		private double? margin;
		private double? margin_free;
		private double? margin_level;
		private string currency;



		public MarginLevelResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.balance = (double?) ob["balance"];
			this.equity = (double?) ob["equity"];
			this.currency = (string) ob["currency"];
			this.margin = (double?) ob["margin"];
			this.margin_free = (double?) ob["margin_free"];
			this.margin_level = (double?) ob["margin_level"];
		}

		public virtual double? Balance
		{
			get
			{
				return balance;
			}
		}

		public virtual double? Equity
		{
			get
			{
				return equity;
			}
		}

		public virtual double? Margin
		{
			get
			{
				return margin;
			}
		}

		public virtual double? Margin_free
		{
			get
			{
				return margin_free;
			}
		}

		public virtual double? Margin_level
		{
			get
			{
				return margin_level;
			}
		}

		public virtual string Currency
		{
			get
			{
				return currency;
			}
		}

	}

}