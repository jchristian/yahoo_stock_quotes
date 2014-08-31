namespace YSQ.core.Quotes
{
    public interface IBuildQuotes
    {
        IFindQuotes Quote(params string[] tickers);
    }
}