using System;
using System.Collections.Generic;
using core.Quotes.Request;

namespace core
{
    public interface IFindQuotes
    {
        IEnumerable<dynamic> Return(Func<IListQuoteReturnParameters, IEnumerable<QuoteReturnParameter>> return_parameters);
    }
}