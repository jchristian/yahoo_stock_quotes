namespace YSQ.core.Historical.Request
{
    internal class PeriodParameterBuilder
    {
        public virtual string Build(Period period)
        {
            var start = "g=";

            if (period == Period.Daily)
                return start + "d";
            if (period == Period.Weekly)
                return start + "w";
            if (period == Period.Monthly)
                return start + "m";
            return "";
        }
    }
}