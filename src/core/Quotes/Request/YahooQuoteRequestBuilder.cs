using System;
using System.Collections.Generic;

namespace core.Quotes.Request
{
    public class YahooQuoteRequestBuilder : IBuildAQuoteRequestRequest
    {
        IListQuoteReturnParameters parameter_list;
        string ticker;

        public YahooQuoteRequestBuilder(IListQuoteReturnParameters parameter_list)
        {
            this.parameter_list = parameter_list;
        }

        public IBuildAQuoteRequestRequest For(string ticker)
        {
            this.ticker = ticker;
            return this;
        }

        public IContainQuoteRequestData Return(Func<IListQuoteReturnParameters, IEnumerable<QuoteReturnParameter>> quote_return_parameters)
        {
            return new YahooQuoteRequest(ticker, quote_return_parameters(parameter_list));
        }
    }
}