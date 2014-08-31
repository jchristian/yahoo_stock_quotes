using System;
using YSQ.core;
using YSQ.core.Historical;
using YSQ.core.Quotes;

namespace YSQ.console_runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var quote_service = new QuoteService();
            var quotes = quote_service.Quote("MSFT", "GOOG").Return(QuoteReturnParameter.Symbol,
                                                                    QuoteReturnParameter.Name,
                                                                    QuoteReturnParameter.LatestTradePrice,
                                                                    QuoteReturnParameter.LatestTradeTime);

            foreach (var quote in quotes)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", quote.Symbol, quote.Name, quote.LatestTradePrice, quote.LatestTradeTime);
            }

            Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Daily historical prices for VTIAX");

            var historical_price_service = new HistoricalPriceService();
            foreach (var price in historical_price_service.Get("VTIAX", new DateTime(2014, 1, 1), DateTime.UtcNow, Period.Daily))
            {
                Console.WriteLine("{0} - {1} ", price.Date.ToString("MMM dd,yyyy"), price.Price);
            }

            Console.ReadLine();
        }
    }
}