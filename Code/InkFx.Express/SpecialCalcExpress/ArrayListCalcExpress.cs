using System.Collections;

namespace InkFx.Express.SpecialCalcExpress
{
    /// <summary>
    /// 专门用于 计算 表达式 运行中 数组集合的 计算器：本计算器不是一个扩展，没有关键字——这是一个特例
    /// </summary>
    internal sealed class ArrayListCalcExpress : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            //string express = ExpressSlice.Express;
            //ArrayList list = new ArrayList();
            //MatchCollection matchItems = ExpressSchema.regexExpressSlice.Matches(express);
            //if (/*matchItems!=null && */matchItems.Count > 0)
            //    foreach (Match matchItem in matchItems)
            //    {
            //        if (matchItem != null && matchItem.Success)
            //        {
            //            string argumentExpress = matchItem.Value.Trim();
            //            ExpressSlice argumentSlice = expressSchema.Arguments[argumentExpress];
            //            object itemValue = argumentSlice.Calc(expressSchema, objOrHash);
            //            list.Add(itemValue);
            //        }
            //    }


            ArrayList list = new ArrayList();
            var listArg = this.Arguments;
            if (listArg != null && listArg.Length >= 1)
            {
                foreach (ExpressSlice argumentSlice in listArg)
                {
                    object itemValue = argumentSlice.Calc(expressSchema, objOrHash);
                    list.Add(itemValue);
                }
            }
            
            return list;
        }
    }
}
