using System.Collections.Generic;
using System.Net;

namespace core.Quotes.RequestProcessing
{
    public interface IParseACsvResponse
    {
        IEnumerable<string> Parse(WebResponse response);
    }
}