/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.response
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using REQUEST_STATUS = pl.xtb.api.message.codes.REQUEST_STATUS;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class TradeTransactionStatusResponse : BaseResponse
	{

		private double? ask;
		private double? bid;
		private long? order;
		private long? requestId;
		private REQUEST_STATUS requestStatus;



		public TradeTransactionStatusResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			this.ask = (double?) ob["ask"];
			this.bid = (double?) ob["bid"];
			this.order = (long?) ob["order"];
			this.requestId = (long?) ob["requestId"];
			this.requestStatus = new REQUEST_STATUS((long?) ob["requestStatus"]);
		}

		public virtual double? Ask
		{
			set
			{
				this.ask = value;
			}
		}

		public virtual double? Bid
		{
			set
			{
				this.bid = value;
			}
		}

		public virtual long? Order
		{
			set
			{
				this.order = value;
			}
		}

		public virtual long? RequestId
		{
			set
			{
				this.requestId = value;
			}
		}

		public virtual REQUEST_STATUS RequestStatus
		{
			set
			{
				this.requestStatus = value;
			}
		}


	}

}