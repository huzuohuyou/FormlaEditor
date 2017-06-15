﻿using System;

namespace FormulaEditor.Model
{
    public class Param
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DataType { get; set; }
        public string Value { private get; set; }
        public string Note
        {
            get { return string.Format("字段：{0} 描述：{1} 数据类型：{2}", Code.Trim(), Name.Trim(),DataType).Trim(); }
        }
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
