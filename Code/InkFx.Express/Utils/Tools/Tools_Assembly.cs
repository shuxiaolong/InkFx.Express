using System;
using System.Diagnostics;
using System.Threading;

namespace InkFx.Express.Utils
{
    internal partial class Tools
    {
        #region  32&64位 程序集 控制



        #endregion




        private static string m_AppFolder = string.Empty;
        /// <summary>
        /// 当前程序工作基本目录
        /// </summary>
        public static string AppFolder
        {
            get
            {
                if (string.IsNullOrEmpty(m_AppFolder))
                {
#if (!WindowsCE && !PocketPC)
                    m_AppFolder = AppDomain.CurrentDomain.BaseDirectory;
#endif
#if (WindowsCE || PocketPC)
                    m_AppFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
#endif
                }
                return m_AppFolder;
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

    }
}
