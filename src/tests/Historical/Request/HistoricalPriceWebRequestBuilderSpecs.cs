using System;
using System.Net;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using YSQ.core.Historical;
using YSQ.core.Historical.Request;
using YSQ.core.Quotes.Request.Processing;

namespace YSQ.tests.Historical.Request
{
    public class HistoricalPriceWebRequestBuilderSpecs
    {
        internal abstract class concern : Observes<HistoricalPriceWebRequestBuilder> {}

        [Subject(typeof(HistoricalPriceWebRequestBuilder))]
        internal class when_building_the_historical_price_web_request : concern
        {
            Establish c = () =>
            {
                ticker = "VTIAX";
                start_date = new DateTime(2010, 1, 2);
                end_date = new DateTime(2014, 2, 15);

                depends.on(new YahooTickersUrlParameterBuilder());
                depends.on(new DateParameterBuilder());
                depends.on(new PeriodParameterBuilder());
            };

            Because of = () =>
                built_web_request = sut.Build(new HistoricalPriceRequest(ticker, start_date, end_date, Period.Daily));

            It should_return_the_base_url_and_the_tickers_and_the_return_parameters = () =>
                built_web_request.RequestUri.AbsoluteUri.ShouldEqual(@"http://real-chart.finance.yahoo.com/table.csv?s=VTIAX&a=0&b=2&c=2010&d=1&e=15&f=2014&g=d&ignore=.csv");

            static WebRequest built_web_request;
            static HistoricalPriceRequest quote_request;
            static string ticker;
            static DateTime start_date;
            static DateTime end_date;
        }
    }
}
