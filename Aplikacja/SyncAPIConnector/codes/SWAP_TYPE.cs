using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncAPIConnector.codes
{
    public class SWAP_TYPE
    {

        	public static readonly SWAP_TYPE SWAP_BY_POINTS = new SWAP_TYPE(0L);
	        public static readonly SWAP_TYPE SWAP_BY_DOLLARS = new SWAP_TYPE(1L);
	        public static readonly SWAP_TYPE SWAP_BY_INTEREST = new SWAP_TYPE(2L);
	        public static readonly SWAP_TYPE SWAP_BY_MARGIN_CURRENCY = new SWAP_TYPE(3L);

                private long? longCode;

        public SWAP_TYPE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }
}
