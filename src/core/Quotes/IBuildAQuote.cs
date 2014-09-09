namespace YSQ.core.Quotes
{
    public interface IBuildAQuote
    {
        IFindAQuote Quote(string ticker);
    }
}