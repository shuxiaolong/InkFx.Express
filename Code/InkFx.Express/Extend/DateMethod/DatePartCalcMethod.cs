using System;
using System.Globalization;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "DATEPART {A}", Keywords = new[] { "DATEPART" }, Level = 1000000, ExpressType = typeof(DatePartCalcMethod))]
    public class DatePartCalcMethod : DatePartBaseExpress
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash).Trim().ToUpper();
            DateTime arg2 = ArgumentsDate(1, expressSchema, objOrHash);

            string dataPart = UniteDataPart(arg1);
            if (!string.IsNullOrEmpty(dataPart))
            {
                if (dataPart == "YEAR") return (long)arg2.Year;
                if (dataPart == "QUARTER") return (long)GetQuarter(arg2);
                if (dataPart == "MONTH") return (long)arg2.Month;
                if (dataPart == "DAYOFYEAR") return (long)arg2.DayOfYear;
                if (dataPart == "DAY") return (long)arg2.Day;
                if (dataPart == "WEEK") return (long)GetWeekOfYear(arg2);
                if (dataPart == "WEEKDAY") return (long)GetWeekDay(arg2);
                if (dataPart == "HOUR") return (long)arg2.Hour;
                if (dataPart == "MINUTE") return (long)arg2.Minute;
                if (dataPart == "SECOND") return (long)arg2.Second;
                if (dataPart == "MILLISECOND") return (long)arg2.Millisecond;
            }

            throw new Exception(string.Format("DATEPART(dataPart, dateTime) 参数 dataPart \'{0}\'不是规范的表达式.", arg1));
        }




        private long GetQuarter(DateTime dateTime)
        {
            int month = dateTime.Month;
            if (month == 1 || month == 2 || month == 3) return 1;
            if (month == 4 || month == 5 || month == 6) return 2;
            if (month == 7 || month == 8 || month == 9) return 3;
            if (month == 10 || month == 11 || month == 12) return 4;
            return 0;
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
        private int GetWeekOfYear(DateTime dateTime)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            return weekOfYear;
        }
    }



}
