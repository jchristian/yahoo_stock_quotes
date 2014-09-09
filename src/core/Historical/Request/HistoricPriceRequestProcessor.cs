using YSQ.core.Historical.Response;
using YSQ.core.Processing;

namespace YSQ.core.Historical.Request
{
    internal class HistoricPriceRequestProcessor
    {
        HistoricalPriceWebRequestBuilder historical_price_web_request_builder;
        IProcessAWebRequest web_request_processor;

        public HistoricPriceRequestProcessor(HistoricalPriceWebRequestBuilder historical_price_web_request_builder, IProcessAWebRequest web_request_processor)
        {
            this.historical_price_web_request_builder = historical_price_web_request_builder;
            this.web_request_processor = web_request_processor;
        }

        public HistoricalPriceResponse Process(HistoricalPriceRequest historical_price_request)
        {
            var web_response = web_request_processor.Process(historical_price_web_request_builder.Build(historical_price_request));
            return new HistoricalPriceResponse(web_response, historical_price_request);
        }
    }
}