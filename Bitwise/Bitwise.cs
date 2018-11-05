using System;
using System.Globalization;
using System.Linq;

namespace SysLib.Bitwise
{
    /// <summary>
    /// Class for manapulating bytes
    /// </summary>
    public static class Bitwise
    {
        private const string _hexNibbles = "0123456789abcdefABCDEF";

        /// <summary>
        /// rotate integer
        /// </summary>
        /// <param name="word">word</param>
        /// <param name="shift">shift</param>
        /// <returns>uint</returns>
        public static uint Rotr32(uint word, int shift)
        {
            return (word << 32 - shift) | word >> shift;
        }

        // <summary>
        // Endian Methods pulled from Org.BouncyCastle.Crypto.Utilities
        // Purpose is to store-retrieve order for byte arrays
        // </summary>
        #region Endian Methods

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt32_To_BE(uint n, byte[] bs)
        {
            bs[0] = (byte)(n >> 24);
            bs[1] = (byte)(n >> 16);
            bs[2] = (byte)(n >> 8);
            bs[3] = (byte)(n);
        }

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt32_To_BE(uint n, byte[] bs, int off)
        {
            bs[off] = (byte)(n >> 24);
            bs[++off] = (byte)(n >> 16);
            bs[++off] = (byte)(n >> 8);
            bs[++off] = (byte)(n);
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>uint</returns>
        public static uint BE_To_UInt32(byte[] bs)
        {
            uint n = (uint)bs[0] << 24;
            n |= (uint)bs[1] << 16;
            n |= (uint)bs[2] << 8;
            n |= (uint)bs[3];
            return n;
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>uint</returns>
        public static uint BE_To_UInt32(byte[] bs, int off)
        {
            uint n = (uint)bs[off] << 24;
            n |= (uint)bs[++off] << 16;
            n |= (uint)bs[++off] << 8;
            n |= (uint)bs[++off];
            return n;
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>ulong</returns>
        public static ulong BE_To_UInt64(byte[] bs)
        {
            uint hi = BE_To_UInt32(bs);
            uint lo = BE_To_UInt32(bs, 4);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>ulong</returns>
        public static ulong BE_To_UInt64(byte[] bs, int off)
        {
            uint hi = BE_To_UInt32(bs, off);
            uint lo = BE_To_UInt32(bs, off + 4);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt64_To_BE(ulong n, byte[] bs)
        {
            UInt32_To_BE((uint)(n >> 32), bs);
            UInt32_To_BE((uint)(n), bs, 4);
        }

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt64_To_BE(ulong n, byte[] bs, int off)
        {
            UInt32_To_BE((uint)(n >> 32), bs, off);
            UInt32_To_BE((uint)(n), bs, off + 4);
        }

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt32_To_LE(uint n, byte[] bs)
        {
            bs[0] = (byte)(n);
            bs[1] = (byte)(n >> 8);
            bs[2] = (byte)(n >> 16);
            bs[3] = (byte)(n >> 24);
        }

        /// <summary>
        /// A method to write a uint into a byte array LittleEndian.
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt32_To_LE(uint n, byte[] bs, int off)
        {
            bs[off] = (byte)(n);
            bs[++off] = (byte)(n >> 8);
            bs[++off] = (byte)(n >> 16);
            bs[++off] = (byte)(n >> 24);
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>uint</returns>
        public static uint LE_To_UInt32(byte[] bs)
        {
            uint n = (uint)bs[0];
            n |= (uint)bs[1] << 8;
            n |= (uint)bs[2] << 16;
            n |= (uint)bs[3] << 24;
            return n;
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>uint</returns>
        public static uint LE_To_UInt32(byte[] bs, int off)
        {
            uint n = (uint)bs[off];
            n |= (uint)bs[++off] << 8;
            n |= (uint)bs[++off] << 16;
            n |= (uint)bs[++off] << 24;
            return n;
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>ulong</returns>
        public static ulong LE_To_UInt64(byte[] bs)
        {
            uint lo = LE_To_UInt32(bs);
            uint hi = LE_To_UInt32(bs, 4);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>ulong</returns>
        public static ulong LE_To_UInt64(byte[] bs, int off)
        {
            uint lo = LE_To_UInt32(bs, off);
            uint hi = LE_To_UInt32(bs, off + 4);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt64_To_LE(ulong n, byte[] bs)
        {
            UInt32_To_LE((uint)n, bs);
            UInt32_To_LE((uint)(n >> 32), bs, 4);
        }

        /// <summary>
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt64_To_LE(ulong n, byte[] bs, int off)
        {
            UInt32_To_LE((uint)n, bs, off);
            UInt32_To_LE((uint)(n >> 32), bs, off + 4);
        }

        #endregion

        /// <summary>
        /// Converts an even digit hexadecimal string into a byte array
        /// </summary>
        /// <param name="hexString">input hexadecimal string</param>
        /// <returns>byte array</returns>
        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException($"The binary key cannot have an odd number of digits: {hexString}");
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            string byteValue = string.Empty;
            try
            {
                for (int index = 0; index < HexAsBytes.Length; index++)
                {
                    byteValue = hexString.Substring(index * 2, 2);
                    HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber);
                }
            }
            catch (FormatException fex)
            {
                throw new FormatException($"{fex.Message} Invalid Hex value: {byteValue}", fex);
            }

            return HexAsBytes;
        }

        /// <summary>
        /// Converts the byte array into a hexadecimal string
        /// </summary>
        /// <param name="byteArray">input byte array</param>
        /// <returns>hexadecimal string</returns>
        public static string ConvertByteArrayToHexString(byte[] byteArray)
        {
            string sTemp = string.Empty;
            foreach (byte b in byteArray)
            {
                sTemp += b.ToString("X2");
            }
            return sTemp;
        }

        /// <summary>
        /// Determins if the input string contains only hexadecimal nibbles
        /// </summary>
        /// <param name="value">input string to check for hex</param>
        /// <returns>bool</returns>
        public static bool ContainsOnlyHexNibbles(string value) => value.All(_hexNibbles.Contains);
    }
}
