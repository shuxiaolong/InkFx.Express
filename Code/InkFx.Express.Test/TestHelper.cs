using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace InkFx.Express.Test
{
    public class TestHelper
    {
        public static int RUN_COUNT = 10000;

        public static void ShowException(string @event, Exception exp)
        {
            string msg = string.Format("执行 {0} 发生异常\r\n异常信息:{1}", @event, exp.Message);
            WriteLine(msg, ConsoleType.Error);
        }
        public static void AssertPerformance(TimeSpan time, int count, int expect)
        {
            double avg = Math.Round((count/time.TotalMilliseconds)*1000, 2);

            string msg = string.Empty;
            ConsoleType type = ConsoleType.Info;

            if (avg >= expect)
            {
                type = ConsoleType.Succeed;
                msg = string.Format("平均 {0} /s, 性能满足 预期 {1} /s", avg, expect);
            }
            else
            {
                type = ConsoleType.Warn;
                msg = string.Format("平均 {0} /s, 性能低于 预期 {1} /s", avg, expect);
            }

            WriteLine(msg, type);
        }
        public static void AssertResult(TimeSpan time, bool result)
        {
            string msg = string.Empty;
            ConsoleType type = ConsoleType.Info;
            if (result)
            {
                type = ConsoleType.Succeed;
                msg = string.Format("耗时 {0} 毫秒, 最终执行成功", time.TotalMilliseconds);
            }
            else
            {
                type = ConsoleType.Error;
                msg = string.Format("耗时 {0} 毫秒, 最终执行失败", time.TotalMilliseconds);
            }

            WriteLine(msg, type);
        }


        private static readonly object m_ConsoleWriteLocker = new object();
        public static void WriteLine()
        {
            WriteLine(string.Empty, ConsoleType.Info);
        }
        public static void WriteLine(object obj, params object[] @params)
        {
            string msg = string.Format(obj.ToString(), @params);
            WriteLine(msg, ConsoleType.Info);
        }
        public static void WriteLine(string msg, ConsoleType type)
        {
            if (string.IsNullOrEmpty(msg)) msg = " ";

            lock (m_ConsoleWriteLocker)
            {
                ConsoleColor bakColor = Console.ForegroundColor;
                ConsoleColor color = ConsoleColor.White;
                if (type == ConsoleType.Title) color = ConsoleColor.Magenta;
                else if (type == ConsoleType.Info) color = ConsoleColor.White;
                else if (type == ConsoleType.Succeed) color = ConsoleColor.Green;
                else if (type == ConsoleType.Debug) color = ConsoleColor.Gray;
                else if (type == ConsoleType.Warn) color = ConsoleColor.DarkYellow;
                else if (type == ConsoleType.Error) color = ConsoleColor.Red;

                Console.ForegroundColor = color;
                Console.WriteLine(msg);
                Console.ForegroundColor = bakColor;

                string folderPath = string.Format(@"{0}\Console\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'));
                string logPath = string.Format(@"{0}\Console_{1:yyyyMMdd}.log", folderPath.TrimEnd('\\', '/'), DateTime.Now);
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                string logMsg = string.Format("{0} \t{1:yyyy-MM-dd HH:mm:ss ffffff} \t\r\n{2}\r\n", type.ToString(), DateTime.Now, msg);
                File.AppendAllText(logPath, logMsg);
            }

        }



        /// <summary>
        /// 运行项目中的 所有标注了 [Test] 的测试函数
        /// </summary>
        public static void RunAllTest()
        {
            Dictionary<MethodInfo, TestAttribute> hashTestMethod = GetMethodAttributes<TestAttribute>();
            List<IGrouping<Type, MethodInfo>> groupTest = hashTestMethod.Keys.GroupBy(x => x.DeclaringType).ToList();

            foreach (IGrouping<Type, MethodInfo> test in groupTest)
            {
                TestHelper.WriteLine(Program.SplitLine);

                List<MethodInfo> listMethod = test.ToList();
                for (int i = 0; i < listMethod.Count; i++)
                {
                    MethodInfo method = listMethod[i];
                    if (method.DeclaringType != null)
                    {
                        try
                        {
                            object instance = method.IsStatic ? null : Activator.CreateInstance(method.DeclaringType);
                            method.Invoke(instance, null);
                        }
                        catch (Exception exp)
                        {
                            string msg = string.Format("执行 {0}.{1} 时发生错误: {2}", method.DeclaringType.Name, method.Name, exp.Message);
                            TestHelper.WriteLine(msg, ConsoleType.Error);
                        }

                        if (i < listMethod.Count - 1) TestHelper.WriteLine(Program.SplitLine2);
                    }
                }
            }
            
        }









        private static DataSet GetTableRecord()
        {
            DataSet ds = new DataSet("Test");
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=MyWord;User Id=sa; Pwd=123.com;"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [Get]; SELECT COUNT(*) FROM [Get] ", conn))
                {
                    adapter.Fill(ds);
                }
            }
            return ds;
        }







        #region  反 射 程 序 集

        private static readonly object listAssemblyLocker = new object();
        private static readonly List<Assembly> listAssembly = new List<Assembly>();

        #region  当 前 所 有 程 序 集

        /// <summary>
        /// 获取程序加载的 程序集（需要提前调用 Load 函数加载）
        /// </summary>
        private static Assembly[] GetCurrentAssemblies()
        {
            List<Assembly> list = new List<Assembly>();
            if (listAssembly != null && listAssembly.Count >= 1)
                lock (listAssemblyLocker)
                {
                    foreach (Assembly assembly in listAssembly)
                    {
                        try
                        {
                            if (!list.Contains(assembly))
                                list.Add(assembly);
                        }
                        catch (Exception) { }
                    }
                }

#if (!WindowsCE && !PocketPC)
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblyArray)
                if (!list.Contains(assembly))
                    list.Add(assembly);

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] dllFiles = Directory.GetFiles(appDirectory, "*.dll");
            string[] exeFiles = Directory.GetFiles(appDirectory, "*.exe");
            List<string> listExeOrDllFile = new List<string>();
            listExeOrDllFile.AddRange(dllFiles);
            listExeOrDllFile.AddRange(exeFiles);

            lock (listAssemblyLocker)
            {
                foreach (string exeOrDllFile in listExeOrDllFile)
                {
                    try
                    {
                        Assembly assembly = Load(Path.GetFileNameWithoutExtension(exeOrDllFile));
                        if (!list.Contains(assembly))
                            list.Add(assembly);
                    }
                    catch (Exception) { }
                }
            }
#endif

            return list.ToArray();
        }

        /// <summary>
        /// 往当前程序中添加程序集
        /// </summary>
        private static Assembly Load(string typeName)
        {
            Assembly assembly = Assembly.Load(typeName);
            if (assembly != null && !listAssembly.Contains(assembly))
                listAssembly.Add(assembly);

            return assembly;
        }

        #endregion


        #region  特 性 高 级 用 法

        /// <summary>
        /// 查找指定程序集，获取 所有指定的 函数特性 T 的 函数信息；
        /// </summary>
        private static Dictionary<MethodInfo, T> GetMethodAttributes<T>() where T : Attribute
        {
            Assembly[] allAssemblys = GetCurrentAssemblies();
            return GetMethodAttributes<T>(allAssemblys);
        }
        /// <summary>
        /// 查找指定程序集，获取 所有指定的 函数特性 T 的 函数信息；
        /// </summary>
        private static Dictionary<MethodInfo, T> GetMethodAttributes<T>(IEnumerable<Assembly> allAssemblys) where T : Attribute
        {
            Dictionary<MethodInfo, T> list = new Dictionary<MethodInfo, T>();

            if (allAssemblys != null)
                foreach (Assembly assembly in allAssemblys)
                {
                    try
                    {
                        Type[] types = assembly.GetTypes();
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




        #endregion

    }

    public enum ConsoleType
    {
        Title,
        Info,
        Succeed,
        Debug,
        Warn,
        Error,
    }


}
