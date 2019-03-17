using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "Tan {A}", Keywords = new[] { "Tan" }, Level = 1000000, ExpressType = typeof(TanCalcMethod))]
    public class TanCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double value = Math.Tan(arg1);
            return value;
        }

       
    }
}
