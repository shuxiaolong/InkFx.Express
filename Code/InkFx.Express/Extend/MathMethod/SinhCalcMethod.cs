using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "Sinh {A}", Keywords = new[] { "Sinh" }, Level = 1000000, ExpressType = typeof(SinhCalcMethod))]
    public class SinhCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double value = Math.Sinh(arg1);
            return value;
        }

       
    }
}
