using System;
using System.Collections.Generic;

namespace core.Quotes.Request
{
    public interface IBuildAQuoteRequestRequest : IBuildAQuoteRequestParameters
    {
        IBuildAQuoteRequestRequest For(string ticker);
    }

    public interface IBuildAQuoteRequestParameters
    {
        IContainQuoteRequestData Return(Func<IListQuoteReturnParameters, IEnumerable<QuoteReturnParameter>> quote_return_parameters);
    }
}