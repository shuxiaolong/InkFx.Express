using System;
using System.Collections;
using System.Collections.Generic;
using InkFx.Express.Utils;

namespace InkFx.Express
{
    /// <summary>
    /// 排序表达式结构 对象：任何一个需要排序的 表达式 都会 被转换成 这个对象
    /// </summary>
    [Serializable]
    public class SortSchema
    {
        private SortSchema() { }

        private readonly List<SortSlice> m_ListSortItem = new List<SortSlice>();

        /// <summary>
        /// 排序 中的 表达式 集合
        /// </summary>
        public List<SortSlice> ListSortItem
        {
            get { return m_ListSortItem; }
            set
            {
                if (m_ListSortItem != value)
                {
                    m_ListSortItem.Clear();
                    if (value != null && value.Count > 0)
                        m_ListSortItem.AddRange(value);
                }
            }
        }

        /// <summary>
        /// 排序的 比较器
        /// </summary>
        public IComparer SortComparer { get; internal set; }

        /// <summary>
        /// 对一个 ICollection 执行排序
        /// </summary>
        public IList Sort(ICollection array)
        {
            if (array == null) return null;

            ArrayList list = new ArrayList(array);
            if (SortComparer != null)
                list.Sort(SortComparer);
            else
                list.Sort();

            return list;
        }

        #region  静 态 函 数

        /// <summary>
        /// 通过排序表达式 初始化一个 SortSchema 对象
        /// </summary>
        public static SortSchema Create(string sortExpress)
        {
            if (StringExtend.IsNullOrWhiteSpace(sortExpress)) return null;

            List<SortSlice> listSortSlice = new List<SortSlice>();
            string[] sortItems = sortExpress.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries); 
            foreach(string sortItem in sortItems)
            {
                if(!StringExtend.IsNullOrWhiteSpace(sortItem))
                {
                    string sortItemTemp = sortItem.Trim();
                    string sortDescType = SortType.DESC.ToString();
                    string sortAscType = SortType.ASC.ToString();

                    SortType sortType = SortType.ASC;
                    if (sortItemTemp.EndsWith(sortDescType, StringComparison.CurrentCultureIgnoreCase))
                    {
                        sortType = SortType.DESC;
                        sortItemTemp = sortItemTemp.Substring(0, sortItemTemp.Length - sortDescType.Length).Trim();
                    }
                    else if (sortItemTemp.EndsWith(sortAscType, StringComparison.CurrentCultureIgnoreCase))
                    {
                        sortType = SortType.ASC;
                        sortItemTemp = sortItemTemp.Substring(0, sortItemTemp.Length - sortAscType.Length).Trim();
                    }

                    ExpressSchema sortSliceSchema = ExpressSchema.Create(sortItemTemp);
                    SortSlice sortSlice = sortSliceSchema == null ? null : new SortSlice { SortExpress = sortSliceSchema, SortType = sortType };
                    if (sortSlice != null) listSortSlice.Add(sortSlice);
                }
            }

            if (listSortSlice.Count <= 0) return null;
            SortSchema sortSchema = new SortSchema { ListSortItem = listSortSlice };
            sortSchema.SortComparer = new SortComparer { SortItems = sortSchema.ListSortItem };
            return sortSchema;
        }

        #endregion
    }


    /// <summary>
    /// 排序表达式 排序类型
    /// </summary>
    [Serializable]
    public enum SortType
    {
        /// <summary>
        /// 升序排列
        /// </summary>
        ASC,
        /// <summary>
        /// 降序排列
        /// </summary>
        DESC
    }


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
