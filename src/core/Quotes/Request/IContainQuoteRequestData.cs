using System.Collections.Generic;

namespace core.Quotes.Request
{
    public interface IContainQuoteRequestData
    {
        IEnumerable<string> Tickers { get; set; }
        IEnumerable<QuoteReturnParameter> ReturnParameters { get; set; }
    }
}