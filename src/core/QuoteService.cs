using System;
using System.Collections.Generic;
using core.Quotes.Request;
using core.Quotes.RequestProcessing;

namespace core
{
    public class QuoteService : IBuildQuotes, IFindQuotes
    {
        IBuildAQuoteRequest quote_request_builder;
        IProcessQuoteRequests quote_request_processor;

        public QuoteService(IBuildAQuoteRequest quote_request_builder, IProcessQuoteRequests quote_request_processor)
        {
            this.quote_request_builder = quote_request_builder;
            this.quote_request_processor = quote_request_processor;
        }

        public IFindQuotes Quote(params string[] tickers)
        {
            quote_request_builder = quote_request_builder.For(tickers);
            return this;
        }

        public IEnumerable<dynamic> Return(params QuoteReturnParameter[] return_parameters)
        {
            var request = quote_request_builder.Return(return_parameters);
            return quote_request_processor.Process(request);
        }
    }
}