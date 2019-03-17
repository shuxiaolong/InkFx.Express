using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.SyntaxHelpers;

namespace InkFx.Express.Test
{
    public class Program 
    {
        public const string SplitLine = "==================================================";
        public const string SplitLine2 = "--------------------------------------------------";
        const string LogoExpress = "REPLACE('InkFx.Express - Love Java.', 'Love Java', 'Love C#')";


        public static void Main2()
        {
            ExpressSchema expressSchema = ExpressSchema.Create("GETUNITINFO('ZhangSan',GETUSERINFO('LS'))");
            object value = expressSchema.Calc(null);
            TestHelper.WriteLine(value);
        }

        public static void Main3()
        {
//常规计算
object value = ExpressHelper.Calc("1+2+(5*6/3)");
Console.WriteLine(value);  //13


//对象计算
Student student =new Student();
student.Age = 20;
student.Name = "张三";
object value2 = ExpressHelper.Calc("[Name] + '   ' + LEN([NAME])", student);
Console.WriteLine(value2);  //张三   2

//常量 YYYY
object value3 = ExpressHelper.Calc("DATEPART(YYYY, GETDATE())");  //SQLServer 语法
Console.WriteLine(value3);  //2019


//注册自定义常量
object value4 = ExpressHelper.Calc(" PI ");
Console.WriteLine(value4);  //3.14159265358979

ExpressHelper.RegisterConst("PI", new ExpressSlice { Express = "PI", ExpressType = ExpressType.Double, MetaValue = 3.14999999 });
object value5 = ExpressHelper.Calc("PI");
Console.WriteLine(value5);  //3.14999999


//公式计算
Hashtable hash =new Hashtable();
hash["A"] = 123;
hash["B"] = 456;
object value6 = ExpressHelper.Calc("[A] + [B]", hash);
Console.WriteLine(value6);  //579


List<Student> list = new List<Student>();
list.Add(new Student() { Name = "张三", Age = 20 });
list.Add(new Student() { Name = "李四", Age = 19 });
list.Add(new Student() { Name = "王五", Age = 20 });
List<Student> list2 = ExpressHelper.Filter<Student>("[Age]==20", list);
Console.WriteLine(list2.Count);  //2 集合包含: 张三、李四

        }

        public static void Main()
        {
            Main3();
            return;

            //显示 Logo 信息
            TestHelper.WriteLine("InkFx.Express");
            TestHelper.WriteLine("    ——最稳、最快、最易扩展的 表达式算法框架");
            TestHelper.WriteLine();
            ExpressSchema logoExpressSchema = ExpressSchema.Create(LogoExpress);
            object logoExpressValue = logoExpressSchema.Calc(null);
            TestHelper.WriteLine("Logo 表达式: \t{0}\r\nLogo 值: \t{1}", LogoExpress, logoExpressValue);
            TestHelper.WriteLine(SplitLine);

            TestHelper.WriteLine("按任意键 开始 InkFx.Express 性能测试...");
            Console.ReadKey();





            //开始执行测试
            TestHelper.RunAllTest();

            TestHelper.WriteLine("按任意键 退出测试...");
            Console.ReadKey();
        }





    }

}
