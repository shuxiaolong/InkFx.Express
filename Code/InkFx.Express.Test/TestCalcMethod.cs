using System;
using System.Collections.Generic;

namespace InkFx.Express.Test
{
    //本段代码注释:
    //之前, 有个认识多年的网友 在使用 InkFx.Express 的时候, 他在扩展函数执行时 发生了一点问题.
    //然后, 我顺手帮他 把他 需要的 两个函数 扩展了一下, 就是下面的 两个函数

    //函数意思: 
    //  GETUSERINFO(string UserNumber) 通过 用户编号 获取 用户对象
    //  GETUNITINFO(string UserNumber, Student UnitUser) 通过 用户编号 获取 用户对象, 并与 UnitUser 合并成集合 返回


    [Serializable]
    [CalcExpress(Express = "GETUSERINFO {A}", Keywords = new[] { "GETUSERINFO" }, Level = 1000000, ExpressType = typeof(GETUSERINFOCalcMethod))]
    public class GETUSERINFOCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return false; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);

            if (arg1 == "ZhangSan") return new Student() { Name = "张三" };
            if (arg1 == "LS") return new Student() { Name = "李四" };


            return null;
        }
    }

    [Serializable]
    [CalcExpress(Express = "GETUNITINFO {A}", Keywords = new[] { "GETUNITINFO" }, Level = 1000000, ExpressType = typeof(GETUNITINFOCalcMethod))]
    public class GETUNITINFOCalcMethod : ExpressBase
    {
        public override bool CanPreCalc
        {
            get { return false; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string arg1 = ArgumentsString(0, expressSchema, objOrHash);
            Student arg2 = ArgumentsObject(1, expressSchema, objOrHash) as Student;

            Student stu1 = null;
            if (arg1 == "ZhangSan") stu1 = new Student() { Name = "张三" };
            if (arg1 == "LS") stu1 = new Student() { Name = "李四" };


            return new List<Student> { stu1, arg2 };
        }
    }
}
