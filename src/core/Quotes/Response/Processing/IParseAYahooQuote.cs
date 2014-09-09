using System.Collections.Generic;

namespace YSQ.core.Quotes.Response.Processing
{
    internal interface IParseAYahooQuote
    {
        dynamic Parse(string quote_data, IEnumerable<QuoteReturnParameter> return_parameters);
    }
}