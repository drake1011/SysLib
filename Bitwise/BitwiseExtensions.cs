using System;
using System.Collections.Generic;
using System.Text;


namespace SysLib.Bitwise
{
    public static class BitwiseExtensions
    {
        #region BitConverter
        public static string ToHex(this byte[] bytes)
        {
            return HexConverter.BytesToHex(bytes);
        }

        public static byte[] ToBytes(this string hex)
        {
            return HexConverter.HexToBytes(hex);
        }

        public static uint ToUint(this byte[] bytes, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt32(bytes) : ByteConverter.BE_To_UInt32(bytes);
        }

        public static ulong ToUlong(this byte[] bytes, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt64(bytes) : ByteConverter.BE_To_UInt64(bytes);
        }

        public static uint ToUint(this byte[] bytes, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt32(bytes, offset) : ByteConverter.BE_To_UInt32(bytes, offset);
        }

        public static ulong ToUlong(this byte[] bytes, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return byteOrder == ByteOrder.LittleEndian ? ByteConverter.LE_To_UInt64(bytes, offset) : ByteConverter.BE_To_UInt64(bytes, offset);
        }

        public static byte[] ToBytes(this uint num, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            var bytes = new byte[Globals.RegisterSize32];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt32_To_LE(num, bytes);
            else
                ByteConverter.UInt32_To_BE(num, bytes);
            return bytes;
        }

        public static byte[] ToBytes(this uint num, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            int count = Globals.RegisterSize32;
            while ((offset + Globals.RegisterSize32) > count)
                count += Globals.RegisterSize32;

            var bytes = new byte[count];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt32_To_LE(num, bytes, offset);
            else
                ByteConverter.UInt32_To_BE(num, bytes, offset);
            return bytes;
        }

        public static byte[] ToBytes(this ulong num, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            var bytes = new byte[Globals.RegisterSize64];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt64_To_LE(num, bytes);
            else
                ByteConverter.UInt64_To_BE(num, bytes);
            return bytes;
        }

        public static byte[] ToBytes(this ulong num, int offset, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            int count = Globals.RegisterSize64;
            while ((offset + Globals.RegisterSize64) > count)
                count += Globals.RegisterSize64;

            var bytes = new byte[count];
            if (byteOrder == ByteOrder.LittleEndian)
                ByteConverter.UInt64_To_LE(num, bytes, offset);
            else
                ByteConverter.UInt64_To_BE(num, bytes, offset);
            return bytes;
        }

        #endregion

        #region HexConverter

        public static byte[] HexToBytes(this string hex)
        {
            return HexConverter.HexToBytes(hex);
        }

        public static string BytesToHex(this byte[] bytes)
        {
            return HexConverter.BytesToHex(bytes);
        }

        public static bool HasValidHexChars(this string input)
        {
            return HexConverter.ContainsOnlyHexNibbles(input);
        }

        #endregion
    }
}
