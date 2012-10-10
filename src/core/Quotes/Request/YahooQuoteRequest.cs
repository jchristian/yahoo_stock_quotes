using System.Collections.Generic;

namespace core.Quotes.Request
{
    public class YahooQuoteRequest : IContainQuoteRequestData
    {
        public string Ticker { get; set; }
        public IEnumerable<QuoteReturnParameter> ReturnParameters { get; set; }

        public YahooQuoteRequest(string ticker, IEnumerable<QuoteReturnParameter> quote_return_parameters)
        {
            Ticker = ticker;
            ReturnParameters = quote_return_parameters;
        }
    }
}