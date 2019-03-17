using System.Collections.Generic;
using System.Text.RegularExpressions;
using InkFx.Express.Utils;

namespace InkFx.Express.SpecialCalcExpress
{
    /// <summary>
    /// 专门用于 计算 表达式 运行中 参数属性的 计算器：本计算器不是一个扩展，没有关键字——这是一个特例
    /// </summary>
    internal sealed class ArgumentCalcExpress : ExpressBase
    {
        private ArgumentCalcExpress() { }
        internal static IExpress Create(ExpressSlice expressSlice, IgnoreDict<ExpressSlice> hashExpressSlice)
        {
            ArgumentCalcExpress item = new ArgumentCalcExpress();
            item.ExpressSlice = expressSlice;

            string express = expressSlice.Express;
            MatchCollection matches = ExpressSchema.regexSingleArgument.Matches(express);
            if (matches.Count >= 1)
            {
                Match prevMatch=null;
                ExpressSlice prevSlice = null;
                for (int i = 0, count = matches.Count; i < count; i++)
                {
                    Match match = matches[i];
                    string matchValue = match.Value.Trim('[', ']').Trim();
                    ExpressSlice matchSlice = hashExpressSlice[matchValue];

                    bool isSource = i == 0 && matchSlice.Express == ExpressSchema.CurrentObjectKeyword;

                    bool isIndex = false;
                    if (prevMatch != null)
                    {
                        int splitIndex = prevMatch.Index + prevMatch.Length;
                        int splitLength = match.Index - splitIndex;
                        string split = splitLength == 0 ? string.Empty : express.Substring(splitIndex, splitLength);
                        if (StringExtend.IsNullOrWhiteSpace(split)) isIndex = true;  //如果两个 参数中括号 之间没有 "." 则 认定之后的参数 是 索引参数
                    }

                    ArgumentSlice argSlice = CreateArgumentSlice(matchSlice, isSource, isIndex);
                    item.m_ListArgSlice.Add(argSlice);

                    prevSlice = matchSlice;
                    prevMatch = match;
                }
            }

            return item;
        }
        internal static ArgumentSlice CreateArgumentSlice(ExpressSlice expressSlice, bool isSource, bool isIndex)
        {
            ArgumentSlice item = new ArgumentSlice();
            item.ExpressSlice = expressSlice;
            item.ArgExpress = expressSlice.Express;
            item.ArgType = isSource ? ArgumentType.ArgSource : (isIndex ? ArgumentType.ArgIndex : ArgumentType.ArgName);
            return item;
        }




        private readonly List<ArgumentSlice> m_ListArgSlice = new List<ArgumentSlice>();
        internal List<ArgumentSlice> ListArgSlice
        {
            get { return m_ListArgSlice; }
        }


        public override bool CanPreCalc
        {
            get { return true; }
        }
        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            object resultTemp = objOrHash;
            foreach (ArgumentSlice slice in m_ListArgSlice)
            {
                if (slice.ArgType == ArgumentType.ArgSource)
                {
                    continue; //[this] 表达式 不进行任何计算
                }
                else if (slice.ArgType == ArgumentType.ArgName)
                {
                    resultTemp = Tools.GetValue(resultTemp, slice.ArgExpress);
                }
                else if (slice.ArgType == ArgumentType.ArgIndex)
                {
                    object indexValue = slice.ExpressSlice.Calc(expressSchema, objOrHash);
                    resultTemp = Tools.GetIndexValue(resultTemp, indexValue);
                }

            }

            //object value = StaticHelper.GetValue(expressSchema, objOrHash, express);
            ////object value = Tools.GetValue(objOrHash, express);  //本函数的 速度 是上面的 1/3

            return resultTemp;
        }


    }



}
