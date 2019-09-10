using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    public class Encrypt
    {
        static void Main(string[] args)
        {
            //EncryptSomeText();
            //PrivateAndPublicKey();
            //226
        }

        public static void EncryptSomeText()
        {
            string original = "My secret data!";

            using (SymmetricAlgorithm simetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = EncryptText(simetricAlgorithm, original);
                string roundTrip = DecryptText(simetricAlgorithm, encrypted);

                Console.WriteLine($"Original: {original}");
                Console.WriteLine($"Round Trip: {roundTrip}");
            }
        }

        static byte[] EncryptText(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        static string DecryptText(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using(StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public static void PrivateAndPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);
            Console.WriteLine(publicKeyXML);
            Console.WriteLine(privateKeyXML);

            UnicodeEncoding byteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = byteConverter.GetBytes("My secret data");
            byte[] encryptData;

            using(RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptData = RSA.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptData, false);
            }

            string decryptedString = byteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString);
        }

    }
}
