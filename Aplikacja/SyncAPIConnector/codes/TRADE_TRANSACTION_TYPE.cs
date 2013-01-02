/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.codes
{

    /// 
    /// <summary>
    /// @author jdabrowski
    /// </summary>
    public class TRADE_TRANSACTION_TYPE
    {
        public static readonly TRADE_TRANSACTION_TYPE ORDER_OPEN = new TRADE_TRANSACTION_TYPE(0L);
        public static readonly TRADE_TRANSACTION_TYPE ORDER_CLOSE = new TRADE_TRANSACTION_TYPE(2L);
        public static readonly TRADE_TRANSACTION_TYPE ORDER_MODIFY = new TRADE_TRANSACTION_TYPE(3L);
        public static readonly TRADE_TRANSACTION_TYPE ORDER_DELETE = new TRADE_TRANSACTION_TYPE(4L);

        private long? longCode;

        private TRADE_TRANSACTION_TYPE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }

}