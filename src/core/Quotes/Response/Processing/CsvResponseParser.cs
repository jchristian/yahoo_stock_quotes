using System.Collections.Generic;
using System.IO;
using System.Net;
using YSQ.core.Quotes.Request.Processing;

namespace YSQ.core.Quotes.Response.Processing
{
    public class CsvResponseParser : IParseACsvResponse
    {
        public IEnumerable<string> Parse(WebResponse response)
        {
            using (var response_stream = new StreamReader(response.GetResponseStream()))
            {
                while (!response_stream.EndOfStream)
                    yield return response_stream.ReadLine();
            }
        }
    }
}