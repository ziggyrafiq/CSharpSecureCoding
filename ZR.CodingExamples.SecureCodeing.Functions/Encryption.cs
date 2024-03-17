using System.Security.Cryptography;
namespace ZR.CodingExamples.SecureCodeing.Functions;
public class Encryption
{
    public byte[] EncryptData(byte[] data, byte[] key, byte[] iv)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (var encryptor = aes.CreateEncryptor())
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }
    }

    public byte[] DecryptData(byte[] encryptedData, byte[] key, byte[] iv)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor())
            using (var memoryStream = new MemoryStream(encryptedData))
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                var decryptedData = new byte[encryptedData.Length];
                var bytesRead = cryptoStream.Read(decryptedData, 0, decryptedData.Length);

                Array.Resize(ref decryptedData, bytesRead);

                return decryptedData;
            }
        }
    }

}
