using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Support
{
    public static class MD5Support
    {
        public static string GetMD5CodeBySystemTime(MD5 md5 = null)
        {
            if (md5 == null)
            {
                md5 = MD5.Create();
            }
            byte[] bs = Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString());
            byte[] bsHash = md5.ComputeHash(bs);
            StringBuilder sb = new();
            for (int i = 0; i < bsHash.Length; i++)
            {
                sb.Append(bsHash[i].ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        public static string GetMD5Code(string EncryptedObject, MD5 md5 = null)
        {
            if (md5 == null)
            {
                md5 = MD5.Create();
            }
            byte[] bs = Encoding.UTF8.GetBytes(EncryptedObject);
            byte[] bsHash = md5.ComputeHash(bs);
            StringBuilder sb = new();
            for (int i = 0; i < bsHash.Length; i++)
            {
                sb.Append(bsHash[i].ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        public static string GetMD5Code(object EncryptedObject, MD5 md5 = null)
        {
            if (md5 == null)
            {
                md5 = MD5.Create();
            }
            byte[] bs = Encoding.UTF8.GetBytes(EncryptedObject.ToString());
            byte[] bsHash = md5.ComputeHash(bs);
            StringBuilder sb = new();
            for (int i = 0; i < bsHash.Length; i++)
            {
                sb.Append(bsHash[i].ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
