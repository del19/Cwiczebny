
namespace pl.xtb.api.message.codes
{

    /// 
    /// <summary>
    /// @author jdabrowski
    /// </summary>
    public class EXECUTION_CODE
    {
        public static readonly EXECUTION_CODE EXE_REQUEST = new EXECUTION_CODE(0L);
        public static readonly EXECUTION_CODE EXE_INSTANT = new EXECUTION_CODE(1L);
        public static readonly EXECUTION_CODE EXE_MARKET = new EXECUTION_CODE(2L);

        private long? longCode;

        public EXECUTION_CODE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }

    }

}