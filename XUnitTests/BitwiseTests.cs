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

        private readonly byte[] _bytes32 = new byte[] { 0x0C, 0x1D, 0x2E, 0x3F };
        private readonly byte[] _bytes64 = new byte[] { 0x0C, 0x1D, 0x2E, 0x3F, 0x11, 0xFF, 0xA0, 0x44 };

        [Fact]
        public void Test_BE_Int64()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex64);
            var intResult = Bitwise.ByteConverter.BE_To_UInt64(bytes);
            var buffer = new byte[8];
            Bitwise.ByteConverter.UInt64_To_BE(intResult, buffer);
            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);
            Assert.Equal(_hex64, hexResult);
        }

        [Fact]
        public void Test_BE_Int64_Ext()
        {
            var bytes = _hex64.HexToBytes();
            var intResult = bytes.ToUlong(ByteOrder.BigEndian);
            var buffer = intResult.ToBytes(ByteOrder.BigEndian);
            var hexResult = buffer.BytesToHex();
            Assert.Equal(_hex64, hexResult);
        }

        [Fact]
        public void Test_BE_Int32()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex32);
            var intResult = Bitwise.ByteConverter.BE_To_UInt32(bytes);
            var buffer = new byte[4];
            Bitwise.ByteConverter.UInt32_To_BE(intResult, buffer);
            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);
            Assert.Equal(_hex32, hexResult);
        }

        [Fact]
        public void Test_BE_Int32_Ext()
        {
            var bytes = _hex32.HexToBytes();
            var intResult = bytes.ToUint(ByteOrder.BigEndian);
            var buffer = intResult.ToBytes(ByteOrder.BigEndian);
            var hexResult = buffer.BytesToHex();
            Assert.Equal(_hex32, hexResult);
        }

        [Fact]
        public void Test_LE_Int64()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex64);
            var intResult = Bitwise.ByteConverter.LE_To_UInt64(bytes);
            var buffer = new byte[8];
            Bitwise.ByteConverter.UInt64_To_LE(intResult, buffer);
            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);
            Assert.Equal(_hex64, hexResult);
        }

        [Fact]
        public void Test_LE_Int64_Ext()
        {
            var bytes = _hex64.HexToBytes();
            var intResult = bytes.ToUlong();
            var buffer = intResult.ToBytes();
            var hexResult = buffer.BytesToHex();
            Assert.Equal(_hex64, hexResult);
        }

        [Fact]
        public void Test_LE_Int32()
        {
            var bytes = Bitwise.HexConverter.HexToBytes(_hex32);
            var intResult = Bitwise.ByteConverter.LE_To_UInt32(bytes);
            var buffer = new byte[4];
            Bitwise.ByteConverter.UInt32_To_LE(intResult, buffer);
            var hexResult = Bitwise.HexConverter.BytesToHex(buffer);
            Assert.Equal(_hex32, hexResult);
        }

        [Fact]
        public void Test_LE_Int32_Ext()
        {
            var bytes = _hex32.HexToBytes();
            var intResult = bytes.ToUint();
            var buffer = intResult.ToBytes();
            var hexResult = buffer.BytesToHex();
            Assert.Equal(_hex32, hexResult);
        }

        [Theory]
        [InlineData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 1)]
        [InlineData(new byte[] { 9, 5, 2, 3, 0, 0, 0, 0 }, 4)]
        [InlineData(new byte[] { 9, 5, 2, 0, 0, 0, 0, 0 }, 3)]
        public void Test_Int32_Off(byte[] bytes, int offset)
        {
            var intResultLE = Bitwise.ByteConverter.LE_To_UInt32(bytes, offset);
            var intResultBE = Bitwise.ByteConverter.LE_To_UInt32(bytes, offset);
            Assert.Equal((uint)0, intResultLE);
            Assert.Equal((uint)0, intResultBE);
        }

        [Theory]
        [InlineData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 1)]
        [InlineData(new byte[] { 9, 5, 2, 3, 0, 0, 0, 0 }, 4)]
        [InlineData(new byte[] { 9, 5, 2, 0, 0, 0, 0, 0 }, 3)]
        public void Test_Int32_Off_Ext(byte[] bytes, int offset)
        {
            var intResultLE = bytes.ToUint(offset);
            var intResultBE = bytes.ToUint(offset, ByteOrder.BigEndian);
            Assert.Equal((uint)0, intResultLE);
            Assert.Equal((uint)0, intResultBE);
        }

        [Theory]
        [InlineData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 1)]
        [InlineData(new byte[] { 9, 5, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 4)]
        [InlineData(new byte[] { 9, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 3)]
        public void Test_Int64_Off(byte[] bytes, int offset)
        {
            var intResultLE = Bitwise.ByteConverter.LE_To_UInt64(bytes, offset);
            var intResultBE = Bitwise.ByteConverter.LE_To_UInt64(bytes, offset);
            Assert.Equal((uint)0, intResultLE);
            Assert.Equal((uint)0, intResultBE);
        }

        [Theory]
        [InlineData(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 1)]
        [InlineData(new byte[] { 9, 5, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 4)]
        [InlineData(new byte[] { 9, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 3)]
        public void Test_Int64_Off_Ext(byte[] bytes, int offset)
        {
            var intResultLE = bytes.ToUlong(offset);
            var intResultBE = bytes.ToUlong(offset, ByteOrder.BigEndian);
            Assert.Equal((uint)0, intResultLE);
            Assert.Equal((uint)0, intResultBE);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void Test_Byte32_Off(int offset)
        {
            var bufferLE = new byte[8];
            var bufferBE = new byte[8];
            Bitwise.ByteConverter.UInt32_To_LE(_uintData, bufferLE, offset);
            Bitwise.ByteConverter.UInt32_To_BE(_uintData, bufferBE, offset);
            Assert.Equal(byte.MinValue, bufferLE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferLE[offset]);
            Assert.Equal(byte.MinValue, bufferBE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferBE[offset]);
            Assert.NotEqual(bufferLE[offset], bufferBE[offset]);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void Test_Byte32_Off_Ext(int offset)
        {
            var bufferLE = _uintData.ToBytes(offset);
            var bufferBE = _uintData.ToBytes(offset, ByteOrder.BigEndian);
            Assert.Equal(byte.MinValue, bufferLE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferLE[offset]);
            Assert.Equal(byte.MinValue, bufferBE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferBE[offset]);
            Assert.NotEqual(bufferLE[offset], bufferBE[offset]);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void Test_Byte64_Off(int offset)
        {
            var bufferLE = new byte[16];
            var bufferBE = new byte[16];
            Bitwise.ByteConverter.UInt64_To_LE(_ulongData, bufferLE, offset);
            Bitwise.ByteConverter.UInt64_To_BE(_ulongData, bufferBE, offset);
            Assert.Equal(byte.MinValue, bufferLE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferLE[offset]);
            Assert.Equal(byte.MinValue, bufferBE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferBE[offset]);
            Assert.NotEqual(bufferLE[offset], bufferBE[offset]);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void Test_Byte64_Off_Ext(int offset)
        {
            var bufferLE = _ulongData.ToBytes(offset);
            var bufferBE = _ulongData.ToBytes(offset, ByteOrder.BigEndian);
            Assert.Equal(byte.MinValue, bufferLE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferLE[offset]);
            Assert.Equal(byte.MinValue, bufferBE[offset - 1]);
            Assert.NotEqual(byte.MinValue, bufferBE[offset]);
            Assert.NotEqual(bufferLE[offset], bufferBE[offset]);
        }

        [Theory]
        [InlineData(new byte[] { })]
        [InlineData(new byte[] { 0, 1, 2 })]
        public void Test_BitConvert_uint_ArrayTooSmall_Fail(byte[] bytes)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.LE_To_UInt32(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.BE_To_UInt32(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt32_To_LE(_uintData, bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt32_To_BE(_uintData, bytes));
        }

        [Theory]
        [InlineData(new byte[] { })]
        [InlineData(new byte[] { 0, 1, 2 })]
        public void Test_BitConvert_uint_ArrayTooSmall_Fail_Ext(byte[] bytes)
        {
            Assert.Throws<ArgumentException>(() => bytes.ToUint());
            Assert.Throws<ArgumentException>(() => bytes.ToUint(ByteOrder.BigEndian));
        }

        [Theory]
        [InlineData(new byte[] { 0, 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 3)]
        public void Test_BitConvert_uint_offsetOutOfBounds_Fail(byte[] bytes, int offset)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.LE_To_UInt32(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.BE_To_UInt32(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt32_To_LE(_uintData, bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt32_To_BE(_uintData, bytes, offset));
        }

        [Theory]
        [InlineData(new byte[] { 0, 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 3)]
        public void Test_BitConvert_uint_offsetOutOfBounds_Fail_Ext(byte[] bytes, int offset)
        {
            Assert.Throws<ArgumentException>(() => bytes.ToUint(offset));
            Assert.Throws<ArgumentException>(() => bytes.ToUint(offset, ByteOrder.BigEndian));
        }

        [Theory]
        [InlineData(new byte[] { })]
        [InlineData(new byte[] { 0, 1, 2 })]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 })]
        public void Test_BitConvert_ulong_ArrayTooSmall_Fail(byte[] bytes)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.LE_To_UInt64(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.BE_To_UInt64(bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt64_To_LE(_ulongData, bytes));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt64_To_BE(_ulongData, bytes));
        }

        [Theory]
        [InlineData(new byte[] { })]
        [InlineData(new byte[] { 0, 1, 2 })]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 })]
        public void Test_BitConvert_ulong_ArrayTooSmall_Fail_Ext(byte[] bytes)
        {
            Assert.Throws<ArgumentException>(() => bytes.ToUlong());
            Assert.Throws<ArgumentException>(() => bytes.ToUlong(ByteOrder.BigEndian));
        }

        [Theory]
        [InlineData(new byte[] { 0, 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 3)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 10)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 1)]
        public void Test_BitConvert_ulong_offsetOutOfBounds_Fail(byte[] bytes, int offset)
        {
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.LE_To_UInt64(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.BE_To_UInt64(bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt64_To_LE(_ulongData, bytes, offset));
            Assert.Throws<ArgumentException>(() => Bitwise.ByteConverter.UInt64_To_BE(_ulongData, bytes, offset));
        }

        [Theory]
        [InlineData(new byte[] { 0, 1, 2, 3 }, 1)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 3)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4 }, 10)]
        [InlineData(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 1)]
        public void Test_BitConvert_ulong_offsetOutOfBounds_Fail_Ext(byte[] bytes, int offset)
        {
            Assert.Throws<ArgumentException>(() => bytes.ToUlong(offset));
            Assert.Throws<ArgumentException>(() => bytes.ToUlong(offset, ByteOrder.BigEndian));
        }

        [Fact]
        public void Test_HexConvert_HexToBytes_Pass()
        {
            var result = HexConverter.HexToBytes(_hex32);
            Assert.Equal(_bytes32, result);
        }

        [Fact]
        public void Test_HexConvert_HexToBytes_Pass_Ext()
        {
            var result = _hex32.HexToBytes();
            Assert.Equal(_bytes32, result);
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

        [Theory]
        [InlineData("010")]
        [InlineData("FFFFFFNF")]
        [InlineData("FFFFFFFF0")]
        public void Test_HexConvert_HexToBytes_Fail_Ext(string hex)
        {
            Assert.Throws<ArgumentException>(() => hex.HexToBytes());
        }

        [Fact]
        public void Test_HexConvert_BytesToHex_Pass()
        {
            var result = HexConverter.BytesToHex(_bytes32);
            Assert.Equal(_hex32, result);
        }

        [Fact]
        public void Test_HexConvert_BytesToHex_Pass_Ext()
        {
            var result = _bytes32.BytesToHex();
            Assert.Equal(_hex32, result);
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
        [InlineData("010")]
        [InlineData("Fa6bcFF")]
        [InlineData("123ad")]
        public void Test_HexConvert_Nibble_Pass_Ext(string hex)
        {
            Assert.True(hex.HasValidHexChars());
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

        [Theory]
        [InlineData("01n0")]
        [InlineData("Fa6bc!FF")]
        [InlineData("123a d")]
        [InlineData("0x0A")]
        public void Test_HexConvert_Nibble_Fail_Ext(string hex)
        {
            Assert.False(hex.HasValidHexChars());
        }
    }
}
