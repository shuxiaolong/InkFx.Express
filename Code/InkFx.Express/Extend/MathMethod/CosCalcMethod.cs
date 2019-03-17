using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "Cos {A}", Keywords = new[] { "Cos" }, Level = 1000000, ExpressType = typeof(CosCalcMethod))]
    public class CosCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double value = Math.Cos(arg1);
            return value;
        }

       
    }
}
