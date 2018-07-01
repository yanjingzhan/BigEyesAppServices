namespace AESEncryptionTool
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Source = new System.Windows.Forms.TextBox();
            this.textEdit_Key = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_Target = new System.Windows.Forms.TextBox();
            this.simpleButton_simpleButton_Decrypt = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Encrypt = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Key.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Source);
            this.panel1.Controls.Add(this.textEdit_Key);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1832, 555);
            this.panel1.TabIndex = 2;
            // 
            // textBox_Source
            // 
            this.textBox_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Source.Location = new System.Drawing.Point(12, 83);
            this.textBox_Source.Multiline = true;
            this.textBox_Source.Name = "textBox_Source";
            this.textBox_Source.Size = new System.Drawing.Size(1808, 466);
            this.textBox_Source.TabIndex = 4;
            // 
            // textEdit_Key
            // 
            this.textEdit_Key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_Key.EditValue = "uioasldjkasldkjd";
            this.textEdit_Key.Location = new System.Drawing.Point(78, 21);
            this.textEdit_Key.Name = "textEdit_Key";
            this.textEdit_Key.Size = new System.Drawing.Size(1742, 36);
            this.textEdit_Key.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 29);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Key";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Target);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 555);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1832, 388);
            this.panel2.TabIndex = 3;
            // 
            // textBox_Target
            // 
            this.textBox_Target.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Target.Location = new System.Drawing.Point(12, 6);
            this.textBox_Target.Multiline = true;
            this.textBox_Target.Name = "textBox_Target";
            this.textBox_Target.Size = new System.Drawing.Size(1808, 382);
            this.textBox_Target.TabIndex = 0;
            // 
            // simpleButton_simpleButton_Decrypt
            // 
            this.simpleButton_simpleButton_Decrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_simpleButton_Decrypt.Location = new System.Drawing.Point(1357, 970);
            this.simpleButton_simpleButton_Decrypt.Name = "simpleButton_simpleButton_Decrypt";
            this.simpleButton_simpleButton_Decrypt.Size = new System.Drawing.Size(463, 87);
            this.simpleButton_simpleButton_Decrypt.TabIndex = 4;
            this.simpleButton_simpleButton_Decrypt.Text = "解密";
            this.simpleButton_simpleButton_Decrypt.Click += new System.EventHandler(this.simpleButton_simpleButton_Decrypt_Click);
            // 
            // simpleButton_Encrypt
            // 
            this.simpleButton_Encrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton_Encrypt.Location = new System.Drawing.Point(12, 970);
            this.simpleButton_Encrypt.Name = "simpleButton_Encrypt";
            this.simpleButton_Encrypt.Size = new System.Drawing.Size(463, 87);
            this.simpleButton_Encrypt.TabIndex = 4;
            this.simpleButton_Encrypt.Text = "加密";
            this.simpleButton_Encrypt.Click += new System.EventHandler(this.simpleButton_Encrypt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1832, 1125);
            this.Controls.Add(this.simpleButton_Encrypt);
            this.Controls.Add(this.simpleButton_simpleButton_Decrypt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加密解密走一走";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Key.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.TextBox textBox_Source;
        private DevExpress.XtraEditors.TextEdit textEdit_Key;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_Target;
        private DevExpress.XtraEditors.SimpleButton simpleButton_simpleButton_Decrypt;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Encrypt;
    }
}

