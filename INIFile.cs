using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace INIFile
{
    public class INIFile
    {
        #region 调用API读取ini文件
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion
        /// <summary>
        /// 构造方法 文件路径
        /// </summary>
        /// <param name="INIPath">文件路径(c:\\a.ini)</param>
        public string filePath;
        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param name="INIPath">文件路径(c:\\a.ini)</param>
        public void SetFilePath(string INIPath)
        {
            filePath = INIPath;
        }
        /// <summary>
        /// 引用方法1：不带参数引用
        /// </summary>
        public INIFile() { }
        /// <summary>
        /// 引用方法2：带参数引用
        /// </summary>
        /// <param name="INIPath">文件路径(c:\\a.ini)</param>
        public INIFile(string INIPath) { SetFilePath(INIPath); }
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.filePath);

        }
        /// <summary>
        /// 读出INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        public string GetValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);

            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.filePath);
            return temp.ToString();
        }

        /// <summary>
        /// 验证文件是否存在
        /// </summary>
        /// <returns>布尔值</returns>
        public bool ExistINIFile()
        {
            if (filePath == "")
            {
                return false;
            }
            else
            {
                return File.Exists(filePath);
            }

        }
        /// <summary>
        /// 读取INI文件的全部Section。
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>        
        /// <returns>字符串</returns>
        public string[] GetSection()
        {
            var stream = new StreamReader(filePath);
            string line;
            //string linex;
            List<string> lines = new List<string>();
            while ((line = stream.ReadLine()) != null)
            {

                while (line != "" && line != null)
                {
                    var sdww = line.IndexOf("=");
                    if (line.IndexOf("[") > -1)
                    {
                        line = line.Replace("[", "");
                        line = line.Replace("]", "");
                        lines.Add(line);
                    }

                    line = stream.ReadLine();
                }
            }

            string[] a = new string[lines.Count];
            for (int i = 0; i < lines.Count; i++)
            {
                a[i] = lines[i];
            }
            return a;
        }
        /// <summary>
        /// 获取Section下的所有key
        /// </summary>
        /// <param name="section">项目名称(如 [TypeName] )</param>
        /// <returns>字符串数组</returns>
        public string[] GetKeys(string section)
        {
            bool flag = false;
            var stream = new StreamReader(filePath);
            string line;
            //string linex;
            List<string> lines = new List<string>();
            while ((line = stream.ReadLine()) != null)
            {

                while (line != "" && line != null)
                {
                    if (line.IndexOf("[") > -1)
                    {
                        line = line.Replace("[", "");
                        line = line.Replace("]", "");
                        if (line == section)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        lines.Add(line);
                    }
                    line = stream.ReadLine();
                }
            }
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IndexOf("=") < 0)
                {
                    lines.RemoveAt(i);
                }

            }

            string[] a = new string[lines.Count];
            for (int i = 0; i < lines.Count; i++)
            {

                a[i] = lines[i].Substring(0, lines[i].IndexOf("="));
            }
            return a;
        }
        /// <summary>
        /// 获取全部key。（无关Section）、
        /// </summary>       
        /// <param name="Key">键</param>
        /// <returns>字符串数组</returns>
        public string[] GetAllKey()
        {
            List<string> key = new List<string>();
            var stream = new StreamReader(filePath);
            while (!stream.EndOfStream)
            {
                key.Add(stream.ReadLine());
            }
            for (int i = 0; i < key.Count; i++)
            {
                if (key[i].IndexOf("=") < 1)
                {
                    key.RemoveAt(i);
                    i -= 1;
                }
            }
            for (int i = 0; i < key.Count; i++)
            {
                string a = key[i].Substring(0, key[i].IndexOf("="));
                key[i] = a;
            }
            for (int i = 0; i < key.Count; i++)
            {
                for (int j = i; j < key.Count; j++)
                {
                    if (key[i] == key[j])
                    {
                        key.RemoveAt(j);
                    }

                }
            }
            string[] keys = new string[key.Count];
            for (int i = 0; i < key.Count; i++)
            {
                keys[i] = key[i];
            }
            return keys;
        }

    }
}
