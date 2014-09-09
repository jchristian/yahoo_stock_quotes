using System.Collections.Generic;
using System.Linq;
using System.Net;
using Machine.Specifications;
using YSQ.core.Processing;
using YSQ.core.Quotes.Request;
using YSQ.core.Quotes.Request.Processing;
using YSQ.core.Quotes.Response;
using YSQ.core.Quotes.Response.Processing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace YSQ.tests.Quotes.Request.Processing
{
    public class YahooQuoteRequestProcessorSpecs
    {
        internal abstract class concern : Observes<IProcessQuoteRequests,
                                            YahooQuoteRequestProcessor> {}

        [Subject(typeof(YahooQuoteRequestProcessor))]
        internal class when_processing_a_quote_request : concern
        {
            Establish c = () =>
            {
                quote_request = new QuoteRequest();
                processed_web_response = Enumerable.Empty<dynamic>();

                var web_request_builder = depends.on<IBuildAQuoteWebRequest>();
                var web_request_processor = depends.on<IProcessAWebRequest>();
                var web_response_processor = depends.on<IProcessAQuoteResponse>();

                var web_request = fake.an<WebRequest>();
                web_request_builder.setup(x => x.Build(quote_request)).Return(web_request);
                var web_response = fake.an<WebResponse>();
                web_request_processor.setup(x => x.Process(web_request)).Return(web_response);
                web_response_processor.setup(x => x.Return(Moq.It.Is<QuoteResponse>(y => y.QuoteRequest == quote_request && y.WebResponse == web_response)))
                                      .Return(processed_web_response);
            };

            Because of = () =>
                processed_quote_request = sut.Process(quote_request);

            It should_return_the_processed_web_response = () =>
                processed_quote_request.ShouldEqual(processed_web_response);

            static IEnumerable<dynamic> processed_quote_request;
            static IEnumerable<dynamic> processed_web_response;
            static QuoteRequest quote_request;
        }
    }
}
