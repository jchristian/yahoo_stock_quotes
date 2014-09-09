using System.Linq;
using Machine.Specifications;
using YSQ.core;
using YSQ.core.Quotes;
using YSQ.core.Quotes.Request;
using developwithpassion.specifications.moq;

namespace YSQ.tests.Quotes.Request
{
    public class QuoteRequestBuilderSpecs
    {
        internal abstract class concern : Observes<IBuildAQuoteRequest,
                                            QuoteRequestBuilder> { }

        [Subject(typeof(QuoteRequestBuilder))]
        internal class when_building_the_ticker_symbol : concern
        {
            Because of = () =>
                quote_request = sut.For(the_ticker).Return(Enumerable.Empty<QuoteReturnParameter>());

            It should_build_a_quote_with_the_correct_ticker = () =>
                quote_request.Tickers.ShouldContainOnly(the_ticker);

            static string the_ticker;
            static QuoteRequest quote_request;
        }

        [Subject(typeof(QuoteRequestBuilder))]
        internal class when_building_the_data_to_return : concern
        {
            Because of = () =>
                quote_request = sut.For(null).Return(new[] { QuoteReturnParameter.Symbol, QuoteReturnParameter.LatestTradePrice });

            It should_build_a_quote_with_the_correct_return_parameters = () =>
                quote_request.ReturnParameters.ShouldContainOnly(QuoteReturnParameter.Symbol, QuoteReturnParameter.LatestTradePrice);

            static QuoteRequest quote_request;
        }
    }
}
