using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using YSQ.core.Processing;

namespace YSQ.core.Historical.Response
{
    internal class HistoricalPriceResponseProcessor
    {
        CsvResponseParser csv_response_parser;

        public HistoricalPriceResponseProcessor(CsvResponseParser csv_response_parser)
        {
            this.csv_response_parser = csv_response_parser;
        }

        public IEnumerable<HistoricalPrice> Process(HistoricalPriceResponse response)
        {
            var rows = csv_response_parser.ParseToRows(response.WebResponse);

            return rows.Rows.Select(x => new HistoricalPrice(DateTime.Parse((string)x.Date, new CultureInfo("en-US")), Decimal.Parse(x.Close, new CultureInfo("en-US")))).ToList();
        }
    }
}