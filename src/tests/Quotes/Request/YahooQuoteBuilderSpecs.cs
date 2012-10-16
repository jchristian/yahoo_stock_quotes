using Machine.Specifications;
using core.Quotes.Request;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace tests.Quotes.Request
{
    public class YahooQuoteBuilderSpecs
    {
        public abstract class concern : Observes<IBuildAQuoteRequest,
                                            YahooQuoteRequestBuilder> { }

        [Subject(typeof(YahooQuoteBuilderSpecs))]
        public class when_building_the_ticker_symbol : concern
        {
            Because of = () =>
                quote_request = sut.For(the_ticker).Return(x => null);

            It should_build_a_quote_with_the_correct_ticker = () =>
                quote_request.Tickers.ShouldContainOnly(the_ticker);

            static string the_ticker;
            static IContainQuoteRequestData quote_request;
        }

        [Subject(typeof(YahooQuoteBuilderSpecs))]
        public class when_building_the_data_to_return : concern
        {
            Establish c = () =>
            {
                var quotes = depends.on<IListQuoteReturnParameters>();

                quotes.setup(x => x.Symbol).Return(ticker_parameter);
                quotes.setup(x => x.LatestPrice).Return(price_parameter);
            };

            Because of = () =>
                quote_request = sut.For(null).Return(x => new[] { x.Symbol, x.LatestPrice });

            It should_build_a_quote_with_the_correct_return_parameters = () =>
                quote_request.ReturnParameters.ShouldContainOnly(ticker_parameter, price_parameter);

            static IContainQuoteRequestData quote_request;
            static QuoteReturnParameter ticker_parameter;
            static QuoteReturnParameter price_parameter;
        }
    }
}
