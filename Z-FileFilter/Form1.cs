using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Z_FileFilter
{
    public partial class Form1 : Form
    {
        delegate void AsynUpdateUI();

        public static bool isSearching = false;
        public static bool wantStop = false;
        private List<Condition> conditions;
        private Point startPos;
        private Color btnColor;
        private Color btnStopColor;

        public Form2 resultTab;
        public static Form1 mainForm;

        public Form1()
        {
            InitializeComponent();
            //初始化参数
            mainForm = this;
            resultTab = new Form2();
            btnColor = Color.FromArgb(0,255,127);
            btnStopColor = Color.Red;
            button1.BackColor = btnColor;
        }
        private void GiveSignValues(ComboBox condition, ComboBox sign)
        {
            sign.BeginUpdate();
            sign.Items.Clear();
            string strCondition = condition.SelectedItem.ToString();
            switch (strCondition)
            {
                case "1-文件大小(MB)":
                    sign.Items.Add("<");
                    sign.Items.Add(">");
                    //sign.Items.AddRange(new string[]
                    //{
                    //    ">","<"
                    //});
                    break;
                case "2-文件名称":
                    sign.Items.AddRange(new string[]
                    {
                        "like","unlike"
                    });
                    break;
                case "3-创建时间":
                    sign.Items.AddRange(new string[]
                    {
                        "之前","之后"
                    });
                    break;
                case "4-最后编辑时间":
                    sign.Items.AddRange(new string[]
                    {
                        "之前","之后"
                    });
                    break;
                default:
                    break;
            }
            sign.EndUpdate();
        }
        private void Condition1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Sign1.Text = "";
            GiveSignValues(Condition1, Sign1);
        }

        private void Condition2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Sign2.Text = "";
            GiveSignValues(Condition2, Sign2);
        }

        private void Condition3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Sign3.Text = "";
            GiveSignValues(Condition3, Sign3);
        }

        private void Condition4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Sign4.Text = "";
            GiveSignValues(Condition4, Sign4);
        }

        private void Condition5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Sign5.Text = "";
            GiveSignValues(Condition5, Sign5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dirPath = FilePathInput.Text;
            if(dirPath == null || dirPath.Equals(""))
            {
                MessageBox.Show("无文字输入！请输入有效的目录路径","警告",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (isSearching)
            {
                button1.Text = "搜索";
                button1.BackColor = btnColor;
                wantStop = true;
                return;
            }
            if(Directory.Exists(dirPath) == true)
            {
                string[] types = new string[5];
                string[] opers = new string[5];
                string[] vals = new string[5];
                Condition[] cons = new Condition[5];

                types[0] = Condition1.Text;
                opers[0] = Sign1.Text;
                vals[0] = Value1.Text;
                cons[0] = new Condition(types[0], opers[0], vals[0]);

                types[1] = Condition2.Text;
                opers[1] = Sign2.Text;
                vals[1] = Value2.Text;
                cons[1] = new Condition(types[1], opers[1], vals[1]);

                types[2] = Condition3.Text;
                opers[2] = Sign3.Text;
                vals[2] = Value3.Text;
                cons[2] = new Condition(types[2], opers[2], vals[2]);

                types[3] = Condition4.Text;
                opers[3] = Sign4.Text;
                vals[3] = Value4.Text;
                cons[3] = new Condition(types[3], opers[3], vals[3]);

                types[4] = Condition5.Text;
                opers[4] = Sign5.Text;
                vals[4] = Value5.Text;
                cons[4] = new Condition(types[4], opers[4], vals[4]);
                //检查各条件之间是否出现矛盾，有任意一个矛盾出现则提示用户
                bool res =  new ConditionChecker(cons.ToList()).CheckConditions(ref conditions);
                PublicTools.WriteLogs("logs", "info", "isConflicted:" + res);
                if (true == res)
                {
                    DialogResult result = MessageBox.Show("检测到您输入的一些条件存在冲突，" +
                        "请重新检查您输入的条件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                else
                {
                    OpenResultTable();
                    //将各个条件封装，带入到检索操作中;检索可能需要时间所以需要另开线程
                    if (Sign.Text.Equals("2-否"))
                    {
                        Thread_TraverseFiles traverse = new Thread_TraverseFiles(dirPath, conditions);
                        traverse.finishEvent += DoFinish;
                        traverse.AddEvent += PutIntoResultTable;
                        Thread thread = new Thread(traverse.DoNoRecursively);
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else
                    {
                        Thread_TraverseFiles traverse = new Thread_TraverseFiles(dirPath, conditions);
                        traverse.finishEvent += DoFinish;
                        traverse.AddEvent += PutIntoResultTable;
                        Thread thread = new Thread(traverse.DoRecursively);
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    isSearching = true;
                    button1.Text = "停止";
                    button1.BackColor = btnStopColor;
                }
            }
            else
            {
                MessageBox.Show("该路径不存在！请重新输入","警告",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void PutIntoResultTable(FileInfo fileInfo)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(
                    delegate ()
                    {
                        ListViewNF listView = resultTab.listView1;
                        var item = new ListViewItem();
                        item.Text = listView.Items.Count +1 + "";
                        item.SubItems.Add(fileInfo.Name);
                        double size = fileInfo.Length * 1.0 / 1024 / 1024;
                        item.SubItems.Add(Convert.ToDouble(size).ToString("0.00"));
                        item.SubItems.Add(fileInfo.FullName);
                        item.SubItems.Add(fileInfo.CreationTime.ToString());
                        item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                        listView.BeginUpdate();
                        listView.Items.Insert(0, item);
                        listView.EndUpdate();
                    }));
            }
        }

        public void DoFinish()
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(
                    delegate ()
                    {
                        this.button1.Text = "搜索";
                        this.button1.BackColor = btnColor;
                        this.conditions = null;
                        Form1.isSearching = false;
                        Form1.wantStop = false;
                        resultTab.LabelFileCount.Text = resultTab.listView1.Items.Count.ToString();
                    }));
            }
        }
        //为了共享静态变量，将该类作为Form1的内部类
        class Thread_TraverseFiles
        {
            public delegate void FinishEvent();
            public delegate void AddToResultTableEvent(FileInfo fileInfo);

            string filePath;
            List<Condition> conditions;
            public FinishEvent finishEvent;
            public AddToResultTableEvent AddEvent;

            public Thread_TraverseFiles() { }
            public Thread_TraverseFiles(string filePath, List<Condition> conditions)
            {
                this.filePath = filePath;
                this.conditions = conditions;
            }

            public void DoRecursively()
            {
                Stack<string> stack = new Stack<string>();
                stack.Push(filePath);
                while (stack.Count != 0)
                {
                    try
                    {
                        string curFilePath = stack.Pop();
                        if (Directory.Exists(curFilePath) == true)
                        {
                            //如果这个目录可读，获取这个目录下所有的文件和目录，加入到stack中
                            FileInfo curFilePathInfo = new FileInfo(curFilePath);
                            DirectoryInfo directoryInfo = new DirectoryInfo(curFilePath);
                            if (PublicTools.IsSystemHidden(directoryInfo))
                            {
                                continue;
                            }

                            bool canList = PublicTools.CheckPermissionOnDir(curFilePath);
                            if (!canList)
                            {
                                continue;
                            }
                            string[] subDirAndFiles = Directory.GetFileSystemEntries(curFilePath);
                            foreach (var path in subDirAndFiles)
                            {
                                stack.Push(path);
                            }
                        }
                        else
                        {
                            if (wantStop)
                            {
                                finishEvent();
                                return;
                            }
                            //对文件操作的逻辑
                            if (curFilePath.Length > 259)
                            {
                                continue;
                            }
                            FileInfo fileInfo = new FileInfo(curFilePath);
                            bool res = FileFilter.DoFilter(fileInfo, conditions);
                            if (res == true)
                            {
                                AddEvent(fileInfo);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PublicTools.WriteLogs("logs", "error", ex.ToString());
                    }
                }
                finishEvent();
            }

            public void DoNoRecursively()
            {
                if (Directory.Exists(filePath) == true)
                {
                    FileInfo curFilePathInfo = new FileInfo(filePath);
                    DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
                    if (PublicTools.IsSystemHidden(directoryInfo))
                    {
                        PublicTools.WriteLogs("logs", "error", "this is a hidden directory[" + filePath + "]");
                        finishEvent();
                        return;
                    }
                    //在这里判定目录的访问控制
                    bool canList = PublicTools.CheckPermissionOnDir(filePath);
                    if (!canList)
                    {
                        PublicTools.WriteLogs("logs","error","you dont have permission " +
                            "to open directory[" + filePath + "]");
                        finishEvent();
                        return;
                    }
                    try
                    {
                        string[] files = Directory.GetFiles(filePath);
                        foreach (var file in files)
                        {
                            //判断用户是否按下停止键，若按下，终止查找线程
                            if (wantStop == true)
                            {
                                finishEvent();
                                return;
                            }
                            //对文件操作的逻辑
                            FileInfo fileInfo = new FileInfo(file);
                            if (FileFilter.DoFilter(fileInfo, conditions))
                            {
                                AddEvent(fileInfo);
                            }
                        }
                        finishEvent();
                    }
                    catch (Exception ex)
                    {
                        PublicTools.WriteLogs("logs", "error", ex.ToString());
                    }
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            startPos = this.Location;
        }

        private void ResultTabSwitch_Click(object sender, EventArgs e)
        {
            string sign = ResultTabSwitch.Text;
            if (sign.Equals(">"))
            {
                OpenResultTable();
            }
            else if (sign.Equals("<"))
            {
                CloseResultTable();
            }
        }

        public void OpenResultTable()
        {
            //先处理查询界面的X位置
            int sumOfWidth = this.ClientSize.Width + resultTab.ClientSize.Width;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int searchTabX = (screenWidth - sumOfWidth) / 2;
            this.Location = new Point(searchTabX, this.Location.Y);
            //再处理结果表的X位置
            int resTabX = searchTabX + this.ClientSize.Width;
            resultTab.Show();
            resultTab.Location = new Point(resTabX, this.Location.Y);
            ResultTabSwitch.Text = "<";
        }

        public void CloseResultTable()
        {
            resultTab.Hide();
            this.Location = startPos;
            ResultTabSwitch.Text = ">";
        }

        private void HelpDocBtn_Click(object sender, EventArgs e)
        {
            string docPath = AppDomain.CurrentDomain.BaseDirectory + "\\helpdoc.txt";
            if (!File.Exists(docPath))
            {
                File.Create(docPath).Close();
                StreamWriter sw = new StreamWriter(docPath, true, System.Text.Encoding.UTF8);
                string a = Properties.Resources.ResourceManager.GetObject("helpdoc").ToString();
                sw.Write(Properties.Resources.helpdoc);
                sw.Flush();
                sw.Close();
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            info.FileName = "helpdoc.txt";
            info.Arguments = "";
            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {
                PublicTools.WriteLogs("logs", "error", ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sign.SelectedItem = null;
            Sign1.SelectedItem = null;
            Sign2.SelectedItem = null;
            Sign3.SelectedItem = null;
            Sign4.SelectedItem = null;
            Sign5.SelectedItem = null;

            Condition1.SelectedItem = null;
            Condition2.SelectedItem = null;
            Condition3.SelectedItem = null;
            Condition4.SelectedItem = null;
            Condition5.SelectedItem = null;

            Value1.Text = "";
            Value2.Text = "";
            Value3.Text = "";
            Value4.Text = "";
            Value5.Text = "";

            this.Update();

            conditions = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string targetPath = PublicTools.OpenFolderBrowserDialog();
            FilePathInput.Text = targetPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(
            PublicTools.CheckPermissionOnDir(FilePathInput.Text));
        }
    }

}
