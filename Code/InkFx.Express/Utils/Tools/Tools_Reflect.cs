using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace InkFx.Express.Utils
{
    internal partial class Tools
    {
        #region  数 据 类 型 和 动 态 赋 值 取 值

        public static bool SetHashValue(IDictionary hash, string key, object value)
        {
            try
            {
                if (hash != null && !string.IsNullOrEmpty(key))
                {
                    if (hash.Contains(key)) hash[key] = value;
                    else hash.Add(key, value);
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        public static object GetHashValue(IDictionary hash, string key)
        {
            try
            {
                if (hash != null && !string.IsNullOrEmpty(key) && hash.Contains(key))
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


        /// <summary>
        /// 通过 索引器 从 对象中取值
        /// </summary>
        public static object GetIndexValue(object obj, object index)
        {
            #region  从 索引器 中取值

            try
            {
                Type type = obj.GetType();

                //尝试使用 int 索引器
                int intIndexValue = Tools.ToInt(index, int.MinValue);
                MethodInfo intIndexMethod = type.GetMethod("get_Item", new[] { typeof(int) });
                if (intIndexMethod != null) return intIndexMethod.Invoke(obj, new object[] { intIndexValue });

                //尝试使用 string 索引器
                string strndexValue = Tools.ToString(index, string.Empty);
                MethodInfo strIndexMethod = type.GetMethod("get_Item", new[] { typeof(string) });
                if (strIndexMethod != null) return strIndexMethod.Invoke(obj, new object[] { strndexValue });

                //尝试使用 对象 索引器
                MethodInfo objIndexMethod = type.GetMethod("get_Item");
                if (objIndexMethod != null)
                {
                    ParameterInfo[] parameters = objIndexMethod.GetParameters();
                    if (parameters.Length == 1)
                    {
                        Type paramType = parameters[0].ParameterType;
                        object objIndexValue = Tools.ChangeType(index, paramType);
                        return objIndexMethod.Invoke(obj, new object[] { objIndexValue });
                    }
                }
            }
            catch (Exception) { }

            #endregion

            return null;
        }
        /// <summary>
        /// 通过 索引器 往 对象中赋值
        /// </summary>
        public static bool SetIndexValue(object obj, object index, object value)
        {
            #region  从 索引器 中赋值

            try
            {
                Type type = obj.GetType();

                //尝试使用 int 索引器
                int intIndexValue = Tools.ToInt(index, int.MinValue);
                MethodInfo intIndexMethod = type.GetMethod("set_Item", new[] { typeof(int) });
                if (intIndexMethod != null)
                {
                    intIndexMethod.Invoke(obj, new object[] { intIndexValue, value });
                    return true;
                }

                //尝试使用 string 索引器
                string strndexValue = Tools.ToString(index, string.Empty);
                MethodInfo strIndexMethod = type.GetMethod("set_Item", new[] { typeof(string) });
                if (strIndexMethod != null)
                {
                    strIndexMethod.Invoke(obj, new object[] { strndexValue, value });
                    return true;
                }

                //尝试使用 对象 索引器
                MethodInfo objIndexMethod = type.GetMethod("set_Item");
                if (objIndexMethod != null)
                {
                    ParameterInfo[] parameters = objIndexMethod.GetParameters();
                    if (parameters.Length == 1)
                    {
                        Type paramType = parameters[0].ParameterType;
                        object objIndexValue = Tools.ChangeType(index, paramType);
                        objIndexMethod.Invoke(obj, new object[] { objIndexValue, value });
                        return true;
                    }
                }
            }
            catch (Exception) { }

            #endregion

            return false;
        }

        public static bool SetValue(object obj, string propertyName, object value)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return false;
            if (!propertyName.Contains(".")) return InnerSetValue(obj, propertyName, value);

#if (!WindowsCE && !PocketPC)
            string[] array = propertyName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
#endif
#if (WindowsCE || PocketPC)
            string[] array = Tools.Split(propertyName, ".", StringSplitOptions.RemoveEmptyEntries);
#endif
            if (/*array == null || */array.Length <= 0) return false;

            object tempValue = obj;
            int count = array.Length;
            for (int i = 0; i < count - 1; i++)
            {
                string property = array[i];
                object innerValue = InnerGetValue(tempValue, property);
                if (innerValue == null) return false;
                else tempValue = innerValue;
            }
            return InnerSetValue(tempValue, array[count - 1], value);
        }
        public static object GetValue(object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return null;
            if (!propertyName.Contains(".")) return InnerGetValue(obj, propertyName);

#if (!WindowsCE && !PocketPC)
            string[] array = propertyName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
#endif
#if (WindowsCE || PocketPC)
            string[] array = Tools.Split(propertyName, ".", StringSplitOptions.RemoveEmptyEntries);
#endif
            if (/*array == null || */array.Length <= 0) return null;

            object tempValue = obj;
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                string property = array[i];
                tempValue = InnerGetValue(tempValue, property);
                if (tempValue == null) return null;
            }
            return tempValue;
        }
        public static T GetValue<T>(object obj, string propertyName)
        {
            object result = GetValue(obj, propertyName);
            if (result == null) return default(T);
            if (result is T) return (T)result;
            try
            {
                object value = ChangeType(result, typeof(T));
                return value is T ? (T)value : default(T);
            }
            catch (Exception) { return default(T); }
        }
        private static bool InnerSetValue(object obj, string propertyName, object value)
        {
            if (obj == null) return false;

            IDictionary hash = obj as IDictionary;
            if (hash != null)
            {
                bool result = SetHashValue(hash, propertyName, value);
                return result;
            }

            DataRow dataRow = obj as DataRow;
            if (dataRow != null)
            {
                bool result = SetDataRow(dataRow, propertyName, value);
                return result;
            }

            DataRowView dataRowView = obj as DataRowView;
            if (dataRowView != null)
            {
                bool result = SetDataRowView(dataRowView, propertyName, value);
                return result;
            }

            bool propertyOrFieldResult = ReflectHelper.SetValue(obj, propertyName, value);
            if (propertyOrFieldResult) return true;

            return false;
        }
        private static object InnerGetValue(object obj, string propertyName)
        {
            if (obj == null) return null;

            IDictionary hash = obj as IDictionary; 
            if (hash != null)
            {
                object value = GetHashValue(hash, propertyName);
                return value;
            }

            DataRow dataRow = obj as DataRow;
            if (dataRow != null)
            {
                object value = GetDataRow(dataRow, propertyName);
                return value;
            }

            DataRowView dataRowView = obj as DataRowView;
            if (dataRowView != null)
            {
                object value = GetDataRowView(dataRowView, propertyName);
                return value;
            }

            object propertyOrFieldValue = ReflectHelper.GetValue(obj, propertyName);
            if (propertyOrFieldValue != null) return propertyOrFieldValue;

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
            FieldInfo[] fieldArray = type.GetFields();
            T target = new T();
            foreach (PropertyInfo property in propertyArray)
            {
                object value = ReflectHelper.GetValue(source, property);
                ReflectHelper.SetValue(target, property, value);
            }
            foreach (FieldInfo field in fieldArray)
            {
                object value = ReflectHelper.GetValue(source, field);
                ReflectHelper.SetValue(target, field, value);
            }
            return target;
        }


        #endregion

    }

    //[Serializable]
    //public class TypeValue
    //{
    //    public Type Type { get; set; }
    //    public object Value { get; set; }

    //    public object() { }
    //    public object(object value)
    //    {
    //        Value = value;
    //        Type = value == null ? null : value.GetType();
    //    }
    //    public object(object value, Type type)
    //    {
    //        Value = value;
    //        Type = type;
    //    }

    //}
}
