﻿using System.Security.Cryptography;
using System.Text;

namespace Web_Api_Inm.Helpers
{
    public class MD5Encryption
    {
        public static string EncryptMD5(string pass)
        {
            //MD5 md5 = MD5CryptoServiceProvider.Create();
            MD5 md5 = MD5.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString();


        }
    }
}



