namespace Autotask
{
    partial class FormRecord
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.listBoxTaskNodes = new System.Windows.Forms.ListBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 33);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(578, 525);
            this.webBrowser.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxTaskNodes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDone, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUrl.Location = new System.Drawing.Point(3, 3);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(578, 21);
            this.textBoxUrl.TabIndex = 0;
            // 
            // listBoxTaskNodes
            // 
            this.listBoxTaskNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTaskNodes.FormattingEnabled = true;
            this.listBoxTaskNodes.HorizontalScrollbar = true;
            this.listBoxTaskNodes.ItemHeight = 12;
            this.listBoxTaskNodes.Location = new System.Drawing.Point(587, 33);
            this.listBoxTaskNodes.Name = "listBoxTaskNodes";
            this.listBoxTaskNodes.Size = new System.Drawing.Size(194, 525);
            this.listBoxTaskNodes.TabIndex = 1;
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.Location = new System.Drawing.Point(706, 3);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 2;
            this.buttonDone.Text = "完成";
            this.buttonDone.UseVisualStyleBackColor = true;
            // 
            // FormRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录制";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.ListBox listBoxTaskNodes;
        private System.Windows.Forms.Button buttonDone;
    }
}

