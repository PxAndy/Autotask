namespace Autotask
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewTask = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDailyRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTask});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(304, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemTask
            // 
            this.toolStripMenuItemTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRecord,
            this.toolStripMenuItemNew,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemRemove,
            this.toolStripSeparator,
            this.toolStripMenuItemEnable,
            this.toolStripMenuItemDisable,
            this.toolStripSeparator1,
            this.toolStripMenuItemRun});
            this.toolStripMenuItemTask.Name = "toolStripMenuItemTask";
            this.toolStripMenuItemTask.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItemTask.Text = "任务";
            // 
            // toolStripMenuItemRecord
            // 
            this.toolStripMenuItemRecord.Name = "toolStripMenuItemRecord";
            this.toolStripMenuItemRecord.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRecord.Text = "录制";
            this.toolStripMenuItemRecord.Click += new System.EventHandler(this.toolStripMenuItemRecord_Click);
            // 
            // toolStripMenuItemNew
            // 
            this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
            this.toolStripMenuItemNew.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemNew.Text = "新建";
            this.toolStripMenuItemNew.Click += new System.EventHandler(this.toolStripMenuItemNew_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemEdit.Text = "编辑";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            this.toolStripMenuItemRemove.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRemove.Text = "删除";
            this.toolStripMenuItemRemove.Click += new System.EventHandler(this.toolStripMenuItemRemove_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItemEnable
            // 
            this.toolStripMenuItemEnable.Name = "toolStripMenuItemEnable";
            this.toolStripMenuItemEnable.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemEnable.Text = "启用";
            this.toolStripMenuItemEnable.Click += new System.EventHandler(this.toolStripMenuItemEnable_Click);
            // 
            // toolStripMenuItemDisable
            // 
            this.toolStripMenuItemDisable.Name = "toolStripMenuItemDisable";
            this.toolStripMenuItemDisable.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDisable.Text = "禁用";
            this.toolStripMenuItemDisable.Click += new System.EventHandler(this.toolStripMenuItemDisable_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItemRun
            // 
            this.toolStripMenuItemRun.Name = "toolStripMenuItemRun";
            this.toolStripMenuItemRun.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRun.Text = "运行";
            this.toolStripMenuItemRun.Click += new System.EventHandler(this.toolStripMenuItemRun_Click);
            // 
            // listViewTask
            // 
            this.listViewTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderDailyRange});
            this.listViewTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTask.FullRowSelect = true;
            this.listViewTask.GridLines = true;
            this.listViewTask.Location = new System.Drawing.Point(0, 25);
            this.listViewTask.Name = "listViewTask";
            this.listViewTask.Size = new System.Drawing.Size(304, 336);
            this.listViewTask.TabIndex = 2;
            this.listViewTask.UseCompatibleStateImageBehavior = false;
            this.listViewTask.View = System.Windows.Forms.View.Details;
            this.listViewTask.SelectedIndexChanged += new System.EventHandler(this.listViewTask_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "名称";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderDailyRange
            // 
            this.columnHeaderDailyRange.Text = "执行区间";
            this.columnHeaderDailyRange.Width = 150;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 361);
            this.Controls.Add(this.listViewTask);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autotask";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTask;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisable;
        private System.Windows.Forms.ListView listViewTask;
        private System.Windows.Forms.ColumnHeader columnHeaderDailyRange;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRun;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecord;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
    }
}