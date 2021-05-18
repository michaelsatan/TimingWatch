using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crypto;
using Microsoft.Win32;
using INIFile;
using RegUtil;



namespace TimingWatch
{
    public partial class TimingWatch : Form
    {
        Keys keys = new Keys();
        string regPath = "software\\TimingWatchs";
        RegistryKey root = Registry.CurrentUser;
        string password = "rhcc";
        string filePath;
        
        public TimingWatch()
        {
            InitializeComponent();
            
            RegUtil.RegUtil regs = new RegUtil.RegUtil();

            if (regs.IsRegeditKeyExit(root, regPath, "path"))
            {
                Crypto.Crypto c = new Crypto.Crypto(password);
                filePath = c.Decrypt(regs.GetRegistryData(root, regPath, "path"));
            }
            PasswordInput.LostFocus += PasswordInput_LostFocus;
            this.PasswordLable.Text = "请输入密钥" + "\n\r" + "如需密钥请向实验室老师申请";

        }

        private void PasswordInput_LostFocus(object sender, EventArgs e)
        {
            PasswordLable.Visible = PasswordInput.Text.Length < 1;
        }

        private new void TextChanged(object sender, EventArgs e)

        {

            if (sender.Equals(PasswordInput))

            {

                PasswordLable.Visible = PasswordInput.Text.Length < 1;

            }
            else
            {
                PasswordLable.Visible = !(PasswordInput.Text.Length < 1);
            }
        }
        private void Label_Click(object sender, EventArgs e)

        {

            if (sender.Equals(PasswordLable))
            {
                PasswordInput.Focus();
                PasswordLable.Visible = false;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            GetKey(this.PasswordInput.Text);

        }

        private void GetKey(string str)
        {

            string[] st = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (var item in st)
            {
                if (item.Contains("key1="))
                {
                    keys.key1_c = item.Replace("key1=", "");
                }
                if (item.Contains("key2="))
                {
                    keys.key2_c = item.Replace("key2=", "");
                }
            }
            Crypto.Crypto c = new Crypto.Crypto();
            c.SetSecreKey(password);
            keys.key1 = c.Decrypt(keys.key1_c);
            c.SetSecreKey(keys.key1);
            keys.key2 = c.Decrypt(keys.key2_c);
            MessageBox.Show(keys.key1);
            MessageBox.Show(keys.key2);
            WriteRegistry();
        }

        private void FileImport_Click(object sender, EventArgs e)
        {
            string filename = "";
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "密钥文件|*.secret|所有文件类型|*.*";
            openfile.InitialDirectory = filePath;
            openfile.Title = "请选择要发送的文件";
            openfile.FileName = "key";
            if (DialogResult.OK == openfile.ShowDialog())
            {
                //将选择的文件的全路径赋值给文本框
                filename = openfile.FileName;
                INIFile.INIFile iniFile = new INIFile.INIFile();
                iniFile.filePath = filename;

                keys.key1_c = iniFile.GetValue("key", "key1");
                keys.key2_c = iniFile.GetValue("key", "key2");

                Crypto.Crypto c = new Crypto.Crypto();
                c.SetSecreKey(password);
                keys.key1 = c.Decrypt(keys.key1_c);
                c.SetSecreKey(keys.key1);
                keys.key2 = c.Decrypt(keys.key2_c);
                string str = "[key]" + "\r\n" + "key1=" + keys.key1_c + "\r\n";
                str = str + "key2=" + keys.key2_c;
                DateTime ds = DateTime.Parse(keys.key2);
                ds = DateTime.Parse(ds.Year.ToString() + "/" + ds.Month.ToString() + "/" + ds.Day.ToString());
                this.PasswordInput.Text = str;
                Clipboard.SetText(str);
                //  MessageBox.Show(keys.key1);
                //  MessageBox.Show(ds.ToString());
                WriteRegistry();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser;
            RegUtil.RegUtil regs = new RegUtil.RegUtil();
            Crypto.Crypto c = new Crypto.Crypto();


            c.SetSecreKey(password);
            
            string secretKey = c.Decrypt(regs.GetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "secretkey"));
            c.SetSecreKey(secretKey);
            string endTimeStr_c = c.Decrypt(regs.GetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "Scheduled"));
            MessageBox.Show(endTimeStr_c);
            MessageBox.Show(secretKey);
            /*if (regs.IsRegistryExist(Registry.CurrentUser, "Software\\360zip\\stat"))
            {
                string ss = regs.GetRegistryData(Registry.CurrentUser, "Software\\360zip\\stat", "promotiontime");
                regs.SetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "path", paths);
                ss = regs.GetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "path");
                MessageBox.Show(ss);
            }
            else
            {

                MessageBox.Show("x");
            }*/
        }
        private void WriteRegistry()
        {
            RegistryKey reg = Registry.CurrentUser;
            RegUtil.RegUtil regs = new RegUtil.RegUtil();
            Crypto.Crypto c = new Crypto.Crypto(password);            
            //regs.SetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "path", keys.paths_c);
            regs.SetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "Scheduled", keys.key2_c);
            regs.SetRegistryData(Registry.CurrentUser, "software\\TimingWatchs", "secretkey", keys.key1_c);
        }
    }
    class Keys
    {
      
        public string key1 { set; get; }
        public string key2 { set; get; }
        public string key1_c { set; get; }
        public string key2_c { set; get; }
    }
}
