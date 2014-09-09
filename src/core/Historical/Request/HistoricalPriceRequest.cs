using System;

namespace YSQ.core.Historical.Request
{
    internal class HistoricalPriceRequest
    {
        public string Ticker { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Period Period { get; set; }

        public HistoricalPriceRequest(string ticker, DateTime start_date, DateTime end_date, Period period)
        {
            Ticker = ticker;
            StartDate = start_date;
            EndDate = end_date;
            Period = period;
        }
    }
}