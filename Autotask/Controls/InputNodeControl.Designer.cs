namespace Autotask.Controls
{
    partial class InputNodeControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elementControl1 = new Autotask.Controls.ElementControl();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.elementControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxText, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 214);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(3, 190);
            this.labelText.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(41, 12);
            this.labelText.TabIndex = 7;
            this.labelText.Text = "文本：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "元素：";
            // 
            // elementControl1
            // 
            this.elementControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementControl1.Location = new System.Drawing.Point(83, 3);
            this.elementControl1.Name = "elementControl1";
            this.elementControl1.Size = new System.Drawing.Size(404, 178);
            this.elementControl1.TabIndex = 4;
            // 
            // textBoxText
            // 
            this.textBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxText.Location = new System.Drawing.Point(83, 187);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(404, 21);
            this.textBoxText.TabIndex = 8;
            this.textBoxText.Leave += new System.EventHandler(this.textBoxText_Leave);
            // 
            // InputNodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InputNodeControl";
            this.Size = new System.Drawing.Size(490, 214);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private ElementControl elementControl1;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TextBox textBoxText;
    }
}
