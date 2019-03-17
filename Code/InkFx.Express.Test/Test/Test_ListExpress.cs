using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace InkFx.Express.Test.Test
{
    public class Test_ListExpress
    {
        [Test]
        public void Test_ObjectShow()
        {
            List<EnWord> listWord = GetListTestObject();
            TestHelper.WriteLine(string.Format("-- 数据准备 对象集合(集合总数: {0})--\r\n", listWord.Count), ConsoleType.Title);

            TestHelper.WriteLine(Program.SplitLine2);
            TestHelper.WriteLine("Word \tMean \tDemo ");
            TestHelper.WriteLine(Program.SplitLine2);
            foreach (EnWord item in listWord.Take(15))
            {
                TestHelper.WriteLine("{0} \t{1} \t{2} ", item.Word, item.Mean, "");
            }
            //TestHelper.WriteLine(Program.SplitLine2);
        }

        [Test]
        public void Test_ListFilter()
        {
            TestHelper.WriteLine("-- 测试 表达式的 集合检索--\r\n", ConsoleType.Title);

            List<EnWord> listWord = GetListTestObject();

            Dictionary<string, int> hashExpress = new Dictionary<string, int>()
            {
                {"[Word] LIKE 'cat%'", 100000},
                {"[Word] LIKE '%cat%g'", 100000},
                {"([Demo] LIKE '%三%') OR ([Mean] LIKE '%三%')", 100000},
                {"([Demo] LIKE '%四%') OR ([Mean] LIKE '%四%')", 100000},
            };

            foreach (string express in hashExpress.Keys)
            {
                int @int = hashExpress[express];

                try
                {
                    //执行分析
                    DateTime beginTime = DateTime.Now;
                    List<EnWord> listFilter = ExpressHelper.Filter<EnWord>(express, listWord);
                    DateTime endTime = DateTime.Now;
                    TimeSpan filterTime = endTime - beginTime;

                    TestHelper.WriteLine("表达式: {0} \r\n原始集合: {1} 筛选集合: {2}\r\n, 耗时 {3} 毫秒", express, listWord.Count, listFilter.Count, filterTime.TotalMilliseconds);
                    TestHelper.AssertPerformance(filterTime, listWord.Count, @int);
                }
                catch (Exception exp)
                {
                    TestHelper.ShowException(express, exp);
                }

                TestHelper.WriteLine();
            }
        }

        [Test]
        public void Test_ListSort()
        {
            TestHelper.WriteLine("-- 测试 表达式的 集合排序--\r\n", ConsoleType.Title);

            List<EnWord> listWord = GetListTestObject();

            //DESC 倒序 //ASC 正序 //默认 ASC
            Dictionary<string, int> hashExpress = new Dictionary<string, int>()
            {
                {"[Word]", 100000},
                {"[Word] ASC", 100000},
                {"[Mean] DESC", 100000},
                {"[Word] DESC,[Mean] ASC", 100000},
                {"[Demo] ASC", 100000},
                {"[Word],[Mean],[Demo]", 100000},
            };

            foreach (string express in hashExpress.Keys)
            {
                int @int = hashExpress[express];

                try
                {
                    //执行分析
                    DateTime beginTime = DateTime.Now;
                    List<EnWord> listFilter = ExpressHelper.Sort<EnWord>(express, listWord);
                    DateTime endTime = DateTime.Now;
                    TimeSpan filterTime = endTime - beginTime;

                    TestHelper.WriteLine("表达式: {0} \r\n原始集合: {1} 排序集合: {2}\r\n, 耗时 {3} 毫秒", express, listWord.Count, listFilter.Count, filterTime.TotalMilliseconds);
                    TestHelper.AssertPerformance(filterTime, listWord.Count, @int);
                }
                catch (Exception exp)
                {
                    TestHelper.ShowException(express, exp);
                }

                TestHelper.WriteLine();
            }
        }






        private static List<EnWord> GetListTestObject()
        {
            string wordFilePath = string.Format(@"{0}\ListWord.data", AppDomain.CurrentDomain.BaseDirectory.Trim('\\', '/'));

            if (File.Exists(wordFilePath))
            {
                //从 磁盘序列化文件获取 单词集合
                List<EnWord> listWord = (List<EnWord>)FileDeserialize(wordFilePath, true);
                return listWord;
            }
            else
            {
                #region  从 数据库获取 单词集合

                List<EnWord> listWord = new List<EnWord>();
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=MyWord;User Id=sa; Pwd=123.com;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM [cetsix];";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EnWord item = new EnWord();
                                item.Word = (Convert.ToString(reader["words"]) ?? string.Empty).Trim();
                                item.Mean = (Convert.ToString(reader["meaning"]) ?? string.Empty).Trim();
                                item.Demo = (Convert.ToString(reader["lx"]) ?? string.Empty).Trim();
                                listWord.Add(item);
                            }
                        }
                    }
                }

                FileSerialize(wordFilePath, listWord, true);
                return listWord;

                #endregion
            }
        }

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
                    Stream stream = withZip ? (Stream)new GZipStream(myFs, CompressionMode.Decompress) : (Stream)myFs;

                    object record = null;
                    try { record = myBf.Deserialize(stream); }
                    finally { stream.Close(); stream.Dispose(); }
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

            try
            {
                BinaryFormatter myBf = new BinaryFormatter();
                using (FileStream myFs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    Stream stream = withZip ? (Stream)new GZipStream(myFs, CompressionMode.Compress) : (Stream)myFs;

                    try { myBf.Serialize(stream, record); }
                    finally { stream.Close(); stream.Dispose(); }
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

    }
}
