using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InkFx.Express
{
    /// <summary>
    /// 排序执行器：本执行器会对 需要排序的 集合 进行计算缓存 —— 将大大节省排序时间；
    /// 但是警告：本类并不是 线程安全的，切记防止 多线程 使用同一个 排序执行器对象；
    /// 本类继承 IDisposable，因此请使用 using 语法，或者手动 执行 Dispose() 以释放缓存数据；
    /// 【提示，本比较执行器 使用的是 SortExecuter.SortExecuterComparer比较器(而非 SortComparer)】；
    /// </summary>
    [Serializable]
    public class SortExecuter : IDisposable
    {
        protected SortExecuter(){ }

        public SortSchema SortSchema { get; internal set; }
        public ICollection Collection { get; internal set; }
        public IComparer SortComparer { get; internal set; }

        public static SortExecuter Create(SortSchema sortSchema, ICollection collection)
        {
            if (sortSchema == null) throw new ExpressException("SortExecuter.Create(*) Error:SortSchema Must Be Effective When Init SortExecuter!");
            
            SortExecuter sortExecuter = new SortExecuter();
            sortExecuter.SortSchema = sortSchema;
            sortExecuter.Collection = collection;
            SortExecuterComparer sortComparer = SortExecuterComparer.Create(sortExecuter);
            sortExecuter.SortComparer = sortComparer;
            return sortExecuter;
        }

        public ArrayList Sort()
        {
            if (Collection == null) return null;

            ArrayList list = new ArrayList(Collection);
            list.Sort((IComparer) SortComparer);

            return list;
        }



        protected readonly Hashtable cacheHashtable = new Hashtable();
        protected string GetValueString(object objOrHash, ExpressSchema itemSchema)
        {
            object result = GetValue(objOrHash, itemSchema);
            return (result ?? string.Empty).ToString();  //.Trim();  //不前后格式化
        }
        protected object GetValue(object objOrHash, ExpressSchema itemSchema)
        {
            Hashtable existValues = cacheHashtable[objOrHash] as Hashtable;
            if (existValues == null)
            {
                existValues = new Hashtable();
                cacheHashtable[objOrHash] = existValues;
            }

            object existValue;
            if (!existValues.ContainsKey(itemSchema))
            {
                existValue = itemSchema.Calc(objOrHash);
                existValues[itemSchema] = existValue;
            }
            else
                existValue = existValues[itemSchema];

            return existValue;
        }


        public void Dispose()
        {
            cacheHashtable.Clear();
        }


        /// <summary>
        /// 针对 SortExecuter 的排序器
        /// </summary>
        [Serializable]
        private sealed class SortExecuterComparer : IComparer
        {
            private SortExecuterComparer(){ }

            public ICollection<SortSlice> SortItems { get; internal set; }
            public SortExecuter SortExecuter { get; internal set; }
            public int Compare(object x, object y)
            {
                if (SortItems == null || SortItems.Count <= 0) return 0;

                foreach (SortSlice sortSlice in SortItems)
                {
                    string xValue = SortExecuter.GetValueString(x, sortSlice.SortExpress);
                    string yValue = SortExecuter.GetValueString(y, sortSlice.SortExpress);

                    int result = StringComparer.CurrentCultureIgnoreCase.Compare(xValue, yValue);
                    //int result = StringComparer.CurrentCulture.Compare(xValue, yValue);  //两者速度相差不大
                    if (result != 0)
                    {
                        //不再进行后续循环
                        if (sortSlice.SortType == SortType.ASC) return result;
                        else return 0 - result;
                    }
                }

                return 0;
            }

            public static SortExecuterComparer Create(SortExecuter sortExecuter)
            {
                SortExecuterComparer sortExecuterComparer = new SortExecuterComparer{ SortExecuter = sortExecuter, SortItems = sortExecuter.SortSchema.ListSortItem };
                return sortExecuterComparer;
            }

           
        }
    }

    /// <summary>
    /// 泛型排序执行器：本执行器会对 需要排序的 集合 进行计算缓存 —— 将大大节省排序时间；
    /// 但是警告：本类并不是 线程安全的，切记防止 多线程 使用同一个 排序执行器对象；
    /// 本类继承 IDisposable，因此请使用 using 语法，或者手动 执行 Dispose() 以释放缓存数据；
    /// 【提示，本比较执行器 使用的是 SortExecuter.SortExecuterComparer比较器(而非 SortComparer)】；
    /// </summary>
    [Serializable]
    public class SortExecuter<T> : SortExecuter, IDisposable
    {
        protected SortExecuter() { }
        public new IComparer<T> SortComparer { get; internal set; }
        public new List<T> Collection { get; internal set; }

        public static SortExecuter<T> Create(SortSchema sortSchema, List<T> list)
        {
            if (sortSchema == null) throw new ExpressException("SortExecuter<T>.Create(*) Error:SortSchema Must Be Effective When Init SortExecuter<T>!");

            SortExecuter<T> sortExecuter = new SortExecuter<T>();
            sortExecuter.SortSchema = sortSchema;
            sortExecuter.Collection = list;
            IComparer<T> sortComparer = SortExecuterComparer<T>.Create(sortExecuter);
            sortExecuter.SortComparer = sortComparer;
            return sortExecuter;
        }
        public new void Sort()
        {
            if (Collection == null) return;
            Collection.Sort(SortComparer);
        }


        /// <summary>
        /// 针对 SortExecuter 的排序器
        /// </summary>
        [Serializable]
        private sealed class SortExecuterComparer<ST> : IComparer<ST>, IComparer
        {
            private SortExecuterComparer() { }

            private ICollection<SortSlice> SortItems { get; set; }
            private SortExecuter<ST> SortExecuter { get; set; }
            public int Compare(ST x, ST y)
            {
                return Compare((object)x, (object)y);
            }
            public int Compare(object x, object y)
            {
                if (SortItems == null || SortItems.Count <= 0) return 0;

                foreach (SortSlice sortSlice in SortItems)
                {
                    string xValue = SortExecuter.GetValueString(x, sortSlice.SortExpress);
                    string yValue = SortExecuter.GetValueString(y, sortSlice.SortExpress);

                    int result = StringComparer.CurrentCultureIgnoreCase.Compare(xValue, yValue);
                    //int result = StringComparer.CurrentCulture.Compare(xValue, yValue);  //两者速度相差不大
                    if (result != 0)
                    {
                        //不再进行后续循环
                        if (sortSlice.SortType == SortType.ASC) return result;
                        else return 0 - result;
                    }
                }

                return 0;
            }

            public static SortExecuterComparer<T> Create(SortExecuter<T> sortExecuter)
            {
                SortExecuterComparer<T> sortExecuterComparer = new SortExecuterComparer<T> { SortExecuter = sortExecuter, SortItems = sortExecuter.SortSchema.ListSortItem };
                return sortExecuterComparer;
            }


        }
    }



    [Serializable]
    internal sealed class SortComparer : IComparer
    {
        public ICollection<SortSlice> SortItems { get; internal set; }

        public int Compare(object x, object y)
        {
            if (SortItems == null || SortItems.Count <= 0) return 0;

            foreach (SortSlice sortSlice in SortItems)
            {
                string xValue = (sortSlice.SortExpress.Calc(x) ?? string.Empty).ToString(); //.Trim();
                string yValue = (sortSlice.SortExpress.Calc(y) ?? string.Empty).ToString(); //.Trim();

                int result = StringComparer.CurrentCultureIgnoreCase.Compare(xValue, yValue);
                //int result = StringComparer.CurrentCulture.Compare(xValue, yValue);  //两者速度相差不大
                if (result != 0)
                {
                    //不再进行后续循环
                    if (sortSlice.SortType == SortType.ASC) return result;
                    else return 0 - result;
                }
            }

            return 0;
        }
    }
}
