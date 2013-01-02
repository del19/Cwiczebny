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
    public class TRADE_OPERATION_CODE
    {
        public static readonly TRADE_OPERATION_CODE BUY = new TRADE_OPERATION_CODE(0L);
        public static readonly TRADE_OPERATION_CODE SELL = new TRADE_OPERATION_CODE(1L);
        public static readonly TRADE_OPERATION_CODE BUY_LIMIT = new TRADE_OPERATION_CODE(2L);
        public static readonly TRADE_OPERATION_CODE SELL_LIMIT = new TRADE_OPERATION_CODE(3L);
        public static readonly TRADE_OPERATION_CODE BUY_STOP = new TRADE_OPERATION_CODE(4L);
        public static readonly TRADE_OPERATION_CODE SELL_STOP = new TRADE_OPERATION_CODE(5L);

        private long? longCode;

        private TRADE_OPERATION_CODE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }

}