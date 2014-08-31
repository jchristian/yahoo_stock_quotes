using YSQ.core.Historical.Request;
using YSQ.core.Historical.Response;
using YSQ.core.Processing;
using YSQ.core.Quotes.Request;
using YSQ.core.Quotes.Request.Processing;
using YSQ.core.Quotes.Response.Processing;

namespace YSQ.core
{
    internal class InitializationFactory
    {
        public static IBuildAQuoteRequest CreateAQuoteRequestBuilder()
        {
            return new QuoteRequestBuilder();
        }

        public static IProcessQuoteRequests CreateAQuoteRequestProcessor()
        {
            return new YahooQuoteRequestProcessor(
                new YahooQuoteWebRequestBuilder(
                    new YahooTickersUrlParameterBuilder(),
                    new YahooReturnParametersUrlParameterBuilder(
                        new YahooReturnParameterMap())),
                new WebRequestProcessor(),
                new YahooQuoteResponseProcessor(
                    new CsvResponseParser(), new YahooQuoteParser()));
        }

        public static HistoricPriceRequestProcessor CreateAHistoricPriceRequestProcessor()
        {
            return new HistoricPriceRequestProcessor(
                new HistoricalPriceWebRequestBuilder(
                    new YahooTickersUrlParameterBuilder(),
                    new DateParameterBuilder(),
                    new PeriodParameterBuilder()),
                new WebRequestProcessor());
        }

        public static HistoricalPriceResponseProcessor CreateAHistoricalPriceResponseProcessor()
        {
            return new HistoricalPriceResponseProcessor(new CsvResponseParser());
        }
    }
}