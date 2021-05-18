namespace TimingWatch
{
    partial class TimingWatch
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
            this.FileImport = new System.Windows.Forms.Button();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.ConfirmKeys = new System.Windows.Forms.Button();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileImport
            // 
            this.FileImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileImport.Location = new System.Drawing.Point(12, 12);
            this.FileImport.Name = "FileImport";
            this.FileImport.Size = new System.Drawing.Size(250, 33);
            this.FileImport.TabIndex = 4;
            this.FileImport.Text = "导 入 密 钥 文 件";
            this.FileImport.UseVisualStyleBackColor = true;
            this.FileImport.Click += new System.EventHandler(this.FileImport_Click);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(12, 51);
            this.PasswordInput.MaximumSize = new System.Drawing.Size(250, 100);
            this.PasswordInput.MinimumSize = new System.Drawing.Size(250, 100);
            this.PasswordInput.Multiline = true;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PasswordInput.Size = new System.Drawing.Size(250, 100);
            this.PasswordInput.TabIndex = 5;
            this.PasswordInput.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // ConfirmKeys
            // 
            this.ConfirmKeys.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmKeys.Location = new System.Drawing.Point(12, 157);
            this.ConfirmKeys.Name = "ConfirmKeys";
            this.ConfirmKeys.Size = new System.Drawing.Size(250, 33);
            this.ConfirmKeys.TabIndex = 6;
            this.ConfirmKeys.Text = "确 认 输 入 密 钥";
            this.ConfirmKeys.UseVisualStyleBackColor = true;
            this.ConfirmKeys.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.BackColor = System.Drawing.SystemColors.Window;
            this.PasswordLable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLable.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.PasswordLable.Location = new System.Drawing.Point(13, 52);
            this.PasswordLable.MaximumSize = new System.Drawing.Size(248, 98);
            this.PasswordLable.MinimumSize = new System.Drawing.Size(248, 98);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(248, 98);
            this.PasswordLable.TabIndex = 7;
            this.PasswordLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PasswordLable.Click += new System.EventHandler(this.Label_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimingWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 290);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.ConfirmKeys);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.FileImport);
            this.Name = "TimingWatch";
            this.Text = "取消定时关机工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button FileImport;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button ConfirmKeys;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.Button button1;
    }
}

