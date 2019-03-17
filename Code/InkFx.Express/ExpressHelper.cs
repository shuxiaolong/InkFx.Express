using System;
using System.Collections;
using System.Collections.Generic;
using InkFx.Express.Utils;

namespace InkFx.Express
{
    /// <summary>
    /// InkFx.Express 静态类 封装
    /// </summary>
    public static class ExpressHelper
    {
        private static readonly Hashtable m_HashCacheExpress = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable m_HashCacheSort = Hashtable.Synchronized(new Hashtable());


        #region  全 局 常 量
         
        private static readonly IgnoreDict<ExpressSlice> m_HashConstSlice = new IgnoreDict<ExpressSlice>()
        {
            {"PI", new ExpressSlice{ Express = "PI", ExpressType = ExpressType.Double, MetaValue = Math.PI}},
            {"π", new ExpressSlice{ Express = "π", ExpressType = ExpressType.Double, MetaValue = Math.PI}},
            {"E", new ExpressSlice{ Express = "E", ExpressType = ExpressType.Double, MetaValue = Math.E}},

            {"MININT32", new ExpressSlice{ Express = "MININT32", ExpressType = ExpressType.Boolean, MetaValue = int.MinValue}},
            {"MAXINT32", new ExpressSlice{ Express = "MAXINT32", ExpressType = ExpressType.Boolean, MetaValue = int.MaxValue}},
            {"MININT64", new ExpressSlice{ Express = "MININT64", ExpressType = ExpressType.Boolean, MetaValue = long.MinValue}},
            {"MAXINT64", new ExpressSlice{ Express = "MAXINT64", ExpressType = ExpressType.Boolean, MetaValue = long.MaxValue}},
            {"NULL", new ExpressSlice{ Express = "NULL", ExpressType = ExpressType.String, MetaValue = DBNull.Value}},
            {"False", new ExpressSlice{ Express = "False", ExpressType = ExpressType.Boolean, MetaValue = false}},
            {"True", new ExpressSlice{ Express = "True", ExpressType = ExpressType.Boolean, MetaValue = true}},

            {"COPYRIGHT", new ExpressSlice{ Express = "COPYRIGHT", ExpressType = ExpressType.String, MetaValue = "InkFx.Express © ShuXiaolong 2015 QQ:514286339" }},
        };

        /// <summary>
        /// 注册 自定义 表达式全局常量 (比如 PI 注册为 3.1415) [当然, PI 已经被 内置注册]
        /// </summary>
        public static void RegisterConst(string constExpress, ExpressSlice constSlice)
        {
            if (StringExtend.IsNullOrWhiteSpace(constExpress) || constSlice == null) return;
            constExpress = (constExpress ?? string.Empty).Trim();
            lock (m_HashConstSlice) { m_HashConstSlice[constExpress] = constSlice; }
        }
        /// <summary>
        /// 移除 自定义 表达式全局常量 (本函数 可以移除 内置注册 的 全局常量)
        /// </summary>
        public static void RemoveConst(string constExpress)
        {
            lock (m_HashConstSlice) { m_HashConstSlice.Remove(constExpress); }
        }

        /// <summary>
        /// 读取 自定义 全局表达式常量 (比如 PI 注册为 3.1415) [当然, PI 已经被 内置注册]
        /// </summary>
        public static ExpressSlice EscapeConst(string constExpress)
        {
            constExpress = (constExpress ?? string.Empty).Trim();

            ExpressSlice constSlice;
            if (string.Equals(constExpress, "COPYRIGHT", StringComparison.CurrentCultureIgnoreCase))
                constSlice = new ExpressSlice { Express = "COPYRIGHT", ExpressType = ExpressType.String, MetaValue = "InkFx.Express © ShuXiaolong 2015 QQ:514286339" };
            else
            { lock (m_HashConstSlice) { constSlice = m_HashConstSlice[constExpress]; } }

            return constSlice;
        }


        #endregion

        /// <summary>
        /// 计算一个表达式，对于已有 表达式 则默认直接使用缓存的 ExpressSchema
        /// </summary>
        public static object Calc(string express)
        {
            return Calc(express, true);
        }
        /// <summary>
        /// 计算一个表达式，需要手动指定 是否 需要缓存 ExpressSchema
        /// </summary>
        public static object Calc(string express, bool withCache)
        {
            ExpressSchema expressSchema = InitExpressSchema(express, withCache);
            if (expressSchema != null)
            {
                object value = expressSchema.Calc(null);
                return value;
            }
            return null;
        }
        /// <summary>
        /// 计算一个表达式，对于已有 表达式 则默认直接使用缓存的 ExpressSchema
        /// </summary>
        public static object Calc(string express, object objOrHash)
        {
            return Calc(express, objOrHash, true);
        }
        /// <summary>
        /// 计算一个表达式，需要手动指定 是否 需要缓存 ExpressSchema withCache：注意 参数 withCache 只缓存 结构对象，并不缓存计算结果(每次执行 都会重复计算结果)
        /// </summary>
        public static object Calc(string express, object objOrHash, bool withCache)
        {
            ExpressSchema expressSchema = InitExpressSchema(express, withCache);
            if (expressSchema != null)
            {
                object value = expressSchema.Calc(objOrHash);
                return value;
            }
            return null;
        }


        /// <summary>
        /// 对一个集合排序(返回排序后的新集合对象)，对于已有 表达式 则默认直接使用缓存的 SortSchema
        /// </summary>
        public static ArrayList Sort(string sortExpress, ICollection collection)
        {
            return Sort(sortExpress, collection, true);
        }
        /// <summary>
        /// 对一个集合排序(返回排序后的新集合对象)，需要手动指定 是否 需要缓存 SortSchema withCache：注意 参数 withCache 只缓存 结构对象，并不缓存排序结果(每次执行 都会重复计算排序结果)
        /// </summary>
        public static ArrayList Sort(string sortExpress, ICollection collection, bool withCache)
        {
            SortSchema sortSchema = InitSortSchema(sortExpress, withCache);
            using (SortExecuter sortExecuter = SortExecuter.Create(sortSchema, collection))
            {
                ArrayList result = sortExecuter.Sort();
                return result;
            }
        }
        /// <summary>
        /// 对一个集合排序(对集合本身执行排序)，对于已有 表达式 则默认直接使用缓存的 SortSchema
        /// </summary>
        public static List<T> Sort<T>(string sortExpress, List<T> list)
        {
            Sort<T>(sortExpress, list, true);
            return list;
        }
        /// <summary>
        /// 对一个集合排序(对集合本身执行排序)，需要手动指定 是否 需要缓存 SortSchema withCache：注意 参数 withCache 只缓存 结构对象，并不缓存排序结果(每次执行 都会重复计算排序结果)
        /// </summary>
        public static List<T> Sort<T>(string sortExpress, List<T> list, bool withCache)
        {
            SortSchema sortSchema = InitSortSchema(sortExpress, withCache);
            using (SortExecuter<T> sortExecuter = SortExecuter<T>.Create(sortSchema, list))
            {
                sortExecuter.Sort();
            }
            return list;
        }


        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static ArrayList Filter(string filterExpress, ICollection collection)
        {
            return Filter(filterExpress, collection, true);
        }
        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static ArrayList Filter(string filterExpress, ICollection collection, bool withCache)
        {
            ExpressSchema filterSchema = InitExpressSchema(filterExpress, withCache);

            ArrayList arrayList = new ArrayList();
            foreach (object item in collection)
            {
                object value = filterSchema.Calc(item);
                if (Equals(value, true)) arrayList.Add(item);
            }
            return arrayList;
        }
        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static List<T> Filter<T>(string filterExpress, IList<T> list)
        {
            return Filter<T>(filterExpress, list, true);
        }
        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static List<T> Filter<T>(string filterExpress, IList<T> list, bool withCache)
        {
            ExpressSchema filterSchema = InitExpressSchema(filterExpress, withCache);

            List<T> listT = new List<T>();
            foreach (T item in list)
            {
                object value = filterSchema.Calc(item);
                if (Equals(value, true)) listT.Add(item);
            }
            return listT;
        }


        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static ArrayList Select(string filterExpress, string sortExpress, ICollection collection)
        {
            return Select(filterExpress, sortExpress, collection, true);
        }
        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static ArrayList Select(string filterExpress, string sortExpress, ICollection collection, bool withCache)
        {
            ArrayList filterArrayList = Filter(filterExpress, collection, withCache);
            ArrayList sortArrayList = Sort(sortExpress, filterArrayList, withCache);

            filterArrayList.Clear();
            return sortArrayList;
        }
        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static List<T> Select<T>(string filterExpress, string sortExpress, IList<T> list)
        {
            return Select<T>(filterExpress, sortExpress, list, true);
        }
        /// <summary>
        /// 对一个集合 进行过滤 并返回 新集合
        /// </summary>
        public static List<T> Select<T>(string filterExpress, string sortExpress, IList<T> list, bool withCache)
        {
            List<T> filterArrayList = Filter<T>(filterExpress, list, withCache);
            Sort<T>(sortExpress, filterArrayList, withCache);
            return filterArrayList;
        }




        /// <summary>
        /// 通过一个表达式 初始化 一个 表达式 的 结构对象
        /// </summary>
        public static ExpressSchema InitExpressSchema(string express, bool withCache)
        {
            if (StringExtend.IsNullOrWhiteSpace(express)) return null;

            ExpressSchema expressSchema = null;

            if (withCache)
            {
                try { expressSchema = m_HashCacheExpress[express] as ExpressSchema; }
                catch (Exception) { }
            }

            if (expressSchema == null)
            {
                expressSchema = ExpressSchema.Create(express);
                if (expressSchema != null && withCache)
                {
                    try
                    {
                        if (m_HashCacheExpress.Count >= MAX_CACHE_COUNT) m_HashCacheExpress.Clear();   //最大缓存 MAX_CACHE_COUNT
                        m_HashCacheExpress[express] = expressSchema;
                    }
                    catch (Exception) { }
                }
            }

            return expressSchema;
        }
        /// <summary>
        /// 通过一个表达式 初始化 一个 排序表达式 的 结构对象
        /// </summary>
        public static SortSchema InitSortSchema(string sortExpress, bool withCache)
        {
            if (StringExtend.IsNullOrWhiteSpace(sortExpress)) return null;

            SortSchema sortSchema = null;

            if (withCache)
            {
                try { sortSchema = m_HashCacheSort[sortExpress] as SortSchema; }
                catch (Exception) { }
            }

            if (sortSchema == null)
            {
                sortSchema = SortSchema.Create(sortExpress);
                if (sortSchema != null && withCache)
                {
                    try
                    {
                        if (m_HashCacheExpress.Count >= MAX_CACHE_COUNT) m_HashCacheExpress.Clear();   //最大缓存 MAX_CACHE_COUNT
                        m_HashCacheSort[sortExpress] = sortSchema;
                    }
                    catch (Exception) { }
                }
            }

            return sortSchema;
        }

        private const int MAX_CACHE_COUNT = 100000;

    }
}
