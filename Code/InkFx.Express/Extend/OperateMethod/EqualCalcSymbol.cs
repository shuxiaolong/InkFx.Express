using System;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} == {A}", Keywords = new[] { "==" }, Level = 605, ExpressType = typeof(EqualCalcSymbol))]
    public class EqualCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            object arg1 = ArgumentsObject(0, expressSchema, objOrHash);
            object arg2 = ArgumentsObject(1, expressSchema, objOrHash);

            if (arg1 == null && arg2 == null) return true;
            if (arg1 == null || arg2 == null) return false;

            bool arg1IsMeta = ReflectHelper.IsMetaType(arg1.GetType());
            bool arg2IsMeta = ReflectHelper.IsMetaType(arg2.GetType());
            if (arg1IsMeta && arg2IsMeta) 
                return arg1.ToString() == arg2.ToString();

            return arg1 == arg2;
        }
    }
}
