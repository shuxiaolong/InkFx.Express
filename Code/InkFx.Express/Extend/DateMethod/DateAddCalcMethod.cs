using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "DATEADD {A}", Keywords = new[] { "DATEADD" }, Level = 1000000, ExpressType = typeof(DateAddCalcMethod))]
    public class DateAddCalcMethod : DatePartBaseExpress
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash).Trim().ToUpper();
            int arg2 = Convert.ToInt32(ArgumentsDouble(1, expressSchema, objOrHash));
            DateTime arg3 = ArgumentsDate(2, expressSchema, objOrHash);

            string dataPart = UniteDataPart(arg1);
            if (!string.IsNullOrEmpty(dataPart))
            {
                if (dataPart == "YEAR") return arg3.AddYears(arg2);
                if (dataPart == "QUARTER") return DateAddQuarter(arg3, arg2);
                if (dataPart == "MONTH") return arg3.AddMonths(arg2);
                if (dataPart == "DAYOFYEAR") return DateAddDayOfYear(arg3, arg2);
                if (dataPart == "DAY") return arg3.AddDays(arg2);
                if (dataPart == "WEEK") return DateAddWeekOfYear(arg3, arg2);
                if (dataPart == "WEEKDAY") return DateAddWeekDay(arg3, arg2);
                if (dataPart == "HOUR") return arg3.AddHours(arg2);
                if (dataPart == "MINUTE") return arg3.AddMinutes(arg2);
                if (dataPart == "SECOND") return arg3.AddSeconds(arg2);
                if (dataPart == "MILLISECOND") return arg3.AddMilliseconds(arg2);
            }

            throw new Exception(string.Format("DATEADD(dataPart, value, dateTime) 参数 dataPart \'{0}\'不是规范的表达式.", arg1));
        }




        private DateTime DateAddQuarter(DateTime dateTime, int value)
        {
            return dateTime.AddMonths(value * 3);
        }
        private DateTime DateAddDayOfYear(DateTime dateTime, int value)
        {
            return dateTime.AddDays(value);
        }
        private DateTime DateAddWeekOfYear(DateTime dateTime, int value)
        {
            return dateTime.AddDays(value * 7);
        }
        private DateTime DateAddWeekDay(DateTime dateTime, int value)
        {
            return dateTime.AddDays(value);
        }

    }
}
