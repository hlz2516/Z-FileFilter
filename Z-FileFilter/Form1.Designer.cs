
namespace Z_FileFilter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FilePathInput = new System.Windows.Forms.TextBox();
            this.LabelFilePath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.HelpDocBtn = new System.Windows.Forms.Button();
            this.Value5 = new System.Windows.Forms.TextBox();
            this.Sign5 = new System.Windows.Forms.ComboBox();
            this.Condition5 = new System.Windows.Forms.ComboBox();
            this.Value4 = new System.Windows.Forms.TextBox();
            this.Value3 = new System.Windows.Forms.TextBox();
            this.Sign4 = new System.Windows.Forms.ComboBox();
            this.Condition4 = new System.Windows.Forms.ComboBox();
            this.Sign3 = new System.Windows.Forms.ComboBox();
            this.Condition3 = new System.Windows.Forms.ComboBox();
            this.Sign = new System.Windows.Forms.ComboBox();
            this.IsRecursion = new System.Windows.Forms.ComboBox();
            this.Value2 = new System.Windows.Forms.TextBox();
            this.Sign2 = new System.Windows.Forms.ComboBox();
            this.Condition2 = new System.Windows.Forms.ComboBox();
            this.Value1 = new System.Windows.Forms.TextBox();
            this.Sign1 = new System.Windows.Forms.ComboBox();
            this.Condition1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ResultTabSwitch = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilePathInput
            // 
            this.FilePathInput.Location = new System.Drawing.Point(126, 30);
            this.FilePathInput.Name = "FilePathInput";
            this.FilePathInput.Size = new System.Drawing.Size(391, 25);
            this.FilePathInput.TabIndex = 0;
            // 
            // LabelFilePath
            // 
            this.LabelFilePath.AutoSize = true;
            this.LabelFilePath.Location = new System.Drawing.Point(53, 33);
            this.LabelFilePath.Name = "LabelFilePath";
            this.LabelFilePath.Size = new System.Drawing.Size(67, 15);
            this.LabelFilePath.TabIndex = 1;
            this.LabelFilePath.Text = "目录路径";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.HelpDocBtn);
            this.groupBox1.Controls.Add(this.Value5);
            this.groupBox1.Controls.Add(this.Sign5);
            this.groupBox1.Controls.Add(this.Condition5);
            this.groupBox1.Controls.Add(this.Value4);
            this.groupBox1.Controls.Add(this.Value3);
            this.groupBox1.Controls.Add(this.Sign4);
            this.groupBox1.Controls.Add(this.Condition4);
            this.groupBox1.Controls.Add(this.Sign3);
            this.groupBox1.Controls.Add(this.Condition3);
            this.groupBox1.Controls.Add(this.Sign);
            this.groupBox1.Controls.Add(this.IsRecursion);
            this.groupBox1.Controls.Add(this.Value2);
            this.groupBox1.Controls.Add(this.Sign2);
            this.groupBox1.Controls.Add(this.Condition2);
            this.groupBox1.Controls.Add(this.Value1);
            this.groupBox1.Controls.Add(this.Sign1);
            this.groupBox1.Controls.Add(this.Condition1);
            this.groupBox1.Location = new System.Drawing.Point(46, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 518);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索条件";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(221, 460);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 30);
            this.button4.TabIndex = 19;
            this.button4.Text = "test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(35, 460);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 30);
            this.button2.TabIndex = 18;
            this.button2.Text = "一键清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HelpDocBtn
            // 
            this.HelpDocBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HelpDocBtn.Location = new System.Drawing.Point(350, 460);
            this.HelpDocBtn.Name = "HelpDocBtn";
            this.HelpDocBtn.Size = new System.Drawing.Size(150, 30);
            this.HelpDocBtn.TabIndex = 17;
            this.HelpDocBtn.Text = "帮助文档";
            this.HelpDocBtn.UseVisualStyleBackColor = true;
            this.HelpDocBtn.Click += new System.EventHandler(this.HelpDocBtn_Click);
            // 
            // Value5
            // 
            this.Value5.Location = new System.Drawing.Point(367, 405);
            this.Value5.Name = "Value5";
            this.Value5.Size = new System.Drawing.Size(133, 25);
            this.Value5.TabIndex = 16;
            // 
            // Sign5
            // 
            this.Sign5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sign5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sign5.FormattingEnabled = true;
            this.Sign5.Location = new System.Drawing.Point(258, 405);
            this.Sign5.Name = "Sign5";
            this.Sign5.Size = new System.Drawing.Size(86, 23);
            this.Sign5.TabIndex = 15;
            // 
            // Condition5
            // 
            this.Condition5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Condition5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Condition5.FormattingEnabled = true;
            this.Condition5.Items.AddRange(new object[] {
            "1-文件大小(MB)",
            "2-文件名称",
            "3-创建时间",
            "4-最后编辑时间"});
            this.Condition5.Location = new System.Drawing.Point(35, 406);
            this.Condition5.Name = "Condition5";
            this.Condition5.Size = new System.Drawing.Size(199, 23);
            this.Condition5.TabIndex = 14;
            this.Condition5.SelectionChangeCommitted += new System.EventHandler(this.Condition5_SelectionChangeCommitted);
            // 
            // Value4
            // 
            this.Value4.Location = new System.Drawing.Point(367, 329);
            this.Value4.Name = "Value4";
            this.Value4.Size = new System.Drawing.Size(133, 25);
            this.Value4.TabIndex = 13;
            // 
            // Value3
            // 
            this.Value3.Location = new System.Drawing.Point(367, 254);
            this.Value3.Name = "Value3";
            this.Value3.Size = new System.Drawing.Size(133, 25);
            this.Value3.TabIndex = 12;
            // 
            // Sign4
            // 
            this.Sign4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sign4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sign4.FormattingEnabled = true;
            this.Sign4.Location = new System.Drawing.Point(258, 329);
            this.Sign4.Name = "Sign4";
            this.Sign4.Size = new System.Drawing.Size(86, 23);
            this.Sign4.TabIndex = 11;
            // 
            // Condition4
            // 
            this.Condition4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Condition4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Condition4.FormattingEnabled = true;
            this.Condition4.Items.AddRange(new object[] {
            "1-文件大小(MB)",
            "2-文件名称",
            "3-创建时间",
            "4-最后编辑时间"});
            this.Condition4.Location = new System.Drawing.Point(35, 330);
            this.Condition4.Name = "Condition4";
            this.Condition4.Size = new System.Drawing.Size(199, 23);
            this.Condition4.TabIndex = 10;
            this.Condition4.SelectionChangeCommitted += new System.EventHandler(this.Condition4_SelectionChangeCommitted);
            // 
            // Sign3
            // 
            this.Sign3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sign3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sign3.FormattingEnabled = true;
            this.Sign3.Location = new System.Drawing.Point(258, 254);
            this.Sign3.Name = "Sign3";
            this.Sign3.Size = new System.Drawing.Size(86, 23);
            this.Sign3.TabIndex = 9;
            // 
            // Condition3
            // 
            this.Condition3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Condition3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Condition3.FormattingEnabled = true;
            this.Condition3.Items.AddRange(new object[] {
            "1-文件大小(MB)",
            "2-文件名称",
            "3-创建时间",
            "4-最后编辑时间"});
            this.Condition3.Location = new System.Drawing.Point(35, 255);
            this.Condition3.Name = "Condition3";
            this.Condition3.Size = new System.Drawing.Size(199, 23);
            this.Condition3.TabIndex = 8;
            this.Condition3.SelectionChangeCommitted += new System.EventHandler(this.Condition3_SelectionChangeCommitted);
            // 
            // Sign
            // 
            this.Sign.BackColor = System.Drawing.SystemColors.Window;
            this.Sign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sign.FormattingEnabled = true;
            this.Sign.Items.AddRange(new object[] {
            "1-是",
            "2-否"});
            this.Sign.Location = new System.Drawing.Point(258, 54);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(86, 23);
            this.Sign.TabIndex = 7;
            // 
            // IsRecursion
            // 
            this.IsRecursion.Enabled = false;
            this.IsRecursion.FormattingEnabled = true;
            this.IsRecursion.Location = new System.Drawing.Point(35, 55);
            this.IsRecursion.Name = "IsRecursion";
            this.IsRecursion.Size = new System.Drawing.Size(199, 23);
            this.IsRecursion.TabIndex = 6;
            this.IsRecursion.Text = "是否递归搜索";
            // 
            // Value2
            // 
            this.Value2.Location = new System.Drawing.Point(367, 185);
            this.Value2.Name = "Value2";
            this.Value2.Size = new System.Drawing.Size(133, 25);
            this.Value2.TabIndex = 5;
            // 
            // Sign2
            // 
            this.Sign2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sign2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sign2.FormattingEnabled = true;
            this.Sign2.Location = new System.Drawing.Point(258, 185);
            this.Sign2.Name = "Sign2";
            this.Sign2.Size = new System.Drawing.Size(86, 23);
            this.Sign2.TabIndex = 4;
            // 
            // Condition2
            // 
            this.Condition2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Condition2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Condition2.FormattingEnabled = true;
            this.Condition2.Items.AddRange(new object[] {
            "1-文件大小(MB)",
            "2-文件名称",
            "3-创建时间",
            "4-最后编辑时间"});
            this.Condition2.Location = new System.Drawing.Point(35, 185);
            this.Condition2.Name = "Condition2";
            this.Condition2.Size = new System.Drawing.Size(199, 23);
            this.Condition2.TabIndex = 3;
            this.Condition2.SelectionChangeCommitted += new System.EventHandler(this.Condition2_SelectionChangeCommitted);
            // 
            // Value1
            // 
            this.Value1.Location = new System.Drawing.Point(367, 121);
            this.Value1.Name = "Value1";
            this.Value1.Size = new System.Drawing.Size(133, 25);
            this.Value1.TabIndex = 2;
            // 
            // Sign1
            // 
            this.Sign1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sign1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sign1.FormattingEnabled = true;
            this.Sign1.Location = new System.Drawing.Point(258, 121);
            this.Sign1.Name = "Sign1";
            this.Sign1.Size = new System.Drawing.Size(86, 23);
            this.Sign1.TabIndex = 1;
            // 
            // Condition1
            // 
            this.Condition1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Condition1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Condition1.FormattingEnabled = true;
            this.Condition1.Items.AddRange(new object[] {
            "1-文件大小(MB)",
            "2-文件名称",
            "3-创建时间",
            "4-最后编辑时间"});
            this.Condition1.Location = new System.Drawing.Point(35, 121);
            this.Condition1.Name = "Condition1";
            this.Condition1.Size = new System.Drawing.Size(199, 23);
            this.Condition1.TabIndex = 0;
            this.Condition1.SelectionChangeCommitted += new System.EventHandler(this.Condition1_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 607);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(479, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResultTabSwitch
            // 
            this.ResultTabSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.ResultTabSwitch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResultTabSwitch.Location = new System.Drawing.Point(601, 75);
            this.ResultTabSwitch.Name = "ResultTabSwitch";
            this.ResultTabSwitch.Size = new System.Drawing.Size(19, 507);
            this.ResultTabSwitch.TabIndex = 6;
            this.ResultTabSwitch.Text = ">";
            this.ResultTabSwitch.UseVisualStyleBackColor = false;
            this.ResultTabSwitch.Click += new System.EventHandler(this.ResultTabSwitch_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(523, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 26);
            this.button3.TabIndex = 7;
            this.button3.Text = "选择目录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 673);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ResultTabSwitch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LabelFilePath);
            this.Controls.Add(this.FilePathInput);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Z-FileFilter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePathInput;
        private System.Windows.Forms.Label LabelFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Value2;
        private System.Windows.Forms.ComboBox Sign2;
        private System.Windows.Forms.ComboBox Condition2;
        private System.Windows.Forms.TextBox Value1;
        private System.Windows.Forms.ComboBox Sign1;
        private System.Windows.Forms.ComboBox Condition1;
        private System.Windows.Forms.ComboBox Sign;
        private System.Windows.Forms.ComboBox IsRecursion;
        private System.Windows.Forms.TextBox Value5;
        private System.Windows.Forms.ComboBox Sign5;
        private System.Windows.Forms.ComboBox Condition5;
        private System.Windows.Forms.TextBox Value4;
        private System.Windows.Forms.TextBox Value3;
        private System.Windows.Forms.ComboBox Sign4;
        private System.Windows.Forms.ComboBox Condition4;
        private System.Windows.Forms.ComboBox Sign3;
        private System.Windows.Forms.ComboBox Condition3;
        public System.Windows.Forms.Button ResultTabSwitch;
        private System.Windows.Forms.Button HelpDocBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

