using System;
using System.Text.RegularExpressions;

namespace InkFx.Express.Extend.StringMethod
{
    [Serializable]
    [CalcExpress(Express = "{A} LIKE {A}", Keywords = new[] { "LIKE" }, Level = 700, ExpressType = typeof(LikeEqualCalcSymbol))]
    public class LikeEqualCalcSymbol : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            string arg2 = ArgumentsString(1, expressSchema, objOrHash);

            bool likeStart = arg2.StartsWith("%");
            bool likeEnd = arg2.EndsWith("%");
            string likeStr = arg2.Trim('%');
            bool likeMid = likeStr.Contains("%");

            if (!likeMid)
            {
                //如果字符串只需要首位匹配, 则只使用 普通字符串函数
                if (likeStart && likeEnd) return arg1.IndexOf(likeStr, StringComparison.CurrentCultureIgnoreCase) >= 0;
                else if (likeStart) return arg1.EndsWith(likeStr, StringComparison.CurrentCultureIgnoreCase);
                else if (likeEnd) return arg1.StartsWith(likeStr, StringComparison.CurrentCultureIgnoreCase);
                else return false;
            }
            else
            {
                //2015-11-17 这里放弃 了 正则表达式, 采用代码方式 执行分析

                string[] splits = arg2.Split('%');
                if (splits.Length <= 0) return true;

                if (!likeStart && !arg1.StartsWith(splits[0], StringComparison.CurrentCultureIgnoreCase)) return false;
                if (!likeEnd && !arg1.EndsWith(splits[splits.Length - 1], StringComparison.CurrentCultureIgnoreCase)) return false;

                int beginIndex = 0;
                foreach (string split in splits)
                {
                    if (string.IsNullOrEmpty(split)) continue;
                    int index = arg1.IndexOf(split, beginIndex, StringComparison.CurrentCultureIgnoreCase);
                    if (index < 0) return false; //没有搜索到字符串, 直接返回 false

                    beginIndex = index + split.Length;
                }


                return true;
            }

            
            
        }
    }
}
