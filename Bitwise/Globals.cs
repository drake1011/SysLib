namespace SysLib.Bitwise
{
    public class Globals
    {
        public static int RegisterSize32 { get; } = 4;
        public static int RegisterSize64 { get; } = 8;
    }

    public enum ByteOrder
    {
        LittleEndian = 0,
        BigEndian = 1
    }
}
