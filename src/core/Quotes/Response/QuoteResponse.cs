using System.Net;
using YSQ.core.Quotes.Request;

namespace YSQ.core.Quotes.Response
{
    internal class QuoteResponse
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