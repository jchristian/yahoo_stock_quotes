using System.Collections.Generic;

namespace YSQ.core.Quotes.Response.Processing
{
    public interface IProcessAQuoteResponse
    {
        IEnumerable<dynamic> Return(QuoteResponse quote_response);
    }
}