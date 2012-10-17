using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    public interface IProcessAWebRequest
    {
        WebResponse Process(WebRequest web_request);
    }
}