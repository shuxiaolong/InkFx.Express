using System;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} != {A}", Keywords = new[] { "!=" }, Level = 620, ExpressType = typeof(NotEqualCalcSymbol))]
    public class NotEqualCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            string arg2 = ArgumentsString(1, expressSchema, objOrHash);
            bool value = arg1 != arg2;
            return value;
        }
    }
}
