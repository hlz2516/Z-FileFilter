using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Z_FileFilter
{
    class Condition
    {
        public string Type { set; get; }
        public string Operator { set; get; }
        public string Value { set; get; }
        public bool  InValid { private set; get; }

        public Condition(){ }
        public Condition(string _type,string _operator,string _value)
        {
            Type = _type;
            Operator = _operator;
            Value = _value;
            CheckValid();
        }

        private void CheckValid()
        {
            if (Type == null || Operator == null || Value == null)
                InValid = true;
            if (Type.Equals("")) InValid = true;
            if (Operator.Equals("")) InValid = true;
            if (Value.Equals("")) InValid = true;
            if (InValid == true)   return;
            //检查类型对应的值是否正确
            switch (Type)
            {
                case "1-文件大小(MB)":
                    double fileSize;
                    try
                    {
                        fileSize = Convert.ToDouble(Value);
                    }
                    catch (InvalidCastException)
                    {
                        MessageBox.Show("请输入浮点数值或整数值[" + Value + "]");
                        InValid = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("未知错误[" + Value + "]，请联系开发者");
                        InValid = true;
                    }
                    break;
                case "3-创建时间":
                case "4-最后编辑时间":
                    DateTime dateTime;
                    try
                    {
                        dateTime = Convert.ToDateTime(Value);
                    }
                    catch (InvalidCastException)
                    {
                        MessageBox.Show("请输入正确的日期格式[yyyy/mm/dd hh:mm:ss]");
                        InValid = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("未知错误[" + Value + "]，请联系开发者");
                        InValid = true;
                    }
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return "type:" + Type + ",operator:" + Operator +
                ",value:" + Value + ",invalid:" + InValid;
        }
    }
}
