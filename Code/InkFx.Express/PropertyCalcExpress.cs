using InkFx.Express.Utils;

namespace InkFx.Express
{
    /// <summary>
    /// 专门用于 计算 表达式 运行中 参数属性的 计算器：本计算器不是一个扩展，没有关键字——这是一个特例
    /// </summary>
    internal sealed class PropertyCalcExpress : ExpressBase
    {
        public override object Calc(ExpressSchema expressSchema, object objOrHash)
        {
            string express = ExpressSlice.Express;
            object value = StaticHelper.GetValue(expressSchema, objOrHash, express);
            //object value = Tools.GetValue(objOrHash, express);  //本函数的 速度 是上面的 1/3
            return value;
        }
    }
}
