using System.Collections.Generic;

namespace core.Quotes.Request
{
    public interface IContainQuoteRequestData {
        string Ticker { get; set; }

        IEnumerable<QuoteReturnParameter> ReturnParameters { get; set; }
    }
}