using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "DATENAME {A}", Keywords = new[] { "DATENAME" }, Level = 1000000, ExpressType = typeof(DateNameCalcMethod))]
    public class DateNameCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            throw new ExpressException("InkFx.Express 函数 DATENAME(datepart, date) 函数 尚未实现.");
            DateTime arg1 = Tools.ToDateTime(ArgumentsString(0, expressSchema, objOrHash), DateTime.MinValue);
            return arg1;
        }
    }
}
