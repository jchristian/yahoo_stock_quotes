using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using YSQ.core.Quotes;

namespace YSQ.tests.Quotes
{
    public class QuoteServiceSpecs
    {
        internal abstract class concern : Observes<QuoteService> { }

        [Subject(typeof(QuoteService))]
        internal class when_getting_all_the_data : concern
        {
            Establish c = () =>
            {
                sut_factory.create_using(() => new QuoteService());
            };

            Because of = () =>
                returned_quotes = sut.Quote("MSFT", "GOOG", "^SP500FTR").Return(Enum.GetValues(typeof(QuoteReturnParameter)).Cast<QuoteReturnParameter>().ToArray());

            It should_return_all_the_data = () =>
            {
                foreach (var quote in returned_quotes)
                {
                    foreach (var return_parameter in Enum.GetValues(typeof(QuoteReturnParameter)).Cast<QuoteReturnParameter>())
                    {
                        Debug.WriteLine("{0} - {1} - {2}", (string)quote.Name, return_parameter.ToString(), (string)quote[return_parameter.ToString()]);
                        Debug.WriteLine("{0} - {1} - {2}", (string)quote.Name, return_parameter.ToString(), (string)quote[return_parameter]);
                    }
                }
            };

            static IEnumerable<dynamic> returned_quotes;
        }
    }
}