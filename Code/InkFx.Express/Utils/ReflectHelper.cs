using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Security;

namespace InkFx.Express.Utils
{
    /// <summary>
    /// 通过反射, 对 对象进行 动态赋值、取值、数据类型转换 等。
    /// [[本静态类 有两个 默认AppSetting参数: ReflectHelper_GetValueType='Emit|Reflect' ReflectHelper_SetValueType='Emit|Reflect' 默认都是 Reflect ]]
    /// 感谢作者 舒小龙(http://www.ink1989.com) 为下面 1000 行 高性能代码, 作出的贡献.
    /// </summary>
    internal static class ReflectHelper
    {


        #region  反 射 程 序 集

        private static readonly object listAssemblyLocker = new object();
        private static readonly List<Assembly> listAssembly = new List<Assembly>();

        #region  当 前 所 有 程 序 集

        /// <summary>
        /// 获取 程序加载的、或 运行目录的、或 手动调用 Load 函数加载 程序集
        /// </summary>
        public static Assembly[] GetCurrentAssemblies()
        {
            List<Assembly> list = new List<Assembly>();

            if (listAssembly != null && listAssembly.Count >= 1)
                lock (listAssemblyLocker)
                {
                    foreach (Assembly assembly in listAssembly)
                    {
                        try
                        {
                            if (list.Contains(assembly)) list.Remove(assembly);
                            list.Add(assembly);
                        }
                        catch (Exception) { }
                    }
                }

#if (!WindowsCE && !PocketPC)
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblyArray)
            {
                if (list.Contains(assembly)) list.Remove(assembly);
                list.Add(assembly);
            }
#endif


            List<string> listExeOrDllFile = new List<string>();

            string appDirectory = Tools.AppFolder;
            string appBinDirectory = string.Format(@"{0}\Bin\", appDirectory.TrimEnd('\\', '/'));
            string[] dllFiles = Directory.GetFiles(appDirectory, "*.dll");
            string[] exeFiles = Directory.GetFiles(appDirectory, "*.exe");
            listExeOrDllFile.AddRange(dllFiles);
            listExeOrDllFile.AddRange(exeFiles);

            if (Directory.Exists(appBinDirectory))
            {
                string[] binDllFiles = Directory.GetFiles(appBinDirectory, "*.dll");
                string[] binExeFiles = Directory.GetFiles(appBinDirectory, "*.exe");
                listExeOrDllFile.AddRange(binDllFiles);
                listExeOrDllFile.AddRange(binExeFiles);
            }
            
            lock (listAssemblyLocker)
            {
                foreach (string exeOrDllFile in listExeOrDllFile)
                {
                    try
                    {
                        Assembly assembly = ReflectHelper.Load(Path.GetFileNameWithoutExtension(exeOrDllFile));
                        if (list.Contains(assembly)) list.Remove(assembly);
                        list.Add(assembly);
                    }
                    catch (Exception) { }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 往当前程序中添加程序集
        /// </summary>
        public static Assembly Load(string typeName)
        {
            Assembly assembly = Assembly.Load(typeName);
            if (assembly == null) return null;

            if(listAssembly.Contains(assembly)) listAssembly.Remove(assembly);
            listAssembly.Add(assembly);
            return assembly;
        }

        #endregion


        #region  特 性 高 级 用 法

        /// <summary>
        /// 查找所有程序集，获取 所有指定的类特性 T 的 类Type；
        /// </summary>
        public static Dictionary<Type, T> GetAttributes<T>() where T : Attribute
        {
            Assembly[] allAssemblys = GetCurrentAssemblies();
            return GetAttributes<T>(allAssemblys);
        }
        /// <summary>
        /// 查找指定程序集，获取 所有指定的类特性 T 的 类Type；
        /// </summary>
        public static Dictionary<Type, T> GetAttributes<T>(IEnumerable<Assembly> allAssemblys) where T : Attribute
        {
            Dictionary<Type, T> list = new Dictionary<Type, T>();

            if (allAssemblys != null)
                foreach (Assembly assembly in allAssemblys/*listAssembly*/)
                {
                    try
                    {
                        List<Type> types = GetListType(assembly);
                        foreach (Type type in types)
                        {
                            if (type.IsDefined(typeof(T), false))
                            {
                                Attribute attribute = Attribute.GetCustomAttribute(type, typeof(T), false);
                                if (attribute != null)
                                {
                                    T wtattri = (T)attribute;
                                    list.Add(type, wtattri);
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        //if (exp is AssemblyMissException) throw new Exception(exp.Message);
                        //else
                        {
                            string logMsg = string.Format("ReflectHelper.GetAttributes<T>(IEnumerable<Assembly> allAssemblys) 反射程序集 {0} 时发生错误,请确保程序集文件是正确的, ReflectHelper 将跳过该程序集.\r\n异常信息:\r\n{1}", assembly.FullName, exp);
                            Tools.LogWarn(logMsg, "Logs/Tools/WarnLog/");
                            //throw new Exception(logMsg);
                        }
                    }
                }

            return list;
        }


        /// <summary>
        /// 查找指定程序集，获取 所有指定的 函数特性 T 的 函数信息；
        /// </summary>
        public static Dictionary<MethodInfo, T> GetMethodAttributes<T>() where T : Attribute
        {
            Assembly[] allAssemblys = GetCurrentAssemblies();
            return GetMethodAttributes<T>(allAssemblys);
        }
        /// <summary>
        /// 查找指定程序集，获取 所有指定的 函数特性 T 的 函数信息；
        /// </summary>
        public static Dictionary<MethodInfo, T> GetMethodAttributes<T>(IEnumerable<Assembly> allAssemblys) where T : Attribute
        {
            Dictionary<MethodInfo, T> list = new Dictionary<MethodInfo, T>();

            if (allAssemblys != null)
                foreach (Assembly assembly in allAssemblys)
                {
                    try
                    {
                        List<Type> types = GetListType(assembly);
                        foreach (Type type in types)
                        {
                            foreach (MethodInfo method in type.GetMethods())
                            {
                                if (method.IsDefined(typeof(T), false))
                                {
                                    Attribute attribute = Attribute.GetCustomAttribute(method, typeof(T), false);
                                    if (attribute != null)
                                    {
                                        T wtattri = (T)attribute;
                                        list.Add(method, wtattri);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        //if (exp is AssemblyMissException) throw new Exception(exp.Message);
                        //else
                        {
                            string logMsg = string.Format("ReflectHelper.GetMethodAttributes<T>(IEnumerable<Assembly> allAssemblys) 反射程序集 {0} 时发生错误,请确保程序集文件是正确的, ReflectHelper 将跳过该程序集.\r\n异常信息:\r\n{1}", assembly.FullName, exp);
                            Tools.LogWarn(logMsg, "Logs/Tools/WarnLog/");
                        }
                    }
                }

            return list;
        }
        /// <summary>
        /// 查找指定程序集，获取 所有指定的 函数特性 T 的 函数信息；
        /// </summary>
        public static Dictionary<MethodInfo, T> GetMethodAttributes<T>(Type type) where T : Attribute
        {
            Dictionary<MethodInfo, T> list = new Dictionary<MethodInfo, T>();

            if (type != null)
                try
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.IsDefined(typeof(T), false))
                        {
                            Attribute attribute = Attribute.GetCustomAttribute(method, typeof(T), false);
                            if (attribute != null)
                            {
                                T wtattri = (T)attribute;
                                list.Add(method, wtattri);
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    if (exp is AssemblyMissException) throw new Exception(exp.Message);
                    else
                    {
                        string logMsg = string.Format("ReflectHelper.GetMethodAttributes<T>(Type type) 反射类型 {0} 时发生错误.\r\n异常信息:\r\n{1}", type.FullName, exp);
                        Tools.LogWarn(logMsg, "Logs/Tools/WarnLog/");
                    }
                }

            return list;
        }

        #endregion

        public static Type FindBaseType(Type sourceType, Type findType)
        {
            if (sourceType == null) return null;

#if (!WindowsCE && !PocketPC)
            bool baseTypeIsSame = sourceType.GUID == findType.GUID;
#endif
#if (WindowsCE || PocketPC)
            bool baseTypeIsSame = (sourceType.Namespace + "." + sourceType.Name) == (findType.Namespace + "." + findType.Name);
#endif
            if (baseTypeIsSame) return sourceType;

            //基类 继承链
            Type baseType = sourceType.BaseType;
            Type findBaseType = FindBaseType(baseType, findType);
            if (findBaseType != null) return findBaseType;

            //接口 继承链
            Type[] interfaceTypes = sourceType.GetInterfaces();
            if (interfaceTypes.Length > 0)
                foreach (Type interfaceType in interfaceTypes)
                {
                    Type findInterfaceBaseType = FindBaseType(interfaceType, findType);
                    if (findInterfaceBaseType != null) return findInterfaceBaseType;
                }

            return null;
        }

        /// <summary>
        /// 获取指定程序集中的 所有类型, 本函数 比 Assembly.GetTypes() 优势在于: 本函数在失败时 能给出 详细的异常提示.
        /// </summary>
        public static List<Type> GetListType(Assembly assembly)
        {
            if (assembly == null) return null;

            try
            {
                Type[] types = assembly.GetTypes();
                return new List<Type>(types);
            }
            catch(Exception exp)
            {
                List<AssemblyName> listErrorRefAssembly = GetListErrorRefAssembly(assembly);
                AssemblyName[] refMissAssemblies = listErrorRefAssembly == null ? new AssemblyName[0] : listErrorRefAssembly.ToArray();
                throw AssemblyMissException.Create(assembly, refMissAssemblies, exp);
            }
        }

        /// <summary>
        /// 获取指定程序集 引用的 程序集集合
        /// </summary>
        public static List<AssemblyName> GetListRefAssembly(Assembly assembly)
        {
            AssemblyName[] refAssemblies = assembly.GetReferencedAssemblies();
            List<AssemblyName> listResult = new List<AssemblyName>(refAssemblies);
            return listResult;
        }
        /// <summary>
        /// 获取指定程序集 依赖但是无法加载的 程序集集合
        /// </summary>
        public static List<AssemblyName> GetListErrorRefAssembly(Assembly assembly)
        {
            List<AssemblyName> listRefAssembly = GetListRefAssembly(assembly);
            if (listRefAssembly == null) return null;

            Assembly[] listCurrAssembly = GetCurrentAssemblies();
            IgnoreDict<Assembly> hashCurrAssembly = new IgnoreDict<Assembly>();
            foreach (Assembly item in listCurrAssembly)
                hashCurrAssembly[item.FullName] = item;

            List<AssemblyName> listErrorRefAssembly = new List<AssemblyName>();
            foreach (AssemblyName item in listRefAssembly)
            {
                if (!hashCurrAssembly.ContainsKey(item.FullName))
                {
                    bool find = TryFindAssemblyByFullName(item);
                    if (!find) listErrorRefAssembly.Add(item);
                }
            }
            return listErrorRefAssembly;
        }
        /// <summary>
        /// 尝试 从 全局GAC 或 当前程序 运行目录, 判断指定的程序集全名 是否存在.
        /// </summary>
        public static bool TryFindAssemblyByFullName(AssemblyName assemblyName)
        {
            try { Assembly.Load(assemblyName); return true; }
            catch (Exception) { return false; }
        }


        /// <summary>
        /// 通过父类型, 反射出 所有子类型
        /// </summary>
        public static List<Type> GetTypes(Type parentType)
        {
            Assembly[] allAssemblys = GetCurrentAssemblies();
            return GetTypes(allAssemblys, parentType);
        }
        /// <summary>
        /// 通过父类型, 反射出 所有子类型
        /// </summary>
        public static List<Type> GetTypes(IEnumerable<Assembly> allAssemblys, Type parentType)
        {
            List<Type> list = new List<Type>();

            if (allAssemblys != null)
                foreach (Assembly assembly in allAssemblys/*listAssembly*/)
                {
                    try
                    {
                        List<Type> types = GetListType(assembly);
                        foreach (Type type in types)
                        {
                            if (parentType.IsAssignableFrom(type))
                                list.Add(type);
                        }
                    }
                    catch (Exception exp)
                    {
#if (!WindowsCE && !PocketPC)
                        string logMsg = string.Format("ReflectHelper.GetTypes<T>(IEnumerable<Assembly> allAssemblys, Type parentType) 反射程序集 {0} 时发生错误,请确保程序集文件是正确的, ReflectHelper 将跳过该程序集:\r\n{1}", assembly.FullName, exp);
                        Tools.LogWarn(logMsg, "Logs/Tools/WarnLog/");
#endif
                    }
                }

            return list;

        }


        #endregion





        #region  动 态 赋 取 值

        internal const BindingFlags Property_Field_BindingFlags = BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
        
        #region  动 态 赋 值

        private static SetValueTypeEnum currentSetValueTypeEnum = SetValueTypeEnum.None;
        internal static SetValueTypeEnum CurrentSetValueTypeEnum
        {
            get
            {
#if (!WindowsCE && !PocketPC)
                if (currentSetValueTypeEnum == SetValueTypeEnum.None)
                    currentSetValueTypeEnum = string.Equals(ConfigurationManager.AppSettings["ReflectHelper_SetValueType"], "Reflect", StringComparison.CurrentCultureIgnoreCase)
                            ? SetValueTypeEnum.Reflect
                            : SetValueTypeEnum.Emit;

                return currentSetValueTypeEnum;
#endif
#if (WindowsCE || PocketPC)
                return SetValueTypeEnum.Reflect;
#endif
            }
        }

#if (!WindowsCE && !PocketPC)

        #region  Emit 委 托 赋 值

        internal static SetValueDelegate InnerEmitCreateSetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || propertyInfo.PropertyType == null || !propertyInfo.CanWrite) return null;
            MethodInfo setMethod = propertyInfo.GetSetMethod(true);
            if (setMethod == null) return null;

            Type propertyType = propertyInfo.PropertyType;

            DynamicMethod dm = new DynamicMethod("SetPropertyValue", null, new[] { typeof(object), typeof(object) }, propertyInfo.PropertyType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(propertyType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, propertyType);  //拆箱
            generator.Emit(OpCodes.Callvirt, setMethod);
            generator.Emit(OpCodes.Nop);
            generator.Emit(OpCodes.Ret);

            return (SetValueDelegate)dm.CreateDelegate(typeof(SetValueDelegate));
        }
        internal static SetValueDelegate InnerEmitCreateSetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null || fieldInfo.FieldType == null || fieldInfo.IsStatic || fieldInfo.IsInitOnly || fieldInfo.IsLiteral) return null;

            Type fieldType = fieldInfo.FieldType;

            DynamicMethod dm = new DynamicMethod("SetFieldValue", null, new[] { typeof(object), typeof(object) }, fieldInfo.FieldType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(fieldType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, fieldType);  //拆箱
            generator.Emit(OpCodes.Stfld, fieldInfo);
            generator.Emit(OpCodes.Ret);

            return (SetValueDelegate)dm.CreateDelegate(typeof(SetValueDelegate));
        }
        internal static StaticSetValueDelegate InnerEmitCreateStaticSetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || propertyInfo.PropertyType == null || !propertyInfo.CanWrite) return null;
            MethodInfo setMethod = propertyInfo.GetSetMethod(true);
            if (setMethod == null) return null;

            Type propertyType = propertyInfo.PropertyType;

            DynamicMethod dm = new DynamicMethod("StaticSetPropertyValue", null, new [] { typeof(object) }, propertyInfo.PropertyType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(propertyType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, propertyType);  //拆箱
            generator.Emit(OpCodes.Call, setMethod);
            generator.Emit(OpCodes.Nop);
            generator.Emit(OpCodes.Ret);

            return (StaticSetValueDelegate)dm.CreateDelegate(typeof(StaticSetValueDelegate));
        }
        internal static StaticSetValueDelegate InnerEmitCreateStaticSetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null || fieldInfo.FieldType == null || !fieldInfo.IsStatic || fieldInfo.IsInitOnly || fieldInfo.IsLiteral) return null;

            Type fieldType = fieldInfo.FieldType;

            DynamicMethod dm = new DynamicMethod("StaticSetFieldValue", null, new[] { typeof(object) }, fieldInfo.FieldType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(fieldType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, fieldType);  //拆箱
            generator.Emit(OpCodes.Stsfld, fieldInfo);
            generator.Emit(OpCodes.Ret);

            return (StaticSetValueDelegate)dm.CreateDelegate(typeof(StaticSetValueDelegate));
        }

        private static readonly Hashtable setPropertyValueDelegates = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable setFieldValueDelegates = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable setStaticPropertyValueDelegates = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable setStaticFieldValueDelegates = Hashtable.Synchronized(new Hashtable());

        public static SetValueDelegate CreateEmitSetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return null;

            SetValueDelegate setValueDelegate = setPropertyValueDelegates[propertyInfo] as SetValueDelegate;
            if (setValueDelegate == null)
            {
                setValueDelegate = InnerEmitCreateSetValueDelegate(propertyInfo);
                setPropertyValueDelegates[propertyInfo] = setValueDelegate;
            }
            return setValueDelegate;
        }
        public static SetValueDelegate CreateEmitSetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null) return null;

            SetValueDelegate setValueDelegate = setFieldValueDelegates[fieldInfo] as SetValueDelegate;
            if (setValueDelegate == null)
            {
                setValueDelegate = InnerEmitCreateSetValueDelegate(fieldInfo);
                setFieldValueDelegates[fieldInfo] = setValueDelegate;
            }
            return setValueDelegate;
        }
        public static StaticSetValueDelegate CreateEmitStaticSetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return null;

            StaticSetValueDelegate setValueDelegate = setStaticPropertyValueDelegates[propertyInfo] as StaticSetValueDelegate;
            if (setValueDelegate == null)
            {
                setValueDelegate = InnerEmitCreateStaticSetValueDelegate(propertyInfo);
                setStaticPropertyValueDelegates[propertyInfo] = setValueDelegate;
            }
            return setValueDelegate;
        }
        public static StaticSetValueDelegate CreateEmitStaticSetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null) return null;

            StaticSetValueDelegate setValueDelegate = setStaticFieldValueDelegates[fieldInfo] as StaticSetValueDelegate;
            if (setValueDelegate == null)
            {
                setValueDelegate = InnerEmitCreateStaticSetValueDelegate(fieldInfo);
                setStaticFieldValueDelegates[fieldInfo] = setValueDelegate;
            }
            return setValueDelegate;
        }


        public static bool EmitSetValue(object target, string propertyOrFieldName, object value)
        {
            if (target == null || string.IsNullOrEmpty(propertyOrFieldName)) return false;

            Type type = target.GetType();
            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return EmitSetValue(target, propertyInfo, value);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return EmitSetValue(target, fieldInfo, value);
            }

            return false;
        }
        public static bool EmitSetStaticValue(Type type, string propertyOrFieldName, object value)
        {
            if (type == null || string.IsNullOrEmpty(propertyOrFieldName)) return false;

            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return EmitSetStaticValue(propertyInfo, value);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return EmitSetStaticValue(fieldInfo, value);
            }

            return false;
        }
        public static bool EmitSetValue(object target, PropertyInfo propertyInfo, object value)
        {
            if (target == null || propertyInfo == null || !propertyInfo.CanWrite) return false;

            SetValueDelegate setter = CreateEmitSetValueDelegate(propertyInfo);
            if (setter != null)
            {
                object newValue = ChangeType(value, propertyInfo.PropertyType);
                setter(target, newValue);
                return true;
            }

            return false;
        }
        public static bool EmitSetStaticValue(PropertyInfo propertyInfo, object value)
        {
            if (propertyInfo == null || !propertyInfo.CanWrite) return false;

            StaticSetValueDelegate setter = CreateEmitStaticSetValueDelegate(propertyInfo);
            if (setter != null)
            {
                object newValue = ChangeType(value, propertyInfo.PropertyType);
                setter(newValue);
                return true;
            }

            return false;
        }
        public static bool EmitSetValue(object target, FieldInfo fieldInfo, object value)
        {
            if (target == null || fieldInfo == null || fieldInfo.IsInitOnly || fieldInfo.IsLiteral) return false;

            SetValueDelegate setter = CreateEmitSetValueDelegate(fieldInfo);
            if (setter != null)
            {
                object newValue = ChangeType(value, fieldInfo.FieldType);
                setter(target, newValue);
                return true;
            }

            return false;
        }
        public static bool EmitSetStaticValue(FieldInfo fieldInfo, object value)
        {
            if (fieldInfo == null || fieldInfo.IsInitOnly || fieldInfo.IsLiteral) return false;

            StaticSetValueDelegate setter = CreateEmitStaticSetValueDelegate(fieldInfo);
            if (setter != null)
            {
                object newValue = ChangeType(value, fieldInfo.FieldType);
                setter(newValue);
                return true;
            }

            return false;
        }

        #endregion

#endif


        #region  纯 反 射 赋 值

        public static bool ReflectSetValue(object target, string propertyOrFieldName, object value)
        {
            if (target == null || string.IsNullOrEmpty(propertyOrFieldName)) return false;

            Type type = target.GetType();
            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return ReflectSetValue(target, propertyInfo, value);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return ReflectSetValue(target, fieldInfo, value);
            }

            return false;
        }
        public static bool ReflectSetStaticValue(Type type, string propertyOrFieldName, object value)
        {
            if (type == null || string.IsNullOrEmpty(propertyOrFieldName)) return false;

            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return ReflectSetStaticValue(propertyInfo, value);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return ReflectSetStaticValue(fieldInfo, value);
            }

            return false;
        }
        public static bool ReflectSetValue(object target, PropertyInfo propertyInfo, object value)
        {
            if (target == null || propertyInfo == null || !propertyInfo.CanWrite) return false;

            object newValue = ChangeType(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(target, newValue, null);
            return true;
        }
        public static bool ReflectSetStaticValue(PropertyInfo propertyInfo, object value)
        {
            if (propertyInfo == null || !propertyInfo.CanWrite) return false;

            object newValue = ChangeType(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(null, newValue, null);
            return true;
        }
        public static bool ReflectSetValue(object target, FieldInfo fieldInfo, object value)
        {
            if (target == null || fieldInfo == null || fieldInfo.IsInitOnly || fieldInfo.IsLiteral) return false;

            object newValue = ChangeType(value, fieldInfo.FieldType);
            fieldInfo.SetValue(target, newValue);
            return true;
        }
        public static bool ReflectSetStaticValue(FieldInfo fieldInfo, object value)
        {
            if (fieldInfo == null || fieldInfo.IsInitOnly || fieldInfo.IsLiteral) return false;

            object newValue = ChangeType(value, fieldInfo.FieldType);
            fieldInfo.SetValue(null, newValue);
            return true;
        }
        
        #endregion

        /// <summary>
        /// 动态为 某个对象的属性 赋值，本函数不支持 多级赋值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static bool SetValue(object target, string propertyOrFieldName, object value)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentSetValueTypeEnum)
            {
                case SetValueTypeEnum.Emit:
                    return EmitSetValue(target, propertyOrFieldName, value);
                default:
                    return ReflectSetValue(target, propertyOrFieldName, value);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectSetValue(target, propertyOrFieldName, value);
#endif
        }
        /// <summary>
        /// 动态为 某个类的静态属性 赋值，本函数不支持 多级赋值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static bool SetStaticValue(Type type, string propertyOrFieldName, object value)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentSetValueTypeEnum)
            {
                case SetValueTypeEnum.Emit:
                    return EmitSetStaticValue(type, propertyOrFieldName, value);
                default:
                    return ReflectSetStaticValue(type, propertyOrFieldName, value);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectSetStaticValue(type, propertyOrFieldName, value);
#endif
        }
        /// <summary>
        /// 动态为 某个对象的属性 赋值，本函数不支持 多级赋值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static bool SetValue(object target, PropertyInfo propertyInfo, object value)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentSetValueTypeEnum)
            {
                case SetValueTypeEnum.Emit:
                    return EmitSetValue(target, propertyInfo, value);
                default:
                    return ReflectSetValue(target, propertyInfo, value);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectSetValue(target, propertyInfo, value);
#endif
        }
        /// <summary>
        /// 动态为 某个类的静态属性 赋值，本函数不支持 多级赋值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static bool SetStaticValue(Type type, PropertyInfo propertyInfo, object value)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentSetValueTypeEnum)
            {
                case SetValueTypeEnum.Emit:
                    return EmitSetStaticValue(propertyInfo, value);
                default:
                    return ReflectSetStaticValue(propertyInfo, value);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectSetStaticValue(propertyInfo, value);
#endif
        }
        /// <summary>
        /// 动态为 某个对象的属性 赋值，本函数不支持 多级赋值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static bool SetValue(object target, FieldInfo fieldInfo, object value)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentSetValueTypeEnum)
            {
                case SetValueTypeEnum.Emit:
                    return EmitSetValue(target, fieldInfo, value);
                default:
                    return ReflectSetValue(target, fieldInfo, value);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectSetValue(target, fieldInfo, value);
#endif
        }
        /// <summary>
        /// 动态为 某个类的静态属性 赋值，本函数不支持 多级赋值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static bool SetStaticValue(FieldInfo fieldInfo, object value)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentSetValueTypeEnum)
            {
                case SetValueTypeEnum.Emit:
                    return EmitSetStaticValue(fieldInfo, value);
                default:
                    return ReflectSetStaticValue(fieldInfo, value);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectSetStaticValue(fieldInfo, value);
#endif
        }

        #endregion

        #region  动 态 取 值

#if (!WindowsCE && !PocketPC)
        private static GetValueTypeEnum currentGetValueTypeEnum = GetValueTypeEnum.None;
#endif
        internal static GetValueTypeEnum CurrentGetValueTypeEnum
        {
            get
            {
#if (!WindowsCE && !PocketPC)
                if (currentGetValueTypeEnum == GetValueTypeEnum.None)
                    currentGetValueTypeEnum = string.Equals(ConfigurationManager.AppSettings["ReflectHelper_GetValueType"], "Reflect", StringComparison.CurrentCultureIgnoreCase)
                            ? GetValueTypeEnum.Reflect
                            : GetValueTypeEnum.Emit;

                return currentGetValueTypeEnum;
#endif
#if (WindowsCE || PocketPC)
                return GetValueTypeEnum.Reflect;
#endif
            }
        }

#if (!WindowsCE && !PocketPC)

        #region  Emit 委 托 取 值

        internal static GetValueDelegate InnerEmitCreateGetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || propertyInfo.PropertyType == null || !propertyInfo.CanRead) return null;
            MethodInfo getMethod = propertyInfo.GetGetMethod(true);
            if (getMethod == null) return null;

            Type propertyType = propertyInfo.PropertyType;

            DynamicMethod dm = new DynamicMethod("GetPropertyValue", typeof(object), new [] { typeof(object) }, propertyInfo.PropertyType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Callvirt, getMethod);
            //if(propertyType.IsValueType) 
                generator.Emit(OpCodes.Box, propertyType);  //装箱
            generator.Emit(OpCodes.Ret);

            return (GetValueDelegate)dm.CreateDelegate(typeof(GetValueDelegate));
        }
        internal static GetValueDelegate InnerEmitCreateGetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null || fieldInfo.FieldType == null || fieldInfo.IsStatic) return null;

            Type fieldType = fieldInfo.FieldType;

            DynamicMethod dm = new DynamicMethod("GetFieldValue", typeof(object), new[] { typeof(object) }, fieldInfo.FieldType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, fieldInfo);
            //if (fieldType.IsValueType) 
                generator.Emit(OpCodes.Box, fieldType);  //装箱
            generator.Emit(OpCodes.Ret);

            return (GetValueDelegate)dm.CreateDelegate(typeof(GetValueDelegate));
        }
        internal static StaticGetValueDelegate InnerEmitCreateStaticGetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || propertyInfo.PropertyType == null || !propertyInfo.CanRead) return null;
            MethodInfo getMethod = propertyInfo.GetGetMethod(true);
            if (getMethod == null) return null;

            Type propertyType = propertyInfo.PropertyType;

            DynamicMethod dm = new DynamicMethod("StaticGetPropertyValue", typeof(object), new Type[] { }, propertyInfo.PropertyType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Call, getMethod);
            //if (propertyType.IsValueType) 
                generator.Emit(OpCodes.Box, propertyType);  //装箱
            generator.Emit(OpCodes.Ret);

            return (StaticGetValueDelegate)dm.CreateDelegate(typeof(StaticGetValueDelegate));
        }
        internal static StaticGetValueDelegate InnerEmitCreateStaticGetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null || fieldInfo.FieldType == null || !fieldInfo.IsStatic) return null;

            Type fieldType = fieldInfo.FieldType;

            DynamicMethod dm = new DynamicMethod("StaticGetFieldValue", typeof(object), new Type[] { }, fieldInfo.FieldType, true);
            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldsfld, fieldInfo);
            //if (fieldType.IsValueType) 
                generator.Emit(OpCodes.Box, fieldType);  //装箱
            generator.Emit(OpCodes.Ret);

            return (StaticGetValueDelegate)dm.CreateDelegate(typeof(StaticGetValueDelegate));
        }

        private static readonly Hashtable getPropertyValueDelegates = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable getFieldValueDelegates = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable getStaticPropertyValueDelegates = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable getStaticFieldValueDelegates = Hashtable.Synchronized(new Hashtable());

        public static GetValueDelegate CreateEmitGetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return null;

            GetValueDelegate getValueDelegate = getPropertyValueDelegates[propertyInfo] as GetValueDelegate;
            if (getValueDelegate == null)
            {
                getValueDelegate = InnerEmitCreateGetValueDelegate(propertyInfo);
                getPropertyValueDelegates[propertyInfo] = getValueDelegate;
            }
            return getValueDelegate;
        }
        public static GetValueDelegate CreateEmitGetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null) return null;

            GetValueDelegate getValueDelegate = getFieldValueDelegates[fieldInfo] as GetValueDelegate;
            if (getValueDelegate == null)
            {
                getValueDelegate = InnerEmitCreateGetValueDelegate(fieldInfo);
                getFieldValueDelegates[fieldInfo] = getValueDelegate;
            }
            return getValueDelegate;
        }
        public static StaticGetValueDelegate CreateEmitStaticGetValueDelegate(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return null;

            StaticGetValueDelegate getValueDelegate = getStaticPropertyValueDelegates[propertyInfo] as StaticGetValueDelegate;
            if (getValueDelegate == null)
            {
                getValueDelegate = InnerEmitCreateStaticGetValueDelegate(propertyInfo);
                getStaticPropertyValueDelegates[propertyInfo] = getValueDelegate;
            }
            return getValueDelegate;
        }
        public static StaticGetValueDelegate CreateEmitStaticGetValueDelegate(FieldInfo fieldInfo)
        {
            if (fieldInfo == null) return null;

            StaticGetValueDelegate getValueDelegate = getStaticFieldValueDelegates[fieldInfo] as StaticGetValueDelegate;
            if (getValueDelegate == null)
            {
                getValueDelegate = InnerEmitCreateStaticGetValueDelegate(fieldInfo);
                getStaticFieldValueDelegates[fieldInfo] = getValueDelegate;
            }
            return getValueDelegate;
        }


        public static object EmitGetValue(object target, string propertyOrFieldName)
        {
            if (target == null || string.IsNullOrEmpty(propertyOrFieldName)) return null;

            Type type = target.GetType();
            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return EmitGetValue(target, propertyInfo);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return EmitGetValue(target, fieldInfo);
            }

            return null;
        }
        public static object EmitGetStaticValue(Type type, string propertyOrFieldName)
        {
            if (type == null || string.IsNullOrEmpty(propertyOrFieldName)) return null;

            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return EmitGetStaticValue(propertyInfo);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null )
                    return EmitGetStaticValue(fieldInfo);
            }

            return null;
        }
        public static object EmitGetValue(object target, PropertyInfo propertyInfo)
        {
            if (target == null || propertyInfo == null || !propertyInfo.CanRead) return null;
            
            GetValueDelegate getter = CreateEmitGetValueDelegate(propertyInfo);
            return getter != null ? getter(target) : null;
        }
        public static object EmitGetStaticValue(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || !propertyInfo.CanRead) return null;

            StaticGetValueDelegate getter = CreateEmitStaticGetValueDelegate(propertyInfo);
            return getter != null ? getter() : null;
        }
        public static object EmitGetValue(object target, FieldInfo fieldInfo)
        {
            if (target == null || fieldInfo == null/* || fieldInfo.IsInitOnly || fieldInfo.IsLiteral*/) return null;

            GetValueDelegate getter = CreateEmitGetValueDelegate(fieldInfo);
            return getter != null ? getter(target) : null;
        }
        public static object EmitGetStaticValue(FieldInfo fieldInfo)
        {
            if (fieldInfo == null/* || fieldInfo.IsInitOnly || fieldInfo.IsLiteral*/) return null;

            StaticGetValueDelegate getter = CreateEmitStaticGetValueDelegate(fieldInfo);
            return getter != null ? getter() : null;
        }

        #endregion

#endif

        #region  纯 反 射 取 值

        public static object ReflectGetValue(object target, string propertyOrFieldName)
        {
            if (target == null || string.IsNullOrEmpty(propertyOrFieldName)) return null;

            Type type = target.GetType();
            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return ReflectGetValue(target, propertyInfo);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return ReflectGetValue(target, fieldInfo);
            }

            return null;
        }
        public static object ReflectGetStaticValue(Type type, string propertyOrFieldName)
        {
            if (type == null || string.IsNullOrEmpty(propertyOrFieldName)) return null;

            PropertyInfo propertyInfo = GetPropertyInfo(type, propertyOrFieldName);
            if (propertyInfo != null)
                return ReflectGetStaticValue(propertyInfo);
            else
            {
                FieldInfo fieldInfo = GetFieldInfo(type, propertyOrFieldName);
                if (fieldInfo != null)
                    return ReflectGetStaticValue(fieldInfo);
            }

            return null;
        }
        public static object ReflectGetValue(object target, PropertyInfo propertyInfo)
        {
            if (target == null || propertyInfo == null || !propertyInfo.CanRead) return null;

            object value = propertyInfo.GetValue(target, null);
            return value;
        }
        public static object ReflectGetStaticValue(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || !propertyInfo.CanRead) return null;

            object value = propertyInfo.GetValue(null, null);
            return value;
        }
        public static object ReflectGetValue(object target, FieldInfo fieldInfo)
        {
            if (target == null || fieldInfo == null/* || fieldInfo.IsInitOnly || fieldInfo.IsLiteral*/) return null;

            object value = fieldInfo.GetValue(target);
            return value;
        }
        public static object ReflectGetStaticValue(FieldInfo fieldInfo)
        {
            if (fieldInfo == null/* || fieldInfo.IsInitOnly || fieldInfo.IsLiteral*/) return null;

            object value = fieldInfo.GetValue(null);
            return value;
        }

        #endregion

        /// <summary>
        /// 动态从 某个对象的属性 取值，本函数不支持 多级取值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_GetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static object GetValue(object target, string propertyOrFieldName)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentGetValueTypeEnum)
            {
                case GetValueTypeEnum.Emit:
                    return EmitGetValue(target, propertyOrFieldName);
                default:
                    return ReflectGetValue(target, propertyOrFieldName);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectGetValue(target, propertyOrFieldName);
#endif
        }
        /// <summary>
        /// 动态从 某个类的静态属性 取值，本函数不支持 多级取值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static object GetStaticValue(Type type, string propertyOrFieldName)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentGetValueTypeEnum)
            {
                case GetValueTypeEnum.Emit:
                    return EmitGetStaticValue(type, propertyOrFieldName);
                default:
                    return ReflectGetStaticValue(type, propertyOrFieldName);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectGetStaticValue(type, propertyOrFieldName);
#endif
        }
        /// <summary>
        /// 动态从 某个对象的属性 取值，本函数不支持 多级取值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_GetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static object GetValue(object target, PropertyInfo propertyInfo)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentGetValueTypeEnum)
            {
                case GetValueTypeEnum.Emit:
                    return EmitGetValue(target, propertyInfo);
                default:
                    return ReflectGetValue(target, propertyInfo);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectGetValue(target, propertyInfo);
#endif
        }
        /// <summary>
        /// 动态从 某个类的静态属性 取值，本函数不支持 多级取值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static object GetStaticValue(PropertyInfo propertyInfo)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentGetValueTypeEnum)
            {
                case GetValueTypeEnum.Emit:
                    return EmitGetStaticValue(propertyInfo);
                default:
                    return ReflectGetStaticValue(propertyInfo);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectGetStaticValue(propertyInfo);
#endif
        }
        /// <summary>
        /// 动态从 某个对象的属性 取值，本函数不支持 多级取值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_GetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static object GetValue(object target, FieldInfo fieldInfo)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentGetValueTypeEnum)
            {
                case GetValueTypeEnum.Emit:
                    return EmitGetValue(target, fieldInfo);
                default:
                    return ReflectGetValue(target, fieldInfo);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectGetValue(target, fieldInfo);
#endif
        }
        /// <summary>
        /// 动态从 某个类的静态属性 取值，本函数不支持 多级取值（注意：如果该函数不稳定，请在 配置文件中 将 appSettings.ReflectHelper_SetValueType 试着赋值为 [默认]Reflect, Emit）
        /// </summary>
        public static object GetStaticValue(FieldInfo fieldInfo)
        {
#if (!WindowsCE && !PocketPC)
            switch (CurrentGetValueTypeEnum)
            {
                case GetValueTypeEnum.Emit:
                    return EmitGetStaticValue(fieldInfo);
                default:
                    return ReflectGetStaticValue(fieldInfo);
            }
#endif
#if (WindowsCE || PocketPC)
            return ReflectGetStaticValue(fieldInfo);
#endif
        }

        #endregion



        #region  数 据 转 换

        #region  基 本 数 据 类 型

        public static bool IsMetaType(Type type)
        {
            if (type.IsEnum) return true;       //枚举视为 基本类型
            return hashMetaTypes.ContainsKey(type);
        }
        public static Type GetTypeBySimpleTypeName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return null;

            switch (typeName.ToLower())
            {
                case "string": case "str": return typeofString;
                case "bool": case "boolean": return typeofBoolean;
                case "byte": return typeofByte;
                case "char": return typeofChar;
                case "decimal": return typeofDecimal;
                case "double": return typeofDouble;
                case "short": case "int16": return typeofInt16;
                case "int": case "int32": return typeofInt32;
                case "long": case "int64": return typeofInt64;
                case "sbyte": return typeofSByte;
                case "float": case "single": return typeofSingle;
                case "timespan": return typeofTimeSpan;
                case "datetime": return typeofDateTime;
                case "ushort": case "uint16": return typeofUInt16;
                case "uint": case "uint32": return typeofUInt32;
                case "ulong": case "uint64": return typeofUInt64;
                case "object": case "obj": return typeofObject;
                case "byte[]": case "bytes": return typeofByteArray;
            }

            return Type.GetType(typeName);
        }

        internal static Assembly urtAssembly = Assembly.Load("mscorlib");//Assembly.GetAssembly(Converter.typeofString);
        internal static Type typeofString = typeof(string);
        internal static Type typeofBoolean = typeof(bool);
        internal static Type typeofByte = typeof(byte);
        internal static Type typeofChar = typeof(char);
        internal static Type typeofDecimal = typeof(decimal);
        internal static Type typeofDouble = typeof(double);
        internal static Type typeofInt16 = typeof(short);
        internal static Type typeofInt32 = typeof(int);
        internal static Type typeofInt64 = typeof(long);
        internal static Type typeofSByte = typeof(sbyte);
        internal static Type typeofSingle = typeof(float);
        internal static Type typeofTimeSpan = typeof(TimeSpan);
        internal static Type typeofDateTime = typeof(DateTime);
        internal static Type typeofUInt16 = typeof(ushort);
        internal static Type typeofUInt32 = typeof(uint);
        internal static Type typeofUInt64 = typeof(ulong);

        internal static Type typeofObject = typeof(object);  //不是基本数据类型
        //internal static Type typeofSystemVoid = typeof(void);
        //internal static Type typeofTypeArray = typeof(Type[]);
        //internal static Type typeofObjectArray = typeof(object[]);
        //internal static Type typeofStringArray = typeof(string[]);
        //internal static Type typeofBooleanArray = typeof(bool[]);
        internal static Type typeofByteArray = typeof(byte[]);
        //internal static Type typeofCharArray = typeof(char[]);
        //internal static Type typeofDecimalArray = typeof(decimal[]);
        //internal static Type typeofDoubleArray = typeof(double[]);
        //internal static Type typeofInt16Array = typeof(short[]);
        //internal static Type typeofInt32Array = typeof(int[]);
        //internal static Type typeofInt64Array = typeof(long[]);
        //internal static Type typeofSByteArray = typeof(sbyte[]);
        //internal static Type typeofSingleArray = typeof(float[]);
        //internal static Type typeofTimeSpanArray = typeof(TimeSpan[]);
        //internal static Type typeofDateTimeArray = typeof(DateTime[]);
        //internal static Type typeofUInt16Array = typeof(ushort[]);
        //internal static Type typeofUInt32Array = typeof(uint[]);
        //internal static Type typeofUInt64Array = typeof(ulong[]);

        internal static Hashtable hashMetaTypes = Hashtable.Synchronized(new Hashtable
                                                   {
                                                       #region  基础数据类型

                                                       { typeofString, 1},
                                                       { typeofBoolean, 1},
                                                       { typeofByte, 1},
                                                       { typeofChar, 1},
                                                       { typeofDecimal, 1},
                                                       { typeofDouble, 1},
                                                       { typeofInt16, 1},
                                                       { typeofInt32, 1},
                                                       { typeofInt64, 1},
                                                       { typeofSByte, 1},
                                                       { typeofSingle, 1},
                                                       { typeofTimeSpan, 1},
                                                       { typeofDateTime, 1},
                                                       { typeofUInt16, 1},
                                                       { typeofUInt32, 1},
                                                       { typeofUInt64, 1},
                                                       //{ typeofObject, 1},
                                                       //{ typeofSystemVoid, 1},
                                                       //{ typeofTypeArray, 1},
                                                       //{ typeofObjectArray, 1},
                                                       //{ typeofStringArray, 1},
                                                       //{ typeofBooleanArray, 1},
                                                       { typeofByteArray, 1},
                                                       //{ typeofCharArray, 1},
                                                       //{ typeofDecimalArray, 1},
                                                       //{ typeofDoubleArray, 1},
                                                       //{ typeofInt16Array, 1},
                                                       //{ typeofInt32Array, 1},
                                                       //{ typeofInt64Array, 1},
                                                       //{ typeofSByteArray, 1},
                                                       //{ typeofSingleArray, 1},
                                                       //{ typeofTimeSpanArray, 1},
                                                       //{ typeofDateTimeArray, 1},
                                                       //{ typeofUInt16Array, 1},
                                                       //{ typeofUInt32Array, 1},
                                                       //{ typeofUInt64Array, 1},
                                                       #endregion
                                                   });

        #endregion

        public static object ChangeType(object obj, Type type)
        {
            if (type == null || obj == null || type == typeofObject) return obj;

            Type objType = obj.GetType();
            if (objType == type || type.IsAssignableFrom(objType)) return obj;

            try
            {
#if (!WindowsCE && !PocketPC)
                object newResult = Convert.ChangeType(obj, type);
                return newResult;
#endif

#if (WindowsCE || PocketPC)

                #region  转换类型
                if (type == typeofBoolean)
                    return Convert.ToBoolean(obj);
                if (type == typeofChar)
                    return Convert.ToChar(obj);
                if (type == typeofSByte)
                    return Convert.ToSByte(obj);
                if (type == typeofByte)
                    return Convert.ToByte(obj);
                if (type == typeofInt16)
                    return Convert.ToInt16(obj);
                if (type == typeofUInt16)
                    return Convert.ToUInt16(obj);
                if (type == typeofInt32)
                    return Convert.ToInt32(obj);
                if (type == typeofUInt32)
                    return Convert.ToUInt32(obj);
                if (type == typeofInt64)
                    return Convert.ToInt64(obj);
                if (type == typeofUInt64)
                    return Convert.ToUInt64(obj);
                if (type == typeofSingle)
                    return Convert.ToSingle(obj);
                if (type == typeofDouble)
                    return Convert.ToDouble(obj);
                if (type == typeofDecimal)
                    return Convert.ToDecimal(obj);
                if (type == typeofDateTime)
                    return Convert.ToDateTime(obj);
                if (type == typeofString)
                    return Convert.ToString(obj);
                if (type == typeofObject)
                    return obj;
                #endregion
                return obj;
#endif
            }
            catch (Exception) { /*return DefaultForType(type); */return obj; }
        }


        #endregion

        #region  获 取 成 员

        public static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            if (type == null || string.IsNullOrEmpty(propertyName)) return null;

            PropertyInfo propertyInfo = type.GetProperty(propertyName, Property_Field_BindingFlags);
            return propertyInfo;
        }
        public static List<PropertyInfo> GetPropertyInfos(Type type)
        {
            if (type == null) return null;
            PropertyInfo[] propertyInfos = type.GetProperties(Property_Field_BindingFlags);
            List<PropertyInfo> listProperty = new List<PropertyInfo>();
            listProperty.AddRange(propertyInfos);
            return listProperty;
        }

        public static FieldInfo GetFieldInfo(Type type, string fieldName)
        {
            if (type == null || string.IsNullOrEmpty(fieldName)) return null;

            FieldInfo fieldInfo = type.GetField(fieldName, Property_Field_BindingFlags);
            return fieldInfo;
        }
        public static List<FieldInfo> GetFieldInfos(Type type)
        {
            if (type == null) return null;
            FieldInfo[] fieldInfos = type.GetFields(Property_Field_BindingFlags);
            List<FieldInfo> listField = new List<FieldInfo>();
            listField.AddRange(fieldInfos);
            return listField;
        }

        #endregion




        [Serializable]
        internal enum SetValueTypeEnum { None, Reflect, Emit }
        [Serializable]
        internal enum GetValueTypeEnum { None, Reflect, Emit }
        public delegate void SetValueDelegate(object target, object value);
        public delegate void StaticSetValueDelegate(object value);
        public delegate object GetValueDelegate(object target);
        public delegate object StaticGetValueDelegate();

        #endregion
    }


    /// <summary>
    /// 表示一个 程序集丢失异常.
    /// </summary>
    [Serializable]
    internal class AssemblyMissException : Exception
    {
        public static AssemblyMissException Create(Assembly assembly, AssemblyName[] refMissAssemblies, Exception innerException)
        {
            string assemblyFullName = assembly == null ? "NULL" : assembly.FullName;
            string innerExpMsg = innerException == null ? "NULL" : innerException.Message;
            List<string> listMissFullName = new List<string>();
            foreach (AssemblyName item in refMissAssemblies)
                listMissFullName.Add(item.FullName);

            string expMsg = string.Format("RefAssembly Is Miss.\r\nAssembly:\r\n    {0}\r\nMissAssemblies:\r\n    {1}\r\nInnerException:\r\n{2}", assemblyFullName, string.Join("\r\n    ", listMissFullName.ToArray()), innerExpMsg);

            AssemblyMissException exp = new AssemblyMissException(expMsg, innerException);
            exp.Assembly = assembly;
            exp.RefMissAssemblies = refMissAssemblies;
            return exp;
        }

        public AssemblyMissException() : base()
        {
        }
        public AssemblyMissException(string message, Exception innerException) : base(message, innerException)
        {
        }


        public Assembly Assembly { get; private set; }
        public AssemblyName[] RefMissAssemblies { get; private set; }
    }
}
