using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncAPIConnector.codes
{
    public class PROFIT_MODE
    {
        public static readonly PROFIT_MODE PROFIT_CALC_FOREX = new PROFIT_MODE(0L);
	    public static readonly PROFIT_MODE PROFIT_CALC_CFD = new PROFIT_MODE(1L);
        public static readonly PROFIT_MODE PROFIT_CALC_FUTURES = new PROFIT_MODE(2L);

        private long? longCode;

        public PROFIT_MODE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }
}
