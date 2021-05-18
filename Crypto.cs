using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    class Crypto
    {
        private string secretkey;//定义密钥
         /// <summary>
        /// 调用方法2 不带参数调用
        /// </summary>
        public Crypto() { }
        /// <summary>
        /// 调用方法1 带参数（密码）调用
        /// </summary>
        /// <param name="secretkeys">密钥</param>
        public Crypto(string secretkeys) //存入密钥
        {
            SetSecreKey(secretkeys);
        }
        /// <summary>
        /// 存入密钥
        /// </summary>
        /// <param name="secretkeys">密钥</param>
        public void SetSecreKey(string secretkeys)
        {
            secretkey = secretkeys;
        }
        /// <summary>
        /// 定义加解密对象
        /// </summary>
        private CspParameters param; //定义加密对象
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="originaltext">明文字符串</param>
        /// <returns>密文字符串</returns>
        public string Encryption(string originaltext) //调用加密 originaltext 原文
        {
            return encryption(originaltext);
        }
        /// <summary>
        /// 加密过程
        /// </summary>
        /// <param name="originaltext">明文字符串</param>
        /// <returns>密文字符串(错误返回："密码为空")</returns>
        private string encryption(string originaltext) //加密 
        {
            string ciphertext = null;
            param = new CspParameters();
            if (secretkey!="")
            {
                param.KeyContainerName = secretkey;//密匙容器的名称，保持加密解密一致才能解密成功
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = Encoding.Default.GetBytes(originaltext);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                ciphertext = Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
            }
            return ciphertext;
            }
            else
            {
                return "密码为空";
            }
            
        }
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="ciphertext">密文字符串</param>
        /// <returns>明文字符串</returns>
        public string Decrypt(string ciphertext) // 调用解密 ciphertext 密文
        {
            return decrypt(ciphertext);
        }
        /// <summary>
        /// 解密过程
        /// </summary>
        /// <param name="ciphertext">密文字符串</param>
        /// <returns>明文字符串(错误返回"密码错误")</returns>
        private string decrypt(string ciphertext) // 解密
        {
            string originaltext = null;
            param = new CspParameters();
            param.KeyContainerName = secretkey;
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
                {
                    byte[] encryptdata = Convert.FromBase64String(ciphertext);
                    byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                    originaltext = Encoding.Default.GetString(decryptdata);
                }
                return originaltext;
            }
            catch (Exception)
            {
                return "密码错误";
            }

        }
    }
}
