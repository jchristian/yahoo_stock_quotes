using System.Collections.Generic;
using System.Net;

namespace YSQ.core.Processing
{
    public interface IParseACsvResponse
    {
        IEnumerable<string> ParseToLines(WebResponse response);
    }
}