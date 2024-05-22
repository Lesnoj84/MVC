using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Classes
{
    public class PassWordHasher : IPassWordHasher
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iteration = 10000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
        private const char Delimeter = ';';

        public string Hash(string newPassword)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(newPassword, salt, Iteration, hashAlgorithm, KeySize);

            return string.Join(Delimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool Verify(string password, string inputPassword)
        {
            var element = password.Split(Delimeter);
            var salt = Convert.FromBase64String(element[0]);
            var hash = Convert.FromBase64String(element[1]);
            var hashIput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iteration, hashAlgorithm, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashIput);
        }


        public class DecryptionHelper
        {
            // Decrypt a Base64 string and return the plain text string
            public static string DecryptString(string cipherText, byte[] key, byte[] iv)
            {
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        using (var ms = new MemoryStream(buffer))
                        {
                            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                using (var sr = new StreamReader(cs))
                                {
                                    return sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
