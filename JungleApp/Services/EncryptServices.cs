using JungleApp.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JungleApp.Services
{
    public class EncryptServices
    {
        internal void TestSymmetricEncryption()
        {
            //TODO: Symmetric Encryption
            /*
             * A symmetric algorithm uses one single key to encrypt and decrypt the data.
             * You need to pass your original key to the receiver so he can decrypt your data
             * 
             * Ex symmetric algorithm: AES
             */

            Debug.WriteLine("Symmetric Encryption");

            string original = "My secret data!";
            using (SymmetricAlgorithm symmetricAlgorithm =new AesManaged())
            {
                Debug.WriteLine("Encrypt with algorithm AES with default key");
                byte[] encrypted = SymmetricEncryptHelper.Encrypt(symmetricAlgorithm, original);

                Debug.WriteLine("Decrypt with algorithm AES with default key");
                string roundtrip = SymmetricEncryptHelper.Decrypt(symmetricAlgorithm, encrypted);

                // Displays: My secret data!
                Debug.WriteLine($"Original: { original }");
                Debug.WriteLine($"Round Trip: { roundtrip}");
            }

        }


        internal void TestHashing()
        {
            //TODO: Hash
            /*
             * Use: if you hash a text y change only one letter, the hash code will change, so
             * hashing is used to check the INTEGRITY of a message.
             * Hashing is an important technique to validate the authenticity of a message.
             * 
             * EX: For generated hash values you can use: SHA256Managed algorithm
             */

            Debug.WriteLine("Hashing with SHA 256 Algorithm");

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();
            
            string data = "A paragraph of text";
            Debug.WriteLine($"Original data: {data}");
            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of changed text";
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));
            Debug.WriteLine($"Changed data: {data}");

            data = "A paragraph of text";
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));
            Debug.WriteLine($"Original data: {data}");

            Debug.WriteLine(hashA.SequenceEqual(hashB)); 
            Debug.WriteLine(hashA.SequenceEqual(hashC));

        }

        internal void TestAsymmetricEncryption()
        {
            //TODO: Asymmetric Encryption
            /*
             * An Asymmetric Algorithm uses two differen keys (no one like Symmetric Algorithm).
             * One key is completely public and can be read and used by everone.
             * The other part is private. It should never be shared with someone else.
             * When you encrypt something with public key, it can be decrypted by using private key, and vice versa.
             * 
             * The .NET Framework also has support for asymmetric encryption. 
             * You can use the RSACryptoServiceProvider and DSACryptoServiceProvider classes.
             */


            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            //rsa.ToXmlString() Not supported by net core
            return;

            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);
            Debug.WriteLine(publicKeyXML);
            Debug.WriteLine(privateKeyXML);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data! (asymmetric)");
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }

            string decryptedString = ByteConverter.GetString(decryptedData);
            Debug.WriteLine(decryptedString); 

        }


        internal void TestDigitalCertificates()
        {
            //TODO: Digital Certificates

            /*
             * Digital Certificates include hashing & asymmetric encryption.
             * When I want to send a message:
             * 1) I hash my message to generate a HASH CODE.
             * 2) Then, I encrypt the hash code and the message with my Private Key to create a personal signature.
             * 
             * When the recepient receive the message:
             * 1) He decrypts the signature using my public key.
             * 2) Now,  he has both the message and the hash code.
             * 3) He can hash the message and compare if it match with the Alice's Hash code
             * 
             * A digital certificate is part of a Public Key Infraestructure (PKI). 
             * A PKI is a system of digital certificates, certificate authorities. Verify the validaty of each involver party.
             * 
             * A Certificate Authority (CA) is a third-party issuer of certificates that is considered 
             * thust-worthy by all parties. The CA issues certificates that contain a public key, a SUBJECT to
             * which the certificate is issued, and the details of the CA.
             * 
             * The Makecert.exe tool. This tool generates X.509 certificates for testing purposes. 
             * makecert testCert.cer
             * 
             * -->MakeCert is deprecated
             */

            return;
            CertificateHelper.SignAndVerify();
        }
    }
}
