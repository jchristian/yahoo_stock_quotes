using System.Collections.Generic;

namespace YSQ.core
{
    public interface IFindQuotes
    {
        IEnumerable<dynamic> Return(params QuoteReturnParameter[] return_parameters);
    }
}