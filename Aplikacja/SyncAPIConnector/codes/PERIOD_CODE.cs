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
    public class PERIOD_CODE
    {
        public static readonly PERIOD_CODE PERIOD_M1 = new PERIOD_CODE(1L);
        public static readonly PERIOD_CODE PERIOD_M5 = new PERIOD_CODE(5L);
        public static readonly PERIOD_CODE PERIOD_M15 = new PERIOD_CODE(15L);
        public static readonly PERIOD_CODE PERIOD_M30 = new PERIOD_CODE(30L);
        public static readonly PERIOD_CODE PERIOD_H1 = new PERIOD_CODE(60L);
        public static readonly PERIOD_CODE PERIOD_H4 = new PERIOD_CODE(240L);
        public static readonly PERIOD_CODE PERIOD_D1 = new PERIOD_CODE(1440L);
        public static readonly PERIOD_CODE PERIOD_W1 = new PERIOD_CODE(10080L);
        public static readonly PERIOD_CODE PERIOD_MN1 = new PERIOD_CODE(43200L);

        private long? longCode;

        private PERIOD_CODE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }


    }

}