using System;
using System.Configuration;
using System.IO;

namespace InkFx.Express.Utils
{
    internal partial class Tools
    {
        #region  记 录 日 志

        private static int logDiskEnable = -1;
        private static int logConsoleEnable = -1;
        private static readonly object logLocker = new object();
        private static bool LogDiskEnable
        {
            get
            {
                if (logDiskEnable < 0)
                    logDiskEnable = Tools.ToBoolean(ConfigurationManager.AppSettings["Tools_LogDiskEnable"], false) ? 1 : 0;
                return logDiskEnable == 1;
            }
        }
        private static bool LogConsoleEnable
        {
            get
            {
                if (logConsoleEnable < 0)
                    logConsoleEnable = Tools.ToBoolean(ConfigurationManager.AppSettings["Tools_LogConsoleEnable"], false) ? 1 : 0;
                return logConsoleEnable == 1;
            }
        }


        public static void LogDebug(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Debug);
        }
        public static void LogWarn(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Warn);
        }
        public static void LogError(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Error);
        }
        public static void LogInfo(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.Info);
        }
        public static void LogFatalError(string logMsg, string dirName)
        {
            WriteLog(logMsg, dirName, LogType.FatalError);
        }

        private static void WriteLog(string logMsg, string dirName, LogType logType)
        {
            bool diskLog = LogDiskEnable;
            bool consoleLog = LogConsoleEnable;
            if (!diskLog && !consoleLog) return;

            lock (logLocker)
            {
                try
                {
                    #region  磁盘日志输出

                    if (diskLog)
                    {
                        string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                        if (string.IsNullOrEmpty(dirName)) dirName = "Logs";

                        string folderPath = FileHelper.FormatFullPath(dirName); //如果不是全路径 则 补全
                        FileHelper.CreateFolder(folderPath);

                        #region  将日志文本 转为 标准格式

                        bool isMultiLog = logMsg.Contains("\r") || logMsg.Contains("\n");  //是否是 多行日志
                        logMsg = !isMultiLog
                            ? string.Format("{0} \t{1} \t{2:yyyy-MM-dd HH:mm:ss:fff}\r\n", logType, logMsg, DateTime.Now)
                            : string.Format("\r\n{0} \r\n{1} \r\n{2:yyyy-MM-dd HH:mm:ss:fff} \r\n", logType, logMsg, DateTime.Now);

                        #endregion

                        string logPath = string.Format(@"{0}\{1}", folderPath.TrimEnd('\\', '/'), fileName);
                        File.AppendAllText(logPath, logMsg);
                    }

                    #endregion

                    #region  控制台输出

                    if (consoleLog)
                    {
                        ConsoleColor oldColor = Console.ForegroundColor;
                        try
                        {
                            if (logType == LogType.Info) Console.ForegroundColor = ConsoleColor.White;
                            else if (logType == LogType.Debug) Console.ForegroundColor = ConsoleColor.Green;
                            else if (logType == LogType.Warn) Console.ForegroundColor = ConsoleColor.DarkYellow;
                            else if (logType == LogType.Error) Console.ForegroundColor = ConsoleColor.Red;
                            else if (logType == LogType.FatalError) Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(logMsg);
                        }
                        finally { Console.ForegroundColor = oldColor; }
                    }

                    #endregion
                }
                catch (Exception) { }
            }
        }

        #endregion


        [Serializable]
        private enum LogType
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
    }



}
