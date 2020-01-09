using System;

namespace SysLib.Bitwise
{
    /// <summary>
    /// Class for manapulating bytes
    /// </summary>
    public static class ByteConverter
    {
        /// <summary>
        /// Validates the array paramerter is large enough for conversion
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="arr">array to test length</param>
        /// <param name="off">offset to the beginning of the array conversion</param>
        private static void ValidateArrayLength<T>(T[] arr, int reg, int off = 0)
        {
            if (arr.Length < reg + off)
                throw new ArgumentException("Destination array is not long enough to copy all the items in the collection. Check array index and length.");
        }

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
        /// A method to write a number into a byte array BigEndian.
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt32_To_BE(uint n, byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32);
            bs[0] = (byte)(n >> 24);
            bs[1] = (byte)(n >> 16);
            bs[2] = (byte)(n >> 8);
            bs[3] = (byte)(n);
        }

        /// <summary>
        /// A method to write a number into a byte array BigEndian.
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt32_To_BE(uint n, byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32, off);
            bs[off] = (byte)(n >> 24);
            bs[++off] = (byte)(n >> 16);
            bs[++off] = (byte)(n >> 8);
            bs[++off] = (byte)(n);
        }

        /// <summary>
        /// A method to write a number from a byte array BigEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>uint</returns>
        public static uint BE_To_UInt32(byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32);
            uint n = (uint)bs[0] << 24;
            n |= (uint)bs[1] << 16;
            n |= (uint)bs[2] << 8;
            n |= (uint)bs[3];
            return n;
        }

        /// <summary>
        /// A method to write a number from a byte array BigEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>uint</returns>
        public static uint BE_To_UInt32(byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32, off);
            uint n = (uint)bs[off] << 24;
            n |= (uint)bs[++off] << 16;
            n |= (uint)bs[++off] << 8;
            n |= (uint)bs[++off];
            return n;
        }

        /// <summary>
        /// A method to write a number from a byte array BigEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>ulong</returns>
        public static ulong BE_To_UInt64(byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64);
            uint hi = BE_To_UInt32(bs);
            uint lo = BE_To_UInt32(bs, Globals.RegisterSize32);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// A method to write a number from a byte array BigEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>ulong</returns>
        public static ulong BE_To_UInt64(byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64, off);
            uint hi = BE_To_UInt32(bs, off);
            uint lo = BE_To_UInt32(bs, off + Globals.RegisterSize32);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// A method to write a number into a byte array BigEndian.
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt64_To_BE(ulong n, byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64);
            UInt32_To_BE((uint)(n >> 32), bs);
            UInt32_To_BE((uint)(n), bs, Globals.RegisterSize32);
        }

        /// <summary>
        /// A method to write a number into a byte array BigEndian.
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt64_To_BE(ulong n, byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64, off);
            UInt32_To_BE((uint)(n >> 32), bs, off);
            UInt32_To_BE((uint)(n), bs, off + Globals.RegisterSize32);
        }

        /// <summary>
        /// A method to write a number into a byte array LittleEndian.
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt32_To_LE(uint n, byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32);
            bs[0] = (byte)(n);
            bs[1] = (byte)(n >> 8);
            bs[2] = (byte)(n >> 16);
            bs[3] = (byte)(n >> 24);
        }

        /// <summary>
        /// A method to write a number into a byte array LittleEndian.
        /// </summary>
        /// <param name="n">unsigned int to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt32_To_LE(uint n, byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32, off);
            bs[off] = (byte)(n);
            bs[++off] = (byte)(n >> 8);
            bs[++off] = (byte)(n >> 16);
            bs[++off] = (byte)(n >> 24);
        }

        /// <summary>
        /// A method to write a number from a byte array LittleEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>uint</returns>
        public static uint LE_To_UInt32(byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32);
            uint n = (uint)bs[0];
            n |= (uint)bs[1] << 8;
            n |= (uint)bs[2] << 16;
            n |= (uint)bs[3] << 24;
            return n;
        }

        /// <summary>
        /// A method to write a number from a byte array LittleEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>uint</returns>
        public static uint LE_To_UInt32(byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize32, off);
            uint n = (uint)bs[off];
            n |= (uint)bs[++off] << 8;
            n |= (uint)bs[++off] << 16;
            n |= (uint)bs[++off] << 24;
            return n;
        }

        /// <summary>
        /// A method to write a number from a byte array LittleEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <returns>ulong</returns>
        public static ulong LE_To_UInt64(byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64);
            uint lo = LE_To_UInt32(bs);
            uint hi = LE_To_UInt32(bs, Globals.RegisterSize32);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// A method to write a number from a byte array LittleEndian.
        /// </summary>
        /// <param name="bs">byte array to convert</param>
        /// <param name="off">offset of byte array</param>
        /// <returns>ulong</returns>
        public static ulong LE_To_UInt64(byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64, off);
            uint lo = LE_To_UInt32(bs, off);
            uint hi = LE_To_UInt32(bs, off + Globals.RegisterSize32);
            return ((ulong)hi << 32) | (ulong)lo;
        }

        /// <summary>
        /// A method to write a number into a byte array LittleEndian.
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        public static void UInt64_To_LE(ulong n, byte[] bs)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64);
            UInt32_To_LE((uint)n, bs);
            UInt32_To_LE((uint)(n >> 32), bs, Globals.RegisterSize32);
        }

        /// <summary>
        /// A method to write a number into a byte array LittleEndian.
        /// </summary>
        /// <param name="n">unsigned long to convert</param>
        /// <param name="bs">byte array buffer to write to</param>
        /// <param name="off">offset of byte array</param>
        public static void UInt64_To_LE(ulong n, byte[] bs, int off)
        {
            ValidateArrayLength(bs, Globals.RegisterSize64, off);
            UInt32_To_LE((uint)n, bs, off);
            UInt32_To_LE((uint)(n >> 32), bs, off + Globals.RegisterSize32);
        }

        #endregion

        /// <summary>
        /// Decodes byte array into ascii form, like in Hex editors
        /// </summary>
        /// <param name="bytes">input bytes</param>
        /// <returns>ascii chars</returns>
        public static string DecodeBytesToAscii(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("Input array cannot be null");

            var ascii = string.Empty;
            foreach (byte b in bytes)
            {
                ascii += Convert.ToChar(b);
            }
            return ascii;
        }
    }
}
