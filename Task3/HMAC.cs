using System;
using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    class HMAC
    {
        
        private byte[] key;
        private byte[] HMAChash;
        public HMAC(byte[] inputBytes, int keyByteSize)
        { 
            key = generationKey(keyByteSize);
            HMAChash = findHMAC(inputBytes,key);
        }

        private byte[] generationKey(int ByteSize)
        {
            byte[] key = new byte[ByteSize];
            RandomNumberGenerator.Create().GetBytes(key, 0, ByteSize);
            return key;
        }

        private byte[] findHMAC(byte[] input, byte[] key)
        {
            var hmac = new HMACSHA256(key);
            var bhash = hmac.ComputeHash(input);
            return bhash;
        }

        public void OutputKey()
        {
            var keyStr = BitConverter.ToString(key).Replace("-", string.Empty);
            Console.WriteLine($"HMAC key: {keyStr}");
        }

        public void OutputHMAC()
        {
            var hmacStr = BitConverter.ToString(HMAChash).Replace("-", string.Empty);
            Console.WriteLine($"HMAC: {hmacStr}");
        }

    }
}
