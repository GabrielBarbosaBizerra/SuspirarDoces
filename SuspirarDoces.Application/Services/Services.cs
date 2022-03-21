using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.Services
{
    public class Services
    {
        public static string EncriptarSenhas(string senha)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] senhaEncriptada = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caractere in senhaEncriptada)
            {
                stringBuilder.Append(caractere.ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }
}
