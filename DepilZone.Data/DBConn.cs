using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DepilZone.Data
{
    class DBConn
    {
        public static SqlConnection ConexionSQL()
        {
            try
            {
                SqlConnection ConectString = new SqlConnection("Server=.;Database=BDDepilzoneQA;Trusted_Connection=True;");
                //SqlConnection ConectString = new SqlConnection("Server=.;Database=BDDepilzoneQA;Trusted_Connection=True;");
                //SqlConnection ConectString = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=BDDepilzone; User Id=sa; password=*#DEPIL#ZON3#; Connection Timeout=300");
                //SqlConnection ConectString = new SqlConnection("Data Source=.; Initial Catalog=BDDepilzone_QA; User Id=sa; password=*#DEPIL#ZON3#; Connection Timeout=300");
                //SqlConnection ConectString = new SqlConnection("Data Source=.; Initial Catalog=BDDepilzone; User Id=sa; password=*#DEPIL#ZON3#; Connection Timeout=300");
                return ConectString;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static string ParametroCripto()
        {
            return "d/3%P.1@l?z!0&N(3";
        }


        /*public static string EncryptString(string text)
        {
            try
            {
                var key = "D3P1LZ0N30123456";
                byte[] iv = new byte[16];
                byte[] array;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(text);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return ToHexString(Convert.ToBase64String(array));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DecryptString(string cipherText)
        {
            try
            {
                string keyString = "D3P1LZ0N30123456";
                string t = FromHexString(cipherText);
                var fullCipher = Convert.FromBase64String(t);

                var iv = new byte[16];
                var cipher = new byte[16];

                Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
                var key = Encoding.UTF8.GetBytes(t);//same key string

                using (var aesAlg = Aes.Create())
                {
                    using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                    {
                        string result;
                        using (var msDecrypt = new MemoryStream(cipher))
                        {
                            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (var srDecrypt = new StreamReader(csDecrypt))
                                {
                                    result = srDecrypt.ReadToEnd();
                                }
                            }
                        }

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }*/



        public static string EncryptString(string text)
        {
            string keyString = "D3P1LZ0N30123456";
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return ToHexString(Convert.ToBase64String(result));
                    }
                }
            }
        }

        public static string DecryptString(string cipherText)
        {
            string keyString = "D3P1LZ0N30123456";
            var fullCipher = Convert.FromBase64String(FromHexString(cipherText));

            //var text = FromHexString(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }




        private static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        private static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
    }
}
