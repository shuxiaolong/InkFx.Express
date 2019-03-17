using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "ISDATE {A}", Keywords = new[] { "ISDATE" }, Level = 1000000, ExpressType = typeof(IsDateCalcMethod))]
    public class IsDateCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            object arg1 = ArgumentsObject(0, expressSchema, objOrHash);
            DateTime time = Tools.ToDateTime(arg1, DateTime.MinValue);
            int result = time == DateTime.MinValue ? 0 : 1;
            return result;
        }
    }
}
