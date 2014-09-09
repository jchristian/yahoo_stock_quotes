using System.Collections.Generic;
using System.Net;

namespace YSQ.core.Processing
{
    internal interface IParseACsvResponse
    {
        IEnumerable<string> ParseToLines(WebResponse response);
    }
}