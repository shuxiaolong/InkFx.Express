using System.Collections;
using System.Text.RegularExpressions;

namespace InkFx.Express
{
    /// <summary>
    /// 专门用于 计算 表达式 运行中 数组集合的 计算器：本计算器不是一个扩展，没有关键字——这是一个特例
    /// </summary>
    internal sealed class ArrayListCalcExpress : ExpressBase
    {
        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string express = ExpressSlice.Express;
            ArrayList list = new ArrayList();

            MatchCollection matchItems = ExpressSchema.regexArgument.Matches(express);
            if (/*matchItems!=null && */matchItems.Count > 0)
                foreach (Match matchItem in matchItems)
                {
                    if (matchItem != null && matchItem.Success)
                    {
                        string argumentExpress = matchItem.Value.Trim();
                        ExpressSlice argumentSlice = expressSchema.Arguments[argumentExpress];
                        object itemValue = argumentSlice.Calc(expressSchema, objOrHash);
                        list.Add(itemValue);
                    }
                }

            return list;
        }
    }
}
