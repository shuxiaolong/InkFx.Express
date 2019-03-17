using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace InkFx.Express.Utils
{
    internal static class Tools
    {

        #region  类 型 转 换

        /// <summary>
        /// 将一个 Type字符串 转换成 Type
        /// </summary>
        public static Type FromTypeName(string typeName)
        {
            return FromTypeName(typeName, null);
        }
        /// <summary>
        /// 将一个 Type字符串 转换成 Type
        /// </summary>
        public static Type FromTypeName(string typeName, Type defaultValue)
        {
            if (string.IsNullOrEmpty(typeName)) return defaultValue;
            Type type = Type.GetType(typeName);
            return type;
        }
        /// <summary>
        /// 将一个 Type 转换成 Type字符串
        /// </summary>
        public static string ToTypeName(Type type)
        {
            if (type == null) return string.Empty;
            string typeName = type.AssemblyQualifiedName;
            return typeName;
        }

        #endregion


        #region  序列化 和 反序列化

        public static byte[] DotNetBinarySerialize(object data)
        {
            return DotNetBinarySerialize(data, false);
        }
        public static byte[] DotNetBinarySerialize(object data, bool throwEeception)
        {
            if (data == null) return null;

            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                using (MemoryStream rems = new MemoryStream())
                {
                    formatter.Serialize(rems, data);
                    return rems.ToArray();          //GetBuffer()  不是实际长度，而是 2的次方 数目    
                }
            }
            catch (Exception exp)
            {
                if (throwEeception) throw;
                else
                {
                    string logMsg = ".Net框架 BinaryFormatter 对数据进行 Binary 序列化操作时,发生错误:" + exp;
                    Tools.ErrorLog(logMsg, "Logs/Knowyou.PB.Core/ErrorLog/");
                    return null;
                }
            }
        }
        public static object DotNetBinaryDeserialize(byte[] data)
        {
            return DotNetBinaryDeserialize(data, false);
        }
        public static object DotNetBinaryDeserialize(byte[] data, bool throwEeception)
        {
            if (data == null || data.Length <= 0) return null;
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                using (MemoryStream rems = new MemoryStream(data))
                {
                    return formatter.Deserialize(rems);
                }
            }
            catch (Exception exp)
            {
                if (throwEeception) throw;
                else
                {
                    string logMsg = ".Net框架 BinaryFormatter 对数据进行 Binary 反序列化操作时,发生错误:" + exp;
                    Tools.ErrorLog(logMsg, "Logs/Knowyou.PB.Core/ErrorLog/");
                    return null;
                }
            }
        }


        public static string DotNetXmlSerialize(object data)
        {
            return DotNetXmlSerialize(data, false);
        }
        public static string DotNetXmlSerialize(object data, bool throwEeception)
        {
            if (data == null) return string.Empty;

            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
                using (TextWriter textWriter = new StringWriter(stringBuilder))
                {
                    xmlSerializer.Serialize(textWriter, data);
                }
                return stringBuilder.ToString();
            }
            catch (Exception exp)
            {
                if (throwEeception) throw;
                else
                {
                    string logMsg = ".Net框架 XmlSerializer 对数据进行 Xml 序列化操作时,发生错误:" + exp;
                    Tools.ErrorLog(logMsg, "Logs/Knowyou.PB.Core/ErrorLog/");
                    return null;
                }
            }
        }
        public static T DotNetXmlDeserialize<T>(string xml)
        {
            return DotNetXmlDeserialize<T>(xml, false);
        }
        public static T DotNetXmlDeserialize<T>(string xml, bool throwEeception)
        {
            try
            {
                T result;
                StringBuilder stringBuilder = new StringBuilder(xml);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (TextReader textReader = new StringReader(stringBuilder.ToString()))
                {
                    Object record = xmlSerializer.Deserialize(textReader);
                    result = (T)record;
                }
                return result;
            }
            catch (Exception exp)
            {
                if (throwEeception) throw;
                else
                {
                    string logMsg = ".Net框架 XmlSerializer 对数据进行 Xml 反序列化操作时,发生错误:" + exp;
                    Tools.ErrorLog(logMsg, "Logs/Knowyou.PB.Core/ErrorLog/");
                    return default(T);
                }
            }
        }






        public static string BinaryToBase64(byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0) return string.Empty;
            try
            {
                string base64 = Convert.ToBase64String(bytes);
                return base64;
            }
            catch (Exception) { return string.Empty; }
        }
        public static byte[] Base64ToBinary(string base64)
        {
            if (base64 == null || base64.Length <= 0) return null;
            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                return bytes;
            }
            catch (Exception) { return null; }
        }
        public static string ObjectToBase64(object record)
        {
            try
            {
                byte[] bytes = DotNetBinarySerialize(record);
                string base64 = Convert.ToBase64String(bytes);
                return base64;
            }
            catch (Exception) { return string.Empty; }
        }
        public static T ObjectFromBase64<T>(string str64)
        {
            object obj = ObjectFromBase64(str64);
            T record = obj is T ? (T)obj : default(T);
            return record;
        }
        public static object ObjectFromBase64(string str64)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(str64);
                object obj = DotNetBinaryDeserialize(bytes);
                return obj;
            }
            catch (Exception) { return null; }
        }




        #endregion


        #region  数 据 转 换

        public static int ToRFInt(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToInt(value, 0);
        }
        public static double ToRFDouble(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToDouble(value, 0);
        }
        public static float ToRFFloat(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToFloat(value, 0);
        }
        public static string ToRFString(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToString(value, string.Empty);
        }
        public static DateTime ToRFDateTime(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToDateTime(value, new DateTime(1900, 01, 01));
        }
        public static Guid ToRFGuid(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToGuid(value, Guid.Empty);
        }
        public static byte ToRFByte(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToByte(value, 0);
        }
        public static bool ToRFBoolean(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToBoolean(value, false);
        }
        public static long ToRFLong(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToLong(value, 0);
        }
        public static char ToRFChar(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToChar(value, Char.MinValue);
        }
        public static decimal ToRFDecimal(object obj, string propertyName)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToDecimal(value, 0);
        }

        public static int ToRFInt(object obj, string propertyName, int defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToInt(value, defaultValue);
        }
        public static double ToRFDouble(object obj, string propertyName, double defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToDouble(value, defaultValue);
        }
        public static float ToRFFloat(object obj, string propertyName, float defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToFloat(value, defaultValue);
        }
        public static string ToRFString(object obj, string propertyName, string defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToString(value, defaultValue);
        }
        public static DateTime ToRFDateTime(object obj, string propertyName, DateTime defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToDateTime(value, defaultValue);
        }
        public static Guid ToRFGuid(object obj, string propertyName, Guid defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToGuid(value, defaultValue);
        }
        public static byte ToRFByte(object obj, string propertyName, byte defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToByte(value, defaultValue);
        }
        public static bool ToRFBoolean(object obj, string propertyName, bool defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToBoolean(value, defaultValue);
        }
        public static long ToRFLong(object obj, string propertyName, long defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToLong(value, defaultValue);
        }
        public static char ToRFChar(object obj, string propertyName, char defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToChar(value, defaultValue);
        }
        public static decimal ToRFDecimal(object obj, string propertyName, decimal defaultValue)
        {
            object value = GetValue(obj, propertyName);
            return Tools.ToDecimal(value, defaultValue);
        }

        public static int ToInt(object obj, int defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is int) return (int)obj;
#if (!WindowsCE && !PocketPC)
            int temp;
            if (int.TryParse(obj.ToString(), out temp))
                return temp;
            else
                return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToInt32(obj); }
            catch { return defaultValue; }
#endif
        }
        public static double ToDouble(object obj, double defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is double) return (double)obj;
#if (!WindowsCE && !PocketPC)
            double temp;
            if (double.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToDouble(obj); }
            catch { return defaultValue; }
#endif
        }
        public static float ToFloat(object obj, float defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is float) return (float)obj;
#if (!WindowsCE && !PocketPC)
            float temp;
            if (float.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToSingle(obj); }
            catch { return defaultValue; }
#endif
        }
        public static string ToString(object obj, string defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is string) return (string)obj;
            return obj.ToString();
        }
        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is DateTime) return (DateTime)obj;
#if (!WindowsCE && !PocketPC)
            DateTime temp;
            if (DateTime.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToDateTime(obj); }
            catch { return defaultValue; }
#endif
        }
        public static Guid ToGuid(object obj, Guid defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is Guid) return (Guid)obj;
            try { return new Guid(obj.ToString()); }
            catch { return defaultValue; }
        }
        public static byte ToByte(object obj, byte defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is byte) return (byte)obj;
#if (!WindowsCE && !PocketPC)
            byte temp;
            if (byte.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToByte(obj); }
            catch { return defaultValue; }
#endif
        }
        public static bool ToBoolean(object obj, bool defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is bool) return (bool)obj;
            if (obj is int) return (int) obj > 0;
            if (obj is long) return (long)obj > 0;
            if (obj is double) return (double)obj > 0;
            if (obj is float) return (float)obj > 0;
            if (obj is decimal) return (decimal)obj > 0;
            if (string.Equals(obj.ToString(), "T", StringComparison.CurrentCultureIgnoreCase)) return true;

#if (!WindowsCE && !PocketPC)            
            bool temp;
            if (bool.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToBoolean(obj); }
            catch { return defaultValue; }
#endif
        }
        public static long ToLong(object obj, long defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is long) return (long)obj;
#if (!WindowsCE && !PocketPC)            
            long temp;
            if (long.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToInt64(obj); }
            catch { return defaultValue; }
#endif
        }
        public static char ToChar(object obj, char defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is char) return (char)obj;
#if (!WindowsCE && !PocketPC)            
            char temp;
            if (char.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToChar(obj); }
            catch { return defaultValue; }
#endif
        }
        public static decimal ToDecimal(object obj, decimal defaultValue)
        {
            if (obj == null) return defaultValue;
            if (obj is decimal) return (decimal)obj;
#if (!WindowsCE && !PocketPC)            
            decimal temp;
            if (decimal.TryParse(obj.ToString(), out temp))
                return temp;
            else return defaultValue;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToDecimal(obj); }
            catch { return defaultValue; }
#endif
        }

        public static int ToInt(object obj)
        {
            if (obj == null) return 0;
            if (obj is int) return (int)obj;
#if (!WindowsCE && !PocketPC)  
            int temp;
            if (int.TryParse(obj.ToString(), out temp))
                return temp;
            return 0;
#endif
#if (WindowsCE || PocketPC)
            try { return Convert.ToInt32(obj); }
            catch { return 0; }
#endif
        }
        public static double ToDouble(object obj)
        {
            if (obj == null) return 0;
            if (obj is double) return (double)obj;
            double temp;
            if (double.TryParse(obj.ToString(), out temp))
                return temp;
            return 0;
        }
        public static float ToFloat(object obj)
        {
            if (obj == null) return 0;
            if (obj is float) return (float)obj;
            float temp;
            if (float.TryParse(obj.ToString(), out temp))
                return temp;
            return 0;
        }
        public static string ToString(object obj)
        {
            if (obj == null) return string.Empty;
            if (obj is string) return (string)obj;
            return obj.ToString();
        }
        public static DateTime ToDateTime(object obj)
        {
            if (obj == null) return new DateTime(1900, 01, 01);
            if (obj is DateTime) return (DateTime)obj;
            DateTime temp;
            if (DateTime.TryParse(obj.ToString(), out temp))
                return temp;
            return new DateTime(1900, 01, 01);
        }
        public static Guid ToGuid(object obj)
        {
            if (obj == null) return Guid.Empty;
            if (obj is Guid) return (Guid)obj;
            try { return new Guid(obj.ToString()); }
            catch { return Guid.Empty; }
        }
        public static byte ToByte(object obj)
        {
            if (obj == null) return 0;
            if (obj is byte) return (byte)obj;
            byte temp;
            byte.TryParse(obj.ToString(), out temp);
            return temp;
        }
        public static bool ToBoolean(object obj)
        {
            if (obj == null) return false;
            if (obj is bool) return (bool)obj;
            if (obj is int) return (int)obj > 0;
            if (obj is long) return (long)obj > 0;
            if (obj is double) return (double)obj > 0;
            if (obj is float) return (float)obj > 0;
            if (obj is decimal) return (decimal)obj > 0;
            if (string.Equals(obj.ToString(), "T", StringComparison.CurrentCultureIgnoreCase)) return true;
            bool temp;
            bool.TryParse(obj.ToString(), out temp);
            return temp;
        }
        public static long ToLong(object obj)
        {
            if (obj == null) return 0;
            if (obj is long) return (long)obj;
            long temp;
            if (long.TryParse(obj.ToString(), out temp))
                return temp;
            return 0;
        }
        public static char ToChar(object obj)
        {
            if (obj == null) return char.MinValue;
            if (obj is char) return (char)obj;
            char temp;
            char.TryParse(obj.ToString(), out temp);
            return temp;
        }
        public static decimal ToDecimal(object obj)
        {
            if (obj == null) return 0;
            if (obj is decimal) return (decimal)obj;
            decimal temp;
            if (decimal.TryParse(obj.ToString(), out temp))
                return temp;
            return 0;
        }

        #endregion


        #region  记 录 日 志

        public static readonly object objLogLocker = new object();

        public static void DebugLog(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Debug);
        }
        public static void WarnLog(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Warn);
        }
        public static void ErrorLog(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Error);
        }
        public static void InfoLog(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Info);
        }
        public static void FatalErrorLog(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.FatalError);
        }
        public static void WriteLog(string logMsg, string dirName, LogType logType)
        {
            lock (objLogLocker)
            {
                try
                {
                    string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                    if (string.IsNullOrEmpty(dirName)) dirName = "Logs";

                    string folderPath = FileHelper.FormatFullPath(dirName); //如果不是全路径 则 补全
                    FileHelper.CreateFolder(folderPath);

                    #region  将日志文本 转为 标准格式

                    bool isMultiLog = logMsg.Contains("\r") || logMsg.Contains("\n");  //是否是 多行日志
                    logMsg = ! isMultiLog
                        ? string.Format("{0} \t{1} \t{2:yyyy-MM-dd HH:mm:ss:fff}\r\n", logType, logMsg, DateTime.Now)
                        : string.Format("\r\n{0} \r\n{1} \r\n{2:yyyy-MM-dd HH:mm:ss:fff} \r\n", logType, logMsg, DateTime.Now);

                    #endregion

                    string logPath = string.Format(@"{0}\{1}", folderPath.TrimEnd('\\', '/'), fileName);
                    File.AppendAllText(logPath, logMsg);
                }
                catch (Exception) { }
            }
        }
        public static void WriteLog(string logMsg, string logPath)
        {
            lock (objLogLocker)
            {
                try
                {
                    logPath = FileHelper.FormatFullPath(logPath); //如果不是全路径 则 补全
                    FileHelper.CreateFolder(logPath);

                    #region  将日志文本 转为 标准格式

                    bool isMultiLog = logMsg.Contains("\r") || logMsg.Contains("\n");  //是否是 多行日志
                    logMsg = !isMultiLog
                        ? string.Format("{0} \t{1:yyyy-MM-dd HH:mm:ss:fff}\r\n", logMsg, DateTime.Now)
                        : string.Format("\r\n{0} \r\n{1:yyyy-MM-dd HH:mm:ss:fff} \r\n", logMsg, DateTime.Now);

                    #endregion

                    File.AppendAllText(logPath, logMsg);
                }
                catch (Exception) { }
            }
        }

        #endregion


        #region  数 据 类 型 和 动 态 赋 值 取 值

        public static bool SetHashValue(IDictionary<string, object> hash, string key, object value)
        {
            try
            {
                if (hash != null && !string.IsNullOrEmpty(key))
                {
                    if (hash.ContainsKey(key)) hash[key] = value;
                    else hash.Add(key, value);
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        public static object GetHashValue(IDictionary<string, object> hash, string key)
        {
            try
            {
                if (hash != null && !string.IsNullOrEmpty(key) && hash.ContainsKey(key))
                    return hash[key];
                return null;
            }
            catch (Exception) { return null; }
        }
        public static bool SetDataRow(DataRow dataRow, string column, object value)
        {
            try
            {
                if (dataRow != null && !string.IsNullOrEmpty(column))
                {
                    //if (dataRow.Table.Columns.Contains(column))
                    //{
                    //    dataRow[column] = value;
                    //    return true;
                    //}
                    //else return false;

                    dataRow[column] = value;
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        public static object GetDataRow(DataRow dataRow, string column)
        {
            try
            {
                if (dataRow != null && !string.IsNullOrEmpty(column) /*&& dataRow.Table.Columns.Contains(column)*/)
                    return dataRow[column];
                return null;
            }
            catch (Exception) { return null; }
        }
        public static bool SetDataRowView(DataRowView dataRowView, string column, object value)
        {
            try
            {
                if (dataRowView != null && !string.IsNullOrEmpty(column))
                {
                    //if (dataRowView.Row.Table.Columns.Contains(column))
                    //{
                    //    dataRowView[column] = value;
                    //    return true;
                    //}
                    //else return false;

                    dataRowView[column] = value;
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        public static object GetDataRowView(DataRowView dataRowView, string column)
        {
            try
            {
                if (dataRowView != null && !string.IsNullOrEmpty(column) /*&& dataRowView.Row.Table.Columns.Contains(column)*/)
                    return dataRowView[column];
                return null;
            }
            catch (Exception) { return null; }
        }

        public static bool SetValue(object obj, string propertyName, object value)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return false;
#if (!WindowsCE && !PocketPC)
            string[] propertyNames = propertyName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
#endif
#if (WindowsCE || PocketPC)
            string[] propertyNames = StringExtend.Split(propertyName, ".", StringSplitOptions.RemoveEmptyEntries);
#endif
            if (propertyNames == null || propertyNames.Length <= 0) return false;

            object tempResult = obj;
            int count = propertyNames.Length;
            for (int i = 0; i < count - 1; i++)
            {
                string property = propertyNames[i];
                TypeValue tempTypeValue = InnerGetValue(tempResult, property);
                if (tempTypeValue == null || tempTypeValue.Value == null) return false;
                else tempResult = tempTypeValue.Value;
            }
            return InnerSetValue(tempResult, propertyNames[count - 1], value);
        }
        public static TypeValue GetTypeValue(object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return null;
#if (!WindowsCE && !PocketPC)
            string[] propertyNames = propertyName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
#endif
#if (WindowsCE || PocketPC)
            string[] propertyNames = StringExtend.Split(propertyName, ".", StringSplitOptions.RemoveEmptyEntries);
#endif
            if (/*propertyNames == null || */propertyNames.Length <= 0) return null;

            TypeValue tempResult = new TypeValue(obj);
            int count = propertyNames.Length;
            for (int i = 0; i < count; i++)
            {
                string property = propertyNames[i];
                tempResult = InnerGetValue(tempResult.Value, property);
                if (tempResult == null || tempResult.Value == null) return null;
            }
            return tempResult;
        }
        public static object GetValue(object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return null;
#if (!WindowsCE && !PocketPC)
            string[] propertyNames = propertyName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
#endif
#if (WindowsCE || PocketPC)
            string[] propertyNames = StringExtend.Split(propertyName, ".", StringSplitOptions.RemoveEmptyEntries);
#endif
            if (/*propertyNames == null || */propertyNames.Length <= 0) return null;

            TypeValue tempResult = new TypeValue(obj);
            int count = propertyNames.Length;
            for (int i = 0; i < count; i++)
            {
                string property = propertyNames[i];
                tempResult = InnerGetValue(tempResult.Value, property);
                if (tempResult == null || tempResult.Value == null) return null;
            }
            return tempResult.Value;
        }
        public static T GetValue<T>(object obj, string propertyName)
        {
            TypeValue result = GetTypeValue(obj, propertyName);
            if (result == null || result.Value == null) return default(T);
            if (result.Value is T) return (T)result.Value;
            try
            {
                object value = ChangeType(result.Value, typeof(T));
                return value is T ? (T)value : default(T);
            }
            catch (Exception) { return default(T); }
        }
        private static bool InnerSetValue(object obj, string propertyName, object value)
        {
            if (obj == null) return false;

            IDictionary<string, object> hash = obj as IDictionary<string, object>;
            if (hash != null) return SetHashValue(hash, propertyName, value);

            DataRow dataRow = obj as DataRow;
            if (dataRow != null) return SetDataRow(dataRow, propertyName, value);

            DataRowView dataRowView = obj as DataRowView;
            if (dataRowView != null) return SetDataRowView(dataRowView, propertyName, value);

            Type type = obj.GetType();
            PropertyInfo property = GetPropertyInfo(type, propertyName); //type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            if (property != null)
            {
                try
                {
                    ReflectHelper.SetValue(obj, property, value);
                    return true;
                }
                catch (Exception) { }
            }
            else
            {
                FieldInfo field = GetFieldInfo(type, propertyName); //type.GetField(propertyName, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                if (field == null) return false;
                try
                {
                    ReflectHelper.SetValue(obj, field, value);
                    return true;
                }
                catch (Exception) { }
            }
            return false;
        }
        private static TypeValue InnerGetValue(object obj, string propertyName)
        {
            if (obj == null) return null;

            IDictionary<string, object> hash = obj as IDictionary<string, object>;
            if (hash != null)
            {
                object value = GetHashValue(hash, propertyName);
                return new TypeValue(value, (value == null ? typeof(object) : value.GetType()));
            }

            DataRow dataRow = obj as DataRow;
            if (dataRow != null)
            {
                object value = GetDataRow(dataRow, propertyName);
                return new TypeValue(value, (value == null ? typeof(object) : value.GetType()));
            }

            DataRowView dataRowView = obj as DataRowView;
            if (dataRowView != null)
            {
                object value = GetDataRowView(dataRowView, propertyName);
                return new TypeValue(value, (value == null ? typeof(object) : value.GetType()));
            }

            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            if (property != null)
            {
                try
                {
                    object value = ReflectHelper.GetValue(obj, property);
                    return new TypeValue(value, property.PropertyType);
                }
                catch (Exception) { }
            }
            else
            {
                FieldInfo field = type.GetField(propertyName, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                if (field == null) return null;
                try
                {
                    object value = ReflectHelper.GetValue(obj, field);
                    return new TypeValue(value, field.FieldType);
                }
                catch (Exception) { }
            }
            return null;
        }

        public static object ChangeType(object obj, Type type)
        {
            return ReflectHelper.ChangeType(obj, type);
        }
        public static object DefaultForType(Type type)
        {
            if (type == null) return null;
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }


        public static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            return ReflectHelper.GetPropertyInfo(type, propertyName);
        }
        public static List<PropertyInfo> GetPropertyInfos(Type type)
        {
            return ReflectHelper.GetPropertyInfos(type);
        }
        public static FieldInfo GetFieldInfo(Type type, string fieldName)
        {
            return ReflectHelper.GetFieldInfo(type, fieldName);
        }
        public static List<FieldInfo> GetFieldInfos(Type type)
        {
            return ReflectHelper.GetFieldInfos(type);
        }

        #endregion


        #region  对 象 浅 克 隆

        public static T CloneObject<T>(T source) where T : new()
        {
            Type type = source.GetType();
            PropertyInfo[] propertyArray = type.GetProperties();
            T target = new T();
            foreach (PropertyInfo property in propertyArray)
            {
                if (property.CanWrite && property.CanRead)
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(target, value, null);
                }
            }
            return target;
        }


        #endregion







        /// <summary>
        /// 延迟指定的 毫秒, 调用GC 回收内存
        /// </summary>
        public static void CallGC(int delayMillSecond)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    if (delayMillSecond > 0) Thread.Sleep(Math.Min(delayMillSecond, 100));
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                catch { }
            });
            thread.Start();
        }
        /// <summary>
        /// 获取 一个类型的 可识别名称
        /// </summary>
        public static string GetKonwTypeName(Type type)
        {
            if (type == null) return string.Empty;

            Type[] genTypes = type.GetGenericArguments();
            string[] listTypeName = new string[genTypes.Length];
            for (int i = 0, count = genTypes.Length; i < count; i++) 
                listTypeName[i] = GetKonwTypeName(genTypes[i]);

            return genTypes.Length > 0 ? string.Format("{0}<{1}>", type.Name, string.Join(",", listTypeName)) : type.Name;
        }


        private static string appDirectory = string.Empty;
        /// <summary>
        /// 当前程序工作基本目录
        /// </summary>
        public static string AppDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(appDirectory))
                {
#if (!WindowsCE && !PocketPC)
                    appDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif
#if (WindowsCE || PocketPC)
                    appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
#endif
                }
                return appDirectory;
            }
        }

        /// <summary>
        /// 表示 当前程序 正在进行 VS调试
        /// </summary>
        public static bool IsVSHostDebug
        {
            get
            {
                Process processes = Process.GetCurrentProcess();
                string processName = processes.ProcessName;
                return processName.EndsWith(".vshost", StringComparison.CurrentCultureIgnoreCase)
                    || processName.EndsWith(".vshost.exe", StringComparison.CurrentCultureIgnoreCase);
            }
        }



    }

    [Serializable]
    public enum LogType
    {
        /// <summary>
        /// 一般信息
        /// </summary>
        Info,
        /// <summary>
        /// 调试信息
        /// </summary>
        Debug,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命错误
        /// </summary>
        FatalError
    }


    public class CaptionValue<T>
    {
        // Fields
        [CompilerGenerated]
        private string caption;
        [CompilerGenerated]
        private T value;

        // Methods
        public CaptionValue()
        {
        }

        public CaptionValue(string sCaption, T objValue)
        {
            Caption = sCaption;
            Value = objValue;
        }

        public override string ToString()
        {
            return Caption ?? string.Empty;
        }

        // Properties
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }

    [Serializable]
    public class TypeValue
    {
        public Type Type { get; set; }
        public object Value { get; set; }

        public TypeValue() { }
        public TypeValue(object value)
        {
            Value = value;
            Type = value == null ? null : value.GetType();
        }
        public TypeValue(object value, Type type)
        {
            Value = value;
            Type = type;
        }

    }


}
