using System;
using System.Text.RegularExpressions;

namespace InkFx.Express.Utils
{
    internal partial class Tools
    {
        #region  数 据 转 换

        public static int ToFInt(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToInt(value);
        }
        public static double ToFDouble(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToDouble(value);
        }
        public static float ToFFloat(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToFloat(value);
        }
        public static string ToFString(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToString(value);
        }
        public static DateTime ToFDateTime(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToDateTime(value);
        }
        public static Guid ToFGuid(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToGuid(value);
        }
        public static byte ToFByte(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToByte(value);
        }
        public static bool ToFBoolean(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToBoolean(value);
        }
        public static long ToFLong(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToLong(value);
        }
        public static char ToFChar(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToChar(value);
        }
        public static decimal ToFDecimal(object obj, string property)
        {
            object value = GetValue(obj, property);
            return Tools.ToDecimal(value);
        }

        public static int ToFInt(object obj, string property, int @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToInt(value, @default);
        }
        public static double ToFDouble(object obj, string property, double @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToDouble(value, @default);
        }
        public static float ToFFloat(object obj, string property, float @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToFloat(value, @default);
        }
        public static string ToFString(object obj, string property, string @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToString(value, @default);
        }
        public static DateTime ToFDateTime(object obj, string property, DateTime @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToDateTime(value, @default);
        }
        public static Guid ToFGuid(object obj, string property, Guid @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToGuid(value, @default);
        }
        public static byte ToFByte(object obj, string property, byte @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToByte(value, @default);
        }
        public static bool ToFBoolean(object obj, string property, bool @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToBoolean(value, @default);
        }
        public static long ToFLong(object obj, string property, long @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToLong(value, @default);
        }
        public static char ToFChar(object obj, string property, char @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToChar(value, @default);
        }
        public static decimal ToFDecimal(object obj, string property, decimal @default)
        {
            object value = GetValue(obj, property);
            return Tools.ToDecimal(value, @default);
        }

        private static readonly DateTime m_DefaultTime = new DateTime(1900, 01, 01);
        public static int ToInt(object obj)
        {
            return ToInt(obj, 0);
        }
        public static double ToDouble(object obj)
        {
            return ToDouble(obj, 0);
        }
        public static float ToFloat(object obj)
        {
            return ToFloat(obj, 0);
        }
        public static string ToString(object obj)
        {
            return ToString(obj, string.Empty);
        }
        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, m_DefaultTime);
        }
        public static Guid ToGuid(object obj)
        {
            return ToGuid(obj, Guid.Empty);
        }
        public static byte ToByte(object obj)
        {
            return ToByte(obj, 0);
        }
        public static bool ToBoolean(object obj)
        {
            return ToBoolean(obj, false);
        }
        public static long ToLong(object obj)
        {
            return ToLong(obj, 0);
        }
        public static char ToChar(object obj)
        {
            return ToChar(obj, char.MinValue);
        }
        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(obj, 0);
        }

        public static int ToInt(object obj, int @default)
        {
            if (obj == null) return @default;
            if (obj is int) return (int)obj;
#if (!WindowsCE && !PocketPC)
            double temp;
            if (double.TryParse(obj.ToString(), out temp))
                return (int)temp;
            else
                return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return (int)Convert.ToDouble(obj); }
            catch { return @default; }
#endif
        }
        public static double ToDouble(object obj, double @default)
        {
            if (obj == null) return @default;
            if (obj is double) return (double)obj;
#if (!WindowsCE && !PocketPC)
            double temp;
            if (double.TryParse(obj.ToString(), out temp))
                return temp;
            else return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToDouble(obj); }
            catch { return @default; }
#endif
        }
        public static float ToFloat(object obj, float @default)
        {
            if (obj == null) return @default;
            if (obj is float) return (float)obj;
#if (!WindowsCE && !PocketPC)
            double temp;
            if (double.TryParse(obj.ToString(), out temp))
                return (float)temp;
            else return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return (float)Convert.ToDouble(obj); }
            catch { return @default; }
#endif
        }
        public static string ToString(object obj, string @default)
        {
            if (obj == null) return @default;
            if (obj is string) return (string)obj;
            return obj.ToString();
        }
        public static DateTime ToDateTime(object obj, DateTime @default)
        {
            if (obj == null) return @default;
            if (obj is DateTime) return (DateTime)obj;
#if (!WindowsCE && !PocketPC)
            DateTime temp;
            if (DateTime.TryParse(obj.ToString(), out temp))
                if (temp.Year >= 1800 && temp.Year <= 2200) return temp; //在 temp 基本有效时, 直接返回. 否则尝试使用 ParseDate 再试一次且优先返回temp2.

            DateTime temp2 = ParseDate(obj.ToString());
            if (temp2 != DateTime.MinValue) return temp2;
            if (temp != DateTime.MinValue) return temp;
            return @default;
#endif
#if (WindowsCE || PocketPC)
            DateTime temp;
            try { temp = Convert.ToDateTime(obj); } catch { }
            if (temp.Year >= 1800 && temp.Year <= 2200) return temp; //在 temp 基本有效时, 直接返回. 否则尝试使用 ParseDate 再试一次且优先返回temp2.

            DateTime temp2 = ParseDate(obj.ToString());
            if (temp2 != DateTime.MinValue) return temp2;
            if (temp != DateTime.MinValue) return temp;
            return @default;
#endif
        }
        public static Guid ToGuid(object obj, Guid @default)
        {
            if (obj == null) return @default;
            if (obj is Guid) return (Guid)obj;
            try { return new Guid(obj.ToString()); }
            catch { return @default; }
        }
        public static byte ToByte(object obj, byte @default)
        {
            if (obj == null) return @default;
            if (obj is byte) return (byte)obj;
#if (!WindowsCE && !PocketPC)
            byte temp;
            if (byte.TryParse(obj.ToString(), out temp))
                return temp;
            else return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToByte(obj); }
            catch { return @default; }
#endif
        }
        public static bool ToBoolean(object obj, bool @default)
        {
            if (obj == null) return @default;
            if (obj is bool) return (bool)obj;
            if (obj is short) return (short)obj > 0;
            if (obj is int) return (int)obj > 0;
            if (obj is long) return (long)obj > 0;
            if (obj is double) return (double)obj > 0;
            if (obj is float) return (float)obj > 0;
            if (obj is decimal) return (decimal)obj > 0;
            if (string.Equals(obj.ToString(), "T", StringComparison.CurrentCultureIgnoreCase)) return true;

#if (!WindowsCE && !PocketPC)
            bool temp;
            if (bool.TryParse(obj.ToString(), out temp)) return temp;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToBoolean(obj); }
            catch { }
#endif

            double number = ToDouble(obj, double.MinValue);
            if (number > 0) return true;

            return false;
        }
        public static long ToLong(object obj, long @default)
        {
            if (obj == null) return @default;
            if (obj is long) return (long)obj;

#if (!WindowsCE && !PocketPC)
            double temp;
            if (double.TryParse(obj.ToString(), out temp))
                return (long)temp;
            else return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return (long)Convert.ToDouble(obj); }
            catch { return @default; }
#endif
        }
        public static char ToChar(object obj, char @default)
        {
            if (obj == null) return @default;
            if (obj is char) return (char)obj;
#if (!WindowsCE && !PocketPC)
            char temp;
            if (char.TryParse(obj.ToString(), out temp))
                return temp;
            else return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToChar(obj); }
            catch { return @default; }
#endif
        }
        public static decimal ToDecimal(object obj, decimal @default)
        {
            if (obj == null) return @default;
            if (obj is decimal) return (decimal)obj;
#if (!WindowsCE && !PocketPC)
            decimal temp;
            if (decimal.TryParse(obj.ToString(), out temp))
                return temp;
            else return @default;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToDecimal(obj); }
            catch { return @default; }
#endif
        }


        public static E ToEnum<E>(object obj) where E : struct
        {
            try
            {
                string strValue = (obj ?? string.Empty).ToString().Trim();
                object result = Enum.Parse(typeof(E), strValue, true);
                return (E)result;
            }
            catch (Exception) { return default(E); }
        }
        public static object ToEnum(Type enumType, object obj)
        {
            try
            {
                string strValue = (obj ?? string.Empty).ToString().Trim();
                object result = Enum.Parse(enumType, strValue, true);
                return result;
            }
            catch (Exception) { return DefaultForType(enumType); }
        }



        #region  万能时间格式转换函数

        /*本函数 从 inkfx.html5.js 移植而来*/
        /*感谢 InkFx http://www.ink-fx.com 为 ParseDate(dateStr) 函数, 付出的努力 */

        /*将一个 字符串 转换成 时间对象, 转换失败将返回 DateTime.MinValue.本函数会尝试解析 各种时间格式, 因此性能不是那么高. (C) InkFx */
        internal static DateTime ParseDate(string dateStr)
        {
            try
            {
                dateStr = (dateStr ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(dateStr)) return DateTime.MinValue;

                DateTime date;

                /*数值转日期 (只识别 1900-2100范围内的时间)*/
                long dateLong = Tools.ToLong(dateStr, long.MinValue);
                if (dateLong != long.MinValue)
                {
                    date = new DateTime(0001, 01, 01, 0, 0, 0, DateTimeKind.Local).AddMilliseconds((double)dateLong / 10000);
                    if (date.Year >= 1900 && date.Year <= 2100) return date; /*C# 的 long>DateTime*/

                    date = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(dateLong).ToLocalTime();
                    if (date.Year >= 1900 && date.Year <= 2100) return date; /*js 的 number>Date*/
                }

                string str = dateStr.ToUpper();
                if (str.IndexOf("/") >= 0) str = str.Replace("/", "-");             /*将 / 替换成 -    //"yyyy/MM/dd HH:mm:ss.ffffff"*/
                if (str.IndexOf("T") >= 0) str = m_ParseDate_T.Replace(str, " ");   /*将 T 替换成 " "  /*"yyyy-MM-ddTHH:mm:ss.ffffff"*/
                if (str.IndexOf("年") >= 0) str = str.Replace("年", "-");
                if (str.IndexOf("月") >= 0) str = str.Replace("月", "-");
                if (str.IndexOf("日") >= 0) str = str.Replace("日", " ");
                if (str.IndexOf("时") >= 0) str = str.Replace("时", ":");
                if (str.IndexOf("分") >= 0) str = str.Replace("分", ":");
                if (str.IndexOf("秒") >= 0) str = str.Replace("秒", " ");

                str = m_ParseDate_Time.Replace(str, m => string.Format(" {0} ", m.Value));
                str = m_ParseDate_Date.Replace(str, m => string.Format(" {0} ", m.Value));
                str = str.Trim();

                date = ParseDatePD(str);
                if (date != DateTime.MinValue) return date;
                return DateTime.MinValue;
            }
            catch (Exception) { return DateTime.MinValue; }
        }
        /*按照 指定格式, 将一个 字符串 转换成 时间对象.本函数性能为 5~7W/s (C) InkFx */
        private static DateTime ParseDateF(string dateStr, string dateFormat)
        {
            dateStr = (dateStr ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(dateStr)) return DateTime.MinValue;
            ParseDateV t = new ParseDateV();

            dateStr = dateStr.Trim().ToUpper();
            if (dateStr.IndexOf("/") >= 0) dateStr = dateStr.Replace("/", "-");             /*将 / 替换成 -    //"yyyy/MM/dd HH:mm:ss.ffffff" */
            if (dateStr.IndexOf("T") >= 0) dateStr = m_ParseDate_T.Replace(dateStr, " ");   /*将 T 替换成 " "  //"yyyy-MM-ddTHH:mm:ss.ffffff" */
            if (dateStr.IndexOf("年") >= 0) dateStr = dateStr.Replace("年", "-");
            if (dateStr.IndexOf("月") >= 0) dateStr = dateStr.Replace("月", "-");
            if (dateStr.IndexOf("日") >= 0) dateStr = dateStr.Replace("日", " ");
            if (dateStr.IndexOf("时") >= 0) dateStr = dateStr.Replace("时", ":");
            if (dateStr.IndexOf("分") >= 0) dateStr = dateStr.Replace("分", ":");
            if (dateStr.IndexOf("秒") >= 0) dateStr = dateStr.Replace("秒", " ");
            if (dateFormat.IndexOf("/") >= 0) dateFormat = dateFormat.Replace("/", "-");
            if (dateFormat.IndexOf("T") >= 0) dateFormat = m_ParseDate_T.Replace(dateFormat, " ");
            if (dateFormat.IndexOf("年") >= 0) dateFormat = dateFormat.Replace("年", "-");
            if (dateFormat.IndexOf("月") >= 0) dateFormat = dateFormat.Replace("月", "-");
            if (dateFormat.IndexOf("日") >= 0) dateFormat = dateFormat.Replace("日", " ");
            if (dateFormat.IndexOf("时") >= 0) dateFormat = dateFormat.Replace("时", ":");
            if (dateFormat.IndexOf("分") >= 0) dateFormat = dateFormat.Replace("分", ":");
            if (dateFormat.IndexOf("秒") >= 0) dateFormat = dateFormat.Replace("秒", " ");

            /*替换英文格式的 月份*/
            /*删除英文格式的 星期*/
            /*类似格式(Chrome默认输出格式): Mon Mar 20 2017 02:46:06 GMT+0800 (中国标准时间)*/
            /*类似格式(IE9默认输出格式): Mon Mar 20 02:46:06 UTC+0800 2017*/
            if (dateStr.IndexOf("(") >= 0) dateStr = m_ParseDate_P.Replace(dateStr, string.Empty);
            if (m_ParseDate_AZ.IsMatch(dateStr))
            {
                dateStr = dateStr.Replace("JAN", "1").Replace("FEB", "2").Replace("MAR", "3").Replace("APR", "4").Replace("MAY", "5").Replace("JUN", "6").Replace("JUL", "7").Replace("AUG", "8").Replace("SEP", "9").Replace("OCT", "10").Replace("NOV", "11").Replace("DEC", "12");
                dateStr = dateStr.Replace("SUN", "").Replace("MON", "").Replace("TUE", "").Replace("WED", "").Replace("THU", "").Replace("FRI", "").Replace("SAT", "").Replace("SUNDAY", "").Replace("MONDAY", "").Replace("TUESDAY", "").Replace("WEDNESDAY", "").Replace("THURSDAY", "").Replace("FRIDAY", "").Replace("SATURDAY", "");
                dateStr = m_ParseDate_GU.Replace(dateStr, ""); /*去掉 GMT+0800 UTC+0800 +0800 +08 的时区内容*/
            }

            /*去掉多余空格*/
            dateStr = m_ParseDate_S.Replace(dateStr, " ").Trim();
            dateFormat = m_ParseDate_S.Replace(dateFormat, " ").Trim();
            dateStr = m_ParseDate_SP.Replace(dateStr, m => m.Value.Trim()).Trim();
            dateFormat = m_ParseDate_SP.Replace(dateFormat, m => m.Value.Trim()).Trim();
            bool failed = false;


            ParseDateD d = new ParseDateD();
            m_ParseDate_N.Replace(dateStr, m =>
            {
                if (failed) return string.Empty;

                int i = m.Index;
                string e = m.Value;
                d.v = dateStr.Substring(d.idxV, i - d.idxV);
                d.idxV = i + e.Length;
                int idxF2 = dateFormat.IndexOf(e, d.idxF);
                if (idxF2 >= 0)
                {
                    d.f = dateFormat.Substring(d.idxF, idxF2 - d.idxF);
                    d.idxF = idxF2 + e.Length;
                    ParseDateSV(d.f, d.v, t);
                    d.cntFV = d.cntFV + 1;
                }
                else
                    failed = true;
                return string.Empty;
            });
            if (failed) return DateTime.MinValue;
            if (d.idxV < dateStr.Length - 1 && d.idxF < dateFormat.Length - 1)
            {
                d.v = dateStr.Substring(d.idxV);
                d.f = dateFormat.Substring(d.idxF);
                ParseDateSV(d.f, d.v, t);
                d.cntFV++;
            }

            /*最后书写格式调整*/
            if (d.cntFV == 2)
            {
                /*yyyy-MM 和 MM-dd, 区分这两个模式*/
                if (t.Y < 1000) { t.d = t.M; t.M = t.Y; t.Y = 1900; }
            }
            else
            {
                /*美国人的书写习惯是月/日/年，学校通常使用mm/dd/yyyy来表示，千万不要和英国dd/mm/yyyy(日/月/年)的书写习惯搞混*/
                /*mm/dd/yyyy dd/mm/yyyy 会被替换成 mm-dd-yyyy dd-mm-yyyy*/
                /*yyyy-MM-dd MM-dd-yyyy dd-MM-yyyy, 区分这三个模式*/
                if (t.d >= 1000) { var temp = t.M; t.M = t.Y; t.Y = t.d; t.d = temp; }
                /*dd MM yyyy 交换位置 (yyyy-MM-dd MM-dd-yyyy)*/
                if (t.M >= 13) { var temp2 = t.M; t.M = t.d; t.d = temp2; }
                /*dd 和 MM 交换位置 (如果 yyyy-AA-BB 中, AA<=12, 默认为AA为MM)*/
            }

            while (t.S > 1000) { t.S = t.S / 1000; } /*毫秒值如果超过 1000, 则认定为微妙、纳秒模式*/

            DateTime date = new DateTime(t.Y, t.M, t.d, t.H, t.N, t.s, t.S);
            return date;
        }
        /*判断 指定字符串 中的 指定字符 是否等于 指定数目*/
        private static bool ParseDateCT(string str2, string s1, int n)
        {
            if (string.IsNullOrEmpty(str2)) return false;
            var idx = str2.IndexOf(s1);
            var cnt = 0;
            while (idx >= 0)
            {
                cnt++;
                idx = str2.IndexOf(s1, idx + s1.Length);
            }
            if (cnt == n) return true;
            return false;
        }
        /*将一个 字符串 尝试各种格式 试图转换成 DateTime 类型*/
        private static DateTime ParseDatePD(string dateStr)
        {
            DateTime dt = DateTime.MinValue;

            dateStr = dateStr.Trim();
            if (ParseDateCT(dateStr, "-", 2))
            {
                if (dt == DateTime.MinValue && ParseDateCT(dateStr, ".", 1))
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "yyyy-MM-dd HH:mm:ss.ffffff");
                }
                else if (dt == DateTime.MinValue && ParseDateCT(dateStr, ":", 2))
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "yyyy-MM-dd HH:mm:ss");
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "yyyy-MM-dd HH:mm:ss ffffff");
                }
                else if (dt == DateTime.MinValue && ParseDateCT(dateStr, ":", 1))
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "yyyy-MM-dd HH:mm");
                }
                else
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "yyyy-MM-dd");
                }
            }
            else if (ParseDateCT(dateStr, "-", 1))
            {
                if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "yyyy-MM");
            }
            else
            {
                if (dt == DateTime.MinValue && ParseDateCT(dateStr, ".", 1))
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "HH:mm:ss.ffffff");
                }
                else if (m_ParseDate_AZ.IsMatch(dateStr))
                {
                    /*类似格式(Chrome默认输出格式): Mon Mar 20 2017 02:46:06 GMT+0800 (中国标准时间)*/
                    /*类似格式(IE9默认输出格式): Mon Mar 20 02:46:06 UTC+0800 2017*/
                    if (dateStr.IndexOf("(") >= 0)
                    {
                        if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "MM dd yyyy HH:mm:ss");
                        if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "MM dd HH:mm:ss yyyy");
                    }
                    else
                    {
                        if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "MM dd HH:mm:ss yyyy");
                        if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "MM dd yyyy HH:mm:ss");
                    }
                }
                else if (dt == DateTime.MinValue && ParseDateCT(dateStr, ":", 2))
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "HH:mm:ss");
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "HH:mm:ss ffffff");
                }
                else if (dt == DateTime.MinValue && ParseDateCT(dateStr, ":", 1))
                {
                    if (dt == DateTime.MinValue) dt = ParseDateF(dateStr, "HH:mm");
                }
            }
            return dt;
        }
        /*尝试为 ParseDateV 的 参数赋值*/
        private static void ParseDateSV(string df, string dv, ParseDateV t)
        {
            if (t == null) return;
            df = m_ParseDate_S.Replace(df, string.Empty);
            dv = m_ParseDate_S.Replace(dv, string.Empty);


            int dv2 = ToInt(dv);
            if (df == "Y" || df == "YYYY" || df == "YY" || df == "yyyy" || df == "yy" || df == "y") t.Y = dv2;
            else if (df == "M" || df == "MM" || df == "MTH" || df == "MONTH") t.M = dv2;
            else if (df == "d" || df == "dd" || df == "day") t.d = dv2;
            else if (df == "H" || df == "HH" || df == "HH24" || df == "hh24") t.H = dv2;
            else if (df == "h" || df == "hh" || df == "HH12" || df == "hh12") t.h = dv2;
            else if (df == "N" || df == "mm" || df == "MI") t.N = dv2;
            else if (df == "s" || df == "ss") t.s = dv2;
            else if (df == "S" || df == "MS" || df == "SSSSSS" || df == "SSS" || df == "SS" || df == "ffffff" || df == "fff" || df == "ff") t.S = dv2;
        }


        private static readonly Regex m_ParseDate_Date = new Regex(@"\d{1,4}\s*-\s*\d{1,2}\s*-\s*\d{1,4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_Time = new Regex(@"\d{1,2}\s*:\s*\d{1,2}(\s*:\s*\d{1,2})*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_T = new Regex(@"(?<=\d)\s*T\s*(?=\d)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_S = new Regex(@"\s+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_N = new Regex(@"[^0-9]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_AZ = new Regex(@"[A-Z]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_GU = new Regex(@"((GMT)|(UTC))*\+\d+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_P = new Regex(@"\([^\)]+\)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex m_ParseDate_SP = new Regex(@"\s*[:/\\-]\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /*Z时区、h12小时、P上下午、W星期 暂时不提供识别*/
        private class ParseDateV
        {
            public ParseDateV()
            {
                DateTime nowTime = DateTime.Now;
                Y = nowTime.Year;
                M = nowTime.Month;
                d = nowTime.Day;
            }

            public int Y = 0;
            public int M = 0;
            public int d = 0;
            public int H = 00;
            public int h = 00;
            public int N = 00;
            public int s = 00;
            public int S = 00;
            public int Z = 0;
            public int P = 0;
            public int W = 0;
        }
        private class ParseDateD
        {
            public int idxV = 0;
            public int idxF = 0;
            public int cntFV = 0;
            public string v;
            public string f;
        }

        #endregion


        #endregion
    }
}
