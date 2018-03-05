using SChat.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SChat.Models.BusinessLogic
{
    public class CryptoFunctions
    {
        public static string CalcHash(string source)
        {
            var HashAlg = new SHA256CryptoServiceProvider();
            var ResultHash = HashAlg.ComputeHash(System.Text.Encoding.ASCII.GetBytes(source));
            return Convert.ToBase64String(ResultHash);
        }

        public static string GenToken(User UserInstance)
        {
            var HashAlg = new SHA1CryptoServiceProvider();
            var SourceString = string.Concat(UserInstance.Name, Convert.ToString(UserInstance.Id), (new Random()).Next(3333).ToString());
            var ResultHash = HashAlg.ComputeHash(System.Text.Encoding.ASCII.GetBytes(SourceString));
            return Convert.ToBase64String(ResultHash);
        }
    }
}