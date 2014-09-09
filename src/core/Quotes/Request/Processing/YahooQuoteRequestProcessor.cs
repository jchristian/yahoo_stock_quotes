using System.Collections.Generic;
using YSQ.core.Processing;
using YSQ.core.Quotes.Response;
using YSQ.core.Quotes.Response.Processing;

namespace YSQ.core.Quotes.Request.Processing
{
    internal class YahooQuoteRequestProcessor : IProcessQuoteRequests
    {
        IBuildAQuoteWebRequest quote_web_request_builder;
        IProcessAWebRequest web_request_processor;
        IProcessAQuoteResponse response_processor;

        public YahooQuoteRequestProcessor(IBuildAQuoteWebRequest quote_web_request_builder, IProcessAWebRequest web_request_processor, IProcessAQuoteResponse response_processor)
        {
            this.quote_web_request_builder = quote_web_request_builder;
            this.web_request_processor = web_request_processor;
            this.response_processor = response_processor;
        }

        public IEnumerable<dynamic> Process(QuoteRequest quote_request)
        {
            var web_request = quote_web_request_builder.Build(quote_request);
            var web_response = web_request_processor.Process(web_request);
     
            return response_processor.Return(new QuoteResponse(web_response, quote_request));
        }
    }
}