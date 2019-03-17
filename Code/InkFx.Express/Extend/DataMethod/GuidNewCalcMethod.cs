using System;

namespace InkFx.Express.Extend.DataMethod
{
    [Serializable]
    [CalcExpress(Express = "NEWID()", Keywords = new[] { "NEWID" }, Level = 1000000, ExpressType = typeof(GuidNewCalcMethod))]
    public class GuidNewCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return false; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            Guid value = Guid.NewGuid();
            return value;
        }
    }
}
