using System;

namespace YSQ.core.Historical
{
    public class HistoricalPrice
    {
        public DateTime Date { get; private set; }
        public decimal Price { get; private set; }

        public HistoricalPrice(DateTime date, decimal price)
        {
            Date = date;
            Price = price;
        }

        protected bool Equals(HistoricalPrice other)
        {
            return Date.Equals(other.Date) && Price == other.Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((HistoricalPrice)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Date.GetHashCode() * 397) ^ Price.GetHashCode();
            }
        }
    }
}