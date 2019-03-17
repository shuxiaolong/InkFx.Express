//-----------------------------------------------------------
// 本类部分代码来自 微软 .Net Framework 4.0 的 string 的 新函数；
//-----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace InkFx.Express.Utils
{
    internal partial class Tools
    {
        #region  操 作 字 符 串


        public static string InsureStartWith(string str, string start)
        {
            return InsureStartWith(str, start, true);
        }
        public static string InsureEndWith(string str, string end)
        {
            return InsureEndWith(str, end, true);
        }
        public static string InsureStartWith(string str, string start, bool ignore)
        {
            //保证字符串 以 指定的字符开头
            string newStr = str.TrimStart();
            bool isStart = ignore
                               ? newStr.StartsWith(start, StringComparison.CurrentCultureIgnoreCase)
                               : newStr.StartsWith(start);
            if (isStart) return str;

            newStr = start + str;
            return newStr;
        }
        public static string InsureEndWith(string str, string end, bool ignore)
        {
            //保证字符串 以 指定的字符皆为
            string newStr = str.TrimEnd();
            bool isEnd = ignore
                               ? newStr.EndsWith(end, StringComparison.CurrentCultureIgnoreCase)
                               : newStr.EndsWith(end);
            if (isEnd) return str;

            newStr = str + end;
            return newStr;
        }

        #endregion


        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value == null)
            {
                return true;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        //Split 函数 是为 WinCE 平台而写；
        //好吧，我承认 Split 函数，微软的代码 看着 头晕，自己写个，性能肯定是比不上微软了；
        public static string[] Split(string source, string split, StringSplitOptions splitOptions)
        {
            return Split(source, split, splitOptions, StringComparison.CurrentCulture);
        }
        public static string[] Split(string source, string split, StringSplitOptions splitOptions, StringComparison stringComparison)
        {
            if (string.IsNullOrEmpty(source)) return new[] { source ?? string.Empty };
            if (split == null || split.Length <= 0) return new[] { source };

            List<string> items = new List<string>();

            while (source.Length > 0)
            {
                int index = source.IndexOf(split, stringComparison);
                if (index >= 0)
                {
                    string item = index == 0 ? string.Empty : source.Substring(0, index);
                    if (splitOptions != StringSplitOptions.RemoveEmptyEntries || !IsNullOrWhiteSpace(item))
                        items.Add(item);
                    source = source.Substring(index + split.Length);
                }
                else
                {
                    if (splitOptions != StringSplitOptions.RemoveEmptyEntries || !IsNullOrWhiteSpace(source))
                        items.Add(source);
                    source = string.Empty;
                }
            }

            return items.ToArray();
        }
        public static string[] Split(string source, char[] split, StringSplitOptions splitOptions)
        {
            return Split(source, split, splitOptions, StringComparison.CurrentCulture);
        }
        public static string[] Split(string source, char[] split, StringSplitOptions splitOptions, StringComparison stringComparison)
        {
            if (string.IsNullOrEmpty(source)) return new[] { source ?? string.Empty };
            if (split == null || split.Length <= 0) return new[] { source };

            int[] listSplitIndex = GetSplitIndex(source, split, stringComparison);
            if (listSplitIndex == null || listSplitIndex.Length <= 0) return new[] { source };

            bool flag = splitOptions == StringSplitOptions.RemoveEmptyEntries;
            List<string> items = new List<string>();

            //|00|111|
            //01234567
            //0  3   7
            //0  1   2

            int listSplitLength = listSplitIndex.Length;
            int splitIndex = 0;                                     //0     1   2
            int sourceSplitIndex = listSplitIndex[splitIndex];      //0     3   7
            StringBuilder sb = new StringBuilder();
            for (int i = 0, count = source.Length; i < count; i++)  //0 1 2 3 4 5 6 7
            {
                if (i >= sourceSplitIndex)                          //0>=0 | 3>=3 | 7>=7 |
                {
                    string splitItem = sb.ToString();               // | 
                    if (!string.IsNullOrEmpty(splitItem) || (!flag)) items.Add(splitItem);  //TF | T | T

                    if (sb.Length > 0) sb.Remove(0, sb.Length);                             //F  | T 
                    splitIndex++;                                           //1  2  3
                    sourceSplitIndex = listSplitLength > splitIndex ? listSplitIndex[splitIndex] : count + 1;      //3  7  8
                }
                else if (i < sourceSplitIndex)                      //1,2<3 | 4,5,6<7
                {
                    sb.Append(source[i]);                           //00    | 111
                }
            }

            string lastSplitItem = sb.ToString();               
            if (!string.IsNullOrEmpty(lastSplitItem) || (!flag)) items.Add(lastSplitItem);

            return items.ToArray();
        }

        private static int[] GetSplitIndex(string source, char[] separator, StringComparison stringComparison)
        {
            List<int> sepList = new List<int>();

            for (int i = 0, count = source.Length; i < count; i++)
            {
                string iString = source[i].ToString();
                for (int j = 0, length = separator.Length; j < length; j++)
                {
                    string jString = separator[j].ToString();
                    if (jString.Equals(iString, stringComparison))
                        sepList.Add(i);
                }
            }

            return sepList.ToArray();
        }


        public static string Join(string separator, params string[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return string.Join(separator, value, 0, value.Length);
        }
        public static string Join(string separator, params object[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Length == 0 || values[0] == null)
            {
                return string.Empty;
            }
            if (separator == null)
            {
                separator = string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder();
            string text = values[0].ToString();
            if (text != null)
            {
                stringBuilder.Append(text);
            }
            for (int i = 1; i < values.Length; i++)
            {
                stringBuilder.Append(separator);
                if (values[i] != null)
                {
                    text = values[i].ToString();
                    if (text != null)
                    {
                        stringBuilder.Append(text);
                    }
                }
            }
            return stringBuilder.ToString();
        }
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (separator == null)
            {
                separator = string.Empty;
            }
            string result;
            using (IEnumerator<T> enumerator = values.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    result = string.Empty;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (!Equals(enumerator.Current, default(T)))
                    {
                        T current = enumerator.Current;
                        string text = current.ToString();
                        if (text != null)
                        {
                            stringBuilder.Append(text);
                        }
                    }
                    while (enumerator.MoveNext())
                    {
                        stringBuilder.Append(separator);
                        if (!Equals(enumerator.Current, default(T)))
                        {
                            T current2 = enumerator.Current;
                            string text2 = current2.ToString();
                            if (text2 != null)
                            {
                                stringBuilder.Append(text2);
                            }
                        }
                    }
                    result = stringBuilder.ToString();
                }
            }
            return result;
        }
        public static string Join(string separator, IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (separator == null)
            {
                separator = string.Empty;
            }
            string result;
            using (IEnumerator<string> enumerator = values.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    result = string.Empty;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (enumerator.Current != null)
                    {
                        stringBuilder.Append(enumerator.Current);
                    }
                    while (enumerator.MoveNext())
                    {
                        stringBuilder.Append(separator);
                        if (enumerator.Current != null)
                        {
                            stringBuilder.Append(enumerator.Current);
                        }
                    }
                    result = stringBuilder.ToString();
                }
            }
            return result;
        }

    }

#if (WindowsCE || PocketPC)

    [Flags]
    internal enum StringSplitOptions
    {
        None = 0,
        RemoveEmptyEntries = 1
    }

#endif

}
