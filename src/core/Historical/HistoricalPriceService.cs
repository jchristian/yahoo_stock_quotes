using System;
using System.Collections.Generic;
using YSQ.core.Historical.Request;
using YSQ.core.Historical.Response;

namespace YSQ.core.Historical
{
    public class HistoricalPriceService : IGetHistoricalPrices
    {
        HistoricPriceRequestProcessor request_processor;
        HistoricalPriceResponseProcessor response_processor;

        public HistoricalPriceService() : this(InitializationFactory.CreateAHistoricPriceRequestProcessor(), InitializationFactory.CreateAHistoricalPriceResponseProcessor()) { }
        HistoricalPriceService(HistoricPriceRequestProcessor request_processor, HistoricalPriceResponseProcessor response_processor)
        {
            this.request_processor = request_processor;
            this.response_processor = response_processor;
        }

        public IEnumerable<HistoricalPrice> Get(string ticker, DateTime start_date, DateTime end_date, Period period)
        {
            return response_processor.Process(request_processor.Process(new HistoricalPriceRequest(ticker, start_date, end_date, period)));
        }
    }
}