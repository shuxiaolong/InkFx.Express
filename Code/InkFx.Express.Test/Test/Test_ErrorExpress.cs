using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace InkFx.Express.Test.Test
{
    public class Test_ErrorExpress
    {
        [Test]
        public void Test_ErrorExpress01()
        {
            TestHelper.WriteLine("-- 测试 错误的表达式分析--\r\n", ConsoleType.Title);
            TestHelper.WriteLine("以下表达式 发生异常, 即为测试通过.\r\n");

            List<string> listExpress = new List<string>()
            {
                "ZhangSan + LiSi",
                "DoMethod('ZhangSan'+ ' | ' + 'LiSi')",
                "AskMarry('ZhangSan ', 'LiSi')",
                "##",
                "AAA",
                "PI + TestInfo",
                "＃￥％……＆％￥……（…………＆$%^&PI_123$+INFO哈哈３２１２３４＃￥＠！＠＃％＆",


                "'版权信息:' + COPYRIGHT ",
            };


            foreach (string express in listExpress)
            {
                try
                {
                    ExpressSchema timeExpress1 = ExpressSchema.Create(express);
                    object value1 = timeExpress1.Calc(null);
                    TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress1.Source, value1);
                }
                catch (Exception exp)
                {
                    TestHelper.ShowException(string.Format("表达式: {0}", express), exp);
                    TestHelper.WriteLine();
                }
            }
        }






    }
}
