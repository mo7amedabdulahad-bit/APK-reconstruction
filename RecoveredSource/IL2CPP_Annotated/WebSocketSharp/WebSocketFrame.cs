// TGFramework.dll - WebSocketSharp.WebSocketFrame
// Extracted from IL2CPP metadata v39
// Method count: 56
// NOTE: Method bodies are stubs - require native decompilation

namespace WebSocketSharp
{
    public class WebSocketFrame
    {
        #region Constructors
        // 0x04C639FC
        public WebSocketFrame() { }
        // 0x04C63DD0
        public WebSocketFrame() { }
        // 0x04C63DD8
        public WebSocketFrame(Opcode, PayloadData) { }
        // 0x04C63FA0
        public WebSocketFrame(Opcode, Mask, PayloadData) { }
        // 0x04C63FB8
        public WebSocketFrame(Fin, Opcode, Mask, PayloadData) { }
        // 0x04C63DF0
        public WebSocketFrame(Fin, Opcode, Mask, PayloadData, Boolean) { }
        #endregion

        #region Static Methods
        // 0x04C63A5C: WebSocketFrame CreatePingFrame(Mask)
        public static WebSocketFrame CreatePingFrame(Mask) { return default; }
        // 0x04C64808: WebSocketFrame parse(Byte[], Stream, Boolean)
        public static WebSocketFrame parse(byte) { return default; }
        // 0x04C6517C: WebSocketFrame CreateCloseFrame(Mask, PayloadData)
        public static WebSocketFrame CreateCloseFrame(Mask, PayloadData) { return default; }
        // 0x04C651F0: WebSocketFrame CreatePongFrame(Mask, PayloadData)
        public static WebSocketFrame CreatePongFrame(Mask, PayloadData) { return default; }
        // 0x04C65264: WebSocketFrame CreateCloseFrame(Mask, Byte[])
        public static WebSocketFrame CreateCloseFrame(Mask, Byte[]) { return default; }
        // 0x04C65304: WebSocketFrame CreateCloseFrame(Mask, CloseStatusCode, String)
        public static WebSocketFrame CreateCloseFrame(Mask, CloseStatusCode, String) { return default; }
        // 0x04C653C8: WebSocketFrame CreateFrame(Fin, Opcode, Mask, Byte[], Boolean)
        public static WebSocketFrame CreateFrame(Fin, Opcode, Mask, Byte[], Boolean) { return default; }
        // 0x04C65484: WebSocketFrame CreatePingFrame(Mask, Byte[])
        public static WebSocketFrame CreatePingFrame(Mask, Byte[]) { return default; }
        // 0x04C655B8: WebSocketFrame Parse(Byte[])
        public static WebSocketFrame Parse(byte) { return default; }
        // 0x04C65610: WebSocketFrame Parse(Byte[], Boolean)
        public static WebSocketFrame Parse(byte) { return default; }
        // 0x04C65794: WebSocketFrame Parse(Stream)
        public static WebSocketFrame Parse(Stream) { return default; }
        // 0x04C657EC: WebSocketFrame Parse(Stream, Boolean)
        public static WebSocketFrame Parse(Stream, Boolean) { return default; }
        #endregion

        #region Methods
        // 0x04C62EE4: Boolean get_IsData()
        public bool get_IsData() { return default; }
        // 0x04C63AF4: Byte[] ToByteArray()
        public byte ToByteArray() { return default; }
        // 0x04C63FC0: Boolean isData(Opcode)
        public bool isData(Opcode) { return default; }
        // 0x04C63FD4: Byte[] createMaskingKey()
        public byte createMaskingKey() { return default; }
        // 0x04C6406C: Byte[] get_ExtendedPayloadLength()
        public byte get_ExtendedPayloadLength() { return default; }
        // 0x04C64074: Fin get_Fin()
        public Fin get_Fin() { return default; }
        // 0x04C6407C: Boolean get_IsBinary()
        public bool get_IsBinary() { return default; }
        // 0x04C6408C: Boolean get_IsClose()
        public bool get_IsClose() { return default; }
        // 0x04C6409C: Boolean get_IsCompressed()
        public bool get_IsCompressed() { return default; }
        // 0x04C640AC: Boolean get_IsContinuation()
        public bool get_IsContinuation() { return default; }
        // 0x04C640BC: Boolean get_IsControl()
        public bool get_IsControl() { return default; }
        // 0x04C640D0: Boolean get_IsFinal()
        public bool get_IsFinal() { return default; }
        // 0x04C640E0: Boolean get_IsFragmented()
        public bool get_IsFragmented() { return default; }
        // 0x04C64100: Boolean get_IsMasked()
        public bool get_IsMasked() { return default; }
        // 0x04C64110: Boolean get_IsPerMessageCompressed()
        public bool get_IsPerMessageCompressed() { return default; }
        // 0x04C64138: Boolean get_IsPing()
        public bool get_IsPing() { return default; }
        // 0x04C64148: Boolean get_IsPong()
        public bool get_IsPong() { return default; }
        // 0x04C64158: Boolean get_IsText()
        public bool get_IsText() { return default; }
        // 0x04C64168: UInt64 get_Length()
        public ulong get_Length() { return default; }
        // 0x04C641B4: Mask get_Mask()
        public Mask get_Mask() { return default; }
        // 0x04C641BC: Byte[] get_MaskingKey()
        public byte get_MaskingKey() { return default; }
        // 0x04C641C4: Opcode get_Opcode()
        public Opcode get_Opcode() { return default; }
        // 0x04C641CC: PayloadData get_PayloadData()
        public PayloadData get_PayloadData() { return default; }
        // 0x04C641D4: Byte get_PayloadLength()
        public byte get_PayloadLength() { return default; }
        // 0x04C641DC: Rsv get_Rsv1()
        public Rsv get_Rsv1() { return default; }
        // 0x04C641E4: Rsv get_Rsv2()
        public Rsv get_Rsv2() { return default; }
        // 0x04C641EC: Rsv get_Rsv3()
        public Rsv get_Rsv3() { return default; }
        // 0x04C641F4: String dump(WebSocketFrame)
        public string dump(WebSocketFrame) { return default; }
        // 0x04C647F4: Boolean isControl(Opcode)
        public bool isControl(Opcode) { return default; }
        // 0x04C64C54: String print(WebSocketFrame)
        public string print(WebSocketFrame) { return default; }
        // 0x04C65524: IEnumerator`1[System.Byte] GetEnumerator()
        public IEnumerator`1[System.Byte] GetEnumerator() { return default; }
        // 0x04C658B8: Void ParseAsync(Stream, Action`1[WebSocketSharp.WebSocketFrame])
        public void ParseAsync(Stream, Action`1[WebSocketSharp.WebSocketFrame]) { return default; }
        // 0x04C65924: Void ParseAsync(Stream, Boolean, Action`1[WebSocketSharp.WebSocketFrame], Action`1[Exception])
        public void ParseAsync(Stream, Boolean, Action`1[WebSocketSharp.WebSocketFrame], Action`1[Exception]) { return default; }
        // 0x04C65A2C: Void ParseAsync(Stream, Action`1[WebSocketSharp.WebSocketFrame], Action`1[Exception])
        public void ParseAsync(Stream, Action`1[WebSocketSharp.WebSocketFrame], Action`1[Exception]) { return default; }
        // 0x04C65AA4: Void Print(Boolean)
        public void Print(bool) { return default; }
        // 0x04C65B50: String PrintToString(Boolean)
        public string PrintToString(bool) { return default; }
        // 0x04C65BD0: String ToString()
        public string ToString() { return default; }
        // 0x04C65BE4: IEnumerator System.Collections.IEnumerable.GetEnumerator()
        public IEnumerator System.Collections.IEnumerable.GetEnumerator() { return default; }
        #endregion
    }
}
