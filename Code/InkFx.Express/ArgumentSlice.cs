using System;

namespace InkFx.Express
{
    /// <summary>
    /// 表示一个 自定义用户参数 片段
    /// </summary>
    [Serializable]
    public class ArgumentSlice
    {
        private string m_ArgExpress = string.Empty;


        /// <summary>
        /// 自定义用户参数 表达式片段
        /// </summary>
        public string ArgExpress
        {
            get { return m_ArgExpress; }
            set { m_ArgExpress = (value ?? string.Empty).Trim(); }
        }
        /// <summary>
        /// 自定义用户参数 表达式片段类型
        /// </summary>
        public ArgumentType ArgType { get; internal set; }
        /// <summary>
        /// 表达式中的 片段
        /// </summary>
        public ExpressSlice ExpressSlice { get; internal set; }
    }

    /// <summary>
    /// 表示一个 自定义用户参数 片段类型
    /// </summary>
    [Serializable]
    public enum ArgumentType
    {
        /// <summary>
        /// 外部需要提供 的 原始参数, 对应 [this] 中的 this
        /// </summary>
        ArgSource,
        /// <summary>
        /// 外部需要提供 的 参数属性名称 (必须是 常量表达式片段 ExpressType.Const)
        /// </summary>
        ArgName,
        /// <summary>
        /// 外部需要提供 的 索引器参数
        /// </summary>
        ArgIndex,
    }
}
