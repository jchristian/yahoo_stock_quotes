using System.Net;

namespace YSQ.core.Quotes.Request.Processing
{
    internal class YahooQuoteWebRequestBuilder : IBuildAQuoteWebRequest
    {
        public const string BaseUrl = "http://finance.yahoo.com/d/quotes.csv";
        public const string CsvFileTypeSpecifier = "e=.csv";

        YahooTickersUrlParameterBuilder tickers_builder;
        YahooReturnParametersUrlParameterBuilder return_parameters_builder;

        public YahooQuoteWebRequestBuilder(YahooTickersUrlParameterBuilder tickers_builder, YahooReturnParametersUrlParameterBuilder return_parameters_builder)
        {
            this.tickers_builder = tickers_builder;
            this.return_parameters_builder = return_parameters_builder;
        }

        public WebRequest Build(QuoteRequest quote_request)
        {
            var tickers_url_parameter = tickers_builder.Build(quote_request.Tickers);
            var return_parameters_url_parameter = return_parameters_builder.Build(quote_request);

            return WebRequest.Create(BaseUrl + "?" + tickers_url_parameter + "&" + return_parameters_url_parameter + "&" + CsvFileTypeSpecifier);
        }
    }
}