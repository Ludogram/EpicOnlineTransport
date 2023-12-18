using System;

namespace EpicTransport {
    public struct Packet {
        public const int headerSize = sizeof(uint) + sizeof(uint) + 1;
        public int size => headerSize + data.Length;

        // header
        public int id;
        public int fragment;
        public bool moreFragments;

        // body
        public byte[] data;

        public byte[] ToBytes() {
            byte[] array = new byte[size];

            // Copy id
            array[0] = (byte)  id;
            array[1] = (byte) (id >> 8);
            array[2] = (byte) (id >> 0x10);
            array[3] = (byte) (id >> 0x18);

            // Copy fragment
            array[4] = (byte) fragment;
            array[5] = (byte) (fragment >> 8);
            array[6] = (byte) (fragment >> 0x10);
            array[7] = (byte) (fragment >> 0x18);

            array[8] = moreFragments ? (byte)1 : (byte)0;

            Array.Copy(data, 0, array, 9, data.Length);

            return array;
        }

        public void FromBytes(ArraySegment<byte> array) {
	        id = BitConverter.ToInt32(array.AsSpan());
	        fragment = BitConverter.ToInt32(array.AsSpan(4));
	        moreFragments = array[8] == 1;

	        data = new byte[array.Count - 9];
	        
	        array[9..].CopyTo(data, 0);
        }

        public void FromBytes(byte[] array) {
	        FromBytes(new ArraySegment<byte>(array));
        }
    }
}