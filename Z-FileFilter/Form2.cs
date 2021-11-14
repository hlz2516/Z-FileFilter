using System;
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
    }
}
