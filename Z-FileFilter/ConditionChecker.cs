using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z_FileFilter
{
    class ConditionChecker
    {
        private List<Condition> conditions;

        public ConditionChecker() { }
        public ConditionChecker(List<Condition> conditions)
        {
            this.conditions = conditions; 
        }
        //只检查每组里面是否存在冲突
        //返回没有冲突的条件
        public bool CheckConditions(ref List<Condition> nonConflictedCons)
        {
            if (nonConflictedCons == null)
                nonConflictedCons = new List<Condition>();

            bool IsConflicted = false;
            var groups = conditions.Where(con=>con.InValid == false)
                .GroupBy(con => con.Type);
            foreach (var group in groups)
            {
                switch (group.Key)
                {
                    case "1-文件大小(MB)":
                        double size1 = double.MinValue, size2 = double.MaxValue;
                        Condition sizeCon1=null, sizeCon2=null;
                        foreach (var item in group)
                        {
                            double fileSize = Convert.ToDouble(item.Value);
                            //如果操作符是大于，则选取较大的值
                            if (item.Operator.Equals(">"))
                            {
                                if(fileSize > size1)
                                {
                                    size1 = fileSize;
                                    sizeCon1 = item;
                                }
                            }
                            //如果是小于，则选取较小的值
                            else if(item.Operator.Equals("<"))
                            {
                                if (fileSize < size2)
                                {
                                    size2 = fileSize;
                                    sizeCon2 = item;
                                }
                            }
                        }

                        if (size1 >= size2)
                        {
                            IsConflicted = true;
                        }
                        else
                        {
                            if (sizeCon1!=null)
                                nonConflictedCons.Add(sizeCon1);
                            if (sizeCon2 != null)
                                nonConflictedCons.Add(sizeCon2);
                        }
                        break;
                    case "2-文件名称":
                        foreach (var item in group)
                        {
                            nonConflictedCons.Add(item);
                        }
                        break;
                    case "3-创建时间":
                    case "4-最后编辑时间":
                        //进入到这里的时间值一定是正确的
                        DateTime t1 = DateTime.MinValue, t2 = DateTime.MaxValue;
                        Condition con1 = null, con2 = null;
                        foreach (var item in group)
                        {
                            DateTime date = DateTime.Parse(item.Value);
                            string oper = item.Operator;
                            if (oper.Equals("之前"))   //取较小值
                            {
                                if (date < t2)
                                {
                                    t2 = date;
                                    con2 = item;
                                }
                            }
                            else if (oper.Equals("之后"))
                            {
                                if (date > t1)
                                {
                                    t1 = date;
                                    con1 = item;
                                }
                            }
                        }
                        if (t1 > t2)
                        {
                            IsConflicted = true;
                        }
                        else
                        {
                            if (con1 != null)
                                nonConflictedCons.Add(con1);
                            if (con2 != null)
                                nonConflictedCons.Add(con2);
                        }
                        break;
                    
                    default:
                        break;
                }
            }
            foreach (var item in nonConflictedCons)
            {
                PublicTools.WriteLogs("logs", "info", item.ToString());
            }
            return IsConflicted;
        }
    }
}
