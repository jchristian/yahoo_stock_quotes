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
    public class YahooWebRequestBuilderSpecs
    {
        public abstract class concern : Observes<IBuildAWebRequest,
                                            YahooWebRequestBuilder> {}

        [Subject(typeof(YahooWebRequestBuilderSpecs))]
        public class when_building_a_web_request : concern
        {
            Establish c = () =>
            {
                base_url = YahooWebRequestBuilder.BaseUrl;
                tickers_url_parameter = "s=GOOG+MSFT";
                return_parameters_url_parameter = "f=snl1d1t1";

                quote_request = fake.an<IContainQuoteRequestData>();
                quote_request.setup(x => x.Tickers).Return(new[] { "GOOG", "MSFT" });
                quote_request.setup(x => x.ReturnParameters).Return(Enumerable.Empty<QuoteReturnParameter>());

                var tickers_builder = depends.on<YahooTickersUrlParameterBuilder>();
                var return_parameters_builder = depends.on<YahooReturnParametersUrlParameterBuilder>();

                tickers_builder.setup(x => x.Build(quote_request)).Return(tickers_url_parameter);
                return_parameters_builder.setup(x => x.Build(quote_request)).Return(return_parameters_url_parameter);
            };

            Because of = () =>
                built_web_request = sut.Build(quote_request);

            It should_return_the_base_url_and_the_tickers_and_the_return_parameters = () =>
                built_web_request.RequestUri.AbsoluteUri.ShouldEqual(base_url + "?" + tickers_url_parameter + "&" + return_parameters_url_parameter);

            static WebRequest built_web_request;
            static IContainQuoteRequestData quote_request;
            static string base_url;
            static string tickers_url_parameter;
            static string return_parameters_url_parameter;
        }
    }
}