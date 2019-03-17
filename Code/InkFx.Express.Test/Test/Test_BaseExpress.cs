using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace InkFx.Express.Test.Test
{
    public class Test_BaseExpress
    {
        [Test]
        public void Test_BaseExpress01()
        {
            TestHelper.WriteLine("-- 测试 最基本表达式计算01--\r\n", ConsoleType.Title);

            Dictionary<string, Int_Int> hashExpress = new Dictionary<string, Int_Int>()
            {
                {
                    "\"AABBCC\" LIKE \"%BB%\" AND 300>100 AND -0.000021323E+12 OR 34.543 AND True OR false AND 5697.000021323E+12 OR -45678.424123 AND [FName] IN (\"ZhangSan\",\"LiSi\")",
                    new Int_Int(1000, 100000)
                },
                {"23 IN (12,23,34)", new Int_Int(1000, 100000)},
                {"2 + Max(12,23,34)", new Int_Int(1000, 100000)},
                {"Max(\"AAA\",\"BBB\",\"CCC\")", new Int_Int(1000, 100000)},
                {"Min(\"AAA\",\"BBB\",\"CCC\")", new Int_Int(1000, 100000)},
                {"Max(\"1989-11-27\",\"1990-07-19\")", new Int_Int(1000, 100000)},
                {"Min(\"1989-11-27\",\"1990-07-19\")", new Int_Int(1000, 100000)},

                {"\"AABBCC\" LIKE \"%BB%\"", new Int_Int(1000, 100000)},
                {"\"ZhangSan\" IN (\"ZhangSan\",\"LiSi\")", new Int_Int(1000, 100000)},
                {"LEN(\"ZhangSan\")", new Int_Int(1000, 100000)},
                {"LEN(\"ZhangSan\"+\"LiSi\")", new Int_Int(1000, 100000)},

                {"NEWID()", new Int_Int(1000, 100000)}, //随机产生一个 Guid 
                {"NEWID() LIKE '%ABC%'", new Int_Int(1000, 100000)}, //随机产生一个 Guid 且 模糊匹配

                {"(1234+987)*765", new Int_Int(1000, 100000)},
                {"(122+5654)*(2+976)", new Int_Int(1000, 100000)},
                {"(2+8)*(1+2+77+(12+8))", new Int_Int(1000, 100000)},
                {"(11111===2222)?111:222", new Int_Int(1000, 100000)},
                {"-0.21323E+2", new Int_Int(1000, 100000)}, //decimal 不支持E表达式
                {"-0.000021323E+12", new Int_Int(1000, 100000)},
                {"100-50+50-50", new Int_Int(1000, 100000)},
                {"11111===11111", new Int_Int(1000, 100000)},
                {"1234*546", new Int_Int(1000, 100000)},
                {"123+65+234+132+432", new Int_Int(1000, 100000)},
                {"1+1+1+1+1", new Int_Int(1000, 100000)},
                {"-2+5*(-2+7)", new Int_Int(1000, 100000)},
                {"123*654*907", new Int_Int(1000, 100000)},
                {"2+(235*(2+3))", new Int_Int(1000, 100000)},
                {"3^4", new Int_Int(1000, 100000)},
                {"345*657", new Int_Int(1000, 100000)},
                {"4*3/6*9/2", new Int_Int(1000, 100000)},
                {"7868*989+5678", new Int_Int(1000, 100000)},
                {"81^(1/4)", new Int_Int(1000, 100000)},
                {"10-1+2-3+4-5+6", new Int_Int(1000, 100000)},
                {"\"QWERTYUIOP{}:\" LIKE \"%ERT%U%\"", new Int_Int(1000, 100000)},
                {"(\"QWERTYUIOP{}:\" LIKE \"%ERT%U\")?1111+1111:2222+2222", new Int_Int(1000, 100000)},
                {
                    "(REPLACE(REPLACE(\"AAAAAAAAKKK\",\"K\",\"M\"),\"A\",\"B\") == \"BBBBBBBBMMM\")?\"HHHHHHHHH\":\"IIIIIIIIII\"",
                    new Int_Int(1000, 100000)
                },
                {"False?111:222", new Int_Int(1000, 100000)},


            };



            foreach (string express in hashExpress.Keys)
            {
                Int_Int int_int = hashExpress[express];

                try
                {
                    //执行分析
                    DateTime beginTime = DateTime.Now;
                    ExpressSchema expressSchema = null;
                    for (int i = 0; i < TestHelper.RUN_COUNT; i++)
                    {
                        expressSchema = ExpressSchema.Create(express);
                    }
                    DateTime endTime = DateTime.Now;
                    TimeSpan createTime = endTime - beginTime;

                    //执行计算
                    beginTime = DateTime.Now;
                    object expressValue = null;
                    for (int i = 0; i < TestHelper.RUN_COUNT * 10; i++)
                    {
                        expressValue = expressSchema.Calc(null);
                    }
                    endTime = DateTime.Now;
                    TimeSpan calcTime = endTime - beginTime;
                    bool isMetaResult = expressSchema.MainSlice.MetaValue != null;


                    TestHelper.WriteLine("表达式: {0}   {6}\r\n最后结果: {1} \r\n分析 {2} 次, 耗时 {3} 毫秒\r\n执行 {4} 次, 耗时 {5} 毫秒", express, expressValue, TestHelper.RUN_COUNT, createTime.TotalMilliseconds, TestHelper.RUN_COUNT * 10, calcTime.TotalMilliseconds, (isMetaResult ? "[预]" : string.Empty));
                    TestHelper.AssertPerformance(createTime, TestHelper.RUN_COUNT, int_int.Value0);
                    TestHelper.AssertPerformance(calcTime, TestHelper.RUN_COUNT * 10, int_int.Value1);
                }
                catch (Exception exp)
                {
                    TestHelper.ShowException(express, exp);
                }

                TestHelper.WriteLine();
            }

        }

        [Test]
        public void Test_BaseExpress02()
        {
            TestHelper.WriteLine("-- 测试 最基本表达式计算02--\r\n", ConsoleType.Title);

            ExpressSchema expressSchema = ExpressSchema.Create("LEN(\"ZhangSan\"+\"LiSi\")");
            object value = expressSchema.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", expressSchema.Source, value);



            ExpressSchema expressSchema2 = ExpressSchema.Create("81^(1/4)");
            object value2 = expressSchema2.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", expressSchema2.Source, value2);



            ExpressSchema expressSchema3 = ExpressSchema.Create("True ? 11+22 : 100/0");
            object value3 = expressSchema3.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", expressSchema3.Source, value3);



            ExpressSchema expressSchema4 = ExpressSchema.Create("100/0");
            object value4 = expressSchema4.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", expressSchema4.Source, value4);
        }
    }
}
