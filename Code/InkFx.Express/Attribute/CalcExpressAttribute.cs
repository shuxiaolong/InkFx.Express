using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InkFx.Express
{
    /// <summary>
    /// 用于 标记一个 IExpress 计算器 的扩展
    /// </summary>
    public class CalcExpressAttribute : Attribute
    {
        private string m_Express = string.Empty;
        private string[] m_Keywords = null;
        private Regex m_Regex;
        private readonly List<Regex> m_ListKwRegex = new List<Regex>();
        private static readonly Regex m_RegexWord = new Regex(@"@*[\w\$]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// 运算表达式
        /// </summary>
        public string Express
        {
            get { return m_Express; }
            set
            {
                m_Express = value ?? string.Empty;
                if (!string.IsNullOrEmpty(m_Express))
                {
                    string symbolTemp = StaticHelper.FormatRegex(m_Express);
                    string regexExpres = symbolTemp.Replace("{A}", @"\{Express_[\d]+\}");
                    m_Regex = new Regex(regexExpres, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
            }
        }
        /// <summary>
        /// 运算优先级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 指向 当前特性 标记的 IExpress 实现类类型
        /// </summary>
        public Type ExpressType { get; set; }

        /// <summary>
        /// 表达式 中 的 关键字
        /// </summary>
        public string[] Keywords
        {
            get { return m_Keywords; }
            set
            {
                m_Keywords = value;
                m_ListKwRegex.Clear();

                if (m_Keywords != null)
                {
                    foreach (string kw in m_Keywords)
                    {
                        string kwTemp = StaticHelper.FormatRegex(kw);
                        bool isWord = m_RegexWord.IsMatch(kwTemp); //如果关键字是 文本, 则要求前后 不能是文本

                        string kwRegexExpres = isWord ? string.Format(@"((?<=^){0}(?=(?=[^\w\$])))|((?<=[^\@\w\$]){0}(?=[^\w\$]))|((?<=[^\@\w\$]){0}(?=$))", kwTemp) : kwTemp;
                        Regex m_KwRegex = new Regex(kwRegexExpres, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        m_ListKwRegex.Add(m_KwRegex);
                    }
                }
            }
        }


        /// <summary>
        /// 用于分析时, 捕获 表达式 的正则
        /// </summary>
        public Regex Regex
        {
            get { return m_Regex; }
        }
        /// <summary>
        /// 用于分析时, 捕获 表达式关键字 的正则
        /// </summary>
        public List<Regex> ListKwRegex
        {
            get { return m_ListKwRegex; }
        }

    }
}
