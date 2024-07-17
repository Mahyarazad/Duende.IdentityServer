using System;
using System.Security.Cryptography;
using System.Text;
namespace IdentityServer.Services
{

    public class MfaCodeGenerator
    {
        public static string GenerateBase32Secret(int length = 16)
        {
            // Generate a random byte array
            var buffer = new byte[length];
            using (var cryptoRng = new RNGCryptoServiceProvider())
            {
                cryptoRng.GetBytes(buffer);
            }

            // Convert the byte array to a Base32-encoded string
            return Base32Encode(buffer);
        }

        private static string Base32Encode(byte[] data)
        {
            const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"; // Base32 character set
            var result = new StringBuilder();

            for (int i = 0; i < data.Length; i += 5)
            {
                int value = 0;
                for (int j = 0; j < 5; j++)
                {
                    value <<= 8;
                    if (i + j < data.Length)
                        value |= data[i + j];
                }

                for (int j = 0; j < 8; j++)
                {
                    int index = (value >> (35 - 5 * j)) & 31;
                    result.Append(base32Chars[index]);
                }
            }

            return result.ToString();
        }
    }
}
