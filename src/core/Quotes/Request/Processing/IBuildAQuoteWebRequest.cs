using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    internal interface IBuildAQuoteWebRequest
    {
        WebRequest Build(QuoteRequest quote_request);
    }
}