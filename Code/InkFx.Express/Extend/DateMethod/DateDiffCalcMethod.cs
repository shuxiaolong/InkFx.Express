using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "DATEDIFF {A}", Keywords = new[] { "DATEDIFF" }, Level = 1000000, ExpressType = typeof(DateDiffCalcMethod))]
    public class DateDiffCalcMethod : DatePartBaseExpress
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash).Trim().ToUpper();
            DateTime arg2 = ArgumentsDate(1, expressSchema, objOrHash);
            DateTime arg3 = ArgumentsDate(2, expressSchema, objOrHash);
            TimeSpan timeSpan = arg3 - arg2;

            string dataPart = UniteDataPart(arg1);
            if (!string.IsNullOrEmpty(dataPart))
            {
                if (dataPart == "YEAR") return (long)(arg3.Year - arg2.Year);
                if (dataPart == "QUARTER") return (long)DateDiffQuarter(arg2, arg3);
                if (dataPart == "MONTH") return (long)DateDiffMonth(arg2, arg3);
                if (dataPart == "DAYOFYEAR") return (long)timeSpan.TotalDays; //DAYOFYEAR 与 DAY 返回值 一样 
                if (dataPart == "DAY") return (long)timeSpan.TotalDays;
                if (dataPart == "WEEK") return (long)DateDiffWeekOfYear(arg2, arg3);
                if (dataPart == "WEEKDAY") return (long)timeSpan.TotalDays; //WEEKDAY 与 DAY 返回值 一样 
                if (dataPart == "HOUR") return (long)timeSpan.TotalHours;
                if (dataPart == "MINUTE") return (long)timeSpan.TotalMinutes;
                if (dataPart == "SECOND") return (long)timeSpan.TotalSeconds;
                if (dataPart == "MILLISECOND") return (long)timeSpan.TotalMilliseconds;
            }

            throw new Exception(string.Format("DATEDIFF(dataPart, dateTime0, dateTime1) 参数 dataPart \'{0}\'不是规范的表达式.", arg1));
        }




        private long DateDiffMonth(DateTime dateTime0, DateTime dateTime1)
        {
            long month = (dateTime1.Month - dateTime0.Month);
            long year = (dateTime1.Year - dateTime0.Year);
            return (year * 12) + month;
        }
        private long DateDiffQuarter(DateTime dateTime0, DateTime dateTime1)
        {
            long year = dateTime1.Year - dateTime0.Year;
            long month = dateTime1.Month - dateTime0.Month;

            if (month == 1 || month == 2 || month == 3) return 1 + year * 4;
            if (month == 4 || month == 5 || month == 6) return 2 + year * 4;
            if (month == 7 || month == 8 || month == 9) return 3 + year * 4;
            if (month == 10 || month == 11 || month == 12) return 4 + year * 4;

            return 0 + year * 4;
        }
        private long DateDiffWeekOfYear(DateTime dateTime0, DateTime dateTime1)
        {
            long weekDay0 = GetWeekDay(dateTime0);
            long totalDay = (long)(dateTime1 - dateTime0).TotalDays;
            long totalWeek = (totalDay + weekDay0 - 1) / 7;
            return totalWeek;
        }

        private long GetWeekDay(DateTime dateTime)
        {
            DayOfWeek week = dateTime.DayOfWeek;
            switch (week)
            {
                case DayOfWeek.Sunday: return 1; break;
                case DayOfWeek.Monday: return 2; break;
                case DayOfWeek.Tuesday: return 3; break;
                case DayOfWeek.Wednesday: return 4; break;
                case DayOfWeek.Thursday: return 5; break;
                case DayOfWeek.Friday: return 6; break;
                case DayOfWeek.Saturday: return 7; break;
            }
            return 0; //不可达代码
        }

    }
}
