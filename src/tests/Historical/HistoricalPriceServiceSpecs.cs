using System;
using System.Collections.Generic;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using YSQ.core.Historical;

namespace YSQ.tests.Historical
{
    public class HistoricalPriceServiceSpecs
    {
        public abstract class concern : Observes<HistoricalPriceService> {}

        [Subject(typeof(HistoricalPriceService))]
        public class when_getting_the_historical_prices_for_VTIAX : concern
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

            public class and_the_period_is_weekly
            {
                Establish c = () =>
                {
                    sut_factory.create_using(() => new HistoricalPriceService());
                };

                Because of = () =>
                    historical_prices = sut.Get("VTIAX", new DateTime(2014, 1, 1), new DateTime(2014, 1, 14), Period.Weekly);

                It should_return_the_historical_prices = () =>
                    historical_prices.ShouldContain(new[]
                                                    {
                                                        new HistoricalPrice(new DateTime(2014, 1, 2), 27.61m),
                                                        new HistoricalPrice(new DateTime(2014, 1, 6), 27.56m),
                                                        new HistoricalPrice(new DateTime(2014, 1, 13), 27.69m)
                                                    });

                static IEnumerable<HistoricalPrice> historical_prices;
            }

            public class and_the_period_is_monthly
            {
                Establish c = () =>
                {
                    sut_factory.create_using(() => new HistoricalPriceService());
                };

                Because of = () =>
                    historical_prices = sut.Get("VTIAX", new DateTime(2014, 1, 1), new DateTime(2014, 3, 31), Period.Monthly);

                It should_return_the_historical_prices = () =>
                    historical_prices.ShouldContain(new[]
                                                    {
                                                        new HistoricalPrice(new DateTime(2014, 1, 2), 27.61m),
                                                        new HistoricalPrice(new DateTime(2014, 2, 3), 26.23m),
                                                        new HistoricalPrice(new DateTime(2014, 3, 3), 27.57m)
                                                    });

                static IEnumerable<HistoricalPrice> historical_prices;
            }
        }
    }
}
