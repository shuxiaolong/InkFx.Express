using System;
using System.Collections;
using InkFx.Express.Utils;

namespace InkFx.Express
{
    /// <summary>
    /// 表达式片段 对象
    /// </summary>
    [Serializable]
    public class ExpressSlice
    {
        private string m_Express = string.Empty;
        private string m_HashKey = string.Empty;
        private string m_Source = string.Empty;

        /// <summary>
        /// 数据类型
        /// </summary>
        public ExpressType ExpressType { get; internal set; }


        /// <summary>
        /// 表达式
        /// </summary>
        public string Express
        {
            get { return m_Express; }
            set { m_Express = (value ?? string.Empty).Trim(); }
        }
        /// <summary>
        /// 表达式片段 在 整个表达式中 的 占位符键值
        /// </summary>
        public string HashKey
        {
            get { return m_HashKey; }
            set { m_HashKey = (value ?? string.Empty).Trim(); }
        }
        /// <summary>
        /// 表达式 的 原始 字符串
        /// </summary>
        public string Source
        {
            get
            {
                if (StringExtend.IsNullOrWhiteSpace(m_Source)) 
                    return Express;
                return m_Source;
            }
            internal set { m_Source = (value ?? string.Empty).Trim(); }
        }


        /// <summary>
        /// 计算器：计算器可以对 当前表达式片段 进行 计算
        /// </summary>
        public IExpress IExpress { get; set; }

        /// <summary>
        /// 常量值：当前表达式 是 元数据，没有 IExpress 对象 且 也不需要 IExpress 对象进行计算 就已经 判定的值 
        /// </summary>
        public object MetaValue { get; set; }






        #region  计 算 表 达 式 片 段

        /// <summary>
        /// 计算表达式的结果
        /// </summary>
        public object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            if (MetaValue != null) return MetaValue;
            else if (IExpress != null)
            {
                object value = IExpress.Calc(expressSchema, objOrHash);
                value = AnalyseSingleArrayItem(value);
                return value;
            }
            return null;
        }

        /// <summary>
        /// 对表达式片段进行预运算
        /// </summary>
        public void PreCalc(ExpressSchema expressSchema)
        {
            if (MetaValue != null) return;
            else if (IExpress != null)
            {
                object value = IExpress.PreCalc(expressSchema);
                value = AnalyseSingleArrayItem(value);
                this.MetaValue = value;
            }
        }

        /// <summary>
        /// 计算表达式的结果 并转换成 Array类型
        /// </summary>
        public ArrayList CalcArray(ExpressSchema expressSchema, object objOrHash)
        {
            if (MetaValue is ArrayList) return (ArrayList)MetaValue;
            else if (IExpress != null)
            {
                object value = IExpress.Calc(expressSchema, objOrHash);
                if (value is ArrayList) return (ArrayList)value;
            }
            return null;
        }
        

        private object AnalyseSingleArrayItem(object value)
        {
            IList list = value as IList;
            if (list == null) return value;
            if (list.Count == 1) return list[0];
            return value;
        }

        #endregion



    }



    /// <summary>
    /// 表达式 片段类型
    /// </summary>
    [Serializable]
    public enum ExpressType
    {

        /// <summary>
        /// 表示一个 常量值
        /// </summary>
        Const,

        /// <summary>
        /// 字符串 类型
        /// </summary>
        String,
        /// <summary>
        /// 数字 类型
        /// </summary>
        Double,
        /// <summary>
        /// Boolean 类型
        /// </summary>
        Boolean,

        ///// <summary>
        ///// 外部需要提供 的 参数表达式
        ///// </summary>
        //Argument,

        /// <summary>
        /// 外部需要提供 的 参数属性 全表达式
        /// </summary>
        Argument,


        //SingleArgument,
        //IndexArgument,
        //FullArgument,
        //SimpleArgument,


        /// <summary>
        /// 集合 类型
        /// </summary>
        ArrayList,
        /// <summary>
        /// 用于计算 的 表达式
        /// </summary>
        Express
    }

}
