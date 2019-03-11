using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Helpers
{
    public class CertificateHelper
    {
        public static void SignAndVerify()
        {
            string textToSign = "Test paragraph";
            byte[] signature = Sign(textToSign, "cn = WouterDeKort");
            // Uncomment this line to make the verification step fail
            // signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }
        static byte[] Sign(string text, string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }
        static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash,
            CryptoConfig.MapNameToOID("SHA1"),
            signature);
        }
        private static byte[] HashData(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }
        private static X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore",
            StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }
    }
}
