using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncAPIConnector.codes
{
    public class SWAP_ROLLOVER_TYPE
    {
        public static readonly SWAP_ROLLOVER_TYPE MONDAY = new SWAP_ROLLOVER_TYPE(0L);
        public static readonly SWAP_ROLLOVER_TYPE TUESDAY = new SWAP_ROLLOVER_TYPE(1L);
        public static readonly SWAP_ROLLOVER_TYPE WEDNSDAY = new SWAP_ROLLOVER_TYPE(2L);
        public static readonly SWAP_ROLLOVER_TYPE THURSDAY = new SWAP_ROLLOVER_TYPE(3L);
        public static readonly SWAP_ROLLOVER_TYPE FRIDAY = new SWAP_ROLLOVER_TYPE(4L);



        private long? longCode;

        public SWAP_ROLLOVER_TYPE(long? code)
        {
            this.longCode = code;
        }

        public virtual long? longValue()
        {
            return longCode;
        }
    }

}
