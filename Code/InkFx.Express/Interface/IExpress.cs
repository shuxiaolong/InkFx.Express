using System;
using System.Collections;

namespace InkFx.Express
{
    public interface IExpress
    {
        ExpressSlice ExpressSlice { get; set; }
        ExpressSlice[] Arguments { get; set; } //get; 
        object Calc(ExpressSchema expressSchema, object objOrHash);
    }

    public abstract class ExpressBase : IExpress
    {
        public ExpressSlice ExpressSlice { get; set; }
        public ExpressSlice[] Arguments { get; set; }

        public abstract object Calc(ExpressSchema expressSchema, object objOrHash);

        protected object ArgumentsObject(int index, ExpressSchema expressSchema, object objOrHash)
        {
            if (Arguments.Length == 1 && Arguments[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = Arguments[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        return computer.ArgumentsObject(index, expressSchema, objOrHash);
                    }
                }
            }

            return Arguments[index].Calc(expressSchema, objOrHash);
        }
        protected string ArgumentsString(int index, ExpressSchema expressSchema, object objOrHash)
        {
            if (Arguments.Length == 1 && Arguments[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = Arguments[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        return computer.ArgumentsString(index, expressSchema, objOrHash);
                    }
                }
            }

            return Arguments[index].CalcString(expressSchema, objOrHash);
        }
        protected double ArgumentsDouble(int index, ExpressSchema expressSchema, object objOrHash)
        {
            if (Arguments.Length == 1 && Arguments[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = Arguments[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        return computer.ArgumentsDouble(index, expressSchema, objOrHash);
                    }
                }
            }

            return Arguments[index].CalcDouble(expressSchema, objOrHash);
        }
        protected bool ArgumentsBoolean(int index, ExpressSchema expressSchema, object objOrHash)
        {
            if (Arguments.Length == 1 && Arguments[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = Arguments[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        return computer.ArgumentsBoolean(index, expressSchema, objOrHash);
                    }
                }
            }

            return Arguments[index].CalcDoolean(expressSchema, objOrHash);
        }
        protected ArrayList ArgumentsArray(int index, ExpressSchema expressSchema, object objOrHash)
        {
            if (Arguments.Length == 1 && Arguments[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = Arguments[0];
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

            return Arguments[index].CalcArray(expressSchema, objOrHash);
        }
        protected DateTime ArgumentsDate(int index, ExpressSchema expressSchema, object objOrHash)
        {
            if (Arguments.Length == 1 && Arguments[0].ExpressType == ExpressType.ArrayList)
            {
                ExpressSlice argument = Arguments[0];
                if (argument != null)
                {
                    ExpressBase computer = argument.IExpress as ExpressBase;
                    if (computer != null)
                    {
                        return computer.ArgumentsDate(index, expressSchema, objOrHash);
                    }
                }
            }

            return Arguments[index].CalcDate(expressSchema, objOrHash);
        }
        
        protected ExpressType ArgumentsType(int index)
        {
            return Arguments[index].ExpressType;
        }
    }
}
