using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YSQ.core.Quotes.Request.Processing
{
    internal class YahooTickersUrlParameterBuilder
    {
        public virtual string Build(params string[] tickers)
        {
            return Build((IEnumerable<string>)tickers);
        }

        public virtual string Build(IEnumerable<string> tickers)
        {
            if (!tickers.Any())
                return "";

            return "s=" + tickers.Skip(1).Aggregate(tickers.First(), (url_parameter, next_ticker) => url_parameter + "+" + next_ticker);
        }
    }
}