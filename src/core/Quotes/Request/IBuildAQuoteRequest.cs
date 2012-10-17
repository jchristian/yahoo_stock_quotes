using System.Collections.Generic;

namespace core.Quotes.Request
{
    public interface IBuildAQuoteRequest
    {
        IBuildAQuoteRequest For(params string[] tickers);
        QuoteRequest Return(IEnumerable<QuoteReturnParameter> quote_return_parameters);
    }
}