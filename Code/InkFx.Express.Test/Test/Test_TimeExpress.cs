using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace InkFx.Express.Test.Test
{
    public class Test_TimeExpress
    {
        [Test]
        public void Test_DateMethod()
        {
            TestHelper.WriteLine("-- 测试 时间函数表达式 01 (完全兼容SQLServer语法)--\r\n", ConsoleType.Title);


            Dictionary<string, Int_Int> hashExpress = new Dictionary<string, Int_Int>()
            {
                {"DATEADD(YEAR, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(YY, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(YYYY, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(QUARTER, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(QQ, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(Q, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(MONTH, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(MM, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(M, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(DAYOFYEAR, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(DY, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(Y, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(DAY, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(DD, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(D, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(WEEK, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(WK, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(WW, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(WEEKDAY, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(DW, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(HOUR, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(HH, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(MINUTE, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(MI, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(N, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(SECOND, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(SS, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(S, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(MILLISECOND, 10, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEADD(MS, 10, GETDATE())", new Int_Int(1000, 100000)},

                {"DATEDIFF(YEAR, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(YY, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(YYYY, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(QUARTER, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(QQ, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(Q, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(MONTH, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(MM, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(M, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(DAYOFYEAR, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(DY, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(Y, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(DAY, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(DD, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(D, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(WEEK, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(WK, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(WW, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(WEEKDAY, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(DW, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(HOUR, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(HH, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(MINUTE, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(MI, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(N, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(SECOND, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(SS, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(S, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(MILLISECOND, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},
                {"DATEDIFF(MS, '1900-01-01', GETDATE())", new Int_Int(1000, 100000)},

                {"DATEPART(YEAR, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(YY, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(YYYY, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(QUARTER, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(QQ, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(Q, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(MONTH, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(MM, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(M, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(DAYOFYEAR, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(DY, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(Y, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(DAY, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(DD, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(D, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(WEEK, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(WK, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(WW, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(WEEKDAY, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(DW, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(HOUR, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(HH, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(MINUTE, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(MI, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(N, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(SECOND, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(SS, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(S, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(MILLISECOND, GETDATE())", new Int_Int(1000, 100000)},
                {"DATEPART(MS, GETDATE())", new Int_Int(1000, 100000)},

                {"YEAR(GETDATE())", new Int_Int(1000, 100000)},
                {"MONTH(GETDATE())", new Int_Int(1000, 100000)},
                {"DAY(GETDATE())", new Int_Int(1000, 100000)},
                {"GETDATE()", new Int_Int(1000, 100000)},
                {"GETUTCDATE()", new Int_Int(1000, 100000)},
                {"ISDATE('1900-01-01')", new Int_Int(1000, 100000)},
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
        public void Test_DateMethod2()
        {
            TestHelper.WriteLine("-- 测试 时间函数表达式 02 (完全兼容SQLServer语法)--\r\n", ConsoleType.Title);

            ExpressSchema timeExpress1 = ExpressSchema.Create("GETDATE ( )");
            object value1 = timeExpress1.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress1.Source, value1);

            ExpressSchema timeExpress2 = ExpressSchema.Create("DATEPART(YEAR, '1989-12-24')");
            object value2 = timeExpress2.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress2.Source, value2);

            ExpressSchema timeExpress3 = ExpressSchema.Create("10 + (DATEPART(YEAR, '1989-12-24'))");
            object value3 = timeExpress3.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress3.Source, value3);
        }

        [Test]
        public void Test_DateMethod3()
        {
            TestHelper.WriteLine("-- 测试 时间函数表达式 03 (完全兼容SQLServer语法)--\r\n", ConsoleType.Title);

            ExpressSchema timeExpress99 = ExpressSchema.Create("PI");
            object value99 = timeExpress99.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress99.Source, value99);

            ExpressSchema timeExpress98 = ExpressSchema.Create("E");
            object value98 = timeExpress98.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress98.Source, value98);



            ExpressSchema timeExpress1 = ExpressSchema.Create("10 + (PI + DATEPART(MONTH, '1989-12-24'))");
            object value1 = timeExpress1.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress1.Source, value1);

            ExpressSchema timeExpress2 = ExpressSchema.Create("E+10 + (PI + DATEPART(MONTH, '1989-12-24'))");
            object value2 = timeExpress2.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress2.Source, value2);

            ExpressSchema timeExpress3 = ExpressSchema.Create("E+10 + (PI + DATEPART(MONTH, '1989-12-24')) + 12.232E-3");
            object value3 = timeExpress3.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress3.Source, value3);


            ExpressSchema timeExpress4 = ExpressSchema.Create("LEN(\"INK\" + GETDATE())");
            object value4 = timeExpress4.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress4.Source, value4);
            value4 = timeExpress4.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress4.Source, value4);
            value4 = timeExpress4.Calc(null);
            TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress4.Source, value4);
        }

        [Test]
        public void Test_DateMethod4()
        {
            TestHelper.WriteLine("-- 测试 时间函数表达式 04 (完全兼容SQLServer语法)--\r\n", ConsoleType.Title);

            List<string> listExpress = new List<string>()
            {
                "DATEPART(YEAR, GETDATE())",
                "DATEPART(QUARTER, GETDATE())",
                "DATEPART(MONTH, GETDATE())",
                "DATEPART(DAYOFYEAR, GETDATE())",
                "DATEPART(DAY, GETDATE())",
                "DATEPART(WEEK, GETDATE())",
                "DATEPART(WEEKDAY, GETDATE())",
                "DATEPART(WEEKDAY, GETDATE())",
                "DATEPART(HOUR, GETDATE())",
                "DATEPART(MINUTE, GETDATE())",
                "DATEPART(SECOND, GETDATE())",
                "DATEPART(MILLISECOND, GETDATE())",
            };

            foreach (string express in listExpress)
            {
                ExpressSchema timeExpress1 = ExpressSchema.Create(express);
                object value1 = timeExpress1.Calc(null);
                TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress1.Source, value1);
            }
        }

        [Test]
        public void Test_DateMethod5()
        {
            TestHelper.WriteLine("-- 测试 时间函数表达式 05 (完全兼容SQLServer语法)--\r\n", ConsoleType.Title);

            List<string> listExpress = new List<string>()
            {
                "DATEADD(YEAR, 1000, '1900-01-01')",
                "DATEADD(QUARTER, 1000, '1900-01-01')",
                "DATEADD(MONTH, 1000, '1900-01-01')",
                "DATEADD(DAYOFYEAR, 1000, '1900-01-01')",
                "DATEADD(DAY, 1000, '1900-01-01')",
                "DATEADD(WEEK, 1000, '1900-01-01')",
                "DATEADD(WEEKDAY, 1000, '1900-01-01')",
                "DATEADD(HOUR, 1000, '1900-01-01')",
                "DATEADD(MINUTE, 1000, '1900-01-01')",
                "DATEADD(SECOND, 1000, '1900-01-01')",
                "DATEADD(MILLISECOND, 1000, '1900-01-01')",
            };

            foreach (string express in listExpress)
            {
                ExpressSchema timeExpress1 = ExpressSchema.Create(express);
                object value1 = timeExpress1.Calc(null);
                TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress1.Source, value1);
            }
        }

        [Test]
        public void Test_DateMethod6()
        {
            TestHelper.WriteLine("-- 测试 时间函数表达式 06 (完全兼容SQLServer语法)--\r\n", ConsoleType.Title);

            List<string> listExpress = new List<string>()
            {
                "DATEDIFF(YEAR, '1900-01-01', '2015-11-23')",
                "DATEDIFF(QUARTER, '1900-01-01', '2015-11-23')",
                "DATEDIFF(MONTH, '1900-10-31', '2015-11-01')",
                "DATEDIFF(DAYOFYEAR, '1900-01-01', '2015-11-23')",
                "DATEDIFF(DAY, '1900-01-01', '2015-11-23')",
                "DATEDIFF(WEEK, '1900-01-01', '2015-11-23')",
                "DATEDIFF(WEEK, '1900-01-01', '2015-11-23')",
                "DATEDIFF(WEEKDAY, '1900-01-01', '2015-11-23')",
                "DATEDIFF(HOUR, '1900-01-01', '2015-11-23')",
                "DATEDIFF(MINUTE, '1900-01-01', '2015-11-23')",
                "DATEDIFF(SECOND, '1900-01-01', '1910-11-23')",
                "DATEDIFF(MILLISECOND, '1900-01-01', '1900-01-23')",
            };

            foreach (string express in listExpress)
            {
                ExpressSchema timeExpress1 = ExpressSchema.Create(express);
                object value1 = timeExpress1.Calc(null);
                TestHelper.WriteLine("表达式: {0} \r\n最后结果: {1} \r\n", timeExpress1.Source, value1);
            }
        }
    }
}
