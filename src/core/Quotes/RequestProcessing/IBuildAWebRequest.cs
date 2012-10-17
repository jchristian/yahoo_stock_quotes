using System.Net;
using core.Quotes.Request;

namespace core.Quotes.RequestProcessing
{
    public interface IBuildAWebRequest
    {
        WebRequest Build(IContainQuoteRequestData quote_request);
    }
}