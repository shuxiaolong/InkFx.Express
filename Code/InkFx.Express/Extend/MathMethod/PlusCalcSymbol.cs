using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} + {A}", Keywords = new[] { "+" }, Level = 1000, ExpressType = typeof(PlusCalcSymbol))]
    public class PlusCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            object argObj1 = ArgumentsObject(0, expressSchema, objOrHash);
            object argObj2 = ArgumentsObject(1, expressSchema, objOrHash);

            if (ArgumentsType(0) == ExpressType.String || ArgumentsType(1) == ExpressType.String || argObj1 is string || argObj2 is string)
            {
                string arg1 = Tools.ToString(argObj1);
                string arg2 = Tools.ToString(argObj2);
                string value = arg1 + arg2;
                return value;
            }
            else
            {
                double arg1 = Tools.ToDouble(argObj1);
                double arg2 = Tools.ToDouble(argObj2);
                double value = arg1 + arg2;
                return value;
            }
        }
    }
}
