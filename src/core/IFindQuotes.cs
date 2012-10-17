using System.Collections.Generic;

namespace core
{
    public interface IFindQuotes
    {
        IEnumerable<dynamic> Return(params QuoteReturnParameter[] return_parameters);
    }
}