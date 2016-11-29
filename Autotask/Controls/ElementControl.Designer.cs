namespace Autotask.Controls
{
    partial class ElementControl
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTag = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTag, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxClass, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxType, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxContent, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 206);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(83, 63);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(281, 21);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签：";
            // 
            // comboBoxTag
            // 
            this.comboBoxTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTag.FormattingEnabled = true;
            this.comboBoxTag.Items.AddRange(new object[] {
            "INPUT",
            "BUTTON",
            "A",
            "LABEL",
            "DIV",
            "SPAN"});
            this.comboBoxTag.Location = new System.Drawing.Point(83, 3);
            this.comboBoxTag.Name = "comboBoxTag";
            this.comboBoxTag.Size = new System.Drawing.Size(281, 20);
            this.comboBoxTag.TabIndex = 1;
            this.comboBoxTag.SelectedIndexChanged += new System.EventHandler(this.comboBoxTag_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID：";
            // 
            // textBoxId
            // 
            this.textBoxId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxId.Location = new System.Drawing.Point(83, 33);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(281, 21);
            this.textBoxId.TabIndex = 3;
            this.textBoxId.Leave += new System.EventHandler(this.textBoxId_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class:";
            // 
            // textBoxClass
            // 
            this.textBoxClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxClass.Location = new System.Drawing.Point(83, 93);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(281, 21);
            this.textBoxClass.TabIndex = 6;
            this.textBoxClass.Leave += new System.EventHandler(this.textBoxClass_Leave);
            // 
            // textBoxType
            // 
            this.textBoxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxType.Location = new System.Drawing.Point(83, 123);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(281, 21);
            this.textBoxType.TabIndex = 9;
            this.textBoxType.Leave += new System.EventHandler(this.textBoxType_Leave);
            // 
            // textBoxContent
            // 
            this.textBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxContent.Location = new System.Drawing.Point(83, 153);
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(281, 21);
            this.textBoxContent.TabIndex = 11;
            this.textBoxContent.Leave += new System.EventHandler(this.textBoxContent_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Type：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Content：";
            // 
            // ElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ElementControl";
            this.Size = new System.Drawing.Size(367, 206);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}
