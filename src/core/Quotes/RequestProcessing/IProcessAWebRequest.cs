using System.Net;

namespace core.Quotes.RequestProcessing
{
    public interface IProcessAWebRequest
    {
        WebResponse Process(WebRequest web_request);
    }
}