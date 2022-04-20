using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Demo
{
    public static class Generator
    {
        private static readonly RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
        public static string GenerateUniqueID(int length)
        {
            int sufficientBufferSizeInBytes = (length * 6 + 7) / 8;
            var buffer = new byte[sufficientBufferSizeInBytes];
            random.GetBytes(buffer);
            return Convert.ToBase64String(buffer).Substring(0, length);
        }
    }
}
