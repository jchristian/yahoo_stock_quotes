using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    public interface IBuildAWebRequest
    {
        WebRequest Build(QuoteRequest quote_request);
    }
}