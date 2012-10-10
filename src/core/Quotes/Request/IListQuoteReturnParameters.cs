namespace core.Quotes.Request
{
    public interface IListQuoteReturnParameters
    {
        QuoteReturnParameter Symbol { get; }
        QuoteReturnParameter Name { get; }
        QuoteReturnParameter LatestPrice { get; }
        QuoteReturnParameter LatestTime { get; }
    }
}