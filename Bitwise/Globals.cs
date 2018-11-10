namespace SysLib.Bitwise
{
    public class Globals
    {
        /// <summary>
        /// Size of uint32 byte register
        /// </summary>
        public static int RegisterSize32 { get; } = 4;

        /// <summary>
        /// Size of uint64 byte register
        /// </summary>
        public static int RegisterSize64 { get; } = 8;
    }

    /// <summary>
    /// Specifies endianness of byte storage
    /// </summary>
    public enum ByteOrder
    {
        LittleEndian = 0,
        BigEndian = 1
    }
}
