using System;

namespace FormulaEditor.Model
{
    public class Param
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DataType { get; set; }
        public string Value { private get; set; }

        public dynamic FixValue{
            get {
                if (DataType== "int")
                {
                    return Convert.ToInt32(Value);
                }else if (DataType == "double")
                {
                    return Convert.ToDouble(Value);
                }
                else if (DataType == "datetime")
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
