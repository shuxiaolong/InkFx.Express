using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InkFx.Express.Utils
{
    /// <summary>
    /// 简单 泛型字典 方便 字典的 取值赋值,该类的引用 是线程安全的
    /// </summary>
    [Serializable]
    internal class SimpDict<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public SimpDict()
        {
        }
        public SimpDict(IEqualityComparer<TKey> comparer) : base(comparer)
        {
        }

#if (!WindowsCE && !PocketPC) 
        public SimpDict(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif

        private readonly object getSetLocker = new object();
        private static readonly TValue defaultValue = default(TValue);

        public new TValue this[TKey key]
        {
            get
            {
                if (key.Equals(null)) return defaultValue;
                lock (getSetLocker) //为了 多线程的 高并发, 取值也 加上 线程锁
                {
                    TValue record;
                    if (TryGetValue(key, out record)) return record;
                    else return defaultValue;
                }
            }
            set
            {
                try
                {
                    if (!key.Equals(null))
                    {
                        lock (getSetLocker)
                        {
                            //if (!value.Equals(default(TValue)))
                            //{
                                if (base.ContainsKey(key)) base[key] = value;
                                else base.Add(key, value);
                            //}
                            //else
                            //{
                            //    base.Remove(key);
                            //}
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        public virtual void AddRange(IDictionary<TKey, TValue> values)
        {
            if (values == null || values.Count <= 0) return;
            foreach (TKey k in values.Keys)
            {
                this[k] = values[k];
            }
        }

    }


    /// <summary>
    /// 字符串 泛型字典,该类的引用 是线程安全的
    /// </summary>
    [Serializable]
    internal class IgnoreDict<T> : SimpDict<string, T>
    {
        public IgnoreDict() : base(StringComparer.CurrentCultureIgnoreCase)
        {
        }
#if (!WindowsCE && !PocketPC) 
        public IgnoreDict(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif

        private static readonly T defaultValue = default(T);


        public virtual void AddRange(IgnoreDict<T> values)
        {
            if (values == null || values.Count <= 0) return;
            foreach (string k in values.Keys)
            {
                this[k] = values[k];
            }
        }

        public virtual Hashtable ToHashtable()
        {
            Hashtable hashtable = new Hashtable();

            try
            {
                foreach (KeyValuePair<string, T> pair in this)
                    try { hashtable[pair.Key] = pair.Value; }
                    catch(Exception){ }
            }
            catch(Exception) { }

            return hashtable;
        }
        public static IgnoreDict<T> FromHashtable(Hashtable hashtable)
        {
            IgnoreDict<T> dictionary = new IgnoreDict<T>();
            try
            {
                foreach (string key in hashtable.Keys)
                {
                    try
                    {
                        object record = hashtable[key];
                        dictionary[key] = record is T ? (T) record : defaultValue;
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }

            return dictionary;
        }
    }


    /// <summary>
    /// 不区分大小写键值的哈希表
    /// </summary>
    [Serializable]
    internal class IgnoreHash : IgnoreDict<object>
    {
        public IgnoreHash() { }
#if (!WindowsCE && !PocketPC) 
        public IgnoreHash(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }




}
