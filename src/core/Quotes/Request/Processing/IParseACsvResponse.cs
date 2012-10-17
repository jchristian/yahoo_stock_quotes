using System.Collections.Generic;
using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    public interface IParseACsvResponse
    {
        IEnumerable<string> Parse(WebResponse response);
    }
}