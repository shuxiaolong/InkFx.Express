using System;

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

        public static void Main()
        {
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
