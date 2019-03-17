using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "GETDATE()", Keywords = new[] { "GETDATE" }, Level = 1000000, ExpressType = typeof(GetDateCalcMethod))]
    public class GetDateCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return false; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            DateTime value = DateTime.Now;
            return value;
        }
    }
}
