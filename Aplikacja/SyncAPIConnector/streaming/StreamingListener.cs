using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pl.xtb.api.message.records;

namespace SyncAPIConnector.streaming
{
    public interface StreamingListener
    {
        void receiveTradeRecord(TradeRecord tradeRecord);
        void receiveTickRecord(TickRecord tickRecord);
    }
}
