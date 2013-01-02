using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncAPIConnector.codes
{
    public class MARGIN_MODE
    {
        public static readonly MARGIN_MODE MARGIN_CALC_FOREX = new MARGIN_MODE(0L);
	    public static readonly MARGIN_MODE MARGIN_CALC_CFD = new MARGIN_MODE(1L);
	    public static readonly MARGIN_MODE MARGIN_CALC_FUTURES = new MARGIN_MODE(2L);
	    public static readonly MARGIN_MODE MARGIN_CALC_CFDINDEX = new MARGIN_MODE(3L);
        public static readonly MARGIN_MODE MARGIN_CALC_CFDLEVERAGE = new MARGIN_MODE(4L);

        private long? longCode;

        public MARGIN_MODE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }
}
