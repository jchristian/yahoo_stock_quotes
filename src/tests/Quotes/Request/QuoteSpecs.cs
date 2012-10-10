using Machine.Specifications;
using core.Containers;
using core.Quotes.Request;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;

namespace tests.Quotes.Request
{
    public class QuoteSpecs
    {
        public abstract class concern : Observes {}

        [Subject(typeof(core.Quotes.Request.Request))]
        public class when_scenario : concern
        {
            Establish c = () =>
            {
                ticker = "MSFT";

                var the_container = fake.an<IFetchDependencies>();
                ContainerFacadeResolver resolver = () => the_container;
                spec.change(() => Container.facade_resolver).to(resolver);

                quote_request_builder = fake.an<IBuildAQuoteRequestRequest>();
                the_container.setup(x => x.A<IBuildAQuoteRequestRequest>()).Return(quote_request_builder);
                quote_request_builder.setup(x => x.For(ticker)).Return(quote_request_builder);
            };

            Because of = () =>
                quote_request_builder = core.Quotes.Request.Request.Quote(ticker);

            It should_return_a_quote_builder = () =>
                quote_request_builder.ShouldNotBeNull();

            static string ticker;
            static IBuildAQuoteRequestRequest quote_request_builder;
        }
    }
}