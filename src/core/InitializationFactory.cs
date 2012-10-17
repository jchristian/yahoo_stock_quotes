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
                new YahooWebRequestBuilder(
                    new YahooTickersUrlParameterBuilder(),
                    new YahooReturnParametersUrlParameterBuilder(
                        new YahooReturnParameterMap())),
                new WebRequestProcessor(),
                new YahooQuoteResponseProcessor(
                    new CsvResponseParser(), new YahooQuoteParser()));
        }
    }
}