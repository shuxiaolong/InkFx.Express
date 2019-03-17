using System;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} > {A}", Keywords = new[] { ">" }, Level = 670, ExpressType = typeof(GreaterThanCalcSymbol))]
    public class GreaterThanCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double arg2 = ArgumentsDouble(1, expressSchema, objOrHash);
            bool value = arg1 > arg2;
            return value;
        }
    }
}
