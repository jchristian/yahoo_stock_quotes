using System.Net;
using YSQ.core.Historical.Request;

namespace YSQ.core.Historical.Response
{
    internal class HistoricalPriceResponse
    {
        public WebResponse WebResponse { get; set; }
        public HistoricalPriceRequest HistoricalPriceRequest { get; set; }

        public HistoricalPriceResponse(WebResponse web_response, HistoricalPriceRequest historical_price_request)
        {
            HistoricalPriceRequest = historical_price_request;
            WebResponse = web_response;
        }
    }
}