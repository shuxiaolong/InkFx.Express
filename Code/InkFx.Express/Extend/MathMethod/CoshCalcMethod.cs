﻿using System;

namespace InkFx.Express.Extend.MathMethod
{
    [Serializable]
    [CalcExpress(Express = "Cosh {A}", Keywords = new[] { "Cosh" }, Level = 1000000, ExpressType = typeof(CoshCalcMethod))]
    public class CoshCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            double arg1 = ArgumentsDouble(0, expressSchema, objOrHash);
            double value = Math.Cosh(arg1);
            return value;
        }

       
    }
}
