// TGFramework.dll - Google.Protobuf.CodedOutputStream
// Extracted from IL2CPP metadata v39
// Method count: 71
// NOTE: Method bodies are stubs - require native decompilation

namespace Google.Protobuf
{
    public class CodedOutputStream
    {
        #region Constructors
        // 0x04CA308C
        public CodedOutputStream(byte) { }
        // 0x04CA30A4
        public CodedOutputStream(byte) { }
        // 0x04CA3108
        public CodedOutputStream(Stream, Byte[], Boolean) { }
        // 0x04CA31D4
        public CodedOutputStream(Stream) { }
        // 0x04CA32C0
        public CodedOutputStream(Stream, Int32) { }
        // 0x04CA332C
        public CodedOutputStream(Stream, Boolean) { }
        // 0x04CA3248
        public CodedOutputStream(Stream, Int32, Boolean) { }
        // 0x04CA4188
        public CodedOutputStream() { }
        #endregion

        #region Methods
        // 0x04CA0810: Void WriteRawBytes(Byte[], Int32, Int32)
        public void WriteRawBytes(byte) { return default; }
        // 0x04CA28A0: Int32 ComputeDoubleSize(Double)
        public int ComputeDoubleSize(double) { return default; }
        // 0x04CA28A8: Int32 ComputeFloatSize(Single)
        public int ComputeFloatSize(float) { return default; }
        // 0x04CA28B0: Int32 ComputeUInt64Size(UInt64)
        public int ComputeUInt64Size(ulong) { return default; }
        // 0x04CA2904: Int32 ComputeRawVarint64Size(UInt64)
        public int ComputeRawVarint64Size(ulong) { return default; }
        // 0x04CA2994: Int32 ComputeInt64Size(Int64)
        public int ComputeInt64Size(long) { return default; }
        // 0x04CA29E8: Int32 ComputeInt32Size(Int32)
        public int ComputeInt32Size(int) { return default; }
        // 0x04CA2A84: Int32 ComputeRawVarint32Size(UInt32)
        public int ComputeRawVarint32Size(uint) { return default; }
        // 0x04CA2AC8: Int32 ComputeFixed64Size(UInt64)
        public int ComputeFixed64Size(ulong) { return default; }
        // 0x04CA2AD0: Int32 ComputeFixed32Size(UInt32)
        public int ComputeFixed32Size(uint) { return default; }
        // 0x04CA2AD8: Int32 ComputeBoolSize(Boolean)
        public int ComputeBoolSize(bool) { return default; }
        // 0x04CA2AE0: Int32 ComputeStringSize(String)
        public int ComputeStringSize(string) { return default; }
        // 0x04CA2B60: Int32 ComputeLengthSize(Int32)
        public int ComputeLengthSize(int) { return default; }
        // 0x04CA2BF0: Int32 ComputeGroupSize(IMessage)
        public int ComputeGroupSize(IMessage) { return default; }
        // 0x04CA2C90: Int32 ComputeMessageSize(IMessage)
        public int ComputeMessageSize(IMessage) { return default; }
        // 0x04CA2D6C: Int32 ComputeBytesSize(ByteString)
        public int ComputeBytesSize(ByteString) { return default; }
        // 0x04CA2DE8: Int32 ComputeUInt32Size(UInt32)
        public int ComputeUInt32Size(uint) { return default; }
        // 0x04CA2E78: Int32 ComputeEnumSize(Int32)
        public int ComputeEnumSize(int) { return default; }
        // 0x04CA2ECC: Int32 ComputeSFixed32Size(Int32)
        public int ComputeSFixed32Size(int) { return default; }
        // 0x04CA2ED4: Int32 ComputeSFixed64Size(Int64)
        public int ComputeSFixed64Size(long) { return default; }
        // 0x04CA2EDC: Int32 ComputeSInt32Size(Int32)
        public int ComputeSInt32Size(int) { return default; }
        // 0x04CA2F74: UInt32 EncodeZigZag32(Int32)
        public uint EncodeZigZag32(int) { return default; }
        // 0x04CA2F80: Int32 ComputeSInt64Size(Int64)
        public int ComputeSInt64Size(long) { return default; }
        // 0x04CA2FD8: UInt64 EncodeZigZag64(Int64)
        public ulong EncodeZigZag64(long) { return default; }
        // 0x04CA2FE4: Int32 ComputeTagSize(Int32)
        public int ComputeTagSize(int) { return default; }
        // 0x04CA33A4: Int64 get_Position()
        public long get_Position() { return default; }
        // 0x04CA33D8: Void WriteDouble(Double)
        public void WriteDouble(double) { return default; }
        // 0x04CA33E0: Void WriteRawLittleEndian64(UInt64)
        public void WriteRawLittleEndian64(ulong) { return default; }
        // 0x04CA35D8: Void WriteFloat(Single)
        public void WriteFloat(float) { return default; }
        // 0x04CA3700: Void WriteUInt64(UInt64)
        public void WriteUInt64(ulong) { return default; }
        // 0x04CA3704: Void WriteRawVarint64(UInt64)
        public void WriteRawVarint64(ulong) { return default; }
        // 0x04CA37EC: Void WriteInt64(Int64)
        public void WriteInt64(long) { return default; }
        // 0x04CA37F0: Void WriteInt32(Int32)
        public void WriteInt32(int) { return default; }
        // 0x04CA3800: Void WriteRawVarint32(UInt32)
        public void WriteRawVarint32(uint) { return default; }
        // 0x04CA38FC: Void WriteFixed64(UInt64)
        public void WriteFixed64(ulong) { return default; }
        // 0x04CA3900: Void WriteFixed32(UInt32)
        public void WriteFixed32(uint) { return default; }
        // 0x04CA3904: Void WriteRawLittleEndian32(UInt32)
        public void WriteRawLittleEndian32(uint) { return default; }
        // 0x04CA3A1C: Void WriteBool(Boolean)
        public void WriteBool(bool) { return default; }
        // 0x04CA3A30: Void WriteRawByte(Byte)
        public void WriteRawByte(byte) { return default; }
        // 0x04CA3A90: Void WriteString(String)
        public void WriteString(string) { return default; }
        // 0x04CA3C3C: Void WriteLength(Int32)
        public void WriteLength(int) { return default; }
        // 0x04CA3C40: Void WriteRawBytes(Byte[])
        public void WriteRawBytes(byte) { return default; }
        // 0x04CA3C58: Void WriteMessage(IMessage)
        public void WriteMessage(IMessage) { return default; }
        // 0x04CA3D68: Void WriteBytes(ByteString)
        public void WriteBytes(ByteString) { return default; }
        // 0x04CA3DA4: Void WriteUInt32(UInt32)
        public void WriteUInt32(uint) { return default; }
        // 0x04CA3DA8: Void WriteEnum(Int32)
        public void WriteEnum(int) { return default; }
        // 0x04CA3DAC: Void WriteSFixed32(Int32)
        public void WriteSFixed32(int) { return default; }
        // 0x04CA3DB0: Void WriteSFixed64(Int64)
        public void WriteSFixed64(long) { return default; }
        // 0x04CA3DB4: Void WriteSInt32(Int32)
        public void WriteSInt32(int) { return default; }
        // 0x04CA3E1C: Void WriteSInt64(Int64)
        public void WriteSInt64(long) { return default; }
        // 0x04CA3E84: Void WriteTag(Int32, WireFormat+WireType)
        public void WriteTag(Int32, WireFormat+WireType) { return default; }
        // 0x04CA3EAC: Void WriteTag(UInt32)
        public void WriteTag(uint) { return default; }
        // 0x04CA3EB0: Void WriteRawTag(Byte)
        public void WriteRawTag(byte) { return default; }
        // 0x04CA3EB4: Void WriteRawTag(Byte, Byte)
        public void WriteRawTag(Byte, Byte) { return default; }
        // 0x04CA3EDC: Void WriteRawTag(Byte, Byte, Byte)
        public void WriteRawTag(Byte, Byte, Byte) { return default; }
        // 0x04CA3F14: Void WriteRawTag(Byte, Byte, Byte, Byte)
        public void WriteRawTag(Byte, Byte, Byte, Byte) { return default; }
        // 0x04CA3F64: Void WriteRawTag(Byte, Byte, Byte, Byte, Byte)
        public void WriteRawTag(Byte, Byte, Byte, Byte, Byte) { return default; }
        // 0x04CA3FC4: Void RefreshBuffer()
        public void RefreshBuffer() { return default; }
        // 0x04CA402C: Void WriteRawByte(UInt32)
        public void WriteRawByte(uint) { return default; }
        // 0x04CA407C: Void Dispose()
        public void Dispose() { return default; }
        // 0x04CA40BC: Void Flush()
        public void Flush() { return default; }
        // 0x04CA40CC: Void CheckNoSpaceLeft()
        public void CheckNoSpaceLeft() { return default; }
        // 0x04CA4128: Int32 get_SpaceLeft()
        public int get_SpaceLeft() { return default; }
        #endregion
    }
}
