// TGFramework.dll - WebSocketSharp.HandshakeResponse
// Extracted from IL2CPP metadata v39
// Method count: 12
// NOTE: Method bodies are stubs - require native decompilation

namespace WebSocketSharp
{
    public class HandshakeResponse
    {
        #region Constructors
        // 0x04C0BC90
        public HandshakeResponse(Version, NameValueCollection) { }
        // 0x04C0BC94
        public HandshakeResponse(HttpStatusCode) { }
        #endregion

        #region Static Methods
        // 0x04C0C018: HandshakeResponse CreateCloseResponse(HttpStatusCode)
        public static HandshakeResponse CreateCloseResponse(HttpStatusCode) { return default; }
        // 0x04C0C0B8: HandshakeResponse Parse(String[])
        public static HandshakeResponse Parse(string) { return default; }
        #endregion

        #region Methods
        // 0x04C0BE24: AuthenticationChallenge get_AuthChallenge()
        public AuthenticationChallenge get_AuthChallenge() { return default; }
        // 0x04C0BEA0: CookieCollection get_Cookies()
        public CookieCollection get_Cookies() { return default; }
        // 0x04C0BEAC: Boolean get_IsUnauthorized()
        public bool get_IsUnauthorized() { return default; }
        // 0x04C0BEF8: Boolean get_IsWebSocketResponse()
        public bool get_IsWebSocketResponse() { return default; }
        // 0x04C0C008: String get_Reason()
        public string get_Reason() { return default; }
        // 0x04C0C010: String get_StatusCode()
        public string get_StatusCode() { return default; }
        // 0x04C0C2F8: Void SetCookies(CookieCollection)
        public void SetCookies(CookieCollection) { return default; }
        // 0x04C0C604: String ToString()
        public string ToString() { return default; }
        #endregion
    }
}
