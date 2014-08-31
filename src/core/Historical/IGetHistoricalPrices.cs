using System;
using System.Collections.Generic;

namespace YSQ.core.Historical
{
    public interface IGetHistoricalPrices
    {
        IEnumerable<HistoricalPrice> Get(string ticker, DateTime start_date, DateTime end_date, Period period);
    }
}