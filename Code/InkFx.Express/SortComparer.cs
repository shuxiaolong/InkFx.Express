using System;
using System.Collections;
using System.Collections.Generic;

namespace InkFx.Express
{
    [Serializable]
    internal sealed class SortComparer : IComparer
    {
        public ICollection<SortSlice> SortItems { get; internal set; }

        public int Compare(object x, object y)
        {
            if (SortItems == null || SortItems.Count <= 0) return 0;

            foreach(SortSlice sortSlice in SortItems)
            {
                string xValue = (sortSlice.SortExpress.Calc(x) ?? string.Empty).ToString(); //.Trim();
                string yValue = (sortSlice.SortExpress.Calc(y) ?? string.Empty).ToString(); //.Trim();

                int result = StringComparer.CurrentCultureIgnoreCase.Compare(xValue, yValue);
                //int result = StringComparer.CurrentCulture.Compare(xValue, yValue);  //两者速度相差不大
                if (result != 0)
                {
                    //不再进行后续循环
                    if (sortSlice.SortType == SortType.ASC) return result; 
                    else return 0 - result;
                }
            }

            return 0;
        }
    }
}
