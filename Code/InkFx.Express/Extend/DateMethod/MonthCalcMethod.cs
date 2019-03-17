using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "MONTH {A}", Keywords = new[] { "MONTH" }, Level = 1000000, ExpressType = typeof(MonthCalcMethod))]
    public class MonthCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            DateTime arg1 = ArgumentsDate(0, expressSchema, objOrHash);
            return arg1.Month;
        }
    }



}
