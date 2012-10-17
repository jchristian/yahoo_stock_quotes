using System.Collections.Generic;

namespace YSQ.core.Quotes.Request.Processing
{
    public interface IProcessQuoteRequests
    {
        IEnumerable<dynamic> Process(QuoteRequest quote_request);
    }
}