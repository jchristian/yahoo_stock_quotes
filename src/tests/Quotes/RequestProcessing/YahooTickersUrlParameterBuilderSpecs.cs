using Machine.Specifications;
using core.Quotes.Request;
using core.Quotes.RequestProcessing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace tests.Quotes.RequestProcessing
{
    public class YahooTickersUrlParameterBuilderSpecs
    {
        public abstract class concern : Observes<YahooTickersUrlParameterBuilder> {}

        [Subject(typeof(YahooTickersUrlParameterBuilder))]
        public class when_building_the_tickers_parameter : concern
        {
            Establish c = () =>
            {
                first_ticker = "GOOG";
                second_ticker = "MSFT";
                third_ticker = "^SP500FTR";

                quote_request = fake.an<IContainQuoteRequestData>();
                quote_request.setup(x => x.Tickers).Return(new[] { first_ticker, second_ticker, third_ticker });
            };

            Because of = () =>
                url_parameter = sut.Build(quote_request);

            It should_return_the_tickers_separated_by_plus_signs = () =>
                url_parameter.ShouldEqual("s=" + first_ticker + "+" + second_ticker + "+" + third_ticker);
            
            static string url_parameter;
            static string first_ticker;
            static string second_ticker;
            static string third_ticker;
            static IContainQuoteRequestData quote_request;
        }
    }
}
