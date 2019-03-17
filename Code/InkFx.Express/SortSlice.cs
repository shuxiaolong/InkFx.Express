using System;

namespace InkFx.Express
{
    /// <summary>
    /// 排序表达式片段 对象
    /// </summary>
    [Serializable]
    public class SortSlice
    {
        /// <summary>
        /// 排序片段 的 算术表达式
        /// </summary>
        public ExpressSchema SortExpress { get; set; }

        /// <summary>
        /// 排序表达 的 排序类型
        /// </summary>
        public SortType SortType { get; set; }

    }


}
