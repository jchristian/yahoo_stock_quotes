using System.Collections.Generic;
using core.Quotes.Request;

namespace core.Quotes.RequestProcessing
{
    public class YahooQuoteRequestProcessor : IProcessQuoteRequests
    {
        IBuildAWebRequest web_request_builder;
        IProcessAWebRequest web_request_processor;
        IProcessAWebResponse response_processor;

        public YahooQuoteRequestProcessor(IBuildAWebRequest web_request_builder, IProcessAWebRequest web_request_processor, IProcessAWebResponse response_processor)
        {
            this.web_request_builder = web_request_builder;
            this.web_request_processor = web_request_processor;
            this.response_processor = response_processor;
        }

        public IEnumerable<dynamic> Process(IContainQuoteRequestData quote_request)
        {
            var web_request = web_request_builder.Build(quote_request);
            var web_response = web_request_processor.Process(web_request);
     
            return response_processor.Return<IEnumerable<dynamic>>(web_response);
        }
    }
}