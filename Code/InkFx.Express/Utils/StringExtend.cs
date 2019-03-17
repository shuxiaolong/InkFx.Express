using System;
using System.Collections.Generic;
using System.Text;

namespace InkFx.Express.Utils
{
    internal static class StringExtend
    {
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
