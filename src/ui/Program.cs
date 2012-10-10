using System;
using System.IO;
using System.Net;
using core.Quotes.Request;

namespace ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var quote_request = Request.Quote("MSFT").Return(x => new[] { x.Symbol, x.Name, x.LatestPrice, x.LatestTime });

            var request = WebRequest.Create("http://finance.yahoo.com/d/quotes.csv?s=^SP500FTR&f=snl1d1t1");
            var response = (HttpWebResponse)request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream());
            var value = reader.ReadToEnd();
            
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
