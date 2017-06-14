using System;

namespace FormulaEditor.Core
{
    public class Param
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { private get; set; }

        public dynamic FixValue{
            get {
                if (Type== "int")
                {
                    return Convert.ToInt32(Value);
                }else if (Type == "double")
                {
                    return Convert.ToDouble(Value);
                }
                else if (Type == "datetime")
                {
                    return Convert.ToDateTime(Value);
                }
                else
                {
                    return Value;
                }
            }
        }
    }
}
