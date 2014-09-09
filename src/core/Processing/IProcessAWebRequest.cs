using System.Net;

namespace YSQ.core.Processing
{
    internal interface IProcessAWebRequest
    {
        WebResponse Process(WebRequest web_request);
    }
}