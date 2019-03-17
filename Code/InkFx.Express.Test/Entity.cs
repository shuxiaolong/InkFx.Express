using System;
using System.Collections.Generic;
using System.Text;

namespace InkFx.Express.Test
{
    public class MyIndex
    {
        public string this[string index]
        {
            get
            {
                if (index == "ZhangSan") return "ZhangSan";
                else if (index == "QFL") return "LiSi";
                return string.Empty;
            }
        }

        public string this[int index]
        {
            get
            {
                if (index == 0) return "ZhangSan";
                else if (index == 1) return "LiSi";
                return string.Empty;
            }
        }
    }


    [Serializable]
    public class EnWord
    {
        public string Word { get; set; }
        public string Mean { get; set; }
        public string Demo { get; set; }
    }


    public class School
    {
        public string Name { get; set; }
    }
    public class Department
    {
        public School School { get; set; }
        public string Name { get; set; }
    }
    public class Student
    {
        public Department Department { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Age { get; set; }
    }


    [Serializable]
    public class TestClass01
    {
        public TestClass01()
        {
            Name = "NULL";
            Age = 10;
            Birthday = new DateTime(1900, 01, 01);
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return string.Format("{0} 生日: {1:yyyy-MM-dd} 年纪:{2}", Name, Birthday, Age);
        }
    }

    [Serializable]
    public class TestClass02
    {
        public int Field01 { get; set; }
        public string Field02 { get; set; }
        public DateTime Field03 { get; set; }
        public TestClass03 Field04 { get; set; }
    }
    [Serializable]
    public class TestClass03
    {
        public int Field01 { get; set; }
        public string Field02 { get; set; }
        public DateTime Field03 { get; set; }
    }

    [Serializable]
    public class Int_Int
    {
        public Int_Int(){ }
        public Int_Int(int value0, int value1)
        {
            this.Value0 = value0;
            this.Value1 = value1;
        }

        public int Value0 { get; set; }
        public int Value1 { get; set; }
    }
}
