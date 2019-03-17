namespace InkFx.Express.SpecialCalcExpress
{
    /// <summary>
    /// 专门用于 分析 表达式 全局常量 计算器：本计算器不是一个扩展，没有关键字，且本类 是一个 单例类(无法new对象)——这是一个特例
    /// </summary>
    internal sealed class GlobalConstCalcExpress : ExpressBase
    {
        private GlobalConstCalcExpress(){ }
        private static readonly GlobalConstCalcExpress m_Instance = new GlobalConstCalcExpress();
        public static GlobalConstCalcExpress Instance
        {
            get { return m_Instance; }
        }



        public override bool CanPreCalc
        {
            get { return true; }
        }

        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            throw new ExpressException("InkFx.Express.GlobalConstCalcExpress 只能 识别常量, 不能用来计算");
        }
        public override ExpressSlice EscapeConst(string constExpress)
        {
            ExpressSlice constSlice = ExpressHelper.EscapeConst(constExpress);
            if (constSlice != null) return constSlice;

            return base.EscapeConst(constExpress);
        }

    }
}
