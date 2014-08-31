#Yahoo Stock Quotes (YSQ)

Get stock quotes from the Yahoo Finance API easily by just

```
//Create the quote service
var quote_service = new QuoteService();

//Get a quote
var quotes = quote_service.Quote("MSFT", "GOOG").Return(QuoteReturnParameter.Symbol,
                                                        QuoteReturnParameter.Name,
                                                        QuoteReturnParameter.LatestTradePrice,
                                                        QuoteReturnParameter.LatestTradeTime);

//Get info from the quotes
foreach (var quote in quotes)
{
    Console.WriteLine("{0} - {1} - {2} - {3}", quote.Symbol, quote.Name, quote.LatestTradePrice, quote.LatestTradeTime);
}
```

Get historical prices easily by just

```
//Create the historical price service
var historical_price_service = new HistoricalPriceService();

//Get the historical prices
var historical_prices = historical_price_service.Get("VTIAX", new DateTime(2014, 1, 1), DateTime.UtcNow, Period.Daily);

//Use the prices!
foreach (var price in historical_prices)
{
    Console.WriteLine("{0} - {1} ", price.Date.ToString("MMM dd,yyyy"), price.Price);
}
```