using System;

namespace InkFx.Express.Utils
{
    internal partial class Tools
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

        /// <summary>
        /// 获取 一个类型的 可识别名称 (本名称 只能用来 显示, 不能再反向 得到 Type)
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

        #endregion

    }
}
