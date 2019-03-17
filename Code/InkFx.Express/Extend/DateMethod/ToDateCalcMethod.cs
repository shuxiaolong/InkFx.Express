using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "TODATE {A}", Keywords = new[] { "TODATE" }, Level = 1000000, ExpressType = typeof(ToDateCalcMethod))]
    public class ToDateCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            DateTime value = Tools.ToDateTime(arg1, DateTime.MinValue);
            return value;
        }
    }
}
