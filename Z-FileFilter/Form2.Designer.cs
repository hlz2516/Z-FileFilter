
using System.Windows.Forms;

namespace Z_FileFilter
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnClear = new System.Windows.Forms.Button();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.LabelProgress = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelFileCount = new System.Windows.Forms.Label();
            this.LabelPercentage = new System.Windows.Forms.Label();
            this.listView1 = new Z_FileFilter.ListViewNF();
            this.BtnSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(841, 622);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(80, 30);
            this.BtnClear.TabIndex = 5;
            this.BtnClear.Text = "清除";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.button5_Click);
            // 
            // CopyBtn
            // 
            this.CopyBtn.Location = new System.Drawing.Point(128, 622);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(100, 30);
            this.CopyBtn.TabIndex = 7;
            this.CopyBtn.Text = "拷贝至...";
            this.CopyBtn.UseVisualStyleBackColor = true;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(243, 622);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(100, 30);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // LabelProgress
            // 
            this.LabelProgress.AutoSize = true;
            this.LabelProgress.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelProgress.Location = new System.Drawing.Point(484, 628);
            this.LabelProgress.Name = "LabelProgress";
            this.LabelProgress.Size = new System.Drawing.Size(47, 19);
            this.LabelProgress.TabIndex = 9;
            this.LabelProgress.Text = "进度";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(533, 622);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(217, 30);
            this.ProgressBar.TabIndex = 10;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(378, 628);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 19);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "数量：";
            // 
            // LabelFileCount
            // 
            this.LabelFileCount.AutoSize = true;
            this.LabelFileCount.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelFileCount.Location = new System.Drawing.Point(428, 628);
            this.LabelFileCount.Name = "LabelFileCount";
            this.LabelFileCount.Size = new System.Drawing.Size(19, 19);
            this.LabelFileCount.TabIndex = 12;
            this.LabelFileCount.Text = "0";
            // 
            // LabelPercentage
            // 
            this.LabelPercentage.AutoSize = true;
            this.LabelPercentage.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelPercentage.Location = new System.Drawing.Point(756, 628);
            this.LabelPercentage.Name = "LabelPercentage";
            this.LabelPercentage.Size = new System.Drawing.Size(29, 19);
            this.LabelPercentage.TabIndex = 13;
            this.LabelPercentage.Text = "0%";
            this.LabelPercentage.Click += new System.EventHandler(this.LabelPercentage_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listView1.Location = new System.Drawing.Point(13, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(917, 592);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // BtnSelectAll
            // 
            this.BtnSelectAll.Location = new System.Drawing.Point(13, 622);
            this.BtnSelectAll.Name = "BtnSelectAll";
            this.BtnSelectAll.Size = new System.Drawing.Size(100, 30);
            this.BtnSelectAll.TabIndex = 14;
            this.BtnSelectAll.Text = "全选";
            this.BtnSelectAll.UseVisualStyleBackColor = true;
            this.BtnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 673);
            this.Controls.Add(this.BtnSelectAll);
            this.Controls.Add(this.LabelPercentage);
            this.Controls.Add(this.LabelFileCount);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.LabelProgress);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.CopyBtn);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "ResultTable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnClear;
        public ListViewNF listView1;
        private Button CopyBtn;
        private Button BtnDelete;
        private Label LabelProgress;
        private ProgressBar ProgressBar;
        private Label Label1;
        public Label LabelFileCount;
        private Label LabelPercentage;
        private Button BtnSelectAll;
    }
}