using System.Collections.Generic;

namespace YSQ.core.Quotes.Response.Processing
{
    public class YahooQuoteParser : IParseAYahooQuote
    {
        public dynamic Parse(string quote_data, IEnumerable<QuoteReturnParameter> return_parameters)
        {
            return new YahooQuote(quote_data.Split(','), return_parameters);
        }
    }
}