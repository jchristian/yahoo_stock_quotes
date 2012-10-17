using System.Net;
using core.Quotes.Request;

namespace core.Quotes.RequestProcessing
{
    public class YahooWebRequestBuilder : IBuildAWebRequest
    {
        public const string BaseUrl = "http://finance.yahoo.com/d/quotes.csv";

        YahooTickersUrlParameterBuilder tickers_builder;
        YahooReturnParametersUrlParameterBuilder return_parameters_builder;

        public YahooWebRequestBuilder(YahooTickersUrlParameterBuilder tickers_builder, YahooReturnParametersUrlParameterBuilder return_parameters_builder)
        {
            this.tickers_builder = tickers_builder;
            this.return_parameters_builder = return_parameters_builder;
        }

        public WebRequest Build(QuoteRequest quote_request)
        {
            var tickers_url_parameter = tickers_builder.Build(quote_request);
            var return_parameters_url_parameter = return_parameters_builder.Build(quote_request);

            return WebRequest.Create(BaseUrl + "?" + tickers_url_parameter + "&" + return_parameters_url_parameter);
        }
    }
}