using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Z_FileFilter
{
    //此类根据输入条件返回布尔值以表示是否满足筛选条件
    //调用此类静态方法时，要求保证Condition的value类型可以正确转换
    class FileFilter
    {
        public static bool DoFilter(FileInfo fileInfo,List<Condition> conditions)
        {
            //表示是否符合条件，默认是
            bool res = true;
            foreach (var item in conditions)
            {
                bool curRes = true;
                string _type = item.Type;
                switch (_type)
                {
                    case "1-文件大小(MB)":
                        curRes = CheckSize(fileInfo, item);
                        break;
                    case "2-文件名称":
                        curRes = CheckName(fileInfo, item);
                        break;
                    case "3-创建时间":
                        curRes = CheckCreateTime(fileInfo, item);
                        break;
                    case "4-最后编辑时间":
                        curRes = CheckLastModTime(fileInfo, item);
                        break;
                    default:
                        break;
                }
                if (curRes == false)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public static bool CheckSize(FileInfo fileInfo,Condition condition)
        {
            return CheckSize(fileInfo, condition.Operator[0], double.Parse(condition.Value));
        }

        public static bool CheckSize(FileInfo fileInfo,char sign,double comparedSize)
        {
            bool res = false;
            //length默认以byte为单位，所以要转换一下
            double fileLen = fileInfo.Length * 1.0 / 1024 / 1024;
            switch (sign)
            {
                case '>':
                    if (fileLen > comparedSize)
                        res = true;
                    break;
                case '<':
                    if (fileLen < comparedSize)
                        res = true;
                    break;
                default:
                    break;
            }
            return res;
        }

        public static bool CheckName(FileInfo fileinfo,Condition condition)
        {
            return CheckName(fileinfo, condition.Operator, condition.Value);
        }

        public static bool CheckName(FileInfo fileInfo,string sign,string value)
        {
            bool res = false;
            string name = fileInfo.Name;
            switch (sign)
            {
                case "like":
                    try
                    {
                        //默认用户输入的值为正则表达式
                        value = value.Trim();
                        Regex regex = new Regex(@value);
                        Match matchRes = regex.Match(name);
                        if (matchRes.Success)
                            res = true;
                    }
                    catch (Exception e)
                    {
                        res = false;
                        PublicTools.WriteLogs("logs", "error", e.Message);
                    }
                    break;
                case "unlike":
                    try
                    {
                        //默认用户输入的值为正则表达式
                        value = value.Trim();
                        Regex regex = new Regex(@value);
                        Match matchRes = regex.Match(name);
                        if (!matchRes.Success)
                            res = true;
                    }
                    catch (Exception e)
                    {
                        res = false;
                        PublicTools.WriteLogs("logs", "error", e.Message);
                    }
                    break;
                default:
                    break;
            }
            return res;
        }

        public static bool CheckCreateTime(FileInfo fileinfo,Condition condition)
        {
            return CheckCreateTime(fileinfo, condition.Operator, DateTime.Parse(condition.Value));
        }

        public static bool CheckCreateTime(FileInfo fileinfo,string sign,DateTime comparedValue)
        {
            bool res = false;
            DateTime dateValue = fileinfo.CreationTime;
            switch (sign)
            {
                case "之前":
                    if (dateValue < comparedValue)
                        res = true;
                    break;
                case "之后":
                    if (dateValue > comparedValue)
                        res = true;
                    break;
                default:
                    break;
            }
            return res;
        }

        public static bool CheckLastModTime(FileInfo fileInfo,Condition condition)
        {
            return CheckLastModTime(fileInfo, condition.Operator, DateTime.Parse(condition.Value));
        }

        public static bool CheckLastModTime(FileInfo fileinfo, string sign, DateTime comparedValue)
        {
            bool res = false;
            DateTime dateValue = fileinfo.LastWriteTime;
            switch (sign)
            {
                case "之前":
                    if (dateValue < comparedValue)
                        res = true;
                    break;
                case "之后":
                    if (dateValue > comparedValue)
                        res = true;
                    break;
                default:
                    break;
            }
            return res;
        }
    }
}
