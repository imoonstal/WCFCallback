namespace FormClient
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReg = new System.Windows.Forms.Button();
            this.btnUnReg = new System.Windows.Forms.Button();
            this.tbDataView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(12, 12);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(118, 23);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnUnReg
            // 
            this.btnUnReg.Location = new System.Drawing.Point(136, 12);
            this.btnUnReg.Name = "btnUnReg";
            this.btnUnReg.Size = new System.Drawing.Size(112, 23);
            this.btnUnReg.TabIndex = 2;
            this.btnUnReg.Text = "UnRegister";
            this.btnUnReg.UseVisualStyleBackColor = true;
            this.btnUnReg.Click += new System.EventHandler(this.btnUnReg_Click);
            // 
            // tbDataView
            // 
            this.tbDataView.Location = new System.Drawing.Point(12, 41);
            this.tbDataView.Multiline = true;
            this.tbDataView.Name = "tbDataView";
            this.tbDataView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDataView.Size = new System.Drawing.Size(237, 137);
            this.tbDataView.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 190);
            this.Controls.Add(this.tbDataView);
            this.Controls.Add(this.btnUnReg);
            this.Controls.Add(this.btnReg);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnUnReg;
        private System.Windows.Forms.TextBox tbDataView;
    }
}

