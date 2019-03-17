using System;

namespace InkFx.Express.Extend.StringMethod
{
    [Serializable]
    [CalcExpress(Express = "REPLACE {A}", Keywords = new[] { "REPLACE" }, Level = 1000000, ExpressType = typeof(StringReplaceCalcMethod))]
    public class StringReplaceCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            string arg2 = ArgumentsString(1, expressSchema, objOrHash);
            string arg3 = ArgumentsString(2, expressSchema, objOrHash);
            string value = arg1.Replace(arg2, arg3);
            return value;
        }

        
    }
}
