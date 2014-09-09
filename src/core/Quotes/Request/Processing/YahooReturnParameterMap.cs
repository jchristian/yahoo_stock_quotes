using System;
using System.Collections.Generic;

namespace YSQ.core.Quotes.Request.Processing
{
    internal class YahooReturnParameterMap
    {
        static readonly IDictionary<QuoteReturnParameter, string> map = new Dictionary<QuoteReturnParameter, string>
        {
            { QuoteReturnParameter.RealTimeAsk, "b2" },
            { QuoteReturnParameter.BidRealTime, "b3" },
            { QuoteReturnParameter.RealTimeChange, "c6" },
            { QuoteReturnParameter.RealTimeAfterHoursChange, "c8" },
            { QuoteReturnParameter.RealTimeHoldingsGainPercent, "g5" },
            { QuoteReturnParameter.RealTimeHoldingsGain, "g6" },
            { QuoteReturnParameter.RealTimeOrderBook, "i5" },
            { QuoteReturnParameter.RealTimeMarketCap, "j3" },
            { QuoteReturnParameter.RealTimeLastTradeWithTime, "k1" },
            { QuoteReturnParameter.RealTimeChangePercent, "k2" },
            { QuoteReturnParameter.RealTimeTodaysRange, "m2" },
            { QuoteReturnParameter.RealTimePERatio, "r2" },
            { QuoteReturnParameter.RealTimeHoldingsValue, "v7" },
            { QuoteReturnParameter.RealTimeDaysValueChange, "w4" },
            { QuoteReturnParameter.Ask, "a" },
            { QuoteReturnParameter.Volume, "v" },
            { QuoteReturnParameter.VolumeAverageDaily, "a2" },
            { QuoteReturnParameter.Bid, "b" },
            { QuoteReturnParameter.BidSize, "b6" },
            { QuoteReturnParameter.BookValue, "b4" },
            { QuoteReturnParameter.Change, "c1" },
            { QuoteReturnParameter.ChangeAsPercent, "p2" },
            { QuoteReturnParameter.ChangeAndPercentChange, "c" },
            { QuoteReturnParameter.ChangeOfTodaysValue, "w1" },
            { QuoteReturnParameter.ChangeFromFiftyWeekLow, "j5" },
            { QuoteReturnParameter.ChangeFromFiftyTwoWeekLowAsPercent, "j6" },
            { QuoteReturnParameter.ChangeFromFiftyTwoWeekHigh, "k4" },
            { QuoteReturnParameter.ChangeFromFiftyTwoWeekHighAsPercent, "k5" },
            { QuoteReturnParameter.ChangeFromTwoHundredDayMovingAverage, "m5" },
            { QuoteReturnParameter.ChangeFromTwoHundredDayMovingAverageAsPercent, "m6" },
            { QuoteReturnParameter.ChangeFromFiftyDayMovingAverage, "m7" },
            { QuoteReturnParameter.ChangeFromFiftyDayMovingAverageAsPercent, "m8" },
            { QuoteReturnParameter.Commission, "c3" },
            { QuoteReturnParameter.DividendPerShare, "d" },
            { QuoteReturnParameter.TradeDate, "d2" },
            { QuoteReturnParameter.LatestTradeWithTime, "l" },
            { QuoteReturnParameter.LatestTradePrice, "l1" },
            { QuoteReturnParameter.LatestTradeDate, "d1" },
            { QuoteReturnParameter.LatestTradeTime, "t1" },
            { QuoteReturnParameter.EPS, "e" },
            { QuoteReturnParameter.ErrorIndication, "e1" },
            { QuoteReturnParameter.EPSEstimateCurrentYear, "e7" },
            { QuoteReturnParameter.EPSEstimateNextYear, "e8" },
            { QuoteReturnParameter.EPSEstimateNextQuarter, "e9" },
            { QuoteReturnParameter.LowForTodays, "g" },
            { QuoteReturnParameter.FiftyTwoWeekLow, "j" },
            { QuoteReturnParameter.TodaysHigh, "h" },
            { QuoteReturnParameter.FiftyTwoWeekHigh, "k" },
            { QuoteReturnParameter.HoldingsGainAsPercent, "g1" },
            { QuoteReturnParameter.AnnualizedGain, "g3" },
            { QuoteReturnParameter.HoldingsGain, "g4" },
            { QuoteReturnParameter.MoreInfo, "i" },
            { QuoteReturnParameter.MarketCap, "j1" },
            { QuoteReturnParameter.EBITDA, "j4" },
            { QuoteReturnParameter.HighLimit, "l2" },
            { QuoteReturnParameter.LowLimit, "l3" },
            { QuoteReturnParameter.TodaysDaysRange, "m" },
            { QuoteReturnParameter.FiftyDayMovingAverage, "m3" },
            { QuoteReturnParameter.TwoHundredDayMovingAverage, "m4" },
            { QuoteReturnParameter.Name, "n" },
            { QuoteReturnParameter.Notes, "n4" },
            { QuoteReturnParameter.Open, "o" },
            { QuoteReturnParameter.PreviousClose, "p" },
            { QuoteReturnParameter.PricePaid, "p1" },
            { QuoteReturnParameter.PriceSales, "p5" },
            { QuoteReturnParameter.PriceBook, "p6" },
            { QuoteReturnParameter.ExDividendDate, "q" },
            { QuoteReturnParameter.PERatio, "r" },
            { QuoteReturnParameter.DividendPayDate, "r1" },
            { QuoteReturnParameter.PEGRatio, "r5" },
            { QuoteReturnParameter.PriceEPSEstimateCurrentYear, "r6" },
            { QuoteReturnParameter.PriceEPSEstimateNextYear, "r7" },
            { QuoteReturnParameter.Symbol, "s" },
            { QuoteReturnParameter.SharesOwned, "s1" },
            { QuoteReturnParameter.ShortRatio, "s7" },
            { QuoteReturnParameter.TradeLinks, "t6" },
            { QuoteReturnParameter.TickerTrend, "t7" },
            { QuoteReturnParameter.OneYearTargetPrice, "t8" },
            { QuoteReturnParameter.HoldingsValue, "v1" },
            { QuoteReturnParameter.FiftyTwoWeekRange, "w" },
            { QuoteReturnParameter.StockExchange, "x" },
            { QuoteReturnParameter.DividendYield, "y" },
        };

        public virtual string Map(QuoteReturnParameter quote_return_parameter)
        {
            if (!map.ContainsKey(quote_return_parameter))
                throw new ArgumentException(string.Format("Parameter {0} was not found in the map", quote_return_parameter));

            return map[quote_return_parameter];
        }
    }
}