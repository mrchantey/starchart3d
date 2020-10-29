
using UnityEngine;
using Unity.Collections;
namespace Ahoy
{

    public static class ByteConverterBigEndian
    {


        public static void InsertBytesBigEndian(NativeArray<byte> bytes, int val, int offset)
        {
            bytes[offset] = (byte)(val >> 24);
            bytes[offset + 1] = (byte)(val >> 16);
            bytes[offset + 2] = (byte)(val >> 8);
            bytes[offset + 3] = (byte)val;
        }
        public static byte[] GetBytesBigEndian(int val)
        {
            var bytes = new byte[4];
            bytes[0] = (byte)(val >> 24);
            bytes[1] = (byte)(val >> 16);
            bytes[2] = (byte)(val >> 8);
            bytes[3] = (byte)val;
            return bytes;
        }
        public static int ToInt32BigEndian(byte[] bytes, int offset = 0)
        {
            var val = 0;
            val += (int)(bytes[offset] << 24);
            val += (int)(bytes[offset + 1] << 16);
            val += (int)(bytes[offset + 2] << 8);
            val += (int)(bytes[offset + 3]);
            return val;
        }
        public static int ToInt32BigEndian(NativeArray<byte> bytes, int offset)
        {
            var val = 0;
            val += (int)(bytes[offset] << 24);
            val += (int)(bytes[offset + 1] << 16);
            val += (int)(bytes[offset + 2] << 8);
            val += (int)(bytes[offset + 3]);
            return val;
        }

    }
}