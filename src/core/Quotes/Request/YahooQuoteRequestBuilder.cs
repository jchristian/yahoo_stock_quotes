using System;
using System.Collections.Generic;

namespace core.Quotes.Request
{
    public class YahooQuoteRequestBuilder : IBuildAQuoteRequest
    {
        IListQuoteReturnParameters parameter_list;
        IEnumerable<string> tickers;

        public YahooQuoteRequestBuilder(IListQuoteReturnParameters parameter_list)
        {
            this.parameter_list = parameter_list;
        }

        public IBuildAQuoteRequest For(params string[] tickers)
        {
            this.tickers = tickers;
            return this;
        }

        public IContainQuoteRequestData Return(Func<IListQuoteReturnParameters, IEnumerable<QuoteReturnParameter>> quote_return_parameters)
        {
            return new YahooQuoteRequest(tickers, quote_return_parameters(parameter_list));
        }
    }
}