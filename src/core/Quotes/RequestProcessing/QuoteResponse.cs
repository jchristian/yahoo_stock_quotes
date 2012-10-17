using System.Net;
using core.Quotes.Request;

namespace core.Quotes.RequestProcessing
{
    public class QuoteResponse
    {
        public WebResponse WebResponse { get; private set; }
        public QuoteRequest QuoteRequest { get; private set; }

        public QuoteResponse() {}
        public QuoteResponse(WebResponse web_response, QuoteRequest quote_request)
        {
            WebResponse = web_response;
            QuoteRequest = quote_request;
        }
    }
}