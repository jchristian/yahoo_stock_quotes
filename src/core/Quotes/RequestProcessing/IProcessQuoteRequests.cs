using System.Collections.Generic;
using core.Quotes.Request;

namespace core.Quotes.RequestProcessing
{
    public interface IProcessQuoteRequests
    {
        IEnumerable<dynamic> Process(QuoteRequest quote_request);
    }
}