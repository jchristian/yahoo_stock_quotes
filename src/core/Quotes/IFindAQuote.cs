namespace YSQ.core.Quotes
{
    public interface IFindAQuote
    {
        dynamic Return(params QuoteReturnParameter[] return_parameters);
    }
}