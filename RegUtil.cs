using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegUtil
{
    class RegUtil
    {
        

        /**//// <summary>
            /// 读取指定名称的注册表的值
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
        public string GetRegistryData(RegistryKey root, string subkey, string name)
        {
            string registData = "";
            
            try
            {
                if (IsRegistryExist( root, subkey))
                {
                    RegistryKey myKey = root;
                    if (subkey.Contains("\\"))
                    {
                        subkey = subkey.Replace("\\", "/");
                        foreach (var item in subkey.Split("/".ToCharArray()))
                        {
                            myKey = myKey.OpenSubKey(item, true);
                        }
                    }
                    else
                    {
                        myKey = root.OpenSubKey(subkey, true);
                    }
                    registData = myKey.GetValue(name).ToString();
                }
                return registData;
            }
            catch (Exception)
            {
                return registData;
            } 
        }
        /**//// <summary>
            /// 向注册表中写数据
            /// </summary>
            /// <param name="name"></param>
            /// <param name="tovalue"></param> 
        public void SetRegistryData(RegistryKey root, string subkey, string name, string value)
        {
            RegistryKey myKey = root;
            
            if (subkey.Contains("\\"))
            {
                subkey = subkey.Replace("\\", "/");
                foreach (var item in subkey.Split("/".ToCharArray()))
                {

                    myKey = myKey.CreateSubKey(item);

                }
            }
            else
            {
                myKey = root.CreateSubKey(subkey);
            }

            myKey.SetValue(name, value);
           
        }

        /**//// <summary>
            /// 删除注册表中指定的注册表项
            /// </summary>
            /// <param name="name"></param>
        public void DeleteRegist(RegistryKey root, string subkey, string name)
        {
            string[] subkeyNames;
            RegistryKey myKey = root.OpenSubKey(subkey, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string aimKey in subkeyNames)
            {
                if (aimKey.ToLower() == name.ToLower())
                    myKey.DeleteSubKeyTree(name);
            }
        }

        /**//// <summary>
            /// 判断指定注册表项是否存在
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
        public bool IsRegistryExist(RegistryKey root, string subkey, string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            try
            {
                RegistryKey myKey = root;
                if (subkey.Contains("\\"))
                {
                    subkey = subkey.Replace("\\", "/");
                    foreach (var item in subkey.Split("/".ToCharArray()))
                    {

                        myKey = myKey.OpenSubKey(item, true);

                    }
                }
                else
                {
                    myKey = root.OpenSubKey(subkey, true);
                }
                subkeyNames = myKey.GetSubKeyNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName.ToLower() == name.ToLower())
                    {
                        _exit = true;
                        return _exit;
                    }
                }

                return _exit;
            }
            catch (Exception)
            {

                return _exit;
            }
           
        }
        public bool IsRegistryExist(RegistryKey root, string subkey)
        {
            bool _exit = false;
            string[] subkeyNames;
            try
            {
                RegistryKey myKey = root;
                if (subkey.Contains("\\"))
                {
                    subkey = subkey.Replace("\\", "/");
                    foreach (var item in subkey.Split("/".ToCharArray()))
                    {
                        _exit = false;
                        subkeyNames = myKey.GetSubKeyNames();
                        foreach (string keyName in subkeyNames)
                        {
                            if (keyName.ToLower() == item.ToLower())
                            {
                                myKey = myKey.OpenSubKey(keyName, true);
                                _exit = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    myKey = root.OpenSubKey(subkey, true);
                    _exit = true;
                }
                return _exit;
            }
            catch (Exception)
            {
                return _exit;
            }
        }       
        /**//// <summary>
            /// 判断键值是否存在
            /// </summary>
        public bool IsRegeditKeyExit(RegistryKey root, string subkey, string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            try
            {
                RegistryKey myKey = root;
                if (subkey.Contains("\\"))
                {
                    subkey = subkey.Replace("\\", "/");
                    foreach (var item in subkey.Split("/".ToCharArray()))
                    {

                        myKey = myKey.OpenSubKey(item, true);

                    }
                }
                else
                {
                    myKey = root.OpenSubKey(subkey, true);
                }

                subkeyNames = myKey.GetValueNames();

                foreach (string keyName in subkeyNames)
                {
                    if (keyName.ToLower() == name.ToLower())
                    {
                        _exit = true;                        
                    }
                }
                return _exit;
            }
            catch (Exception)
            {

                return _exit;
            }
        }
       
    }
}
