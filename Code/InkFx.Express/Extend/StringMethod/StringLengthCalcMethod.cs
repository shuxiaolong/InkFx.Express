using System;

namespace InkFx.Express.Extend.StringMethod
{
    [Serializable]
    [CalcExpress(Express = "LEN {A}", Keywords = new[] { "LEN" }, Level = 1000000, ExpressType = typeof(StringLengthCalcMethod))]
    public class StringLengthCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            double value = arg1.Length;
            return value;
        }
    }
}
