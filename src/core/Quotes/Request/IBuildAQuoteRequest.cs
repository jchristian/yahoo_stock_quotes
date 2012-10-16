using System;
using System.Collections.Generic;

namespace core.Quotes.Request
{
    public interface IBuildAQuoteRequest
    {
        IBuildAQuoteRequest For(params string[] tickers);
        IContainQuoteRequestData Return(Func<IListQuoteReturnParameters, IEnumerable<QuoteReturnParameter>> quote_return_parameters);
    }
}