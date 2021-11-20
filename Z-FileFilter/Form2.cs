using System;
using System.IO;
using System.Windows.Forms;

namespace Z_FileFilter
{
    public partial class Form2 : Form
    {
        public ListViewNF GetListView() { return listView1; }

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("文件名", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("大小(MB)", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("文件路径", 250, HorizontalAlignment.Left);
            listView1.Columns.Add("创建时间", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("最后编辑时间", 150, HorizontalAlignment.Left);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1.mainForm.ResultTabSwitch.Text = ">";
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
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + items[2].Text;
            System.Diagnostics.Process.Start(psi);
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            string targetPath = PublicTools.OpenFolderBrowserDialog();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var item = listView1.Items[i];
                //System.Diagnostics.Debug.WriteLine(item.SubItems[2].Text);
                FileInfo fileInfo = new FileInfo(item.SubItems[2].Text);
                //拷贝至指定目录，允许覆盖
                fileInfo.CopyTo(targetPath + "\\" + fileInfo.Name,true);
            }
            MessageBox.Show("已完成拷贝！", "提示", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("你确定要删除结果表里所有的文件吗？\n" +
                "如果确定，请点击是，如果不确定，请点击否", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                for (int i = listView1.Items.Count-1; i >=0 ; i--)
                {
                    var item = listView1.Items[i];
                    FileInfo fileInfo = new FileInfo(item.SubItems[2].Text);
                    fileInfo.Delete();
                    listView1.Items.Remove(item);
                }
                MessageBox.Show("已删除完毕！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (res == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
