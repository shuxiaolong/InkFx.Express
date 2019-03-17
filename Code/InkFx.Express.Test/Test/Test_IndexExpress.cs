using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace InkFx.Express.Test.Test
{
    public class Test_IndexExpress
    {
        //[Test]
        //public void Test_ListIndexExpress01()
        //{
        //    List<Student> listObj = GetListTestObject();


        //    ExpressSchema expressTestSchema1 = ExpressSchema.Create("[Department.School.Name] == '李湾小学'");
        //    object value1 = expressTestSchema1.Calc(listObj[1]);
        //    Console.WriteLine(value1);

        //    ExpressSchema expressTestSchema2 = ExpressSchema.Create("[this][1]");
        //    object value2 = expressTestSchema2.Calc(listObj);
        //    Console.WriteLine(value2);


        //    Dictionary<string, Int_Int> hashExpress = new Dictionary<string, Int_Int>()
        //    {
        //        {"[Number] LIKE '%Zhang%'", new Int_Int(1000, 100000)},
        //        {"[this].[Name] + '|' + [this].[Number]", new Int_Int(1000, 100000)},
        //        {"[this].[Department].[School].[Name] == '李湾小学'", new Int_Int(1000, 100000)},
        //        {"[this].[Department].[School].[Name] + ' | ' + [this].[Department].[Name] + ' | ' + [this].[Name]", new Int_Int(1000, 100000)}
        //    };


        //    foreach (string express in hashExpress.Keys)
        //    {
        //        Int_Int int_int = hashExpress[express];

        //        try
        //        {
        //            //执行分析
        //            DateTime beginTime = DateTime.Now;
        //            ExpressSchema expressSchema = null;
        //            for (int i = 0; i < TestHelper.RUN_COUNT; i++)
        //            {
        //                expressSchema = ExpressSchema.Create(express);
        //            }
        //            DateTime endTime = DateTime.Now;
        //            TimeSpan createTime = endTime - beginTime;

        //            //执行计算
        //            beginTime = DateTime.Now;
        //            List<string> listExpressValue = new List<string>();
        //            foreach (Student item in listObj)
        //                for (int i = 0; i < TestHelper.RUN_COUNT * 10; i++)
        //                {
        //                    object expressValue = expressSchema.Calc(item);
        //                    if (i == 0) listExpressValue.Add((expressValue ?? "NULL").ToString()); //计算多次, 但只添加第一次最后结果
        //                }
        //            endTime = DateTime.Now;
        //            TimeSpan calcTime = endTime - beginTime;


        //            Console.WriteLine("表达式: {0} \r\n最后结果: \r\n{1} \r\n分析 {2} 次, 耗时 {3} 毫秒\r\n执行 {4} 次, 耗时 {5} 毫秒", express, string.Join("\r\n", listExpressValue.ToArray()), TestHelper.RUN_COUNT, createTime.TotalMilliseconds, TestHelper.RUN_COUNT * 10, calcTime.TotalMilliseconds);
        //            TestHelper.AssertPerformance(createTime, TestHelper.RUN_COUNT, int_int.Value0);
        //            TestHelper.AssertPerformance(calcTime, TestHelper.RUN_COUNT * 10 * listObj.Count, int_int.Value1);
        //        }
        //        catch (Exception exp)
        //        {
        //            TestHelper.ShowException(express, exp);
        //        }

        //        Console.WriteLine();
        //    }
        //}

        //[Test]
        //public void Test_HashIndexExpress02()
        //{
        //    List<Student> listObj = GetListTestObject();


        //    Console.WriteLine("测试 用户参数:");

        //    ExpressSchema expressTestSchema1 = ExpressSchema.Create("[Department.School.Name] == '李湾小学'");
        //    object value1 = expressTestSchema1.Calc(listObj[1]);
        //    Console.WriteLine(value1);

        //    ExpressSchema expressTestSchema2 = ExpressSchema.Create("[Department].[School].[Name] == '李湾小学'");
        //    object value2 = expressTestSchema2.Calc(listObj[1]);
        //    Console.WriteLine(value2);

        //    ExpressSchema expressTestSchema3 = ExpressSchema.Create("[this].[Department].[School].[Name] == '李湾小学'");
        //    object value3 = expressTestSchema3.Calc(listObj[1]);
        //    Console.WriteLine(value3);





        //    Console.WriteLine("测试 用户参数 (索引参数):");

        //    ExpressSchema expressTestSchema4 = ExpressSchema.Create("[this][1].[Department.School.Name]");
        //    object value4 = expressTestSchema4.Calc(listObj);
        //    Console.WriteLine(value4);

        //    ExpressSchema expressTestSchema5 = ExpressSchema.Create("[this][1].[Department].[School].[Name]");
        //    object value5 = expressTestSchema5.Calc(listObj);
        //    Console.WriteLine(value5);



        //}





        private static List<Student> GetListTestObject()
        {
            School school_01 = new School { Name = "张湾小学" };
            School school_02 = new School { Name = "李湾小学" };
            Department depart_01 = new Department { Name = "理科", School = school_01 };
            Department depart_02 = new Department { Name = "文科", School = school_02 };
            Student stu_01 = new Student { Name = "张三", Number = "ZhangSan", Department = depart_01 };
            Student stu_02 = new Student { Name = "李四", Number = "LiSi", Department = depart_02 };

            return new List<Student>() {stu_01, stu_02};
        }

    }
}
