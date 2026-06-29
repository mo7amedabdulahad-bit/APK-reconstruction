// TGFramework.dll - Google.Protobuf.CodedInputStream
// Extracted from IL2CPP metadata v39
// Method count: 54
// NOTE: Method bodies are stubs - require native decompilation

namespace Google.Protobuf
{
    public class CodedInputStream
    {
        #region Constructors
        // 0x04CA0518
        public CodedInputStream(byte) { }
        // 0x04CA0AE4
        public CodedInputStream(byte) { }
        // 0x04CA0C30
        public CodedInputStream(Stream) { }
        // 0x04CA0C38
        public CodedInputStream(Stream, Boolean) { }
        // 0x04CA0A70
        public CodedInputStream(Stream, Byte[], Int32, Int32) { }
        // 0x04CA0CFC
        public CodedInputStream(Stream, Byte[], Int32, Int32, Int32, Int32) { }
        #endregion

        #region Static Methods
        // 0x04CA0DC0: CodedInputStream CreateWithLimits(Stream, Int32, Int32)
        public static CodedInputStream CreateWithLimits(Stream, Int32, Int32) { return default; }
        #endregion

        #region Methods
        // 0x04CA0E6C: Int64 get_Position()
        public long get_Position() { return default; }
        // 0x04CA0EAC: UInt32 get_LastTag()
        public uint get_LastTag() { return default; }
        // 0x04CA0EB4: Int32 get_SizeLimit()
        public int get_SizeLimit() { return default; }
        // 0x04CA0EBC: Int32 get_RecursionLimit()
        public int get_RecursionLimit() { return default; }
        // 0x04CA0EC4: Void Dispose()
        public void Dispose() { return default; }
        // 0x04CA0EE8: Void CheckReadEndOfStreamTag()
        public void CheckReadEndOfStreamTag() { return default; }
        // 0x04CA0F84: UInt32 PeekTag()
        public uint PeekTag() { return default; }
        // 0x04CA0FC4: UInt32 ReadTag()
        public uint ReadTag() { return default; }
        // 0x04CA10B8: UInt32 ReadRawVarint32()
        public uint ReadRawVarint32() { return default; }
        // 0x04CA121C: Boolean get_IsAtEnd()
        public bool get_IsAtEnd() { return default; }
        // 0x04CA12BC: Void SkipLastField()
        public void SkipLastField() { return default; }
        // 0x04CA13D4: Void SkipGroup(UInt32)
        public void SkipGroup(uint) { return default; }
        // 0x04CA153C: UInt32 ReadFixed32()
        public uint ReadFixed32() { return default; }
        // 0x04CA1540: UInt64 ReadFixed64()
        public ulong ReadFixed64() { return default; }
        // 0x04CA1544: Int32 ReadLength()
        public int ReadLength() { return default; }
        // 0x04CA1548: Void SkipRawBytes(Int32)
        public void SkipRawBytes(int) { return default; }
        // 0x04CA16D4: Double ReadDouble()
        public double ReadDouble() { return default; }
        // 0x04CA16E8: UInt64 ReadRawLittleEndian64()
        public ulong ReadRawLittleEndian64() { return default; }
        // 0x04CA1790: Single ReadFloat()
        public float ReadFloat() { return default; }
        // 0x04CA17E8: Byte[] ReadRawBytes(Int32)
        public byte ReadRawBytes(int) { return default; }
        // 0x04CA1C88: UInt64 ReadUInt64()
        public ulong ReadUInt64() { return default; }
        // 0x04CA1C8C: UInt64 ReadRawVarint64()
        public ulong ReadRawVarint64() { return default; }
        // 0x04CA1CF4: Int64 ReadInt64()
        public long ReadInt64() { return default; }
        // 0x04CA1CF8: Int32 ReadInt32()
        public int ReadInt32() { return default; }
        // 0x04CA1CFC: UInt32 ReadRawLittleEndian32()
        public uint ReadRawLittleEndian32() { return default; }
        // 0x04CA1D54: Boolean ReadBool()
        public bool ReadBool() { return default; }
        // 0x04CA1D6C: String ReadString()
        public string ReadString() { return default; }
        // 0x04CA1E84: Void ReadMessage(IMessage)
        public void ReadMessage(IMessage) { return default; }
        // 0x04CA1FD8: Int32 PushLimit(Int32)
        public int PushLimit(int) { return default; }
        // 0x04CA204C: Boolean get_ReachedLimit()
        public bool get_ReachedLimit() { return default; }
        // 0x04CA207C: Void PopLimit(Int32)
        public void PopLimit(int) { return default; }
        // 0x04CA20B4: ByteString ReadBytes()
        public ByteString ReadBytes() { return default; }
        // 0x04CA218C: UInt32 ReadUInt32()
        public uint ReadUInt32() { return default; }
        // 0x04CA2190: Int32 ReadEnum()
        public int ReadEnum() { return default; }
        // 0x04CA2194: Int32 ReadSFixed32()
        public int ReadSFixed32() { return default; }
        // 0x04CA2198: Int64 ReadSFixed64()
        public long ReadSFixed64() { return default; }
        // 0x04CA219C: Int32 ReadSInt32()
        public int ReadSInt32() { return default; }
        // 0x04CA21B8: Int32 DecodeZigZag32(UInt32)
        public int DecodeZigZag32(uint) { return default; }
        // 0x04CA21C8: Int64 ReadSInt64()
        public long ReadSInt64() { return default; }
        // 0x04CA21E4: Int64 DecodeZigZag64(UInt64)
        public long DecodeZigZag64(ulong) { return default; }
        // 0x04CA21F4: Boolean MaybeConsumeTag(UInt32)
        public bool MaybeConsumeTag(uint) { return default; }
        // 0x04CA224C: UInt32 SlowReadRawVarint32()
        public uint SlowReadRawVarint32() { return default; }
        // 0x04CA2318: Byte ReadRawByte()
        public byte ReadRawByte() { return default; }
        // 0x04CA23E0: UInt32 ReadRawVarint32(Stream)
        public uint ReadRawVarint32(Stream) { return default; }
        // 0x04CA250C: Void RecomputeBufferSizeAfterLimit()
        public void RecomputeBufferSizeAfterLimit() { return default; }
        // 0x04CA2540: Boolean RefillBuffer(Boolean)
        public bool RefillBuffer(bool) { return default; }
        // 0x04CA2700: Void SkipImpl(Int32)
        public void SkipImpl(int) { return default; }
        #endregion
    }
}
