using System.Collections;
using Machine.Specifications;
using YSQ.core.Quotes.Request;
using YSQ.core.Quotes.Request.Processing;
using developwithpassion.specifications.moq;

namespace YSQ.tests.Quotes.Request.Processing
{
    public class YahooTickersUrlParameterBuilderSpecs
    {
        internal abstract class concern : Observes<YahooTickersUrlParameterBuilder> {}

        [Subject(typeof(YahooTickersUrlParameterBuilder))]
        internal class when_building_the_tickers_parameter : concern
        {
            Establish c = () =>
            {
                first_ticker = "GOOG";
                second_ticker = "MSFT";
                third_ticker = "^SP500FTR";
            };

            Because of = () =>
                url_parameter = sut.Build(new[] { first_ticker, second_ticker, third_ticker });

            It should_return_the_tickers_separated_by_plus_signs = () =>
                url_parameter.ShouldEqual("s=" + first_ticker + "+" + second_ticker + "+" + third_ticker);
            
            static string url_parameter;
            static string first_ticker;
            static string second_ticker;
            static string third_ticker;
        }
    }
}
