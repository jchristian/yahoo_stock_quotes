using System;
using System.Collections.Generic;

namespace core.Quotes.Request
{
    public interface IBuildAQuoteRequest
    {
        IBuildAQuoteRequest For(params string[] tickers);
        IContainQuoteRequestData Return(IEnumerable<core.QuoteReturnParameter> quote_return_parameters);
    }
}