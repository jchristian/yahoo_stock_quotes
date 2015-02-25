using System.Collections.Generic;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace YSQ.core.Quotes.Response.Processing
{
    internal class YahooQuoteParser : IParseAYahooQuote
    {
        public dynamic Parse(string quote_data, IEnumerable<QuoteReturnParameter> return_parameters)
        {
            using (var reader = new CsvReader(new StringReader(quote_data), false))
            {
                var parsed_data = Parse(reader);
                return new YahooQuote(parsed_data.ToList(), return_parameters);
            }
        }

        IEnumerable<string> Parse(CsvReader reader)
        {
            var field_count = reader.FieldCount;
            while (reader.ReadNextRecord())
            {
                for (var i = 0; i < field_count; i++)
                {
                    yield return reader[i];
                }
            }
        }
    }
}