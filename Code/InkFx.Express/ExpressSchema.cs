using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using InkFx.Express.SpecialCalcExpress;
using InkFx.Express.Utils;

namespace InkFx.Express
{
    /// <summary>
    /// 表达式结构 对象：任何一个需要计算的 表达式 都会 被转换成 这个对象
    /// </summary>
    [Serializable]
    public class ExpressSchema
    {
        private ExpressSchema() { }

        private string m_Source = string.Empty;
        private readonly Dictionary<string, ExpressSlice> m_HashArguments = new Dictionary<string, ExpressSlice>(StringComparer.CurrentCultureIgnoreCase);

        /// <summary>
        /// 表达式 的 原始 字符串
        /// </summary>
        public string Source
        {
            get { return m_Source; }
            internal set { m_Source = (value ?? string.Empty).Trim(); }
        }

        /// <summary>
        /// 当前表达式的 主片段
        /// </summary>
        public ExpressSlice MainSlice { get; internal set; }

        /// <summary>
        /// 该表达式的 所有参数 列表
        /// </summary>
        public Dictionary<string, ExpressSlice> Arguments
        {
            get { return m_HashArguments; }
            internal set
            {
                if (m_HashArguments != value)
                {
                    m_HashArguments.Clear();
                    if (value != null && value.Count > 0)
                        foreach (string key in value.Keys)
                            m_HashArguments.Add(key, value[key]);
                }
            }
        }

        /// <summary>
        /// 计算表达式的结果
        /// </summary>
        public object Calc(object objOrHash)
        {
            ExpressSlice mainSlice = MainSlice;
            if (mainSlice != null)
            {
                object result = (mainSlice.MetaValue != null || mainSlice.IExpress == null)
                                    ? mainSlice.MetaValue
                                    : mainSlice.IExpress.Calc(this, objOrHash);
                return result;
            }

            return null;
        }


        #region  静 态 函 数

        #region  常 量 值

        internal const string ExpressSchemaKeyFormat = "{{Express_{0}}}";
        internal const string CurrentObjectKeyword = "this";     //[this] 关键字 指向 参数对象

        internal const string UNKNOW_EXPRESS = "无法识别表达式 \'{0}\'.";
        internal const string UNKNOW_EXPRESS_SLICE = "未知的表达式片段或常量 \'{0}\'.";
        internal const string UNKNOW_EXPRESS_ERROR1 = "\'{0}\' 附近 存在语法错误.";
        internal const string UNKNOW_EXPRESS_ERROR2 = "\'{0}\' 表达式中 存在语法错误.";
        internal const string UNKNOW_EXPRESS_IEXPRESS = "计算器类型 \"{0}\" 没有实现 IExpress.";

        #endregion

        #region  参 数 配 置

        private static int m_ExpressSchemaPreCalc = -1;

        /// <summary>
        /// 是否对 表达式 在分析时 进行预运算
        /// </summary>
        public static bool ExpressSchemaPreCalc
        {
            get
            {
                if (m_ExpressSchemaPreCalc == -1)
                {
                    string value = ConfigurationManager.AppSettings["InkFx.Express:PreCalc"] ?? "True";
                    bool result = Tools.ToBoolean(value);
                    m_ExpressSchemaPreCalc = result ? 1 : 0;
                }

                return m_ExpressSchemaPreCalc == 1;
            }
        }


        #endregion

        #region  正 则 表 达 式

        internal static readonly Regex regexExpressSlice = new Regex(@"\{Express_\d+\}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        internal static readonly Regex regexOnlyExpressSlice = new Regex(@"^\{Express_\d+\}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex regexString = new Regex(@"(""((\\"")|(\\\\)|[^\""])*"")|('((\\')|(\\\\)|[^\'])*')", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex regexDouble = new Regex(@"(?<=[^\w]|(^))(-){0,1}\d+(\.){0,1}\d*(((E\+)|(E\-))\d+){0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex regexBoolean = new Regex(@"(?<=(^|[^\w]))((False)|(True))(?=($|[^\w]))", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        internal static readonly Regex regexFullArgument = new Regex(@"(\[\{Express_\d+\}\])((\[\{Express_\d+\}\])|([\.|\s]))*(\[\{Express_\d+\}\])*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        internal static readonly Regex regexSingleArgument = new Regex(@"\[\{Express_\d+\}\]", RegexOptions.IgnoreCase | RegexOptions.Compiled);


        internal static readonly Regex regexSingleBracket = new Regex(@"\([^\(\)]*\)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        internal static readonly Regex regexConstOrSlice = new Regex(@"((@*[\w\$]+)(\.(@*[\w\$]+))*)|(\{Express_\d+\})", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        internal static readonly Regex regexConst = new Regex(@"^((@*[\w\$]+)(\.(@*[\w\$]+))*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        #endregion




        /// <summary>
        /// 通过表达式 初始化一个 ExpressSchema 对象
        /// </summary>
        public static ExpressSchema Create(string express)
        {
            if (StringExtend.IsNullOrWhiteSpace(express)) return null;
            express = express.Trim();


            IgnoreDict<ExpressSlice> hashExpressSlice = new IgnoreDict<ExpressSlice>();

            #region  复杂分析前, 可以提前确认的 片段

            //提前获取 可能 需要 的计算器
            List<CalcExpressAttribute> listCalcExpressAttribute = FindCalcExpressAttributes(express);

            //提前获取 元数据
            string noStringExpress = MatchExpressString(express, hashExpressSlice, listCalcExpressAttribute);
            string noDoubleExpress = MatchExpressDouble(noStringExpress, hashExpressSlice, listCalcExpressAttribute);
            string noBooleanExpress = MatchExpressBoolean(noDoubleExpress, hashExpressSlice, listCalcExpressAttribute);

            //提前获取 用户参数
            string noArgumentExpress = MatchExpressArgument(noBooleanExpress, hashExpressSlice, listCalcExpressAttribute);

            #endregion


            //开始进行 复杂的结构分析
            ExpressSlice mainSlice = CreateSlice(noArgumentExpress, hashExpressSlice, listCalcExpressAttribute);


            ExpressSchema expressSchema = new ExpressSchema();
            expressSchema.Source = express;
            expressSchema.MainSlice = mainSlice;
            expressSchema.Arguments = hashExpressSlice;

            //在最后返回前, 无法替换的 常量表达式 抛出异常
            CheckConstExpress(mainSlice, hashExpressSlice, listCalcExpressAttribute); 

            if (ExpressSchemaPreCalc) PreCalc(expressSchema);
            return expressSchema;
        }


        /// <summary>
        /// 通过表达式, 和 结构片段Hash 初始化一个 ExpressSlice 对象
        /// </summary>
        private static ExpressSlice CreateSlice(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            if (StringExtend.IsNullOrWhiteSpace(express)) return null;
            express = express.Trim();
            ExpressSlice existSlice = hashExpressSlice[express];
            if (existSlice != null) return existSlice;


            //复杂的 表达式分析
            string singleExpress = MatchExpress(express, hashExpressSlice, listCalcExpressAttribute);
            singleExpress = singleExpress.Trim();


            ExpressSlice resultSlice = hashExpressSlice[singleExpress];
            if (resultSlice == null)
            {
                //匹配 可能的常量
                singleExpress = MatchExpressConst(singleExpress, hashExpressSlice, listCalcExpressAttribute);
                singleExpress = singleExpress.Trim();
                resultSlice = hashExpressSlice[singleExpress];
                if (resultSlice == null) throw new ExpressException(string.Format(UNKNOW_EXPRESS, express));
            }


            ReplaceConstExpress(resultSlice, hashExpressSlice, listCalcExpressAttribute); //在最后返回前, 替换 常量表达式
            return resultSlice;
        }


        #region  匹 配 元 数 据

        private static string MatchExpressString(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            string replaceExpress = regexString.Replace(express, match =>
            {
                string matchValue = match.Value;

                string strValue = StaticHelper.FormatString(matchValue);
                ExpressSlice expressSlice = new ExpressSlice();
                expressSlice.ExpressType = ExpressType.String;
                expressSlice.Express = strValue;
                expressSlice.Source = matchValue;
                expressSlice.MetaValue = strValue;

                if (!hashExpressSlice.ContainsKey(expressSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, expressSlice);
                    expressSlice.HashKey = replaceKey;
                }

                return " " + expressSlice.HashKey + " ";
            });
            return replaceExpress;
        }
        private static string MatchExpressDouble(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            string replaceExpress = regexDouble.Replace(express, match =>
            {
                string matchValue = match.Value;

                ExpressSlice expressSlice = new ExpressSlice();
                expressSlice.ExpressType = ExpressType.Double;
                expressSlice.Express = matchValue;
                expressSlice.Source = matchValue;
                expressSlice.MetaValue = Tools.ToDouble(matchValue, 0);

                if (!hashExpressSlice.ContainsKey(expressSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, expressSlice);
                    expressSlice.HashKey = replaceKey;
                }
                
                return " " + expressSlice.HashKey + " ";
            });
            return replaceExpress;
        }
        private static string MatchExpressBoolean(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            string replaceExpress = regexBoolean.Replace(express, match =>
            {
                string matchValue = match.Value;

                ExpressSlice expressSlice = new ExpressSlice();
                expressSlice.ExpressType = ExpressType.Boolean;
                expressSlice.Express = matchValue;
                expressSlice.Source = matchValue;
                expressSlice.MetaValue = Tools.ToBoolean(matchValue, false);

                if (!hashExpressSlice.ContainsKey(expressSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, expressSlice);
                    expressSlice.HashKey = replaceKey;
                }

                return " " + expressSlice.HashKey + " ";
            });
            return replaceExpress;
        }

        private static string MatchExpressArgument(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            string replaceExpress = ReplaceMidGroupBracket(express, match =>
            {
                string matchValue = match;
                matchValue = matchValue.Trim('[', ']');
                //bool isChildExpress = regexArgument.IsMatch(matchValue);
                ExpressSlice replaceSlice = CreateSlice(matchValue, hashExpressSlice, listCalcExpressAttribute); //!isChildExpress ? null : 

                if (!hashExpressSlice.ContainsKey(replaceSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, replaceSlice);
                    replaceSlice.HashKey = replaceKey;
                }
                
                return "[" + replaceSlice.HashKey +"]";
            });

            replaceExpress = regexFullArgument.Replace(replaceExpress, match =>
            {
                string matchValue = match.Value;

                ExpressSlice expressSlice = new ExpressSlice();
                expressSlice.ExpressType = ExpressType.Argument;
                expressSlice.Express = matchValue;
                expressSlice.Source = ReSourceExpress(matchValue, hashExpressSlice);
                expressSlice.IExpress = ArgumentCalcExpress.Create(expressSlice, hashExpressSlice);

                if (!hashExpressSlice.ContainsKey(expressSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, expressSlice);
                    expressSlice.HashKey = replaceKey;
                }

                return " " + expressSlice.HashKey + " ";
            });
            
            return replaceExpress;
        }
        private static string MatchExpressConst(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            if (StringExtend.IsNullOrWhiteSpace(express)) return express;
            express = express.Trim();
            ExpressSlice existSlice = hashExpressSlice[express];
            if (existSlice != null) return existSlice.Express;

            //结构简单, 则 直接返回 常量
            bool isConst = regexConst.IsMatch(express);
            if (isConst)
            {
                ExpressSlice constSlice = GetConstSlice(express);

                if (!hashExpressSlice.ContainsKey(constSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, constSlice);
                    constSlice.HashKey = replaceKey;
                }

                return " " + constSlice.HashKey + " ";
            }


            int beginSliceCount = hashExpressSlice.Count;

            ConstMatch source = new ConstMatch(express, false);
            List<ConstMatch> listSouceConstMatch = new List<ConstMatch> {source};
            List<ConstMatch> listSplitItem = MatchRegexSplitConst(listSouceConstMatch, regexExpressSlice, false);


            //先用 计算器常量 进行拆分
            foreach (CalcExpressAttribute attr in listCalcExpressAttribute)
            {
                List<Regex> listRegex = attr.ListKwRegex;
                if (listRegex == null || listRegex.Count <= 0) continue;

                foreach (Regex regex in listRegex)
                    listSplitItem = MatchRegexSplitConst(listSplitItem, regex, true);
            }

            //将拆分后的 片段 重组为 原始表达式
            List<string> listSplitStr = new List<string>();
            foreach (ConstMatch match in listSplitItem)
            {
                if (match.IsKeyword || match.IsSlice)
                {
                    listSplitStr.Add(match.Value);
                    continue;
                }
                else
                {
                    ExpressSlice constSlice = GetConstSlice(match.Value);

                    if (!hashExpressSlice.ContainsKey(constSlice.HashKey))
                    {
                        string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                        hashExpressSlice.Add(replaceKey, constSlice);
                        constSlice.HashKey = replaceKey;
                    }

                    listSplitStr.Add(constSlice.HashKey);
                }
            }

            string reExpress = string.Join(" ", listSplitStr.ToArray());

            int endSliceCount = hashExpressSlice.Count;
            if (endSliceCount > beginSliceCount) //以上分析, 有所作为 则 继续递归分析, 否则直接抛出异常
            {
                ExpressSlice reExpressSlice = CreateSlice(reExpress, hashExpressSlice, listCalcExpressAttribute);

                if (!hashExpressSlice.ContainsKey(reExpressSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, reExpressSlice);
                    reExpressSlice.HashKey = replaceKey;
                }

                return " " + reExpressSlice.HashKey + " ";
            }


            //代码到这里, 错误已经无法 挽回, 开始分析 明确的 错误原因

            List<ConstMatch> listErrorWord = listSplitItem.FindAll(x => (!x.IsSlice && !x.IsKeyword) && !StringExtend.IsNullOrWhiteSpace(x.Value));
            if (listErrorWord.Count >= 1)
            {
                throw new ExpressException(string.Format(UNKNOW_EXPRESS_ERROR1, listErrorWord[0].Value));
            }


            //全部字符都已经进行分析, 但是无法 组成最后 唯一的主表达式
            bool isAllSlice = listErrorWord.Count <= 0; 
            if (isAllSlice)
            {
                List<ConstMatch> listErrorSlice = listSplitItem.FindAll(x => (x.IsSlice && !x.IsKeyword) && !StringExtend.IsNullOrWhiteSpace(x.Value));
                foreach (ConstMatch errorSliceMatch in listErrorSlice)
                {
                    ExpressSlice errorSlice = hashExpressSlice[errorSliceMatch.Value.Trim()];
                    if (errorSlice != null && errorSlice.ExpressType == ExpressType.Const)
                        throw new ExpressException(string.Format(UNKNOW_EXPRESS_SLICE, errorSlice.Express));
                }
            }

            //无法分析出 错误片段, 将整个 表达式 全部作为异常 抛出
            string sourceExpress = ReSourceExpress(express, hashExpressSlice);
            throw new ExpressException(string.Format(UNKNOW_EXPRESS_ERROR2, sourceExpress));
        }




        /// <summary>
        /// 匹配 成组出现的 中括号
        /// </summary>
        private static string ReplaceMidGroupBracket(string express, MatchBracket evaluator)
        {
            return ReplaceGroupBracket(express, '[', ']', evaluator);
        }
        private static string ReplaceSmallGroupBracket(string express, MatchBracket evaluator)
        {
            return ReplaceGroupBracket(express, '(', ')', evaluator);
        }
        private static string ReplaceGroupBracket(string express, char startBracket, char endBracket, MatchBracket evaluator)
        {
            if (string.IsNullOrEmpty(express) || string.IsNullOrEmpty(express.Trim()) || evaluator == null) return express;


            int startCount = 0;
            int endCount = 0;
            int startIndex = 0;
            List<char> listChar = new List<char>();

            for (int i = 0, count = express.Length; i < count; i++)
            {
                char @char = express[i];
                if (@char == startBracket)
                {
                    startCount++;
                    if (startCount == 1) startIndex = i;
                }
                else if (@char == endBracket)
                {
                    endCount++;
                    if (startCount == endCount && endCount >= 1)
                    {
                        //匹配到一组
                        int endIndex = i;
                        string match = express.Substring(startIndex, endIndex - startIndex + 1);
                        string replace = evaluator(match);
                        listChar.AddRange(replace);

                        startCount = endCount = startIndex = 0;
                        continue; //防止 循环之后的追加 char
                    }
                }

                if (startCount <= 0) listChar.Add(@char);
            }

            string result = new string(listChar.ToArray());
            return result;
        }


        private static string ReSourceExpress(string express, IgnoreDict<ExpressSlice> hashExpressSlice)
        {
            string replaceExpress = regexExpressSlice.Replace(express, match =>
            {
                string matchValue = match.Value;

                ExpressSlice expressSlice = hashExpressSlice[matchValue.Trim()];
                return expressSlice == null ? matchValue : expressSlice.Source;
            });

            return replaceExpress;
        }
        private static ExpressSlice GetConstSlice(string express)
        {
            ExpressSlice constSlice = new ExpressSlice();
            constSlice.Express = express;
            constSlice.Source = express;
            constSlice.ExpressType = ExpressType.Const;
            constSlice.MetaValue = null;
            constSlice.IExpress = null;
            return constSlice;
        }

        private static List<ConstMatch> MatchRegexSplitConst(IEnumerable<ConstMatch> input, Regex regex, bool isKeyword)
        {
            List<ConstMatch> listResult = new List<ConstMatch>();

            foreach (ConstMatch strMatch in input)
            {
                if (strMatch.IsKeyword || strMatch.IsSlice)
                {
                    listResult.Add(strMatch);
                    continue;
                }

                string str = strMatch.Value;
                if (StringExtend.IsNullOrWhiteSpace(str)) continue;

                int index = 0;
                MatchCollection matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    if (match.Index > index)
                    {
                        string prevStr = str.Substring(index, (match.Index - index));
                        if (!StringExtend.IsNullOrWhiteSpace(prevStr)) listResult.Add(new ConstMatch(prevStr, false));
                    }
                    string matchValue = match.Value;
                    if (!StringExtend.IsNullOrWhiteSpace(matchValue)) listResult.Add(new ConstMatch(matchValue, isKeyword));
                    index = match.Index + match.Length;
                }

                if (index < str.Length)
                {
                    string lastStr = str.Substring(index);
                    if (!StringExtend.IsNullOrWhiteSpace(lastStr)) listResult.Add(new ConstMatch(lastStr, false));
                    index = index + lastStr.Length;
                }
            }

            return listResult;
        }
        private class ConstMatch
        {
            public ConstMatch(string value, bool isKeyword)
            {
                value = (value ?? string.Empty).Trim();
                this.Value = value;
                this.IsKeyword = isKeyword;
                this.IsSlice = ExpressSchema.regexOnlyExpressSlice.IsMatch(value);
            }

            public string Value { get; set; }
            public bool IsKeyword { get; set; }
            public bool IsSlice { get; set; }

            public override string ToString()
            {
                return Value;
            }
        }

        #endregion

        #region  匹 配 运 算 符

        /// <summary>
        /// 通过表达式 先过滤出 可能使用的 计算器
        /// </summary>
        private static List<CalcExpressAttribute> FindCalcExpressAttributes(string express)
        {
            if (StringExtend.IsNullOrWhiteSpace(express)) return null;

            List<CalcExpressAttribute> listReultCalcExpressAttribute = new List<CalcExpressAttribute>();

            List<CalcExpressAttribute> listCalcExpressAttribute = StaticHelper.ListCalcExpressAttribute;
            if (listCalcExpressAttribute != null)
            {
                foreach (CalcExpressAttribute attribute in listCalcExpressAttribute)
                {
                    try
                    {
                        if (attribute != null && attribute.Keywords != null && attribute.Keywords.Length > 0)
                        {
                            bool match = true;
                            foreach (string keyword in attribute.Keywords)
                            {
                                int index = express.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase);
                                if (index < 0) match = false;
                            }
                            if (match)
                                listReultCalcExpressAttribute.Add(attribute);
                        }
                    }
                    catch(Exception) { }
                }
            }

            listReultCalcExpressAttribute.Sort((x, y) => y.Level - x.Level);
            return listReultCalcExpressAttribute;
        }

        private static string MatchExpress(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            //先匹配 数组
            bool matchExpressBracket;
            string replaceExpress = MatchArrayOrBracket(express, hashExpressSlice, listCalcExpressAttribute, out matchExpressBracket);
            
            bool matchAnyExpress = false;
            if (listCalcExpressAttribute != null)
            {
                //先判定运算的优先级
                Match priorMatch = null;
                CalcExpressAttribute priorExpressAttribute = null;                //对于运算的优先级，平级时 前后运算
                foreach (CalcExpressAttribute computeAttribute in listCalcExpressAttribute)
                {
                    if (priorMatch != null && /*priorExpressAttribute != null && */computeAttribute.Level < priorExpressAttribute.Level) continue;
                    Match match = computeAttribute.Regex.Match(replaceExpress);
                    if (match.Success)
                    {
                        if ((priorMatch == null/* && priorExpressAttribute == null*/)                                           //如果还没有确定优先级，则当前优先
                            || (computeAttribute.Level > priorExpressAttribute.Level)                                           //如果等级高，则优先
                            || (computeAttribute.Level == priorExpressAttribute.Level && match.Index < priorMatch.Index))       //如果等级一致，则前面的优先
                        {
                            priorMatch = match;
                            priorExpressAttribute = computeAttribute;
                        }
                    }
                }

                //再来对判定优先的 匹配式 进行分析
                if (priorExpressAttribute != null && /*priorMatch!=null && */priorMatch.Success)
                {
                    matchAnyExpress = true;
                    Type expressType = priorExpressAttribute.ExpressType;
                    string matchValue = priorMatch.Value;


                    //初始化 计算器 对象
                    IExpress computer = Activator.CreateInstance(expressType) as IExpress;
                    if (computer == null) throw new ExpressException(string.Format(UNKNOW_EXPRESS_IEXPRESS, Tools.ToTypeName(expressType)));

                    //捕获 计算器 参数
                    List<ExpressSlice> listArgument = MatchExpressArgs(matchValue, hashExpressSlice, listCalcExpressAttribute);
                    computer.Arguments = listArgument.ToArray();

                    //合并为 当前 表达式片段对象
                    ExpressSlice expressSlice = new ExpressSlice();
                    expressSlice.ExpressType = ExpressType.Express;
                    expressSlice.Express = matchValue;
                    expressSlice.Source = ReSourceExpress(matchValue, hashExpressSlice);
                    computer.ExpressSlice = expressSlice;
                    expressSlice.IExpress = computer;

                    if (!hashExpressSlice.ContainsKey(expressSlice.HashKey))
                    {
                        string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                        hashExpressSlice.Add(replaceKey, expressSlice);
                        expressSlice.HashKey = replaceKey;
                    }


                    //置换 匹配到的 表达式
                    replaceExpress = replaceExpress.Substring(0, priorMatch.Index) + (" " + expressSlice.HashKey + " ") + replaceExpress.Substring(priorMatch.Index + priorMatch.Length);
                }
            }

            //如果匹配到 数组 或者 计算器 则 再次递归 【警告：数组是否匹配到也是 递归条件】
            if (matchExpressBracket || matchAnyExpress)
                replaceExpress = MatchExpress(replaceExpress, hashExpressSlice, listCalcExpressAttribute);

            return replaceExpress;
        }
        private static string MatchArrayOrBracket(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute, out bool matchAnyone)
        {
            bool matchAnySingleBracket = false;
            bool matchAnyArray = false;
            bool matchAnyoneTemp = false;

            //替换 无意义的括号
            //string replaceExpress = ReplaceExpressBracket(express, hashExpressSlice, listCalcExpressAttribute, out matchAnySingleBracket); //2015-11-17 取消本段
            string replaceExpress = express;

            //替换 括号型的数组
            replaceExpress = MatchExpressArray(replaceExpress, hashExpressSlice, listCalcExpressAttribute, out matchAnyArray);
            
            //不存在 任何括号之后, 开始匹配计算器
            if (!matchAnyArray)
            {                
                replaceExpress = regexSingleBracket.Replace(replaceExpress, match =>
                {
                    matchAnyoneTemp = true;
                    string matchValue = match.Value;

                    bool matchBracket = matchValue.StartsWith("(") && matchValue.EndsWith(")");
                    string replaceString = StaticHelper.FormatBracket(matchValue);
                    if (StringExtend.IsNullOrWhiteSpace(replaceString)) return "()";  //如果 是 纯 括号，则不匹配

                    //匹配 计算器表达式
                    string singleExpress = MatchExpress(replaceString, hashExpressSlice, listCalcExpressAttribute);
                    singleExpress = singleExpress.Trim();

                    if (singleExpress != replaceString && matchBracket) singleExpress = string.Format("({0})", singleExpress); //如果匹配到 计算器, 则 恢复 前后括号
                    return singleExpress;
                });
            }

            matchAnyone = matchAnySingleBracket || matchAnyoneTemp || matchAnyArray;
            return replaceExpress;
        }
        private static string MatchExpressArray(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute, out bool matchAnyone)
        {
            bool matchAnyoneTemp = false;
            string replaceExpress = regexSingleBracket.Replace(express, match =>  //regexArray
            {
                string matchValue = match.Value;
                if (string.IsNullOrEmpty(matchValue.TrimStart('(').TrimEnd(')').Trim())) return matchValue; //纯括号 直接返回


                string arrayExpress = StaticHelper.FormatArray(matchValue);
                ExpressSlice expressSlice = new ExpressSlice();
                expressSlice.ExpressType = ExpressType.ArrayList;


                string reArrayExpress;
                //捕获 数组 参数
                List < ExpressSlice > listArgument = MatchArrayItems(arrayExpress, hashExpressSlice, listCalcExpressAttribute, out reArrayExpress);
                expressSlice.IExpress = new ArrayListCalcExpress { ExpressSlice = expressSlice, Arguments = listArgument.ToArray() };
                expressSlice.Express = reArrayExpress;
                expressSlice.Source = ReSourceExpress(reArrayExpress, hashExpressSlice);

                if (!hashExpressSlice.ContainsKey(expressSlice.HashKey))
                {
                    string replaceKey = string.Format(ExpressSchemaKeyFormat, hashExpressSlice.Count.ToString());
                    hashExpressSlice.Add(replaceKey, expressSlice);
                    expressSlice.HashKey = replaceKey;
                }
                
                matchAnyoneTemp = listArgument.Count >= 1;
                return " " + expressSlice.HashKey + " ";
            });

            matchAnyone = matchAnyoneTemp;
            return replaceExpress;
        }

        private static List<ExpressSlice> MatchArrayItems(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute, out string reArrayExpress)
        {
            reArrayExpress = express;
            List<ExpressSlice> listArgument = new List<ExpressSlice>();

            List<string> listHashKey = new List<string>();
            string[] splits = express.Split(new[] {','});
            foreach (string split in splits)
            {
                string argExpress = split;
                ExpressSlice argSlice = CreateSlice(argExpress, hashExpressSlice, listCalcExpressAttribute); //hashExpressSlice[argumentExpress];
                listArgument.Add(argSlice);
                listHashKey.Add(argSlice.HashKey);
            }

            reArrayExpress = string.Join(", ", listHashKey.ToArray());
            return listArgument;
        }
        private static List<ExpressSlice> MatchExpressArgs(string express, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            List<ExpressSlice> listArgument = new List<ExpressSlice>();

            MatchCollection matchArgs = regexExpressSlice.Matches(express);
            if ( /*matchArgs!=null && */matchArgs.Count > 0)
                foreach (Match matchArg in matchArgs)
                {
                    if (matchArg != null && matchArg.Success)
                    {
                        string argExpress = matchArg.Value.Trim();
                        ExpressSlice argSlice = hashExpressSlice[argExpress];
                        listArgument.Add(argSlice);
                    }
                }

            return listArgument;
        }

        private static void CheckConstExpress(ExpressSlice expressSlice, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            if (expressSlice == null || expressSlice.IExpress is ArgumentCalcExpress) return; //属性计算器 常量忽略检查
            if (expressSlice.ExpressType == ExpressType.Const)
                throw new ExpressException(string.Format(UNKNOW_EXPRESS_SLICE, expressSlice.Express));

            if (expressSlice.IExpress != null)
            {
                ExpressSlice[] listArg = expressSlice.IExpress.Arguments;
                if (listArg != null && listArg.Length >= 1)
                {
                    foreach (ExpressSlice argSlice in listArg)
                        CheckConstExpress(argSlice, hashExpressSlice, listCalcExpressAttribute);
                }
            }

        }
        private static void ReplaceConstExpress(ExpressSlice expressSlice, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            List<IExpress> listIExpress = new List<IExpress> { GlobalConstCalcExpress.Instance };
            ReplaceConstExpress(listIExpress, expressSlice, hashExpressSlice, listCalcExpressAttribute);
        }
        private static void ReplaceConstExpress(List<IExpress> listIExpress, ExpressSlice expressSlice, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            //if (/*expressSlice.ExpressType != ExpressType.Express || */expressSlice.IExpress == null) return;
            if (listIExpress == null) listIExpress = new List<IExpress> { GlobalConstCalcExpress.Instance };


            if (expressSlice.ExpressType == ExpressType.Const)
            {
                ExpressSlice constSlice = EscapeConstExpress(listIExpress, expressSlice.Express, hashExpressSlice, listCalcExpressAttribute);
                if (constSlice != null)
                {
                    expressSlice.ExpressType = constSlice.ExpressType;
                    expressSlice.MetaValue = constSlice.MetaValue;
                }
                //单独 的 常量 不抛出异常 (因为 可能会有 函数 能识别这个常量)
                //else
                //    throw new ExpressException(string.Format(UNKNOW_EXPRESS_SLICE, expressSlice.Express));
            }
            else if (/*expressSlice.ExpressType == ExpressType.Express && */expressSlice.IExpress != null)
            {
                IExpress computer = expressSlice.IExpress;
                ExpressSlice[] listArg = computer.Arguments;
                if (listArg == null || listArg.Length <= 0) return;


                foreach (ExpressSlice arg in listArg)
                {
                    if (arg.ExpressType == ExpressType.Const)
                    {
                        ExpressSlice constSlice = null;

                        listIExpress.Add(computer); //将 computer 添加到 计算链中
                        try { constSlice = EscapeConstExpress(listIExpress, arg.Express, hashExpressSlice, listCalcExpressAttribute); }
                        finally { listIExpress.Remove(computer); } //将 computer 从 计算链中 移除

                        if (constSlice != null)
                        {
                            arg.ExpressType = constSlice.ExpressType;
                            arg.MetaValue = constSlice.MetaValue;
                        }
                        else
                            throw new ExpressException(string.Format(UNKNOW_EXPRESS_SLICE, arg.Express));
                    }
                    else if (/*arg.ExpressType == ExpressType.Express && */arg.IExpress != null)
                    {
                        listIExpress.Add(computer); //将 computer 添加到 计算链中
                        try { ReplaceConstExpress(listIExpress, arg, hashExpressSlice, listCalcExpressAttribute); }
                        finally { listIExpress.Remove(computer); } //将 computer 从 计算链中 移除
                    }
                }
            }

        }
        private static ExpressSlice EscapeConstExpress(List<IExpress> listIExpress, string constExpress, IgnoreDict<ExpressSlice> hashExpressSlice, List<CalcExpressAttribute> listCalcExpressAttribute)
        {
            if (listIExpress == null || listIExpress.Count <= 0) return null;
            if (StringExtend.IsNullOrWhiteSpace(constExpress)) return null;

            for (int i = listIExpress.Count - 1; i >= 0; i--)  //优先 最后进入集合的 计算链
            {
                IExpress computer = listIExpress[i];
                if (computer == null) continue;

                ExpressSlice resultSlice = computer.EscapeConst(constExpress);
                if (resultSlice != null) return resultSlice;
            }

            return null;
        }

        #endregion


        #region  表达式 预 运 算

        /// <summary>
        /// 对一个 表达式 进行 预运算
        /// </summary>
        public static void PreCalc(ExpressSchema expressSchema)
        {
            if (expressSchema == null) return;

            ExpressSlice mainSlice = expressSchema.MainSlice;
            if (mainSlice != null)
            {
                object result = mainSlice.IExpress == null
                                    ? mainSlice.MetaValue
                                    : mainSlice.IExpress.PreCalc(expressSchema);
                if (result != null) mainSlice.MetaValue = result;
            }
        }

        #endregion


        #endregion

    }

    /// <summary>
    /// 匹配成组 出现的 括号嵌套组
    /// </summary>
    public delegate string MatchBracket(string match);
}
