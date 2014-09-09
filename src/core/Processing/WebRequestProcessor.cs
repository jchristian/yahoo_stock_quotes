using System.Net;

namespace YSQ.core.Processing
{
    internal class WebRequestProcessor : IProcessAWebRequest
    {
        public WebResponse Process(WebRequest web_request)
        {
            return web_request.GetResponse();
        }
    }
}