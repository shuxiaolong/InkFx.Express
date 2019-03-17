using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} ^ {A}", Keywords = new[] { "^" }, Level = 100000, ExpressType = typeof(PowCalcSymbol))]
    public class PowCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double arg2 = ArgumentsDouble(1, expressSchema, objOrHash);
            double value = Math.Pow(arg1, arg2);
            return value;
        }
    }
}
