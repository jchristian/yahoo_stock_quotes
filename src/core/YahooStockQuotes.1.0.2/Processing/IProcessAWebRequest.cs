using System.Net;

namespace YSQ.core.Processing
{
    public interface IProcessAWebRequest
    {
        WebResponse Process(WebRequest web_request);
    }
}