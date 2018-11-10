using SysLib.Bitwise;
using System;
using Xunit;

namespace SysLib.XUnitTests
{
    public class BitwiseTests
    {
        private const string _hex32 = "0C1D2E3F";
        private const string _hex64 = "A1A2A3A4B0B1B2B3";

        private const uint _uintData = 1059986700;
        private const ulong _ulongData = 11647051514067923635;

        private readonly byte[] _bytes = new byte[] { 0x0C, 0x1D, 0x2E, 0x3F };

        [Fact]
        public void Test_BE_Int64()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex64);
            var intResult = Bitwise.BitConverter.BE_To_UInt64(bytes);

            var buffer = new byte[8];
            Bitwise.BitConverter.UInt64_To_BE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(_hex64, hexResult);
        }

        [Fact]
        public void Test_BE_Int32()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex32);
            var intResult = Bitwise.BitConverter.BE_To_UInt32(bytes);

            var buffer = new byte[4];
            Bitwise.BitConverter.UInt32_To_BE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(_hex32, hexResult);
        }

        [Fact]
        public void Test_LE_Int64()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex64);
            var intResult = Bitwise.BitConverter.LE_To_UInt64(bytes);

            var buffer = new byte[8];
            Bitwise.BitConverter.UInt64_To_LE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(_hex64, hexResult);
        }

        [Fact]
        public void Test_LE_Int32()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex32);
            var intResult = Bitwise.BitConverter.LE_To_UInt32(bytes);

            var buffer = new byte[4];
            Bitwise.BitConverter.UInt32_To_LE(intResult, buffer);

            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);

            Assert.Equal(_hex32, hexResult);
        }

        [Theory]
        [InlineData(new byte[] { })]
        [InlineData(new byte[] { 0, 1, 2 })]
        public void Test_BitConvert_uint_ArrayTooSmall_Fail(byte[] bytes)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.LE_To_UInt32(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.BE_To_UInt32(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt32_To_LE(_uintData, bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt32_To_BE(_uintData, bytes));
        }

        [Theory]
        [InlineData(new byte[] { 0, 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 3)]
        public void Test_BitConvert_uint_offsetOutOfBounds_Fail(byte[] bytes, int offset)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.LE_To_UInt32(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.BE_To_UInt32(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt32_To_LE(_uintData, bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt32_To_BE(_uintData, bytes, offset));
        }

        [Theory]
        [InlineData(new byte[] { })]
        [InlineData(new byte[] { 0, 1, 2 })]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 })]
        public void Test_BitConvert_ulong_ArrayTooSmall_Fail(byte[] bytes)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.LE_To_UInt64(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.BE_To_UInt64(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt64_To_LE(_ulongData, bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt64_To_BE(_ulongData, bytes));
        }

        [Theory]
        [InlineData(new byte[] { 0, 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 3)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 0)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 1)]
        public void Test_BitConvert_ulong_offsetOutOfBounds_Fail(byte[] bytes, int offset)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.LE_To_UInt64(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.BE_To_UInt64(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt64_To_LE(_ulongData, bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.BitConverter.UInt64_To_BE(_ulongData, bytes, offset));
        }

        [Fact]
        public void Test_HexConvert_HexToBytes_Pass()
        {
            var result = HexConverter.HexToBytes(_hex32);
            Assert.Equal(result, _bytes);
        }

        [Theory]
        [InlineData("010")]
        [InlineData("FFFFFFNF")]
        [InlineData("FFFFFFFF0")]
        public void Test_HexConvert_HexToBytes_Fail(string hex)
        {
            Assert.Throws<ArgumentException>(() => HexConverter.HexToBytes(hex));
            Assert.Throws<ArgumentNullException>(() => HexConverter.HexToBytes(null));
        }

        [Fact]
        public void Test_HexConvert_BytesToHex_Pass()
        {
            var result = HexConverter.BytesToHex(_bytes);
            Assert.Equal(result, _hex32);
        }

        [Fact]
        public void Test_HexConvert_BytesToHex_Fail()
        {
            Assert.Throws<ArgumentNullException>(() => HexConverter.BytesToHex(null));
        }

        [Theory]
        [InlineData("010")]
        [InlineData("Fa6bcFF")]
        [InlineData("123ad")]
        public void Test_HexConvert_Nibble_Pass(string hex)
        {
            Assert.True(HexConverter.ContainsOnlyHexNibbles(hex));
        }

        [Theory]
        [InlineData("01n0")]
        [InlineData("Fa6bc!FF")]
        [InlineData("123a d")]
        [InlineData("0x0A")]
        public void Test_HexConvert_Nibble_Fail(string hex)
        {
            Assert.False(HexConverter.ContainsOnlyHexNibbles(hex));
        }
    }
}
