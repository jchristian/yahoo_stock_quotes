using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using LumenWorks.Framework.IO.Csv;
using YSQ.core.Extensions;

namespace YSQ.core.Processing
{
    public class CsvResponseParser : IParseACsvResponse
    {
        public IEnumerable<string> ParseToLines(WebResponse response)
        {
            using (var response_stream = new StreamReader(response.GetResponseStream()))
            {
                while (!response_stream.EndOfStream)
                    yield return response_stream.ReadLine();
            }
        }

        public virtual ParsedCSVFile ParseToRows(WebResponse response)
        {
            using (var reader = new CsvReader(new StreamReader(response.GetResponseStream()), true))
            {
                return new ParsedCSVFile(GetRows(reader).ToArray(), reader.GetFieldHeaders().Select(StringExtensions.RemoveWhitespace).ToArray());
            }
        }

        IEnumerable<dynamic> GetRows(CsvReader reader)
        {
            var fieldCount = reader.FieldCount;
            var headers = reader.GetFieldHeaders();

            while (reader.ReadNextRecord())
            {
                IDictionary<string, object> row = new ExpandoObject();
                for (var i = 0; i < fieldCount; i++)
                    row.Add(headers[i].RemoveWhitespace(), reader[i]);
                yield return row;
            }
        }
    }
}