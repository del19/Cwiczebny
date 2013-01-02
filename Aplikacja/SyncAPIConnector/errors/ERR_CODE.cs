/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.error
{

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class ERR_CODE
	{

		public static readonly ERR_CODE OK = new ERR_CODE("0");
		public static readonly ERR_CODE OK_NONE = new ERR_CODE("1");
		public static readonly ERR_CODE COMMON_ERROR = new ERR_CODE("2");
		public static readonly ERR_CODE INVALID_PARAMETERS = new ERR_CODE("3");
		public static readonly ERR_CODE SERVER_BUSY = new ERR_CODE("4");
		public static readonly ERR_CODE OLD_VERSION = new ERR_CODE("5");
		public static readonly ERR_CODE NO_CONNECTION = new ERR_CODE("6");
		public static readonly ERR_CODE NOT_ENOUGH_RIGHTS = new ERR_CODE("7");
		public static readonly ERR_CODE TOO_FREQUENT_REQUESTS = new ERR_CODE("8");
		public static readonly ERR_CODE DISABLED_OR_FAILED = new ERR_CODE("9");
		public static readonly ERR_CODE GENERATED_KEY_REQUIRED = new ERR_CODE("10");
		public static readonly ERR_CODE SECURED_LOGIN_REQUIRED = new ERR_CODE("11");
		public static readonly ERR_CODE ACCOUNT_DISABLED = new ERR_CODE("64");
		public static readonly ERR_CODE INVALID_ACCOUNT = new ERR_CODE("65");
		public static readonly ERR_CODE TRADE_TIMEOUT = new ERR_CODE("128");
		public static readonly ERR_CODE INVALID_PRICES = new ERR_CODE("129");
		public static readonly ERR_CODE INVALID_SL_TP = new ERR_CODE("130");
		public static readonly ERR_CODE INVALID_VOLUME = new ERR_CODE("131");
		public static readonly ERR_CODE MARKET_IS_CLOSED = new ERR_CODE("132");
		public static readonly ERR_CODE TRADE_IS_DISABLED = new ERR_CODE("133");
		public static readonly ERR_CODE NOT_ENOUGH_MONEY = new ERR_CODE("134");
		public static readonly ERR_CODE PRICE_IS_CHANGED = new ERR_CODE("135");
		public static readonly ERR_CODE QUOTES_ARE_OFF = new ERR_CODE("136");
		public static readonly ERR_CODE BROKER_IS_BUSY = new ERR_CODE("137");
		public static readonly ERR_CODE REQUOTE = new ERR_CODE("138");
		public static readonly ERR_CODE ORDER_IS_LOCKED = new ERR_CODE("139");
		public static readonly ERR_CODE LONG_POSITIONS_ONLY = new ERR_CODE("140");
		public static readonly ERR_CODE TOO_MANY_REQUESTS = new ERR_CODE("141");
		public static readonly ERR_CODE ORDER_ACCEPTED = new ERR_CODE("142");
		public static readonly ERR_CODE ORDER_IN_PROGRESS = new ERR_CODE("143");
		public static readonly ERR_CODE ORDER_IS_CANCELLED_BY_USER = new ERR_CODE("144");
		public static readonly ERR_CODE MODIFICATION_DENIED = new ERR_CODE("145");
		public static readonly ERR_CODE TRADE_CONTEXT_IS_BUSY = new ERR_CODE("146");
		public static readonly ERR_CODE EXPIRATION_FOR_PENDING_DISABLED = new ERR_CODE("147");
		public static readonly ERR_CODE TOO_MANY_ORDERS = new ERR_CODE("148");
		public static readonly ERR_CODE HEDGE_IS_PROHIBITED = new ERR_CODE("149");
		public static readonly ERR_CODE NETWORK_PROBLEM = new ERR_CODE("255");

		private string stringCode;

		public ERR_CODE(string code)
		{
			this.stringCode = code;
		}

		public virtual string stringValue()
		{
			return stringCode;
		}
	}

}