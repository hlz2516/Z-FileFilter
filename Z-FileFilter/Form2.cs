using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Z_FileFilter
{
    public partial class Form2 : Form
    {
        delegate void AsyncResultTab();

        private static Form2 resultTable;

        public Form2()
        {
            InitializeComponent();
            resultTable = this;
            listView1.Columns.Add("INDEX", "序号", 50, HorizontalAlignment.Center, 1);
            listView1.Columns.Add("NAME", "文件名", 150, HorizontalAlignment.Center, 1);
            listView1.Columns.Add("SIZE", "大小(MB)", 60, HorizontalAlignment.Center, 1);
            listView1.Columns.Add("PATH", "文件路径", 250, HorizontalAlignment.Center, 1);
            listView1.Columns.Add("CREATE_TIME", "创建时间", 150, HorizontalAlignment.Center, 1);
            listView1.Columns.Add("LAST_MOD_TIME", "最后编辑时间", 150, HorizontalAlignment.Center, 1);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ProgressBar.Value = 0;
            LabelPercentage.Text = "0%";
            LabelFileCount.Text = "0";
            this.Update();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1.mainForm.CloseResultTable();
            e.Cancel = true; 
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            var items = listView1.SelectedItems[0].SubItems;
            ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            int index = listView1.Columns["PATH"].Index;
            psi.Arguments = "/e,/select," + items[index].Text;
            Process.Start(psi);
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            int n = listView1.SelectedItems.Count;
            if (n <= 0)
            {
                MessageBox.Show("请先选中你要拷贝的文件（可多选）!", "提示");
                return;
            }
            string targetPath = PublicTools.OpenFolderBrowserDialog();
            if (string.IsNullOrEmpty(targetPath))
            {
                return;
            }
            //set progress-bar attribute
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = n;

            List<string> filePaths = new List<string>();
            int index = listView1.Columns["PATH"].Index;
            for (int i = 0; i < n; i++)
            {
                filePaths.Add(listView1.SelectedItems[i].SubItems[index].Text);
            }
            //开启一个后台线程做遍历拷贝的操作
            FileOpration fileCopy = new FileOpration(targetPath,filePaths);
            fileCopy.updProgress = UpdateProgressBar;
            Thread thread = new Thread(fileCopy.CopyEvent);
            thread.IsBackground = true;
            thread.Start();
        }
        
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int n = listView1.SelectedItems.Count;
            if (n <= 0)
            {
                MessageBox.Show("请先选中你要删除的文件（可多选）!", "提示");
                return;
            }
            //删除前先提示用户总计m个可删除文件，n个不可删除文件，问是否开始删除
            List<int> indexs = new List<int>();
            int idx = listView1.Columns["PATH"].Index;
            for (int i = 0; i < n; i++)
            {
                var item = listView1.SelectedItems[i];
                string path = item.SubItems[idx].Text;
                bool canDel = PublicTools.CheckDelPermissionOnFile(path);
                if (!canDel)
                {
                    indexs.Add(int.Parse(item.Text));
                }
            }
            var res = MessageBox.Show("共计" + (n - indexs.Count) + "个可删除文件，" +
                indexs.Count + "个不可删除文件(需要管理员权限)，是否开始删除？\n" +
                "若选择否，将自动为您标红不可删除的条目", "警告",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                int m = n - indexs.Count;
                //set progress-bar attribute
                ProgressBar.Minimum = 0;
                ProgressBar.Maximum = m;

                List<string> filePaths = new List<string>();
                int index = listView1.Columns["PATH"].Index;
                for (int i = 0; i < m; i++)
                {
                    filePaths.Add(listView1.SelectedItems[i].SubItems[index].Text);
                }
                FileOpration fileDel = new FileOpration(filePaths);
                fileDel.updProgress = UpdateProgressBar;
                Thread thread = new Thread(fileDel.DeleteEvent);
                thread.IsBackground = true;
                thread.Start();
            }
            else if (res == DialogResult.No)
            {
                //将不可删除的条目的序号标红
                foreach (var index in indexs)
                {
                    var item = listView1.Items[index - 1];
                    var _index = listView1.Columns["INDEX"].Index;
                    item.SubItems[_index].ForeColor = Color.Red;
                }
            }
        }

        public void UpdateProgressBar(int curFileCount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AsyncResultTab(delegate() {
                    int barMaxSize = ProgressBar.Maximum;
                    double percentage = curFileCount * 1.0 / barMaxSize * 100;
                    ProgressBar.Value = curFileCount;
                    LabelPercentage.Text = percentage.ToString("0.00") + "%";
                    ProgressBar.Update();
                    LabelPercentage.Update();
                }));
            }
        }

        class FileOpration
        {
            public delegate void UpdProgress(int curSize);

            string targetPath;
            List<string> filePaths;
            public UpdProgress updProgress;

            public FileOpration() { }
            public FileOpration(List<string> _filePaths)
            {
                filePaths = _filePaths;
            }
            public FileOpration(string _targetPath,List<string> _filePaths)
            {
                filePaths = _filePaths;
                targetPath = _targetPath;
            }

            public void CopyEvent()
            {
                try
                {
                    for (int i = 0; i < filePaths.Count; i++)
                    {
                        FileInfo fileInfo = new FileInfo(filePaths[i]);
                        //拷贝至指定目录，允许覆盖
                        fileInfo.CopyTo(targetPath + "\\" + fileInfo.Name, true);
                        //做一个updEvent来更新界面
                        updProgress(i + 1);
                    }
                    MessageBox.Show("已完成拷贝任务！", "提示");
                    
                }
                catch (Exception e)
                {
                    PublicTools.WriteLogs("logs", "error", "copy files error!" + e.Message);
                }
            }

            public void DeleteEvent()
            {
                try
                {
                    for (int i = 0; i < filePaths.Count; i++)
                    {
                        File.Delete(filePaths[i]);
                        updProgress(i + 1);
                    }
                    var form = Form2.resultTable;
                    if (form.InvokeRequired)
                    {
                        form.Invoke(new AsyncResultTab(delegate () {
                            form.FreshTable();
                        }));
                    }

                    MessageBox.Show("已完成删除任务！", "提示");
                }
                catch (Exception e)
                {
                    PublicTools.WriteLogs("logs", "error", "delete files error!" + e.Message);
                }
            }
        }

        private void LabelPercentage_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            if (BtnSelectAll.Text.Equals("全选"))
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Selected = true;
                }
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FreshTable();
            }
        }

        private void FreshTable()
        {
            // 遍历条目，依次检测其存在性，是否被标记，然后刷新
            foreach (ListViewItem item in listView1.Items)
            {
                int pathIndex = listView1.Columns["PATH"].Index;
                int indexIndex = listView1.Columns["INDEX"].Index;
                var path = item.SubItems[pathIndex].Text;
                var indexColor = item.SubItems[indexIndex].ForeColor;
                if (!File.Exists(path))
                {
                    listView1.Items.Remove(item);
                    continue;
                }
                if (indexColor == Color.Red)
                {
                    item.SubItems[indexIndex].ForeColor = Color.Black;
                }
            }
            //更新文件数量
            LabelFileCount.Text = listView1.Items.Count.ToString();
        }
    }
}
