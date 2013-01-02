using System;

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
	[Obsolete]
	public class MarginLevelRecord : BaseResponseRecord
	{

		private double? balance;
		private double? equity;
		private double? margin;
		private double? margin_free;
		private double? margin_level;
		private string currency;



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



        public void FieldsFromJSONObject(JSONObject value)
        {
			this.balance = (double?)value["balance"];
			this.equity = (double?)value["equity"];
			this.currency = (string)value["currency"];
			this.margin = (double?)value["margin"];
			this.margin_free = (double?)value["margin_free"];
			this.margin_level = (double?)value["margin_level"];
        }
    }

}