// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

using (var rNGCryptoServiceProvider = new RSACryptoServiceProvider())
{
    var SigningSecretKey = new byte[64];
    var val = rNGCryptoServiceProvider.EncryptValue(SigningSecretKey);
    Console.WriteLine(val);
    Console.WriteLine($"Secret Key is {Convert.ToBase64String(SigningSecretKey)}");
}
Console.ReadLine();
