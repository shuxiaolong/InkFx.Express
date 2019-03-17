using System;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} AND {A}", Keywords = new[] { "AND" }, Level = 525, ExpressType = typeof(AndCalcSymbol))]
    public class AndCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {               
            bool arg1 = ArgumentsBoolean(0, expressSchema, objOrHash);
            if (!arg1) return false;
            else
            {
                bool arg2 = ArgumentsBoolean(1, expressSchema, objOrHash);
                bool value = arg2;
                return value;
            }
        }
    }
}
