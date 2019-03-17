using System;

namespace InkFx.Express.Extend.DateMethod
{
    [Serializable]
    [CalcExpress(Express = "GETUTCDATE()", Keywords = new[] { "GETUTCDATE" }, Level = 1000000, ExpressType = typeof(GetUTCDateCalcMethod))]
    public class GetUTCDateCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return false; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            DateTime value = DateTime.UtcNow;
            return value;
        }
    }
}
