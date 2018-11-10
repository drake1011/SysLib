using System;
using System.Globalization;
using System.Linq;

namespace SysLib.Bitwise
{
    public static class HexConverter
    {
        /// <summary>
        /// All possible hex nibbles
        /// </summary>
        public static string HexNibbles { get => "0123456789abcdefABCDEF"; }

        /// <summary>
        /// Converts an even digit hexadecimal string into a byte array
        /// </summary>
        /// <param name="hex">input hexadecimal string</param>
        /// <returns>byte array</returns>
        public static byte[] HexToBytes(string hex)
        {
            if (hex == null)
                throw new ArgumentNullException("Input string cannot be null");

            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException($"The binary key cannot have an odd number of digits: {hex}");
            }

            if(!ContainsOnlyHexNibbles(hex))
                throw new ArgumentException($"The hex string has invalid nibble(s)");

            var bytes = new byte[hex.Length / 2];
            var byteValue = string.Empty;
            try
            {
                for (int index = 0; index < bytes.Length; index++)
                {
                    byteValue = hex.Substring(index * 2, 2);
                    bytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber);
                }
            }
            catch (FormatException fex)
            {
                throw new FormatException($"{fex.Message} Invalid Hex value: {byteValue}", fex);
            }

            return bytes;
        }

        /// <summary>
        /// Converts the byte array into a hexadecimal string
        /// </summary>
        /// <param name="bytes">input byte array</param>
        /// <returns>hexadecimal string</returns>
        public static string BytesToHex(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("Input array cannot be null");

            var hex = string.Empty;
            foreach (byte b in bytes)
            {
                hex += b.ToString("X2");
            }
            return hex;
        }

        /// <summary>
        /// Determins if the input string contains only hexadecimal nibbles
        /// </summary>
        /// <param name="value">input string to check for hex</param>
        /// <returns>true if all characters in string are valid hex nibbles</returns>
        public static bool ContainsOnlyHexNibbles(string value) => value.All(HexNibbles.Contains);
    }
}
