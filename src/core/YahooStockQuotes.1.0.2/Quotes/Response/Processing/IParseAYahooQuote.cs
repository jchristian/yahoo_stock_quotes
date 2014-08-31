using System.Collections.Generic;

namespace YSQ.core.Quotes.Response.Processing
{
    public interface IParseAYahooQuote
    {
        dynamic Parse(string quote_data, IEnumerable<QuoteReturnParameter> return_parameters);
    }
}