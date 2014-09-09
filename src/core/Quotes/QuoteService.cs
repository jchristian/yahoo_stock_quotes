using System.Collections.Generic;
using System.Linq;
using YSQ.core.Quotes.Request;
using YSQ.core.Quotes.Request.Processing;

namespace YSQ.core.Quotes
{
    public class QuoteService : IBuildQuotes, IBuildAQuote, IFindQuotes, IFindAQuote
    {
        IBuildAQuoteRequest quote_request_builder;
        IProcessQuoteRequests quote_request_processor;

        public QuoteService() : this(InitializationFactory.CreateAQuoteRequestBuilder(), InitializationFactory.CreateAQuoteRequestProcessor()) { }
        QuoteService(IBuildAQuoteRequest quote_request_builder, IProcessQuoteRequests quote_request_processor)
        {
            this.quote_request_builder = quote_request_builder;
            this.quote_request_processor = quote_request_processor;
        }

        public virtual IFindAQuote Quote(string ticker)
        {
            quote_request_builder = quote_request_builder.For(ticker);
            return this;
        }

        dynamic IFindAQuote.Return(params QuoteReturnParameter[] return_parameters)
        {
            var request = quote_request_builder.Return(return_parameters);
            return quote_request_processor.Process(request).First();
        }

        public virtual IFindQuotes Quote(params string[] tickers)
        {
            quote_request_builder = quote_request_builder.For(tickers);
            return this;
        }

        IEnumerable<dynamic> IFindQuotes.Return(params QuoteReturnParameter[] return_parameters)
        {
            var request = quote_request_builder.Return(return_parameters);
            return quote_request_processor.Process(request);
        }
    }
}