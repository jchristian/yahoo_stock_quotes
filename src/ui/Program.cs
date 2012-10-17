using System;
using System.IO;
using System.Net;
using core;

namespace ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var quote_service = new QuoteService(null, null);
            var quotes = quote_service.Quote("MSFT", "GOOG").Return(QuoteReturnParameter.Symbol, QuoteReturnParameter.Name, QuoteReturnParameter.LatestPrice, QuoteReturnParameter.LatestTime);

            foreach (var quote in quotes)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", quote.Symbol, quote.Name, quote.LatestPrice, quote.LastestTime);
            }

            var request = WebRequest.Create("http://finance.yahoo.com/d/quotes.csv?s=^SP500FTR&f=snl1d1t1");
            var response = (HttpWebResponse)request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream());
            var value = reader.ReadToEnd();
            
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
