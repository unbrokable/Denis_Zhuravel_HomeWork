using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Application
{
    public class Hasher : IHasher
    {
        public string Hash(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }

        public T HashObject<T>(T data)
        {
            foreach (var item in data.GetType().GetProperties().Where(i => i.PropertyType.Name.CompareTo( "String") == 0).ToList())
            {
                item.SetValue(data, Hash(item.GetValue(data).ToString()));
            }
            return data;
        }
    }
}
