using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "Sin {A}", Keywords = new[] { "Sin" }, Level = 1000000, ExpressType = typeof(SinCalcMethod))]
    public class SinCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double value = Math.Sin(arg1);
            return value;
        }

       
    }
}
