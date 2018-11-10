namespace SysLib.Bitwise
{
    public static class BitwiseExtensions
    {
        #region BitConverter

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">byte array to convert</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static uint ToUint(this byte[] bytes, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt32(bytes) : ByteConverter.BE_To_UInt32(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">byte array to convert</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static ulong ToUlong(this byte[] bytes, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt64(bytes) : ByteConverter.BE_To_UInt64(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">byte array to convert</param>
        /// <param name="offset">offset index of the conversion</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static uint ToUint(this byte[] bytes, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt32(bytes, offset) : ByteConverter.BE_To_UInt32(bytes, offset);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">byte array to convert</param>
        /// <param name="offset">offset index of the conversion</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static ulong ToUlong(this byte[] bytes, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt64(bytes, offset) : ByteConverter.BE_To_UInt64(bytes, offset);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">number to convert</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static byte[] ToBytes(this uint num, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            var bytes = new byte[Globals.RegisterSize32];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt32_To_LE(num, bytes);
            else
                ByteConverter.UInt32_To_BE(num, bytes);
            return bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">number to convert</param>
        /// <param name="offset">offset index of the conversion</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static byte[] ToBytes(this uint num, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            var bytes = new byte[GetBufferSize(Globals.RegisterSize32, offset)];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt32_To_LE(num, bytes, offset);
            else
                ByteConverter.UInt32_To_BE(num, bytes, offset);
            return bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">number to convert</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns></returns>
        public static byte[] ToBytes(this ulong num, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            var bytes = new byte[Globals.RegisterSize64];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt64_To_LE(num, bytes);
            else
                ByteConverter.UInt64_To_BE(num, bytes);
            return bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">number to convert</param>
        /// <param name="offset">offset index of the conversion</param>
        /// <param name="byteOrder">Endianness of conversion</param>
        /// <returns>byte array</returns>
        public static byte[] ToBytes(this ulong num, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            var bytes = new byte[GetBufferSize(Globals.RegisterSize64, offset)];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt64_To_LE(num, bytes, offset);
            else
                ByteConverter.UInt64_To_BE(num, bytes, offset);
            return bytes;
        }

        /// <summary>
        /// Extends buffer past offset
        /// </summary>
        /// <param name="baseSize">base size of the byte register</param>
        /// <param name="offset">offset index of the conversion</param>
        /// <returns>byte array buffer size</returns>
        private static int GetBufferSize(int baseSize, int offset)
        {
            var count = baseSize;
            while ((offset + baseSize) > count)
                count += baseSize;
            return count;
        }

        #endregion

        #region HexConverter

        /// <summary>
        /// Converts the byte array into a hexadecimal string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>hexadecimal string</returns>
        public static string ToHex(this byte[] bytes)
        {
            return HexConverter.BytesToHex(bytes);
        }

        /// <summary>
        /// Converts an even digit hexadecimal string into a byte array
        /// </summary>
        /// <param name="hex"></param>
        /// <returns>byte array</returns>
        public static byte[] ToBytes(this string hex)
        {
            return HexConverter.HexToBytes(hex);
        }

        /// <summary>
        /// Determins if the input string contains only hexadecimal nibbles
        /// </summary>
        /// <param name="input">input string to check for hex</param>
        /// <returns>true if all characters in string are valid hex nibbles</returns>
        public static bool HasValidHexChars(this string input)
        {
            return HexConverter.ContainsOnlyHexNibbles(input);
        }

        #endregion
    }
}
