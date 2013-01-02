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
    public class REQUEST_STATUS
    {
        public static readonly REQUEST_STATUS ERROR = new REQUEST_STATUS(0L);
        public static readonly REQUEST_STATUS PENDING = new REQUEST_STATUS(1L);
        public static readonly REQUEST_STATUS REQUOTED = new REQUEST_STATUS(2L);
        public static readonly REQUEST_STATUS ACCEPTED = new REQUEST_STATUS(3L);
        public static readonly REQUEST_STATUS REJECTED = new REQUEST_STATUS(4L);
        public static readonly REQUEST_STATUS PRICED = new REQUEST_STATUS(5L);
        private long? longCode;

        public REQUEST_STATUS(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }

}