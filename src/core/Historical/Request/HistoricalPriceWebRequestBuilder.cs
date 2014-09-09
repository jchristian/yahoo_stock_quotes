using System.Net;
using YSQ.core.Quotes.Request.Processing;

namespace YSQ.core.Historical.Request
{
    internal class HistoricalPriceWebRequestBuilder
    {
        const string Base_Url = @"http://real-chart.finance.yahoo.com/table.csv";
        const string Terminator = @"&ignore=.csv";

        YahooTickersUrlParameterBuilder tickers_parameter_builder;
        DateParameterBuilder date_parameter_builder;
        PeriodParameterBuilder period_parameter_builder;

        public HistoricalPriceWebRequestBuilder(YahooTickersUrlParameterBuilder tickers_parameter_builder,
                                                DateParameterBuilder date_parameter_builder,
                                                PeriodParameterBuilder period_parameter_builder)
        {
            this.tickers_parameter_builder = tickers_parameter_builder;
            this.date_parameter_builder = date_parameter_builder;
            this.period_parameter_builder = period_parameter_builder;
        }

        public virtual WebRequest Build(HistoricalPriceRequest historical_price_request)
        {
            return WebRequest.Create(Base_Url + "?" +
                                     tickers_parameter_builder.Build(historical_price_request.Ticker) + "&" +
                                     date_parameter_builder.Build(historical_price_request.StartDate, "a", "b", "c") + "&" +
                                     date_parameter_builder.Build(historical_price_request.EndDate, "d", "e", "f") + "&" +
                                     period_parameter_builder.Build(historical_price_request.Period) +
                                     Terminator);
        }
    }
}