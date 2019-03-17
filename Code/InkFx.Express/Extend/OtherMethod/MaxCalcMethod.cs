using System;
using System.Collections;
using InkFx.Express.Utils;

namespace InkFx.Express.Extend.OtherMethod
{
    [Serializable]
    [CalcExpress(Express = "Max {A}", Keywords = new[] { "Max" }, Level = 1000000, ExpressType = typeof(MaxCalcMethod))]
    public class MaxCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            ArrayList arrayList = ArgumentsArray(0, expressSchema, objOrHash);
            if(arrayList==null || arrayList.Count<=0) return null;

            bool isDateTime = arrayList[0] is DateTime;
            bool isDouble = arrayList[0] is Double;
            //bool isString = arrayList[0] is String;

            if (isDateTime)
            {
                DateTime maxDateTime = Tools.ToDateTime(arrayList[0]);
                for (int i=1;i<arrayList.Count;i++)
                {
                    DateTime itemValue = Tools.ToDateTime(arrayList[i]);
                    if (itemValue > maxDateTime) maxDateTime = itemValue;
                }
                return maxDateTime;
            }
            else if (isDouble)
            {
                double maxDouble = Tools.ToDouble(arrayList[0]);
                for (int i = 1; i < arrayList.Count; i++)
                {
                    double itemValue = Tools.ToDouble(arrayList[i]);
                    if (itemValue > maxDouble) maxDouble = itemValue;
                }
                return maxDouble;
            }
            else
            {
                string maxString = Tools.ToString(arrayList[0]);
                for (int i = 1; i < arrayList.Count; i++)
                {
                    string itemValue = Tools.ToString(arrayList[i]);
                    if (String.Compare(itemValue, maxString, StringComparison.CurrentCulture) >= 0)
                        maxString = itemValue;
                }
                return maxString;
            }
        }

       
    }
}
