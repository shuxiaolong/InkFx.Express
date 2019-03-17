using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "YEAR {A}", Keywords = new[] { "YEAR" }, Level = 1000000, ExpressType = typeof(YearCalcMethod))]
    public class YearCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            DateTime arg1 = ArgumentsDate(0, expressSchema, objOrHash);
            return arg1.Year;
        }
    }



}
