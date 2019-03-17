using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "DATEFORMAT {A}", Keywords = new[] { "DATEFORMAT" }, Level = 1000000, ExpressType = typeof(DateFormatCalcMethod))]
    public class DateFormatCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash).Trim();
            DateTime arg2 = ArgumentsDate(1, expressSchema, objOrHash);
            string value = string.IsNullOrEmpty(arg1) ? arg2.ToString("yyyy-MM-dd hh:mm:ss") : arg2.ToString(arg1);
            return value;
        }
    }
}
