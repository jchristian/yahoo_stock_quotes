using developwithpassion.specifications.moq;
using Machine.Specifications;
using YSQ.core.Quotes;
using YSQ.core.Quotes.Response.Processing;

namespace YSQ.tests.Quotes.Request.Processing
{
    public class YahooQuoteParserSpecs
    {
        internal abstract class concern : Observes<IParseAYahooQuote,
                                            YahooQuoteParser> {}

        [Subject(typeof(YahooQuoteParser))]
        internal class when_parsing_a_quote : concern
        {
            public class and_the_name_does_not_have_a_comma
            {
                Because of = () =>
                    actual = sut.Parse("Symbol,Name", new[] { QuoteReturnParameter.Symbol, QuoteReturnParameter.Name });

                It should_parse_the_symbol_field = () =>
                    ((string)actual.Symbol).ShouldEqual("Symbol");

                It should_parse_the_name_field = () =>
                    ((string)actual.Name).ShouldEqual("Name");

                static dynamic actual;
            }

            public class and_a_field_has_quotes_around_it
            {
                Because of = () =>
                    actual = sut.Parse("Symbol,\"Name of\",1.234", new[] { QuoteReturnParameter.Symbol, QuoteReturnParameter.Name, QuoteReturnParameter.LatestTradePrice });

                It should_parse_the_symbol_field = () =>
                    ((string)actual.Symbol).ShouldEqual("Symbol");

                It should_parse_the_name_field_and_remove_the_quotes = () =>
                    ((string)actual.Name).ShouldEqual("Name of");

                It should_parse_the_latest_price_field = () =>
                    ((string)actual.LatestTradePrice).ShouldEqual("1.234");

                static dynamic actual;
            }

            public class and_the_name_does_have_a_comma
            {
                Because of = () =>
                    actual = sut.Parse("Symbol,\"Name of, inc, co\",1.234", new[] { QuoteReturnParameter.Symbol, QuoteReturnParameter.Name, QuoteReturnParameter.LatestTradePrice });

                It should_parse_the_symbol_field = () =>
                    ((string)actual.Symbol).ShouldEqual("Symbol");

                It should_parse_the_name_field = () =>
                    ((string)actual.Name).ShouldEqual("Name of, inc, co");

                It should_parse_the_latest_price_field = () =>
                    ((string)actual.LatestTradePrice).ShouldEqual("1.234");

                static dynamic actual;
            }
        }
    }
}
