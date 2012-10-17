using System.Collections.Generic;
using YSQ.core.Quotes.Response;
using YSQ.core.Quotes.Response.Processing;

namespace YSQ.core.Quotes.Request.Processing
{
    public class YahooQuoteRequestProcessor : IProcessQuoteRequests
    {
        IBuildAWebRequest web_request_builder;
        IProcessAWebRequest web_request_processor;
        IProcessAQuoteResponse response_processor;

        public YahooQuoteRequestProcessor(IBuildAWebRequest web_request_builder, IProcessAWebRequest web_request_processor, IProcessAQuoteResponse response_processor)
        {
            this.web_request_builder = web_request_builder;
            this.web_request_processor = web_request_processor;
            this.response_processor = response_processor;
        }

        public IEnumerable<dynamic> Process(QuoteRequest quote_request)
        {
            var web_request = web_request_builder.Build(quote_request);
            var web_response = web_request_processor.Process(web_request);
     
            return response_processor.Return(new QuoteResponse(web_response, quote_request));
        }
    }
}