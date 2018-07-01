using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AESEncryptionTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void simpleButton_Encrypt_Click(object sender, EventArgs e)
        {
            ChongGuanDotNetUtils.Helpers.CryptHelper.Key = this.textEdit_Key.Text.Length == 16 ? this.textEdit_Key.Text : ChongGuanDotNetUtils.Helpers.CryptHelper.Key;

            try
            {
                this.textBox_Target.Text = ChongGuanDotNetUtils.Helpers.CryptHelper.Encrypt(this.textBox_Source.Text);
            }
            catch { }
        }

        private void simpleButton_simpleButton_Decrypt_Click(object sender, EventArgs e)
        {
            ChongGuanDotNetUtils.Helpers.CryptHelper.Key = this.textEdit_Key.Text.Length == 16 ? this.textEdit_Key.Text : ChongGuanDotNetUtils.Helpers.CryptHelper.Key;

            try
            {
                this.textBox_Source.Text = ChongGuanDotNetUtils.Helpers.CryptHelper.Decrypt(this.textBox_Target.Text);
            }
            catch { }
        }
    }
}
