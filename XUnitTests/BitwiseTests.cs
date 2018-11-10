using SysLib.Bitwise;
using System;
using Xunit;

namespace SysLib.XUnitTests
{
    public class BitwiseTests
    {
        private const string hex32 = "0C1D2E3F";
        private const string hex64 = "A1A2A3A4B0B1B2B3";

        [Fact]
        public void Test_BE_Int64()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(hex64);
            var intResult = Bitwise.BitConverter.BE_To_UInt64(bytes);

            var buffer = new byte[8];
            Bitwise.BitConverter.UInt64_To_BE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(hex64, hexResult);
        }

        [Fact]
        public void Test_BE_Int32()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(hex32);
            var intResult = Bitwise.BitConverter.BE_To_UInt32(bytes);

            var buffer = new byte[4];
            Bitwise.BitConverter.UInt32_To_BE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(hex32, hexResult);
        }

        [Fact]
        public void Test_LE_Int64()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(hex64);
            var intResult = Bitwise.BitConverter.LE_To_UInt64(bytes);

            var buffer = new byte[8];
            Bitwise.BitConverter.UInt64_To_LE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(hex64, hexResult);
        }

        [Fact]
        public void Test_LE_Int32()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(hex32);
            var intResult = Bitwise.BitConverter.LE_To_UInt32(bytes);

            var buffer = new byte[4];
            Bitwise.BitConverter.UInt32_To_LE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(hex32, hexResult);
        }
    }
}
