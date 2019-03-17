using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace InkFx.Express.Utils
{
    /// <summary>
    /// 操作 磁盘文件的类，包括：  
    /// 文件的 删除，复制
    /// 文件夹的 删除，复制
    /// </summary>
    internal class FileHelper
    {

        #region  路 径 格 式 化

        /// <summary>
        /// 该函数可以将一个 半路径、表达式路径 转换为 标准的 全路径；
        /// 对于不全的路径 默认补全 当前域路径，比如 \AAAA\；
        /// 对于有环境变量的路径 将自动检索 环境变量予以替换，比如 %SystemRoot%\system32；
        /// </summary>
        public static List<string> FormatFullPath(IEnumerable<string> listPath)
        {
            if (listPath == null) return null;
            List<string> listResult = new List<string>();

            foreach (string path in listPath)
            {
                string fullPath = FormatFullPath(path);
                listResult.Add(fullPath);
            }
            return listResult;
        }
        /// <summary>
        /// 该函数可以将一个 半路径、表达式路径 转换为 标准的 全路径；
        /// 对于不全的路径 默认补全 当前域路径，比如 \AAAA\ 会成为 D:\运行目录\AAAA\；
        /// 对于有环境变量的路径 将自动检索 环境变量予以替换，比如 %SystemRoot%\system32  会成为 C:\Windows\system32\；
        /// </summary>
        public static string FormatFullPath(string path)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;

            string formatPath = FormatPath(path);

            //已经是 全路径, 直接返回
            bool isFullPath = formatPath.IndexOf(":") > 0 || formatPath.StartsWith(@"\\"); 
            if (isFullPath) return formatPath;

            //计算 基于当前目录 的 全路径
            string diskFullPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), formatPath);

            //如果 基于当前目录 的 全路径 存在, 则直接 返回
            bool fileExist = File.Exists(diskFullPath);
            if (fileExist) return diskFullPath;

            bool folderExist = Directory.Exists(diskFullPath);
            if (folderExist)
            {
                if (!diskFullPath.EndsWith("\\")) diskFullPath = diskFullPath.TrimEnd('\\', '/') + "\\";  //如果文件夹 不是以 \ 结尾, 则 追加 \ 结尾符
                return diskFullPath;
            }

            //替换 路径中 的 环境变量
            bool matchOSValue = false;
            string OSValuePath = Regex.Replace(formatPath, @"^%[\w\(\)]+%", m =>
            {
                string OSValue = GetEnvironmentVariable(m.Value);
                matchOSValue = !string.IsNullOrEmpty(OSValue);
                return matchOSValue ? OSValue : m.Value;
            }, (RegexOptions.IgnoreCase | RegexOptions.Compiled));

            //已经替换了 系统环境变量, 则返回 系统环境变量替换后的路径
            if (matchOSValue) return OSValuePath;

            //无计可施, 默认返回 基于当前目录 的全路径
            return diskFullPath;
        }
        /// <summary>
        /// 该函数会将一个路劲字符串中的 所有 / 转变成 \ ；且不会增加额外的路径字符串；
        /// </summary>
        public static string FormatPath(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(path.Trim())) return string.Empty;

            //http://www.baidu.com/
            bool isServerPath = path.StartsWith(@"\\");
            bool isWebPath = path.IndexOf(@"://") > 0 || path.IndexOf(@":\\") > 0;
            if (!isWebPath)
            {
                path = path.Replace(@"/", @"\");
                while (path.IndexOf(@"\\") >= 0)
                    path = path.Replace(@"\\", @"\");

                if (isServerPath && path.StartsWith(@"\"))
                    path = @"\" + path;
            }
            else
            {
                path = path.Replace(@"\", @"/");
                while (path.IndexOf(@"//") >= 0)
                    path = path.Replace(@"//", @"/");

                if (path.IndexOf(@"://") < 0)
                    path = path.Replace(@":/", @"://");
            }
            return path;
        }
        /// <summary>
        /// 该函数会将一个Web路径字符串 进行标准格式化；
        /// </summary>
        public static string FormatWebPath(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(path.Trim())) return string.Empty;

            //http://www.baidu.com/
            bool isWebPath = path.IndexOf(@"://") > 0 || path.IndexOf(@":\\") > 0;

            path = path.Replace(@"\", @"/");
            while (path.IndexOf(@"//") >= 0)
                path = path.Replace(@"//", @"/");

            if (isWebPath && path.IndexOf(@"://") < 0)
                path = path.Replace(@":/", @"://");

            return path;
        }
        /// <summary>
        /// 判断某个路径 是否是 全路径 (以 盘符、服务器、协议 等开头)
        /// </summary>
        public static bool IsFullPath(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(path.Trim())) return false;
            return path.IndexOf(":") > 0 || path.StartsWith(@"\\");
        }

        /// <summary>
        /// 获取 文件|文件夹 的 父级文件夹
        /// </summary>
        public static string GetParentFolderPath(string path)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;
            path = FormatFullPath(path);

            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Directory != null) return fileInfo.Directory.FullName;
            }
            else if (Directory.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (dirInfo.Parent != null) return dirInfo.Parent.FullName;
            }

            path = path.TrimEnd('\\', '/');
            int lastSplit1 = path.LastIndexOf('\\');
            int lastSplit2 = path.LastIndexOf('/');
            int lastSplit = Math.Max(lastSplit1, lastSplit2);
            string parentPath = path.Substring(lastSplit + 1);
            return parentPath;
        }

        /// <summary>
        /// 按照优先级 当前进程>当前用户>当前机器 中 寻找 指定名称的环境变量 (名称允许首尾 %)
        /// </summary>
        private static string GetEnvironmentVariable(string valueName)
        {
            valueName = (valueName ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(valueName)) return string.Empty;
            string valueName2 = valueName.Trim().Trim('%').Trim();

            string value21 = Environment.GetEnvironmentVariable(valueName2, EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(value21)) return value21;
            string value22 = Environment.GetEnvironmentVariable(valueName2, EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(value22)) return value22;
            string value23 = Environment.GetEnvironmentVariable(valueName2, EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrEmpty(value23)) return value23;


            string value1 = Environment.GetEnvironmentVariable(valueName, EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(value1)) return value1;
            string value2 = Environment.GetEnvironmentVariable(valueName, EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(value2)) return value2;
            string value3 = Environment.GetEnvironmentVariable(valueName, EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrEmpty(value3)) return value3;

            return string.Empty;
        }



        #endregion

        #region  基 本 操 作

        /// <summary>
        /// 创建文件夹：
        /// 参数可以是 下面三种格式：
        /// D:\aaa\bbb\kk.txt 将会创建 D:\aaa\bbb\ 文件夹；
        /// D:\aaa\bbb\ 将会创建 D:\aaa\bbb\ 文件夹；
        /// D:\aaa\bbb 将会创建 D:\aaa\ 文件夹；
        /// </summary>
        /// <param name="path">文件夹名： D:\aaa\bbb\ 或者 D:\aaa\bbb\kk.txt</param>
        public static bool CreateFolder(string path)
        {
            path = FormatFullPath(path);
            path = path.Replace(@"/", @"\");
            path = path.Substring(0, path.LastIndexOf(@"\", StringComparison.CurrentCultureIgnoreCase));
            try
            {
                if (Directory.Exists(path)) return true;
                Directory.CreateDirectory(path);
                return Directory.Exists(path);
            }
            catch (Exception) { return false; }
        }
        /// <summary>
        /// 删除文件夹——该方法，没有任何异常处理；
        /// 参数可以是 文件路径：
        /// D:\aaa\bbb\kk.txt 将会删除 D:\aaa\bbb\ 文件夹；
        /// D:\aaa\bbb\ 将会删除 D:\aaa\bbb\ 文件夹；
        /// D:\aaa\bbb 如果 D:\aaa\bbb 文件夹存在 则删除；
        /// D:\aaa\bbb 如果 D:\aaa\bbb 文件夹不存在，将会删除 D:\aaa\ 文件夹；
        /// </summary>
        /// <param name="path">文件夹名：D:\aaa\bbb\ 或者 D:\aaa\bbb\kk.txt</param>
        /// <param name="recursive">是否删除该目录 全部子文件</param>
        public static bool DeleteFolder(string path, bool recursive)
        {
            path = FormatFullPath(path);
            path = path.Replace(@"/", @"\");
            path = path.Substring(0, path.LastIndexOf(@"\", StringComparison.CurrentCultureIgnoreCase));
            try
            {
                if (!Directory.Exists(path)) return true;
                Directory.Delete(path, recursive);
                return !Directory.Exists(path);
            }
            catch (Exception) { return false; }
        }
        /// <summary>
        /// 复制文件夹，并且将文件夹下的子文件全部复制；
        /// </summary>
        public static void CopyFolder(string oldPath, string newPath)
        {
            oldPath = FormatFullPath(oldPath);
            newPath = FormatFullPath(newPath);

            DirectoryInfo oldFolder = new DirectoryInfo(oldPath);
            DirectoryInfo newFolder = new DirectoryInfo(newPath);
            CopyFolder(oldFolder, newFolder);
        }
        /// <summary>
        /// 复制文件夹，并且将文件夹下的子文件全部复制；
        /// </summary>
        public static void CopyFolder(DirectoryInfo oldFolder, DirectoryInfo newFolder)
        {
            if (oldFolder == null || newFolder == null) return;

            if (!oldFolder.Exists) oldFolder.Create();
            if (!newFolder.Exists) newFolder.Create();

            FileInfo[] files = oldFolder.GetFiles();
            DirectoryInfo[] folders = oldFolder.GetDirectories();

            foreach (FileInfo file in files)
            {
                try
                {
                    string newFilePath = string.Format(@"{0}\{1}", newFolder.FullName.TrimEnd('\\', '/'), file.Name);
                    CopyFile(file.FullName, newFilePath, true);
                }
                catch (Exception) { }
            }

            foreach (DirectoryInfo folder in folders)
            {
                try
                {
                    string newFolderPath = string.Format(@"{0}\{1}", newFolder.FullName.TrimEnd('\\', '/'), folder.Name);
                    CopyFolder(folder.FullName, newFolderPath);
                }
                catch (Exception) { }
            }
        }
        /// <summary>
        /// 移动文件夹，并且将文件夹下的子文件全部复制；
        /// </summary>
        public static void MoveFolder(string oldPath, string newPath)
        {
            oldPath = FormatFullPath(oldPath);
            newPath = FormatFullPath(newPath);

            try
            {
                if (!Directory.Exists(oldPath)) return;
                Directory.Move(oldPath, newPath);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 修改文件夹 名称
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="newName">文件夹 新名称</param>
        public static bool RenameFolder(string path, string newName)
        {
            path = FormatFullPath(path);
            string parentPath = GetParentFolderPath(path);
            string newPath = string.Format(@"{0}\{1}", parentPath.TrimEnd('\\', '/'), newName);
            try
            {
                MoveFolder(path, newPath);
                return Directory.Exists(newPath);
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// 创建文件：
        /// 创建文件的编码格式为基本文本格式；
        /// </summary>Directory
        /// <param name="path">文件名： D:\aaa\bbb\kk.txt</param>
        /// <param name="overWrite">如果文件存在是否创建 新文件 将旧文件覆盖</param>
        public static void CreateFile(string path, bool overWrite)
        {
            path = FormatFullPath(path);
            if (overWrite || !File.Exists(path))
            {
                CreateFolder(path);
                File.Create(path);
            }
        }
        /// <summary>
        /// 删除文件；
        /// </summary>
        /// <param name="path">即将删除的文件名</param>
        public static bool DeleteFile(string path)
        {
            path = FormatFullPath(path);

            try
            {
                if (!File.Exists(path)) return true;
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.IsReadOnly) fileInfo.IsReadOnly = false;
                fileInfo.Delete();
                return !fileInfo.Exists;
            }
            catch (Exception) { return false; }
        }
        /// <summary>
        /// 复制文件，如果文件不存在，则引发 异常
        /// </summary>
        /// <param name="oldPath">文件地址</param>
        /// <param name="newPath">文件需要复制到的地址</param>
        /// <param name="overWrite">是否允许 改写 新路径下 已经存在的 同名文件</param>
        public static void CopyFile(string oldPath, string newPath, bool overWrite)
        {
            oldPath = FormatFullPath(oldPath);
            newPath = FormatFullPath(newPath);
            if (!File.Exists(oldPath)) return;

            CreateFolder(newPath);
            File.Copy(oldPath, newPath, overWrite);
        }
        /// <summary>
        /// 移动文件，如果文件不存在，则引发 异常；
        /// </summary>
        /// <param name="oldPath">文件地址</param>
        /// <param name="newPath">文件需要移动到的地址</param>
        public static void MoveFile(string oldPath, string newPath)
        {
            oldPath = FormatFullPath(oldPath);
            newPath = FormatFullPath(newPath);

            try
            {
                if (!File.Exists(oldPath)) return;
                File.Move(oldPath, newPath);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 修改文件 名称
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="newName">文件 新名称</param>
        public static bool RenameFile(string path, string newName)
        {
            path = FormatFullPath(path);
            string parentPath = GetParentFolderPath(path);
            string newPath = string.Format(@"{0}\{1}", parentPath.TrimEnd('\\', '/'), newName);
            try
            {
                MoveFile(path, newPath);
                return File.Exists(newPath);
            }
            catch (Exception) { return false; }
        }



        /// <summary>
        /// 判断文件是否存在，可以是 相对路径；
        /// </summary>
        /// <param name="path">文件路径</param>
        public static bool ExistFile(string path)
        {
            path = FormatFullPath(path);
            return File.Exists(path);
        }
        /// <summary>
        /// 判断文件夹是否存在，可以是 相对路径；
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static bool ExistFolder(string path)
        {
            path = FormatFullPath(path);
            return Directory.Exists(path);
        }
        /// <summary>
        /// 判断文件夹是否有子成员（文件或文件夹），如果文件夹本身都不存在则直接返回 false；
        /// </summary>
        public static bool ExistChildren(string path)
        {
            path = FormatFullPath(path);
            if (!Directory.Exists(path)) return false;

            string[] children = Directory.GetFileSystemEntries(path);
            return children.Length > 0;
        }





        #endregion

        #region  文 件 结 构

        /// <summary>
        /// 获取文件夹及其子文件夹下的所有文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        public static List<FileInfo> GetAllFileInfos(string folderPath)
        {
            return GetAllFileInfos(folderPath, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        public static List<FileInfo> GetAllFileInfos(DirectoryInfo folderInfo)
        {
            return GetAllFileInfos(folderInfo, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<FileInfo> GetAllFileInfos(string folderPath, FilterFileInfo filter)
        {
            if (folderPath.IndexOf(":") < 0) folderPath = string.Format(@"{0}\{1}\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), folderPath.TrimEnd('\\', '/'));
            folderPath = folderPath.Replace(@"/", @"\").TrimEnd('\\', '/') + @"\";
            if (!Directory.Exists(folderPath)) return null;

            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
            List<FileInfo> listFileInfo = GetAllFileInfos(folderInfo, filter);
            return listFileInfo;
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<FileInfo> GetAllFileInfos(DirectoryInfo folderInfo, FilterFileInfo filter)
        {
            if (folderInfo == null || !folderInfo.Exists) return null;

            List<FileInfo> listResult = new List<FileInfo>();
            DirectoryInfo[] listChildFolderInfo = folderInfo.GetDirectories();
            FileInfo[] listChildFileInfo = folderInfo.GetFiles();

            foreach (DirectoryInfo childFolderInfo in listChildFolderInfo)
            {
                try
                {
                    List<FileInfo> listGrandChildFileInfo = GetAllFileInfos(childFolderInfo, filter);
                    if (listGrandChildFileInfo != null && listGrandChildFileInfo.Count >= 1)
                        foreach (FileInfo grandChildFileInfo in listGrandChildFileInfo)
                        {
                            try
                            {
                                if (grandChildFileInfo != null && grandChildFileInfo.Exists && (filter == null || filter(grandChildFileInfo)))
                                    listResult.Add(grandChildFileInfo);
                            }
                            catch (Exception) { }
                        }
                }
                catch (Exception) { }
            }

            foreach (FileInfo childFileInfo in listChildFileInfo)
            {
                try
                {
                    if (childFileInfo != null && childFileInfo.Exists && (filter == null || filter(childFileInfo)))
                        listResult.Add(childFileInfo);
                }
                catch (Exception) { }
            }

            return listResult;
        }

        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        public static List<FileSystemInfo> GetAllFolderAndFileInfos(string folderPath)
        {
            return GetAllFolderAndFileInfos(folderPath, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        public static List<FileSystemInfo> GetAllFolderAndFileInfos(DirectoryInfo folderInfo)
        {
            return GetAllFolderAndFileInfos(folderInfo, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<FileSystemInfo> GetAllFolderAndFileInfos(string folderPath, FilterFolderAndFileInfo filter)
        {
            if (folderPath.IndexOf(":") < 0) folderPath = string.Format(@"{0}\{1}\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), folderPath.TrimEnd('\\', '/'));
            folderPath = folderPath.Replace(@"/", @"\").TrimEnd('\\', '/') + @"\";
            if (!Directory.Exists(folderPath)) return null;

            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
            List<FileSystemInfo> listFileInfo = GetAllFolderAndFileInfos(folderInfo, filter);
            return listFileInfo;
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<FileSystemInfo> GetAllFolderAndFileInfos(DirectoryInfo folderInfo, FilterFolderAndFileInfo filter)
        {
            if (folderInfo == null || !folderInfo.Exists) return null;

            List<FileSystemInfo> listResult = new List<FileSystemInfo>();
            DirectoryInfo[] listChildFolderInfo = folderInfo.GetDirectories();
            FileInfo[] listChildFileInfo = folderInfo.GetFiles();

            foreach (DirectoryInfo childFolderInfo in listChildFolderInfo)
            {
                try
                {
                    if (childFolderInfo != null && childFolderInfo.Exists && (filter == null || filter(childFolderInfo)))
                        listResult.Add(childFolderInfo);

                    List<FileSystemInfo> listGrandChildFileInfo = GetAllFolderAndFileInfos(childFolderInfo, filter);
                    if (listGrandChildFileInfo != null && listGrandChildFileInfo.Count >= 1)
                        foreach (FileSystemInfo grandChildFileInfo in listGrandChildFileInfo)
                        {
                            try
                            {
                                if (grandChildFileInfo != null && grandChildFileInfo.Exists && (filter == null || filter(grandChildFileInfo)))
                                    listResult.Add(grandChildFileInfo);
                            }
                            catch (Exception) { }
                        }
                }
                catch (Exception) { }
            }

            foreach (FileInfo childFileInfo in listChildFileInfo)
            {
                try
                {
                    if (childFileInfo != null && childFileInfo.Exists && (filter == null || filter(childFileInfo)))
                        listResult.Add(childFileInfo);
                }
                catch (Exception) { }
            }

            return listResult;
        }

        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        public static List<string> GetAllFilePaths(string folderPath)
        {
            return GetAllFilePaths(folderPath, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        public static List<string> GetAllFilePaths(DirectoryInfo folderInfo)
        {
            return GetAllFilePaths(folderInfo, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<string> GetAllFilePaths(string folderPath, FilterFilePath filter)
        {
            if (folderPath.IndexOf(":") < 0) folderPath = string.Format(@"{0}\{1}\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), folderPath.TrimEnd('\\', '/'));
            folderPath = folderPath.Replace(@"/", @"\").TrimEnd('\\', '/') + @"\"; 
            if (!Directory.Exists(folderPath)) return null;


            List<string> listResult = new List<string>();
            string[] listChildFolderPath = Directory.GetDirectories(folderPath);
            string[] listChildFilePath = Directory.GetFiles(folderPath);

            foreach (string childFolderInfo in listChildFolderPath)
            {
                try
                {
                    string tempPath = childFolderInfo.TrimEnd('\\', '/') + "\\";
                    List<string> listGrandChildFileInfo = GetAllFilePaths(tempPath, filter);
                    if (listGrandChildFileInfo != null && listGrandChildFileInfo.Count >= 1)
                        foreach (string grandChildFilePath in listGrandChildFileInfo)
                        {
                            try
                            {
                                if (File.Exists(grandChildFilePath) && (filter == null || filter(grandChildFilePath)))
                                    listResult.Add(grandChildFilePath);
                            }
                            catch (Exception) { }
                        }
                }
                catch (Exception) { }
            }

            foreach (string childFileInfo in listChildFilePath)
            {
                try
                {
                    if (File.Exists(childFileInfo) && (filter == null || filter(childFileInfo)))
                        listResult.Add(childFileInfo);
                }
                catch (Exception) { }
            }

            return listResult;
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<string> GetAllFilePaths(DirectoryInfo folderInfo, FilterFilePath filter)
        {
            if (folderInfo == null || !folderInfo.Exists) return null;
            return GetAllFilePaths(folderInfo.FullName, filter);
        }

        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        public static List<string> GetAllFolderAndFilePaths(string folderPath)
        {
            return GetAllFolderAndFilePaths(folderPath, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        public static List<string> GetAllFolderAndFilePaths(DirectoryInfo folderInfo)
        {
            return GetAllFolderAndFilePaths(folderInfo, null);
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderPath">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<string> GetAllFolderAndFilePaths(string folderPath, FilterFolderAndFilePath filter)
        {
            if (folderPath.IndexOf(":") < 0) folderPath = string.Format(@"{0}\{1}\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), folderPath.TrimEnd('\\', '/'));
            folderPath = folderPath.Replace(@"/", @"\").TrimEnd('\\', '/') + @"\";
            if (!Directory.Exists(folderPath)) return null;


            List<string> listResult = new List<string>();
            string[] listChildFolderPath = Directory.GetDirectories(folderPath);
            string[] listChildFilePath = Directory.GetFiles(folderPath);

            foreach (string childFolderInfo in listChildFolderPath)
            {
                try
                {
                    if (Directory.Exists(childFolderInfo) && (filter == null || filter(childFolderInfo)))
                        listResult.Add(childFolderInfo);

                    List<string> listGrandChildFileInfo = GetAllFolderAndFilePaths(childFolderInfo, filter);
                    if (listGrandChildFileInfo != null && listGrandChildFileInfo.Count >= 1)
                        foreach (string grandChildFilePath in listGrandChildFileInfo)
                        {
                            try
                            {
                                if (File.Exists(grandChildFilePath) && (filter == null || filter(grandChildFilePath)))
                                    listResult.Add(grandChildFilePath);
                            }
                            catch (Exception) { }
                        }
                }
                catch (Exception) { }
            }

            foreach (string childFileInfo in listChildFilePath)
            {
                try
                {
                    if (File.Exists(childFileInfo) && (filter == null || filter(childFileInfo)))
                        listResult.Add(childFileInfo);
                }
                catch (Exception) { }
            }

            return listResult;
        }
        /// <summary>
        /// 获取文件夹及其子文件夹下的所有 文件夹+文件
        /// </summary>
        /// <param name="folderInfo">需要检索的文件夹</param>
        /// <param name="filter">确定指定的 FileInfo 是否应该 纳入返回结果中</param>
        public static List<string> GetAllFolderAndFilePaths(DirectoryInfo folderInfo, FilterFolderAndFilePath filter)
        {
            if (folderInfo == null || !folderInfo.Exists) return null;
            return GetAllFolderAndFilePaths(folderInfo.FullName, filter);
        }


        /// <summary>
        /// 获取磁盘驱动器 信息
        /// </summary>
        public static DriveInfo[] GetAllDriveInfos()
        {
            DriveInfo[] listDrive = DriveInfo.GetDrives();
            return listDrive;
        }
        /// <summary>
        /// 获取磁盘驱动器 路径
        /// </summary>
        public static List<string> GetAllDrivePaths()
        {
            DriveInfo[] listDrive = DriveInfo.GetDrives();
            List<string> listResult = new List<string>();
            foreach (DriveInfo temp in listDrive)
            {
                try
                {
                    string driveName = temp.Name;
                    listResult.Add(driveName);
                }
                catch (Exception) { }
            }
            return listResult;
        }


        #endregion

        #region  程 序 目 录

        /// <summary>
        /// 获取当前 进程的 启动目录: WinForm、控制台 为 exe 所在目录; Web 为 根目录(Bin目录的父级目录);
        /// </summary>
        /// <returns></returns>
        public static string AppRootFolderPath()
        {
            string path;
#if (!WindowsCE && !PocketPC)
            path = AppDomain.CurrentDomain.BaseDirectory;
#endif
#if (WindowsCE || PocketPC)
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
#endif
            return path;
        }

        #endregion


        #region  文 件 读 写

        #region  文 件 字 节

        /// <summary>
        /// 获取文件的字节流
        /// </summary>
        public static byte[] ReadFileBytes(string path)
        {
            path = FormatFullPath(path);
            if (!File.Exists(path)) return null;

            FileInfo fileInfo = new FileInfo(path);
            return ReadFileBytes(path, 0, fileInfo.Length);
        }
        /// <summary>
        /// 写入文件的字节流, 文件不存在将创建文件 (overWrite 表示, 是否清空文件 现有字节 重新添加字节流, overWrite==false 则会在 文件末尾处 追加字节流)
        /// </summary>
        public static bool WriteFileBytes(string path, byte[] bytes, bool overWrite)
        {
            path = FormatFullPath(path);
            if (File.Exists(path) && overWrite) DeleteFile(path);
            long length = File.Exists(path) ? new FileInfo(path).Length : 0;
            return WiteFileBytes(path, length, bytes);
        }

        /// <summary>
        /// 读取指定文件 从指定字节开始 的 指定长度的 字节 (剩余字节不足, 则直接返回剩余字节流)
        /// </summary>
        public static byte[] ReadFileBytes(string path, long offset, long length)
        {
            path = FormatFullPath(path);
            if (!File.Exists(path)) return null;

            if (offset < 0) offset = 0;
            if (length < 0) length = long.MaxValue;

            const int PACKAGE_SIZE = 1024 * 512; //每次512K

            using (FileStream myFs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                myFs.Position = offset;
                long fileByteLength = Math.Min(length, myFs.Length - myFs.Position);
                byte[] bytes = new byte[fileByteLength];

                long readLength = 0;
                while (readLength < fileByteLength)
                {
                    long leaveLength = myFs.Length - myFs.Position;
                    long leaveLength2 = fileByteLength - readLength;
                    int bufferLength = (leaveLength > (long)PACKAGE_SIZE) ? PACKAGE_SIZE : Convert.ToInt32(leaveLength);
                    bufferLength = (leaveLength2 > (long)bufferLength) ? bufferLength : Convert.ToInt32(leaveLength2);

                    byte[] buffer = new byte[bufferLength];
                    myFs.Read(buffer, 0, bufferLength);

                    Array.Copy(buffer, 0, bytes, readLength, bufferLength);
                    readLength = readLength + bufferLength;

                    if (myFs.Position >= myFs.Length) break;
                }

                myFs.Close();
                return bytes;
            }
        }
        /// <summary>
        /// 写入指定文件 从指定字节开始 的 指定长度的 字节 (剩余字节不足, 则直接返回剩余字节流)
        /// </summary>
        public static bool WiteFileBytes(string path, long offset, byte[] bytes)
        {
            path = FormatFullPath(path);
            CreateFolder(path);

            if (offset < 0) offset = 0;
            if (bytes == null) return false;

            const int PACKAGE_SIZE = 1024 * 512; //每次512K
            long byteLength = bytes.Length;

            using (FileStream myFs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                myFs.Position = offset;

                long writeLength = 0;
                while (writeLength < byteLength)
                {
                    long leaveLength = byteLength - writeLength;
                    int bufferLength = (leaveLength > (long)PACKAGE_SIZE) ? PACKAGE_SIZE : Convert.ToInt32(leaveLength);

                    byte[] buffer = new byte[bufferLength];
                    Array.Copy(bytes, writeLength, buffer, 0, bufferLength);

                    myFs.Write(buffer, 0, bufferLength);

                    writeLength = writeLength + bufferLength;

                    if (writeLength >= byteLength) break;
                }

                myFs.Close();
                return true;
            }
        }

        /// <summary>
        /// FileHelper 中, 文件MD5计算错误时 的默认值
        /// </summary>
        public const string ERROR_FILE_MD5 = "XXXXXXXXXXXXXXXXXXXX";
        /// <summary>
        /// 计算文件的MD5, 计算错误将返回 XXXXXXXXXXXXXXXXXXXX
        /// </summary>
        public static string GetFileMD5(string path)
        {
            if (!File.Exists(path)) return ERROR_FILE_MD5;

            try
            {
                using (FileStream myFs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (MD5 md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] hash = md5.ComputeHash(myFs);
                        myFs.Close();

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("x2"));
                        return sb.ToString();
                    }
                }
            }
            catch (Exception)
            {
                return ERROR_FILE_MD5;
            }
        }
        /// <summary>
        /// 计算指定文件 从指定字节开始 的 指定长度的 文件的MD5 (剩余字节不足, 则只计算剩余字节流), 计算错误将返回 XXXXXXXXXXXXXXXXXXXX
        /// </summary>
        public static string GetFileMD5(string path, long offset, long length)
        {
            if (!File.Exists(path)) return ERROR_FILE_MD5;

            try
            {
                const int PACKAGE_SIZE = 1024 * 1024; //每次1M

                using (MD5 md5 = new MD5CryptoServiceProvider())
                {
                    md5.Initialize();

                    using (FileStream myFs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        myFs.Position = offset;
                        long fileByteLength = Math.Min(length, myFs.Length - myFs.Position);
                        byte[] buffer = new byte[PACKAGE_SIZE];

                        long readLength = 0;
                        while (readLength < fileByteLength)
                        {
                            long leaveLength = myFs.Length - myFs.Position;
                            long leaveLength2 = fileByteLength - readLength;
                            int bufferLength = (leaveLength > (long)PACKAGE_SIZE) ? PACKAGE_SIZE : Convert.ToInt32(leaveLength);
                            bufferLength = (leaveLength2 > (long)bufferLength) ? bufferLength : Convert.ToInt32(leaveLength2);

                            myFs.Read(buffer, 0, bufferLength);

                            if (readLength + bufferLength < fileByteLength)     //不是最后一块
                                md5.TransformBlock(buffer, 0, bufferLength, buffer, 0);
                            else                                                //最后一块
                                md5.TransformFinalBlock(buffer, 0, bufferLength);

                            readLength = readLength + bufferLength;
                            if (myFs.Position >= myFs.Length) break;
                        }

                        byte[] hash = md5.Hash;
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("x2"));
                        return sb.ToString();
                    }
                }
            }
            catch (Exception)
            {
                return ERROR_FILE_MD5;
            }
        }

        #endregion


        #region  文 本 文 件

        /// <summary>
        /// 通过给定的文件路径，判断文件的编码类型
        /// </summary>
        public static Encoding GetFileEncoding(string path)
        {
            path = FormatFullPath(path);
            using (FileStream myFs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader myBr = new BinaryReader(myFs))
                {
                    Byte[] buffer = myBr.ReadBytes(2);
                    if (buffer[0] >= 0xEF)
                    {
                        if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                            return Encoding.UTF8;
                        else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                            return Encoding.Unicode;
                        else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                            return Encoding.BigEndianUnicode;
                        else
                            return Encoding.Default;
                    }
                    else
                        return Encoding.Default;
                }
            }
        }

        /// <summary>
        /// 读取磁盘上的代码文件，默认返回值 是 空字符串
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        /// <param name="encoding">文本的编码方式</param>
        public static string ReadAllText(string path)
        {
            path = FormatFullPath(path);
            if (!File.Exists(path)) return string.Empty;

            Encoding encoding = GetFileEncoding(path);
            return ReadAllText(path, encoding);
        }
        /// <summary>
        /// 读取磁盘上的代码文件，默认返回值 是 空字符串
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        /// <param name="encoding">文本的编码方式</param>
        public static string ReadAllText(string path, Encoding encoding)
        {
            path = FormatFullPath(path);
            if (!File.Exists(path)) return string.Empty;
            return File.ReadAllText(path, encoding);
        }


        /// <summary>
        /// 读取磁盘上的代码文件 字符串集合，默认返回值 是 空字符串；
        /// 每隔一行，作为一个集合对象；空格行 不算；
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        public static List<string> ReadAllLines(string path)
        {
            return ReadAllLines(path, true, true);
        }
        /// <summary>
        /// 读取磁盘上的代码文件 字符串集合，默认返回值 是 空字符串；
        /// 每隔一行，作为一个集合对象；空格行 不算；
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        /// <param name="encoding">文本的编码方式</param>
        public static List<string> ReadAllLines(string path, Encoding encoding)
        {
            return ReadAllLines(path, true, true, encoding);
        }
        /// <summary>
        /// 读取磁盘上的代码文件 字符串集合，默认返回值 是 空字符串；
        /// 每隔一行，作为一个集合对象；空格行 不算；
        /// 如果 withNullLine==true, 则 withEmptyLine 自动矫正为 true；
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        /// <param name="withNullLine">是否包括 空白行</param>
        /// <param name="withEmptyLine">是否包括 仅空格行</param>
        public static List<string> ReadAllLines(string path, bool withNullLine, bool withEmptyLine)
        {
            path = FormatFullPath(path);
            if (!File.Exists(path)) return null;

            Encoding encoding = GetFileEncoding(path);
            return ReadAllLines(path, withNullLine, withEmptyLine, encoding);
        }
        /// <summary>
        /// 读取磁盘上的代码文件 字符串集合，默认返回值 是 空字符串；
        /// 每隔一行，作为一个集合对象；空格行 不算；
        /// 如果 withNullLine==true, 则 withEmptyLine 自动矫正为 true；
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        /// <param name="withNullLine">是否包括 空白行</param>
        /// <param name="withEmptyLine">是否包括 仅空格行</param>
        /// <param name="encoding">文本的编码方式</param>
        public static List<string> ReadAllLines(string path, bool withNullLine, bool withEmptyLine, Encoding encoding)
        {
            path = FormatFullPath(path);
            if (!File.Exists(path)) return null;

            string[] array = File.ReadAllLines(path, encoding);
            List<string> listResult = array == null ? null : new List<string>(array);
            return listResult;
        }


        /// <summary>
        /// 将字符串写入磁盘，写入失败 会抛出异常;
        /// 默认使用 UTF-8 编码
        /// </summary>
        /// <param name="path">路径如： D:\aa.txt</param>
        /// <param name="content">需要写入的字符串</param>
        public static void WriteAllText(string path, string content)
        {
            path = FormatFullPath(path);
            WriteAllText(path, content, Encoding.UTF8);
        }
        /// <summary>
        /// 将字符串写入磁盘，写入失败异常
        /// </summary>
        /// <param name="path">路径如： D:\aa.txt</param>
        /// <param name="content">需要写入的字符串</param>
        /// <param name="encoding">文本的编码方式</param>
        public static void WriteAllText(string path, string content, Encoding encoding)
        {
            path = FormatFullPath(path);
            FileHelper.CreateFolder(path);
            File.WriteAllText(path, content, encoding);
        }

        /// <summary>
        /// 将字符串追加到磁盘，写入失败 会抛出异常;
        /// 默认使用 UTF-8 编码
        /// </summary>
        /// <param name="path">路径如： D:\aa.txt</param>
        /// <param name="content">需要写入的字符串</param>
        public static void AppendAllText(string path, string content)
        {
            path = FormatFullPath(path);
            AppendAllText(path, content, Encoding.UTF8);
        }
        /// <summary>
        /// 将字符串追加到磁盘，写入失败 会抛出异常
        /// </summary>
        /// <param name="path">路径如： D:\aa.txt</param>
        /// <param name="content">需要写入的字符串</param>
        /// <param name="encoding">文本的编码方式</param>
        public static void AppendAllText(string path, string content, Encoding encoding)
        {
            path = FormatFullPath(path);
            FileHelper.CreateFolder(path);
            File.AppendAllText(path, content, encoding);
        }

        /// <summary>
        /// 将字符串追加到磁盘，写入失败 会抛出异常;
        /// 默认使用 UTF-8 编码
        /// </summary>
        /// <param name="path">路径如： D:\aa.txt</param>
        /// <param name="content">需要追加的字符串</param>
        public static void AppendAllLines(string path, IEnumerable<string> content)
        {
            path = FormatFullPath(path);
            AppendAllLines(path, content, Encoding.UTF8);
        }
        /// <summary>
        /// 将字符串追加到磁盘，写入失败 会抛出异常
        /// </summary>
        /// <param name="path">路径如： D:\aa.txt</param>
        /// <param name="contents">需要追加的字符串</param>
        /// <param name="encoding">文本的编码方式</param>
        public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            path = FormatFullPath(path);
            FileHelper.CreateFolder(path);
            using (var mySw = new StreamWriter(path, true, encoding))
            {
                foreach (string current in contents)
                {
                    mySw.WriteLine(current);
                }
            }
        }

        #endregion


        #region  序 列 化 文 件

        /// <summary>
        /// 读取数据流，反序列化为对象；
        /// 如果路径不存在 将 返回 null；
        /// 失败将抛出异常；
        /// </summary>
        /// <param name="path">序列化文件的路径</param>
        /// <param name="withZip">反序列化时，是否需要使用 Zip解压</param>
        public static object FileDeserialize(string path, bool withZip)
        {
            if (!File.Exists(path)) return null;

            try
            {
                BinaryFormatter myBf = new BinaryFormatter();
                using (FileStream myFs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Stream stream = withZip ? (Stream)new GZipStream(myFs, CompressionMode.Compress) : (Stream)myFs;

                    object record = null;
                    try { record = myBf.Deserialize(stream); }
                    finally { stream.Dispose(); }
                    return record;
                }
            }
            catch (Exception exp)
            {
                throw new Exception(string.Format("读取磁盘序列化失败: {0}", exp.Message));
                //return null;
            }
        }
        /// <summary>
        /// 写入数据流，将对象写入磁盘；
        /// 如果路径不存在，该方法 将创建；
        /// </summary>
        /// <param name="path">序列化路径</param>
        /// <param name="record">需要序列化的对象</param>
        /// <param name="withZip">序列化时，是否需要使用 Zip压缩</param>
        public static bool FileSerialize(string path, object record, bool withZip)
        {
            //if (!File.Exists(path)) return false;
            CreateFolder(path);

            try
            {
                BinaryFormatter myBf = new BinaryFormatter();
                using (FileStream myFs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    Stream stream = withZip ? (Stream)new GZipStream(myFs, CompressionMode.Decompress) : (Stream)myFs;

                    try { myBf.Serialize(stream, record); }
                    finally { stream.Dispose(); }
                }
                return true;
            }
            catch (Exception exp)
            {
                throw new Exception(string.Format("写入磁盘序列化失败: {0}", exp.Message));
                //return false;
            }
        }

        #endregion


        #endregion

    }

    internal delegate bool FilterFileInfo(FileInfo fileInfo);
    internal delegate bool FilterFolderAndFileInfo(FileSystemInfo fileInfo);
    internal delegate bool FilterFilePath(string filePath);
    internal delegate bool FilterFolderAndFilePath(string filePath);


}
