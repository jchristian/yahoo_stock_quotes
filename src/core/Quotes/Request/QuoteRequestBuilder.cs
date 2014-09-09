using System.Collections.Generic;

namespace YSQ.core.Quotes.Request
{
    internal class QuoteRequestBuilder : IBuildAQuoteRequest
    {
        IEnumerable<string> tickers;

        public IBuildAQuoteRequest For(params string[] tickers)
        {
            this.tickers = tickers;
            return this;
        }

        public QuoteRequest Return(IEnumerable<QuoteReturnParameter> quote_return_parameters)
        {
            return new QuoteRequest(tickers, quote_return_parameters);
        }
    }
}