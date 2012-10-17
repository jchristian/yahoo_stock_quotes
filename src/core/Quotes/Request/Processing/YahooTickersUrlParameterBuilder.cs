using System.Linq;

namespace YSQ.core.Quotes.Request.Processing
{
    public class YahooTickersUrlParameterBuilder
    {
        public virtual string Build(QuoteRequest quote_request)
        {
            if (!quote_request.Tickers.Any())
                return "";

            return "s=" + quote_request.Tickers.Skip(1).Aggregate(quote_request.Tickers.First(), (url_parameter, next_ticker) => url_parameter + "+" + next_ticker);
        }
    }
}