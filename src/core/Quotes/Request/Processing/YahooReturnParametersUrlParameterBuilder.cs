using System.Linq;

namespace YSQ.core.Quotes.Request.Processing
{
    internal class YahooReturnParametersUrlParameterBuilder
    {
        YahooReturnParameterMap return_parameter_map;

        protected YahooReturnParametersUrlParameterBuilder() {}
        public YahooReturnParametersUrlParameterBuilder(YahooReturnParameterMap return_parameter_map)
        {
            this.return_parameter_map = return_parameter_map;
        }

        public virtual string Build(QuoteRequest quote_request)
        {
            if (!quote_request.ReturnParameters.Any())
                return "";

            var url_return_parameters = quote_request.ReturnParameters.Select(x => return_parameter_map.Map(x));
            return url_return_parameters.Aggregate("f=", (url_parameter, quote_return_parameter) => url_parameter + quote_return_parameter);
        }
    }
}