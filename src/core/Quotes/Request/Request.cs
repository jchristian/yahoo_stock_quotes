using core.Containers;

namespace core.Quotes.Request
{
    public class Request
    {
        public static IBuildAQuoteRequestRequest Quote(string ticker)
        {
            return Container.Fetch.A<IBuildAQuoteRequestRequest>().For(ticker);
        }
    }
}