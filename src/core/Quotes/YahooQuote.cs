using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace YSQ.core.Quotes
{
    internal class YahooQuote : DynamicObject
    {
        IDictionary<string, string> return_parameter_dictionary;

        public YahooQuote(IEnumerable<string> quote_data, IEnumerable<QuoteReturnParameter> return_parameters)
        {
            return_parameter_dictionary = return_parameters.Zip(quote_data, (x, y) => new Tuple<string, string>(x.ToString(), y)).ToDictionary(x => x.Item1, x => x.Item2);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (return_parameter_dictionary.ContainsKey(binder.Name))
            {
                result = return_parameter_dictionary[binder.Name];
                return true;
            }

            result = null;
            return false;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var index = indexes.First() as string;
            if (index != null && return_parameter_dictionary.ContainsKey(index))
            {
                result = return_parameter_dictionary[index];
                return true;
            }

            var indexAsEnum = indexes.First() as QuoteReturnParameter?;
            if (indexAsEnum != null && return_parameter_dictionary.ContainsKey(indexAsEnum.Value.ToString()))
            {
                result = return_parameter_dictionary[indexAsEnum.ToString()];
                return true;
            }

            result = null;
            return false;
        }
    }
}