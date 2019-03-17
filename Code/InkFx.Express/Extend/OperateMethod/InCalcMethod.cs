using System;
using System.Collections;

namespace InkFx.Express.Extend.OperateMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} IN {A}", Keywords = new[] { "IN" }, ExpressType = typeof(InCalcMethod))]
    public class InCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash).Trim();
            if (string.IsNullOrEmpty(arg1)) return false;

            ArrayList arg2 = ArgumentsArray(1, expressSchema, objOrHash);
            bool find = false;
            if (arg2 != null && arg2.Count > 0)
            {
                foreach (object arg2Item in arg2)
                {
                    if (string.Equals((arg2Item ?? string.Empty).ToString().Trim(), arg1, StringComparison.CurrentCultureIgnoreCase))
                    {
                        find = true;
                        break;
                    }
                }
            }

            return find;
        }
    }
}
