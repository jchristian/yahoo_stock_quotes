using Machine.Specifications;
using YSQ.core;
using YSQ.core.Quotes;
using YSQ.core.Quotes.Request;
using YSQ.core.Quotes.Request.Processing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace YSQ.tests.Quotes.Request.Processing
{
    public class YahooReturnParametersUrlParameterBuilderSpecs
    {
        internal abstract class concern : Observes<YahooReturnParametersUrlParameterBuilder> {}

        [Subject(typeof(YahooReturnParametersUrlParameterBuilder))]
        internal class when_building_the_return_parameters_url_parameter : concern
        {
            Establish c = () =>
            {
                var first_quote_return_parameter = QuoteReturnParameter.Symbol;
                var second_quote_return_parameter = QuoteReturnParameter.Name;
                var third_quote_return_parameter = QuoteReturnParameter.LatestTradePrice;

                quote_request = new QuoteRequest { ReturnParameters = new[] { first_quote_return_parameter, second_quote_return_parameter, third_quote_return_parameter } };

                var return_paramter_map = depends.on<YahooReturnParameterMap>();
                
                return_paramter_map.setup(x => x.Map(first_quote_return_parameter)).Return(first_url_return_parameter);
                return_paramter_map.setup(x => x.Map(second_quote_return_parameter)).Return(second_url_return_parameter);
                return_paramter_map.setup(x => x.Map(third_quote_return_parameter)).Return(third_url_return_parameter);
            };

            Because of = () =>
                return_parameters_url_parameter = sut.Build(quote_request);

            It should_return_the_concatenated_return_parameters = () =>
                return_parameters_url_parameter.ShouldEqual("f=" + first_url_return_parameter + second_url_return_parameter + third_url_return_parameter);
            
            static string return_parameters_url_parameter;
            static string first_url_return_parameter;
            static string second_url_return_parameter;
            static string third_url_return_parameter;
            static QuoteRequest quote_request;
        }
    }
}
