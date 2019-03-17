using System;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} ? {A} : {A}", Keywords = new[] { "?", ":" }, Level = 100, ExpressType = typeof(TernaryCalcSymbol))]
    public class TernaryCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            bool arg1 = ArgumentsBoolean(0, expressSchema, objOrHash);
            //if (Arguments[1].Type != Arguments[2].Type)
            //    throw new Exception("TernaryCalcSymbol Type Is Not Same!");

            string value = arg1 ? ArgumentsString(1, expressSchema, objOrHash) : ArgumentsString(2, expressSchema, objOrHash);
            return value;  //Arguments[1].ExpressType
        }
    }
}
