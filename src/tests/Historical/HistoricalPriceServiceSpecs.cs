using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using YSQ.core.Historical;

namespace YSQ.tests.Historical
{
    public class HistoricalPriceServiceSpecs
    {
        internal abstract class concern : Observes<HistoricalPriceService> {}

        [Subject(typeof(HistoricalPriceService))]
        internal class when_getting_the_historical_prices_for_VTIAX : concern
        {
            public class and_the_period_is_daily
            {
                Establish c = () =>
                {
                    sut_factory.create_using(() => new HistoricalPriceService());
                };

                Because of = () =>
                    historical_prices = sut.Get("VTIAX", new DateTime(2014, 1, 1), new DateTime(2014, 1, 5), Period.Daily);

                It should_return_the_historical_prices = () =>
                    historical_prices.ShouldContain(new[]
                                                    {
                                                        new HistoricalPrice(new DateTime(2014, 1, 2), 27.61m),
                                                        new HistoricalPrice(new DateTime(2014, 1, 3), 27.59m)
                                                    });

                static IEnumerable<HistoricalPrice> historical_prices;
            }

            public class and_culture_info_is_from_brazil
            {
                Establish c = () =>
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    sut_factory.create_using(() => new HistoricalPriceService());
                };

                Because of = () =>
                    historical_prices = sut.Get("VTIAX", new DateTime(2014, 1, 1), new DateTime(2014, 1, 5), Period.Daily);

                It should_return_the_historical_prices = () =>
                    historical_prices.ShouldContain(new[]
                                                    {
                                                        new HistoricalPrice(new DateTime(2014, 1, 2), 27.61m),
                                                        new HistoricalPrice(new DateTime(2014, 1, 3), 27.59m)
                                                    });

                static IEnumerable<HistoricalPrice> historical_prices;
            }
        }
    }
}
