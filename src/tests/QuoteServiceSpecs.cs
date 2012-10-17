using System.Collections.Generic;
using Machine.Specifications;
using core;
using core.Quotes.Request;
using core.Quotes.RequestProcessing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace tests
{
    public class QuoteServiceSpecs
    {
        public abstract class concern : Observes<QuoteService> { }

        [Subject(typeof(QuoteService))]
        public class when_building_a_quote_for_multiple_tickers : concern
        {
            Establish c = () =>
            {
                first_ticker = "MSFT";
                second_ticker = "GOOG";

                quote_request_builder = depends.on<IBuildAQuoteRequest>();
            };

            Because of = () =>
                sut.Quote(first_ticker, second_ticker);

            It should_save_the_quotes = () =>
                quote_request_builder.received(x => x.For(first_ticker, second_ticker));

            static string first_ticker;
            static string second_ticker;
            static IBuildAQuoteRequest quote_request_builder;
        }

        [Subject(typeof(QuoteService))]
        public class when_finding_the_quotes : concern
        {
            Establish c = () =>
            {
                var quote_request = fake.an<IContainQuoteRequestData>();
                quote_return_parameters = new[] { QuoteReturnParameter.Symbol };
                quotes_from_processor = new List<dynamic>();

                var quote_request_builder = depends.on<IBuildAQuoteRequest>();
                var quote_request_processor = depends.on<IProcessQuoteRequests>();
                
                quote_request_builder.setup(x => x.Return(quote_return_parameters)).Return(quote_request);
                quote_request_processor.setup(x => x.Process(quote_request)).Return(quotes_from_processor);
            };

            Because of = () =>
                returned_quotes = sut.Return(quote_return_parameters);

            It should_return_the_quotes_processed_using_the_request = () =>
                returned_quotes.ShouldEqual(quotes_from_processor);

            static QuoteReturnParameter[] quote_return_parameters;
            static IEnumerable<dynamic> returned_quotes;
            static IEnumerable<dynamic> quotes_from_processor;
        }
    }
}