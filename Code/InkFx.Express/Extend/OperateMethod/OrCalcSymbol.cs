using System;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} OR {A}", Keywords = new[] { "OR" }, Level = 520, ExpressType = typeof(OrCalcSymbol))]
    public class OrCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            bool arg1 = ArgumentsBoolean(0, expressSchema, objOrHash);
            if (arg1) return true;
            else
            {
                bool arg2 = ArgumentsBoolean(1, expressSchema, objOrHash);
                bool value = arg2;
                return value;
            }
        }
    }
}
