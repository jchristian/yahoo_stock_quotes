using System.Collections.Generic;

namespace YSQ.core.Quotes.Request.Processing
{
    internal interface IProcessQuoteRequests
    {
        IEnumerable<dynamic> Process(QuoteRequest quote_request);
    }
}