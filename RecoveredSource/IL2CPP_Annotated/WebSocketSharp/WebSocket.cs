// TGFramework.dll - WebSocketSharp.WebSocket
// Extracted from IL2CPP metadata v39
// Method count: 120
// NOTE: Method bodies are stubs - require native decompilation

namespace WebSocketSharp
{
    public class WebSocket
    {
        #region Constructors
        // 0x04C0E2C4
        public WebSocket(HttpListenerWebSocketContext, String, Logger) { }
        // 0x04C0E5BC
        public WebSocket(TcpListenerWebSocketContext, String, Logger) { }
        // 0x04C0E6CC
        public WebSocket(String, String[]) { }
        #endregion

        #region Methods
        // 0x04C0E3E0: Void init()
        public void init() { return default; }
        // 0x04C0E8D8: String CreateBase64Key()
        public string CreateBase64Key() { return default; }
        // 0x04C0E998: CookieCollection get_CookieCollection()
        public CookieCollection get_CookieCollection() { return default; }
        // 0x04C0E9A0: Func`2[WebSocketSharp.Net.WebSockets.WebSocketContext,String] get_CustomHandshakeRequestChecker()
        public Func`2[WebSocketSharp.Net.WebSockets.WebSocketContext,String] get_CustomHandshakeRequestChecker() { return default; }
        // 0x04C0EA7C: Void set_CustomHandshakeRequestChecker(Func`2[WebSocketSharp.Net.WebSockets.WebSocketContext,String])
        public void set_CustomHandshakeRequestChecker(Func`2[WebSocketSharp.Net.WebSockets.WebSocketContext,String]) { return default; }
        // 0x04C0EA84: Boolean get_IsConnected()
        public bool get_IsConnected() { return default; }
        // 0x04C0EAC4: CompressionMethod get_Compression()
        public CompressionMethod get_Compression() { return default; }
        // 0x04C0EACC: Void set_Compression(CompressionMethod)
        public void set_Compression(CompressionMethod) { return default; }
        // 0x04C0EC0C: String checkIfAvailable(String, Boolean, Boolean)
        public string checkIfAvailable(String, Boolean, Boolean) { return default; }
        // 0x04C0ECD4: Void error(String)
        public void error(string) { return default; }
        // 0x04C0EE2C: IEnumerable`1[WebSocketSharp.Net.Cookie] get_Cookies()
        public IEnumerable`1[WebSocketSharp.Net.Cookie] get_Cookies() { return default; }
        // 0x04C0EEA0: NetworkCredential get_Credentials()
        public NetworkCredential get_Credentials() { return default; }
        // 0x04C0EEA8: String get_Extensions()
        public string get_Extensions() { return default; }
        // 0x04C0EECC: Boolean get_IsAlive()
        public bool get_IsAlive() { return default; }
        // 0x04C0EED0: Boolean Ping()
        public bool Ping() { return default; }
        // 0x04C0EF70: Boolean get_IsSecure()
        public bool get_IsSecure() { return default; }
        // 0x04C0EF78: Logger get_Log()
        public Logger get_Log() { return default; }
        // 0x04C0EF90: Void set_Log(Logger)
        public void set_Log(Logger) { return default; }
        // 0x04C0EFBC: String get_Origin()
        public string get_Origin() { return default; }
        // 0x04C0EFC4: Void set_Origin(String)
        public void set_Origin(string) { return default; }
        // 0x04C0F1D8: String get_Protocol()
        public string get_Protocol() { return default; }
        // 0x04C0F1FC: Void set_Protocol(String)
        public void set_Protocol(string) { return default; }
        // 0x04C0F204: WebSocketState get_ReadyState()
        public WebSocketState get_ReadyState() { return default; }
        // 0x04C0F21C: RemoteCertificateValidationCallback get_ServerCertificateValidationCallback()
        public RemoteCertificateValidationCallback get_ServerCertificateValidationCallback() { return default; }
        // 0x04C0F224: Void set_ServerCertificateValidationCallback(RemoteCertificateValidationCallback)
        public void set_ServerCertificateValidationCallback(RemoteCertificateValidationCallback) { return default; }
        // 0x04C0F374: Uri get_Url()
        public Uri get_Url() { return default; }
        // 0x04C0F3A4: Void add_OnClose(EventHandler`1[WebSocketSharp.CloseEventArgs])
        public void add_OnClose(EventHandler`1[WebSocketSharp.CloseEventArgs]) { return default; }
        // 0x04C0F454: Void remove_OnClose(EventHandler`1[WebSocketSharp.CloseEventArgs])
        public void remove_OnClose(EventHandler`1[WebSocketSharp.CloseEventArgs]) { return default; }
        // 0x04C0F504: Void add_OnError(EventHandler`1[WebSocketSharp.ErrorEventArgs])
        public void add_OnError(EventHandler`1[WebSocketSharp.ErrorEventArgs]) { return default; }
        // 0x04C0F5B4: Void remove_OnError(EventHandler`1[WebSocketSharp.ErrorEventArgs])
        public void remove_OnError(EventHandler`1[WebSocketSharp.ErrorEventArgs]) { return default; }
        // 0x04C0F664: Void add_OnMessage(EventHandler`1[WebSocketSharp.MessageEventArgs])
        public void add_OnMessage(EventHandler`1[WebSocketSharp.MessageEventArgs]) { return default; }
        // 0x04C0F714: Void remove_OnMessage(EventHandler`1[WebSocketSharp.MessageEventArgs])
        public void remove_OnMessage(EventHandler`1[WebSocketSharp.MessageEventArgs]) { return default; }
        // 0x04C0F7C4: Void add_OnOpen(EventHandler)
        public void add_OnOpen(EventHandler) { return default; }
        // 0x04C0F860: Void remove_OnOpen(EventHandler)
        public void remove_OnOpen(EventHandler) { return default; }
        // 0x04C0F8FC: Boolean acceptCloseFrame(WebSocketFrame)
        public bool acceptCloseFrame(WebSocketFrame) { return default; }
        // 0x04C0F948: Void close(PayloadData, Boolean, Boolean)
        public void close(PayloadData, Boolean, Boolean) { return default; }
        // 0x04C0FD84: Boolean acceptDataFrame(WebSocketFrame)
        public bool acceptDataFrame(WebSocketFrame) { return default; }
        // 0x04C0FE5C: Void enqueueToMessageEventQueue(MessageEventArgs)
        public void enqueueToMessageEventQueue(MessageEventArgs) { return default; }
        // 0x04C0FF5C: Void acceptException(Exception, String)
        public void acceptException(Exception, String) { return default; }
        // 0x04C100D8: Void Close(HttpStatusCode)
        public void Close(HttpStatusCode) { return default; }
        // 0x04C100F4: Void close(CloseStatusCode, String, Boolean)
        public void close(CloseStatusCode, String, Boolean) { return default; }
        // 0x04C101A4: Boolean acceptFragmentedFrame(WebSocketFrame)
        public bool acceptFragmentedFrame(WebSocketFrame) { return default; }
        // 0x04C101F0: Boolean acceptFragments(WebSocketFrame)
        public bool acceptFragments(WebSocketFrame) { return default; }
        // 0x04C10430: Boolean concatenateFragmentsInto(Stream)
        public bool concatenateFragmentsInto(Stream) { return default; }
        // 0x04C10564: Boolean acceptFrame(WebSocketFrame)
        public bool acceptFrame(WebSocketFrame) { return default; }
        // 0x04C10698: Boolean acceptUnsupportedFrame(WebSocketFrame, CloseStatusCode, String)
        public bool acceptUnsupportedFrame(WebSocketFrame, CloseStatusCode, String) { return default; }
        // 0x04C1077C: Boolean acceptPongFrame(WebSocketFrame)
        public bool acceptPongFrame(WebSocketFrame) { return default; }
        // 0x04C107EC: Boolean acceptPingFrame(WebSocketFrame)
        public bool acceptPingFrame(WebSocketFrame) { return default; }
        // 0x04C108A0: Boolean acceptHandshake()
        public bool acceptHandshake() { return default; }
        // 0x04C10AB4: String checkIfValidHandshakeRequest(WebSocketContext)
        public string checkIfValidHandshakeRequest(WebSocketContext) { return default; }
        // 0x04C10C74: Void acceptSecWebSocketExtensionsHeader(String)
        public void acceptSecWebSocketExtensionsHeader(string) { return default; }
        // 0x04C110EC: HandshakeResponse createHandshakeResponse()
        public HandshakeResponse createHandshakeResponse() { return default; }
        // 0x04C11200: Boolean send(HandshakeResponse)
        public bool send(HandshakeResponse) { return default; }
        // 0x04C112A0: Boolean send(WebSocketFrame)
        public bool send(WebSocketFrame) { return default; }
        // 0x04C1140C: String checkIfCanConnect()
        public string checkIfCanConnect() { return default; }
        // 0x04C114AC: Boolean validateSecWebSocketKeyHeader(String)
        public bool validateSecWebSocketKeyHeader(string) { return default; }
        // 0x04C114D8: Boolean validateSecWebSocketVersionClientHeader(String)
        public bool validateSecWebSocketVersionClientHeader(string) { return default; }
        // 0x04C11538: String checkIfValidHandshakeResponse(HandshakeResponse)
        public string checkIfValidHandshakeResponse(HandshakeResponse) { return default; }
        // 0x04C11744: Boolean validateSecWebSocketAcceptHeader(String)
        public bool validateSecWebSocketAcceptHeader(string) { return default; }
        // 0x04C11774: Boolean validateSecWebSocketProtocolHeader(String)
        public bool validateSecWebSocketProtocolHeader(string) { return default; }
        // 0x04C11894: Boolean validateSecWebSocketExtensionsHeader(String)
        public bool validateSecWebSocketExtensionsHeader(string) { return default; }
        // 0x04C119C4: Boolean validateSecWebSocketVersionServerHeader(String)
        public bool validateSecWebSocketVersionServerHeader(string) { return default; }
        // 0x04C11A24: Boolean closeHandshake(Byte[], Int32, Action)
        public bool closeHandshake(byte) { return default; }
        // 0x04C11CAC: Void closeAsync(PayloadData, Boolean, Boolean)
        public void closeAsync(PayloadData, Boolean, Boolean) { return default; }
        // 0x04C11DEC: Void closeClientResources()
        public void closeClientResources() { return default; }
        // 0x04C11E50: Void closeServerResources()
        public void closeServerResources() { return default; }
        // 0x04C11EBC: Boolean connect()
        public bool connect() { return default; }
        // 0x04C120E8: Boolean doHandshake()
        public bool doHandshake() { return default; }
        // 0x04C121E0: String createExtensionsRequest()
        public string createExtensionsRequest() { return default; }
        // 0x04C12294: HandshakeRequest createHandshakeRequest()
        public HandshakeRequest createHandshakeRequest() { return default; }
        // 0x04C125A8: String CreateResponseKey(String)
        public string CreateResponseKey(string) { return default; }
        // 0x04C126D8: HandshakeResponse createHandshakeResponse(HttpStatusCode)
        public HandshakeResponse createHandshakeResponse(HttpStatusCode) { return default; }
        // 0x04C1275C: MessageEventArgs dequeueFromMessageEventQueue()
        public MessageEventArgs dequeueFromMessageEventQueue() { return default; }
        // 0x04C12888: Void setClientStream()
        public void setClientStream() { return default; }
        // 0x04C12958: HandshakeResponse sendHandshakeRequest()
        public HandshakeResponse sendHandshakeRequest() { return default; }
        // 0x04C12B14: Void open()
        public void open() { return default; }
        // 0x04C12D9C: Void startReceiving()
        public void startReceiving() { return default; }
        // 0x04C12F34: HandshakeResponse receiveHandshakeResponse()
        public HandshakeResponse receiveHandshakeResponse() { return default; }
        // 0x04C12FD0: Boolean send(Byte[])
        public bool send(byte) { return default; }
        // 0x04C13120: Void send(HandshakeRequest)
        public void send(HandshakeRequest) { return default; }
        // 0x04C131AC: Boolean send(Opcode, Byte[])
        public bool send(Opcode, Byte[]) { return default; }
        // 0x04C13408: Boolean send(Opcode, Stream)
        public bool send(Opcode, Stream) { return default; }
        // 0x04C136E4: Boolean sendFragmented(Opcode, Stream, Mask, Boolean)
        public bool sendFragmented(Opcode, Stream, Mask, Boolean) { return default; }
        // 0x04C1399C: Void sendAsync(Opcode, Byte[], Action`1[Boolean])
        public void sendAsync(Opcode, Byte[], Action`1[Boolean]) { return default; }
        // 0x04C13AF8: Void sendAsync(Opcode, Stream, Action`1[Boolean])
        public void sendAsync(Opcode, Stream, Action`1[Boolean]) { return default; }
        // 0x04C13C54: HandshakeResponse sendHandshakeRequest(HandshakeRequest)
        public HandshakeResponse sendHandshakeRequest(HandshakeRequest) { return default; }
        // 0x04C13C6C: Void Close(HandshakeResponse)
        public void Close(HandshakeResponse) { return default; }
        // 0x04C13CB4: Void Close(CloseEventArgs, Byte[], Int32)
        public void Close(CloseEventArgs, Byte[], Int32) { return default; }
        // 0x04C13F98: Void ConnectAsServer()
        public void ConnectAsServer() { return default; }
        // 0x04C14064: Boolean Ping(Byte[], Int32)
        public bool Ping(byte) { return default; }
        // 0x04C14198: Void Send(Opcode, Byte[], Dictionary`2[WebSocketSharp.CompressionMethod,System.Byte[]])
        public void Send(Opcode, Byte[], Dictionary`2[WebSocketSharp.CompressionMethod,System.Byte[]]) { return default; }
        // 0x04C1451C: Void Send(Opcode, Stream, Dictionary`2[WebSocketSharp.CompressionMethod,System.IO.Stream])
        public void Send(Opcode, Stream, Dictionary`2[WebSocketSharp.CompressionMethod,System.IO.Stream]) { return default; }
        // 0x04C147D0: Void Close()
        public void Close() { return default; }
        // 0x04C14888: Void Close(UInt16)
        public void Close(ushort) { return default; }
        // 0x04C14890: Void Close(UInt16, String)
        public void Close(UInt16, String) { return default; }
        // 0x04C14A58: Void Close(CloseStatusCode)
        public void Close(CloseStatusCode) { return default; }
        // 0x04C14A60: Void Close(CloseStatusCode, String)
        public void Close(CloseStatusCode, String) { return default; }
        // 0x04C14C00: Void CloseAsync()
        public void CloseAsync() { return default; }
        // 0x04C14CB8: Void CloseAsync(UInt16)
        public void CloseAsync(ushort) { return default; }
        // 0x04C14CC0: Void CloseAsync(UInt16, String)
        public void CloseAsync(UInt16, String) { return default; }
        // 0x04C14E88: Void CloseAsync(CloseStatusCode)
        public void CloseAsync(CloseStatusCode) { return default; }
        // 0x04C14E90: Void CloseAsync(CloseStatusCode, String)
        public void CloseAsync(CloseStatusCode, String) { return default; }
        // 0x04C15030: Void Connect()
        public void Connect() { return default; }
        // 0x04C150A0: Void ConnectAsync()
        public void ConnectAsync() { return default; }
        // 0x04C151FC: Boolean Ping(String)
        public bool Ping(string) { return default; }
        // 0x04C15350: Void Send(Byte[])
        public void Send(byte) { return default; }
        // 0x04C15494: Void Send(FileInfo)
        public void Send(FileInfo) { return default; }
        // 0x04C15544: Void Send(String)
        public void Send(string) { return default; }
        // 0x04C15674: Void SendAsync(Byte[], Action`1[Boolean])
        public void SendAsync(byte) { return default; }
        // 0x04C157D4: Void SendAsync(FileInfo, Action`1[Boolean])
        public void SendAsync(FileInfo, Action`1[Boolean]) { return default; }
        // 0x04C15898: Void SendAsync(String, Action`1[Boolean])
        public void SendAsync(String, Action`1[Boolean]) { return default; }
        // 0x04C159E4: Void SendAsync(Stream, Int32, Action`1[Boolean])
        public void SendAsync(Stream, Int32, Action`1[Boolean]) { return default; }
        // 0x04C15BB4: Void SetCookie(Cookie)
        public void SetCookie(Cookie) { return default; }
        // 0x04C15DE4: Void SetCredentials(String, String, Boolean)
        public void SetCredentials(String, String, Boolean) { return default; }
        // 0x04C160F4: Void System.IDisposable.Dispose()
        public void System.IDisposable.Dispose() { return default; }
        // 0x04C16100: Boolean <acceptHandshake>b__89_0(String)
        public bool <acceptHandshake>b__89_0(string) { return default; }
        // 0x04C16114: Boolean <validateSecWebSocketExtensionsHeader>b__131_0(String)
        public bool <validateSecWebSocketExtensionsHeader>b__131_0(string) { return default; }
        #endregion
    }
}
