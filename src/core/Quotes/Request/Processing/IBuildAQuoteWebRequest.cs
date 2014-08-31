using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    public interface IBuildAQuoteWebRequest
    {
        WebRequest Build(QuoteRequest quote_request);
    }
}