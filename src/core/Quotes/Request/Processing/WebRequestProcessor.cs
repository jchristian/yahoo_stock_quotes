using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    public class WebRequestProcessor : IProcessAWebRequest
    {
        public WebResponse Process(WebRequest web_request)
        {
            return web_request.GetResponse();
        }
    }
}