namespace core
{
    public interface IBuildQuotes
    {
        IFindQuotes Quote(params string[] tickers);
    }
}