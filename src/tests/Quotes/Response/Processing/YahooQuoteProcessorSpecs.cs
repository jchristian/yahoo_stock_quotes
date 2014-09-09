using System.Collections.Generic;
using Machine.Specifications;
using YSQ.core;
using YSQ.core.Quotes;
using YSQ.core.Quotes.Response.Processing;
using developwithpassion.specifications.moq;

namespace YSQ.tests.Quotes.Response.Processing
{
    public class YahooQuoteProcessorSpecs
    {
        internal abstract class concern : Observes<IParseAYahooQuote,
                                            YahooQuoteParser> {}

        [Subject(typeof(YahooQuoteParser))]
        internal class when_parsing_a_yahoo_quote : concern
        {
            Establish c = () =>
            {
                quote_name = "Google";
                quote_symbol = "GOOG";

                quote_data = string.Format("{0},{1}", quote_name, quote_symbol);
                return_parameters = new[] { QuoteReturnParameter.Name, QuoteReturnParameter.Symbol };
            };

            Because of = () =>
                parsed_quote = sut.Parse(quote_data, return_parameters);

            It should_return_a_quote_with_the_correct_name = () =>
                ((string)parsed_quote.Name).ShouldEqual(quote_name);

            It should_return_a_quote_with_the_correct_symbol = () =>
               ((string) parsed_quote.Symbol).ShouldEqual(quote_symbol);

            static dynamic parsed_quote;
            static string quote_data;
            static IEnumerable<QuoteReturnParameter> return_parameters;
            static string quote_name;
            static string quote_symbol;

        }
    }
}
