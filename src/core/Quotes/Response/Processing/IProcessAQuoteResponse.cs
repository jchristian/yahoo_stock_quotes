using System.Collections.Generic;

namespace YSQ.core.Quotes.Response.Processing
{
    internal interface IProcessAQuoteResponse
    {
        IEnumerable<dynamic> Return(QuoteResponse quote_response);
    }
}