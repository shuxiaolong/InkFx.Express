using System;
using System.Collections.Generic;
using InkFx.Express.Utils;

namespace InkFx.Express
{
    internal static class StaticHelper
    {
        /// <summary>
        /// 格式化一个正则表达式
        /// </summary>
        internal static string FormatRegex(string str)
        {
            return str.Replace("+", "\\+").Replace("*", "\\*").Replace("?", "\\?").Replace("(", "\\(").Replace(")", "\\)").Replace("[", "\\[").Replace("]", "\\]").Replace("^", "\\^").Replace("|", "\\|").Replace("&", "\\&").Replace("$", "\\$").Replace(" ", @"\s*").Replace(@"\(\)", @"\s*\(\s*\)\s*");
        }

        internal static string FormatString(string input)
        {
            input = (input ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(input)) return string.Empty;

            if ((input.StartsWith("\"") && input.EndsWith("\""))
                || (input.StartsWith("\'") && input.EndsWith("\'")))
                input = input.Substring(1, input.Length - 2);

            return input;
        }

        internal static string FormatArray(string input)
        {
            input = (input ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(input)) return string.Empty;

            if ((input.StartsWith("(") && input.EndsWith(")"))
                || (input.StartsWith("[") && input.EndsWith("]")))
                input = input.Substring(1, input.Length - 2);

            return input;
        }

        internal static string FormatBracket(string input)
        {
            input = (input ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(input)) return string.Empty;

            if (input.StartsWith("(") && input.EndsWith(")"))
                input = input.Substring(1, input.Length - 2);

            return input;
        }


        #region  所 有 计 算 器 插 件

        private static readonly object listCalcExpressLocker = new object();
        private static readonly List<CalcExpressAttribute> listCalcExpressAttribute = new List<CalcExpressAttribute>();
        internal static List<CalcExpressAttribute> ListCalcExpressAttribute
        {
            get { return listCalcExpressAttribute; }
            set
            {
                if (listCalcExpressAttribute != value)
                {
                    listCalcExpressAttribute.Clear();
                    if (value != null)
                        listCalcExpressAttribute.AddRange(value);
                }
            }
        }

        /// <summary>
        /// 本函数 会 扫描所有程序集 以需找插件，效率极低：速度约为 200-700毫秒，使用本函数 务必做好 缓存机制
        /// </summary>
        internal static List<CalcExpressAttribute> InitAllCalcExpressAttributes()
        {
            List<CalcExpressAttribute> listCoputeAttrbute = new List<CalcExpressAttribute>();

            Dictionary<Type, CalcExpressAttribute> allTypeAttributes = ReflectHelper.GetAttributes<CalcExpressAttribute>();
            if(allTypeAttributes!=null)
            {
                foreach(KeyValuePair<Type, CalcExpressAttribute> pair in allTypeAttributes)
                {
                    try
                    {
                        //Type type = pair.Key;
                        CalcExpressAttribute attribute = pair.Value;
                        if (/*type != null && */attribute != null)
                        {
                            try { listCoputeAttrbute.Add(attribute); }
                            catch (Exception) { }
                        }
                    }
                    catch (Exception) { }
                }
            }

            return listCoputeAttrbute;
        }

        #endregion



        static StaticHelper()
        {
            lock(listCalcExpressLocker)
            {
                //if (ListCalcExpressAttribute.Count <= 0)
                {
                    ListCalcExpressAttribute = InitAllCalcExpressAttributes();
                }
            }
        }


    }
}
