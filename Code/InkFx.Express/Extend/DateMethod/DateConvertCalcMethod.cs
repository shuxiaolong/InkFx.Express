using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "CONVERTDATE {A}", Keywords = new[] { "CONVERTDATE" }, Level = 1000000, ExpressType = typeof(DateConvertCalcMethod))]
    public class DateConvertCalcMethod : ExpressBase
    {
        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            DateTime value = Tools.ToDateTime(arg1, DateTime.MinValue);
            return value;
        }
    }
}
