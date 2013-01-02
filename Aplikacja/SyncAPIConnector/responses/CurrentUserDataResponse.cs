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
	public class CurrentUserDataResponse : BaseResponse
	{

        private string currency;
        private long? leverage;



        public CurrentUserDataResponse(string body)
            : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
            this.currency = (string)ob["currency"];
            this.leverage = (long?) ob["leverage"];
		}

        public virtual string Currency
        {
            get
            {
                return currency;
            }
        }

		public virtual long? Leverage
		{
			get
			{
				return leverage;
			}
		}



	}

}