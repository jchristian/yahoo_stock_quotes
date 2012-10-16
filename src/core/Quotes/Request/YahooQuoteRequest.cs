using System.Collections.Generic;

namespace core.Quotes.Request
{
    public class YahooQuoteRequest : IContainQuoteRequestData
    {
        public IEnumerable<string> Tickers { get; set; }
        public IEnumerable<QuoteReturnParameter> ReturnParameters { get; set; }

        public YahooQuoteRequest(IEnumerable<string> tickers, IEnumerable<QuoteReturnParameter> quote_return_parameters)
        {
            Tickers = tickers;
            ReturnParameters = quote_return_parameters;
        }
    }
}