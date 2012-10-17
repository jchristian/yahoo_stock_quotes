using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using Machine.Specifications;
using core;
using core.Quotes.Request;
using core.Quotes.RequestProcessing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace tests.Quotes.RequestProcessing
{
    public class YahooQuoteResponseProcessorSpecs
    {
        public abstract class concern : Observes<IProcessAQuoteResponse,
                                            YahooQuoteResponseProcessor> {}

        [Subject(typeof(YahooQuoteResponseProcessor))]
        public class when_processing_a_quote_response : concern
        {
            Establish c = () =>
            {
                first_parsed_quote = new ExpandoObject();
                second_parsed_quote = new ExpandoObject();
                quoted_response = new QuoteResponse(fake.an<WebResponse>(), new QuoteRequest { ReturnParameters = Enumerable.Empty<QuoteReturnParameter>()});

                var csv_response_processor = depends.on<IParseACsvResponse>();
                var yahoo_quote_parser = depends.on<IParseAYahooQuote>();

                var first_yahoo_quote = "first_quote";
                var second_yahoo_quote = "second_quote";
                csv_response_processor.setup(x => x.Parse(quoted_response.WebResponse)).Return(new[] { first_yahoo_quote, second_yahoo_quote });
                yahoo_quote_parser.setup(x => x.Parse(first_yahoo_quote, quoted_response.QuoteRequest.ReturnParameters)).Return(first_parsed_quote);
                yahoo_quote_parser.setup(x => x.Parse(second_yahoo_quote, quoted_response.QuoteRequest.ReturnParameters)).Return(second_parsed_quote);
            };

            Because of = () =>
                returned_quotes = sut.Return(quoted_response);

            It should_return_a_list_of_parsed_quotes = () =>
                returned_quotes.ShouldContainOnly(new[] { first_parsed_quote, second_parsed_quote });

            static IEnumerable<dynamic> returned_quotes;
            static QuoteResponse quoted_response;
            static dynamic first_parsed_quote;
            static dynamic second_parsed_quote;
        }
    }
}
