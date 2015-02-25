using System.Linq;
using System.Net;
using Machine.Specifications;
using YSQ.core;
using YSQ.core.Quotes;
using YSQ.core.Quotes.Request;
using YSQ.core.Quotes.Request.Processing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace YSQ.tests.Quotes.Request.Processing
{
    public class YahooWebRequestBuilderSpecs
    {
        internal abstract class concern : Observes<IBuildAQuoteWebRequest,
                                            YahooQuoteWebRequestBuilder> {}

        [Subject(typeof(YahooWebRequestBuilderSpecs))]
        internal class when_building_a_web_request : concern
        {
            Establish c = () =>
            {
                base_url = YahooQuoteWebRequestBuilder.BaseUrl;
                tickers_url_parameter = "s=GOOG+MSFT";
                return_parameters_url_parameter = "f=snl1d1t1";

                quote_request = new QuoteRequest { Tickers = new[] { "GOOG", "MSFT" }, ReturnParameters = Enumerable.Empty<QuoteReturnParameter>() };

                var tickers_builder = depends.on<YahooTickersUrlParameterBuilder>();
                var return_parameters_builder = depends.on<YahooReturnParametersUrlParameterBuilder>();

                tickers_builder.setup(x => x.Build(quote_request.Tickers)).Return(tickers_url_parameter);
                return_parameters_builder.setup(x => x.Build(quote_request)).Return(return_parameters_url_parameter);
            };

            Because of = () =>
                built_web_request = sut.Build(quote_request);

            It should_return_the_base_url_and_the_tickers_and_the_return_parameters = () =>
                built_web_request.RequestUri.AbsoluteUri.ShouldEqual(base_url + "?" + tickers_url_parameter + "&" + return_parameters_url_parameter + "&" + YahooQuoteWebRequestBuilder.CsvFileTypeSpecifier);

            static WebRequest built_web_request;
            static QuoteRequest quote_request;
            static string base_url;
            static string tickers_url_parameter;
            static string return_parameters_url_parameter;
        }
    }
}