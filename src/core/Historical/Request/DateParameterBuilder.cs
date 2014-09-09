using System;

namespace YSQ.core.Historical.Request
{
    internal class DateParameterBuilder
    {
        public virtual string Build(DateTime start_date, string month_param, string day_param, string year_param)
        {
            return month_param + "=" + (start_date.Month - 1) + "&" + day_param + "=" + start_date.Day + "&" + year_param + "=" + start_date.Year;
        }
    }
}