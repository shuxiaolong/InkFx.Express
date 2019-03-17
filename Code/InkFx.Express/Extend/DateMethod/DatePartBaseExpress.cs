using System;
using System.Collections;

namespace InkFx.Express.Extend.DateMethod
{
    public abstract class DatePartBaseExpress : ExpressBase
    {
        public override ExpressSlice EscapeConst(string constExpress)
        {
            constExpress = constExpress.Trim().ToUpper();
            string uniteDataPart = UniteDataPart(constExpress);

            if (!string.IsNullOrEmpty(uniteDataPart))
                return new ExpressSlice { Express = constExpress, ExpressType = ExpressType.String, MetaValue = uniteDataPart };

            return base.EscapeConst(constExpress);
        }

        /// <summary>
        /// 时间函数 DataPart 的统一名称
        /// </summary>
        public string UniteDataPart(string dataPart)
        {
            dataPart = dataPart.Trim().ToUpper();

            if (dataPart == "YEAR") return "YEAR";
            if (dataPart == "YY") return "YEAR";
            if (dataPart == "YYYY") return "YEAR";
            if (dataPart == "QUARTER") return "QUARTER";
            if (dataPart == "QQ") return "QUARTER";
            if (dataPart == "Q") return "QUARTER";
            if (dataPart == "MONTH") return "MONTH";
            if (dataPart == "MM") return "MONTH";
            if (dataPart == "M") return "MONTH";
            if (dataPart == "DAYOFYEAR") return "DAYOFYEAR";
            if (dataPart == "DY") return "DAYOFYEAR";
            if (dataPart == "Y") return "DAYOFYEAR";
            if (dataPart == "DAY") return "DAY";
            if (dataPart == "DD") return "DAY";
            if (dataPart == "D") return "DAY";
            if (dataPart == "WEEK") return "WEEK";
            if (dataPart == "WK") return "WEEK";
            if (dataPart == "WW") return "WEEK";
            if (dataPart == "WEEKDAY") return "WEEKDAY";
            if (dataPart == "DW") return "WEEKDAY";
            if (dataPart == "HOUR") return "HOUR";
            if (dataPart == "HH") return "HOUR";
            if (dataPart == "MINUTE") return "MINUTE";
            if (dataPart == "MI") return "MINUTE";
            if (dataPart == "N") return "MINUTE";
            if (dataPart == "SECOND") return "SECOND";
            if (dataPart == "SS") return "SECOND";
            if (dataPart == "S") return "SECOND";
            if (dataPart == "MILLISECOND") return "MILLISECOND";
            if (dataPart == "MS") return "MILLISECOND";

            return string.Empty;
        }

    }
}
