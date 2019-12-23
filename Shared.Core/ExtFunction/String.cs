using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shared
{
    /// <summary>
    /// String 的擴充方法
    /// </summary>
    public static partial class ExtFunction
    {
        const string passPhrase = "Pas5pr@se";//can be any string
        const string saltValue = "s@1tValue";//can be any string
        const string hashAlgorithm = "SHA1";//can be "MD5"
        const int passwordIterations = 2;//can be any number
        const string initVector = "@1B2c3D4e5F6g7H8";//must be 16 bytes
        const int keySize = 256;//can be 192 or 128

        /// <summary>
        /// 字串加密
        /// </summary>
        /// <param name="plainText">被加密字串</param>
        /// <returns>加密字串</returns>
        public static string Encrypt(this string plainText)
        {
            string cipherText;
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
            {
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                cipherText = Convert.ToBase64String(cipherTextBytes);
            }
            return cipherText;
        }

        public static string Decrypt(this string cipherText)
        {
            string plainText;
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
            {
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            return plainText;
        }
    }
}
