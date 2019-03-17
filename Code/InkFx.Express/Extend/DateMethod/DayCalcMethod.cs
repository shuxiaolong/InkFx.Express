using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "DAY {A}", Keywords = new[] { "DAY" }, Level = 1000000, ExpressType = typeof(DayCalcMethod))]
    public class DayCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            DateTime arg1 = ArgumentsDate(0, expressSchema, objOrHash);
            return arg1.Day;
        }
    }



}
