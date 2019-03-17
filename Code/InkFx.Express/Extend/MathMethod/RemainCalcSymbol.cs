using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} % {A}", Keywords = new[] { "%" }, Level = 10000, ExpressType = typeof(RemainCalcSymbol))]
    public class RemainCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double arg2 = ArgumentsDouble(1, expressSchema, objOrHash);
            double value = arg1%arg2;
            return value;
        }
    }
}
