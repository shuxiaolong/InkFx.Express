using System;
using System.Collections;
using InkFx.Express.Utils;

namespace InkFx.Express
{
    /// <summary>
    /// 自定义 表达式片段 计算器 接口
    /// </summary>
    public interface IExpress
    {
        /// <summary>
        /// 当前计算器 是否具备 预处理能力 (比如: GETDATE() 函数, 计算的结果是 实时时间, 那么 GETDATE() 就不具备 预处理能力)
        /// </summary>
        bool CanPreCalc { get; }

        /// <summary>
        /// 表达式主片段
        /// </summary>
        ExpressSlice ExpressSlice { get; set; }
        /// <summary>
        /// 表达式参数片段
        /// </summary>
        ExpressSlice[] Arguments { get; set; } //get; 

        /// <summary>
        /// 将一个 常量表达式 转换成 一个确定类型的 片段
        /// </summary>
        ExpressSlice EscapeConst(string constExpress);
        /// <summary>
        /// 计算表达式片段的值
        /// </summary>
        object Calc(ExpressSchema expressSchema, object objOrHash);

        /// <summary>
        /// 对表达式 进行 预运算
        /// </summary>
        object PreCalc(ExpressSchema expressSchema);

    }

    /// <summary>
    /// 自定义 表达式片段 计算器 基类
    /// </summary>
    public abstract class ExpressBase : IExpress
    {
        public virtual bool CanPreCalc
        {
            get
            {
                ExpressSlice[] listArg = this.Arguments;
                if (listArg == null || listArg.Length <= 0) return false; //无参数的计算器 全部不启用 预处理

                return true;
            }
        }
        public ExpressSlice ExpressSlice { get; set; }
        public ExpressSlice[] Arguments { get; set; }


        public virtual ExpressSlice EscapeConst(string constExpress)
        {
            return null;
        }
        public abstract object Calc(ExpressSchema expressSchema, object objOrHash);
        public virtual object PreCalc(ExpressSchema expressSchema)
        {
            ExpressSlice[] listArg = this.Arguments;
            if (listArg == null || listArg.Length <= 0) return null;

            try
            {
                bool withAllMetaValue = true;
                foreach (ExpressSlice slice in listArg)
                {
                    slice.PreCalc(expressSchema);
                    withAllMetaValue = withAllMetaValue && slice.MetaValue != null;
                }

                if (withAllMetaValue && this.CanPreCalc) return this.Calc(expressSchema, null);
                else return null;
            }
            catch (Exception) { return null; } //预处理时 发生的异常 全部吞掉
        }



        /// <summary>
        /// 将指定 索引的 子片段 计算出一个 object 
        /// </summary>
        protected object ArgumentsObject(int index, ExpressSchema expressSchema, object objOrHash)
        {
            ExpressSlice[] listArg = Arguments;
            if (listArg == null || index < 0) return null;

            if (listArg.Length == 1 && listArg[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = listArg[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        return computer.ArgumentsObject(index, expressSchema, objOrHash);
                    }
                }
            }

            if (index >= listArg.Length) throw new ExpressException(string.Format("表达式 第{0}个 参数无效 (索引{1}越界).", (index + 1), index));

            ExpressSlice slice = listArg[index];
            return slice.Calc(expressSchema, objOrHash);
        }
        /// <summary>
        /// 将指定 索引的 子片段 计算出一个 string 
        /// </summary>
        protected string ArgumentsString(int index, ExpressSchema expressSchema, object objOrHash)
        {
            object value = ArgumentsObject(index, expressSchema, objOrHash);
            return Tools.ToString(value, string.Empty);
        }
        /// <summary>
        /// 将指定 索引的 子片段 计算出一个 double 
        /// </summary>
        protected double ArgumentsDouble(int index, ExpressSchema expressSchema, object objOrHash)
        {
            object value = ArgumentsObject(index, expressSchema, objOrHash);
            return Tools.ToDouble(value, 0);
        }
        /// <summary>
        /// 将指定 索引的 子片段 计算出一个 bool 
        /// </summary>
        protected bool ArgumentsBoolean(int index, ExpressSchema expressSchema, object objOrHash)
        {
            object value = ArgumentsObject(index, expressSchema, objOrHash);
            return Tools.ToBoolean(value, false);
        }
        /// <summary>
        /// 将指定 索引的 子片段 计算出一个 ArrayList 
        /// </summary>
        protected ArrayList ArgumentsArray(int index, ExpressSchema expressSchema, object objOrHash)
        {
            ExpressSlice[] listArg = Arguments;
            if (listArg == null || index < 0) return null;

            if (listArg.Length == 1 && listArg[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = listArg[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        ArrayList result = computer.ArgumentsArray(index, expressSchema, objOrHash);
                        return result ?? argument.CalcArray(expressSchema, objOrHash);
                    }
                }
            }

            if (index >= listArg.Length) throw new ExpressException(string.Format("表达式 第{0}个 参数无效 (索引{1}越界).", (index + 1), index));

            ExpressSlice slice = listArg[index];
            return slice.CalcArray(expressSchema, objOrHash);
        }
        /// <summary>
        /// 将指定 索引的 子片段 计算出一个 DateTime 
        /// </summary>
        protected DateTime ArgumentsDate(int index, ExpressSchema expressSchema, object objOrHash)
        {
            object value = ArgumentsObject(index, expressSchema, objOrHash);
            return Tools.ToDateTime(value, DateTime.MinValue);
        }

        /// <summary>
        /// 得到指定 索引的 子片段 的数据类型
        /// </summary>
        protected ExpressType ArgumentsType(int index)
        {
            return Arguments[index].ExpressType;
        }
    }
}
