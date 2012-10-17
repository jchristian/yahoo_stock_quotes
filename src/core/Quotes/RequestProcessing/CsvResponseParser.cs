using System.Collections.Generic;
using System.IO;
using System.Net;

namespace core.Quotes.RequestProcessing
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