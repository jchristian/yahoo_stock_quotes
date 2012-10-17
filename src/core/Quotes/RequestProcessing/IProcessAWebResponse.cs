using System.Net;

namespace core.Quotes.RequestProcessing
{
    public interface IProcessAWebResponse
    {
        T Return<T>(WebResponse web_response);
    }
}