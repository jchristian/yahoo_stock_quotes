using System;
using System.Collections.Generic;

namespace core.Quotes.RequestProcessing
{
    public class YahooReturnParameterMap
    {
        static readonly IDictionary<QuoteReturnParameter, string> map = new Dictionary<QuoteReturnParameter, string>
                                                                        {
                                                                            { QuoteReturnParameter.LatestDate, "d1" },
                                                                            { QuoteReturnParameter.LatestPrice, "l1" },
                                                                            { QuoteReturnParameter.LatestTime, "t1" },
                                                                            { QuoteReturnParameter.Name, "n" },
                                                                            { QuoteReturnParameter.Symbol, "s" }
                                                                        };

        public virtual string Map(QuoteReturnParameter quote_return_parameter)
        {
            if(!map.ContainsKey(quote_return_parameter))
                throw new ArgumentException(string.Format("Parameter {0} was not found in the map", quote_return_parameter));

            return map[quote_return_parameter];
        }
    }
}