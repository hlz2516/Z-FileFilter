using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Z_FileFilter
{
    public class PublicTools
    {
        public static bool IsSystemHidden(DirectoryInfo dirInfo)
        {
            if (dirInfo.Parent == null)
            {
                return false;
            }
            string attributes = dirInfo.Attributes.ToString();
            if (attributes.IndexOf("Hidden") > -1 && attributes.IndexOf("System") > -1)
            {
                return true;
            }
            return false;
        }

        public static void PrintFileInfo(FileInfo fileInfo)
        {
            double fileSize = fileInfo.Length * 1.0 / 1024 / 1024;
            PublicTools.WriteLogs("logs", "info", "Name=>[" + fileInfo.Name +
                "]Size=>[" + fileSize + "]CreateTime=>[" + fileInfo.CreationTime +
                "]LastWriteTime=>[" + fileInfo.LastWriteTime + "]FullName=>[" +
                fileInfo.FullName + "]");
        }

        public static void WriteLogs(string fileName, string type, string content)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory + fileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + type + "-->" + content);
                    //  sw.WriteLine("----------------------------------------");
                    sw.Close();
                }
            }
        }

        public static string OpenFolderBrowserDialog()
        {
            string path = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            return path;
        }

        public static bool CheckPermissionOnDir(string path)
        {
            bool res = false;
            DirectorySecurity fileAcl = null;
            try
            {
                fileAcl = Directory.GetAccessControl(path);
            }
            catch (Exception)
            {
                PublicTools.WriteLogs("logs", "error", "you dont have" +
                    " permission to open the directory:[" + path + "]");
                return res;
            }
            var rules = fileAcl.GetAccessRules(true, true,
                typeof(System.Security.Principal.NTAccount)).
                OfType<FileSystemAccessRule>().ToList();
            string userName = Path.Combine(
                Environment.UserDomainName, Environment.UserName);
            var userRules = rules.Where(i => i.IdentityReference.Value.Equals(userName)
            || i.IdentityReference.Value.Equals("NT AUTHORITY\\Authenticated Users")
            || i.IdentityReference.Value.Equals("BUILTIN\\Users"));
            foreach (var rule in userRules)
            {
                bool canListDir, canRead, canAllow;
                //Debug.WriteLine(rule.FileSystemRights);
                canListDir = (rule.FileSystemRights & FileSystemRights.ListDirectory) == FileSystemRights.ListDirectory;
                canRead = (rule.FileSystemRights & FileSystemRights.ReadAndExecute) == FileSystemRights.ReadAndExecute;
                canAllow = rule.AccessControlType != AccessControlType.Deny;
                if (canListDir && canRead && canAllow)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
    }
}
