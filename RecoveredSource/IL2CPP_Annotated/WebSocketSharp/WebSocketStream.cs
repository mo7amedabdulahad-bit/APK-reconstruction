// TGFramework.dll - WebSocketSharp.WebSocketStream
// Extracted from IL2CPP metadata v39
// Method count: 18
// NOTE: Method bodies are stubs - require native decompilation

namespace WebSocketSharp
{
    public class WebSocketStream
    {
        #region Constructors
        // 0x04C660AC
        public WebSocketStream(Stream, Boolean) { }
        // 0x04C66140
        public WebSocketStream(NetworkStream) { }
        // 0x04C66148
        public WebSocketStream(SslStream) { }
        #endregion

        #region Static Methods
        // 0x04C6684C: WebSocketStream CreateClientStream(TcpClient, Boolean, String, RemoteCertificateValidationCallback)
        public static WebSocketStream CreateClientStream(TcpClient, Boolean, String, RemoteCertificateValidationCallback) { return default; }
        // 0x04C669F0: WebSocketStream CreateServerStream(TcpClient, Boolean, X509Certificate)
        public static WebSocketStream CreateServerStream(TcpClient, Boolean, X509Certificate) { return default; }
        #endregion

        #region Methods
        // 0x04C62BC4: Void ReadFrameAsync(Action`1[WebSocketSharp.WebSocketFrame], Action`1[Exception])
        public void ReadFrameAsync(Action`1[WebSocketSharp.WebSocketFrame], Action`1[Exception]) { return default; }
        // 0x04C66150: Boolean get_DataAvailable()
        public bool get_DataAvailable() { return default; }
        // 0x04C66230: Boolean get_IsSecure()
        public bool get_IsSecure() { return default; }
        // 0x04C66238: Byte[] readHandshakeEntityBody(Stream, String)
        public byte readHandshakeEntityBody(Stream, String) { return default; }
        // 0x04C6634C: String[] readHandshakeHeaders(Stream)
        public string readHandshakeHeaders(Stream) { return default; }
        // 0x04C666A8: Boolean Write(Byte[])
        public bool Write(byte) { return default; }
        // 0x04C6682C: Void Close()
        public void Close() { return default; }
        // 0x04C66AE4: Void Dispose()
        public void Dispose() { return default; }
        // 0x04C66AFC: WebSocketFrame ReadFrame()
        public WebSocketFrame ReadFrame() { return default; }
        // 0x04C66B58: HandshakeRequest ReadHandshakeRequest()
        public HandshakeRequest ReadHandshakeRequest() { return default; }
        // 0x04C66BF8: HandshakeResponse ReadHandshakeResponse()
        public HandshakeResponse ReadHandshakeResponse() { return default; }
        // 0x04C66C98: Boolean WriteFrame(WebSocketFrame)
        public bool WriteFrame(WebSocketFrame) { return default; }
        // 0x04C66CC0: Boolean WriteHandshake(HandshakeBase)
        public bool WriteHandshake(HandshakeBase) { return default; }
        #endregion
    }
}
