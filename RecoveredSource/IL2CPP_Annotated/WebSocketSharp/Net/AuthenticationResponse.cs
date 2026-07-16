// TGFramework.dll - WebSocketSharp.Net.AuthenticationResponse
// Extracted from IL2CPP metadata v39
// Method count: 23
// NOTE: Method bodies are stubs - require native decompilation

namespace WebSocketSharp.Net
{
    public class AuthenticationResponse
    {
        #region Constructors
        // 0x04C67DF0
        public AuthenticationResponse(AuthenticationSchemes, NameValueCollection) { }
        // 0x04C67E28
        public AuthenticationResponse(NetworkCredential) { }
        // 0x04C67FDC
        public AuthenticationResponse(AuthenticationChallenge, NetworkCredential, UInt32) { }
        // 0x04C67E9C
        public AuthenticationResponse(AuthenticationSchemes, NameValueCollection, NetworkCredential, UInt32) { }
        #endregion

        #region Static Methods
        // 0x04C68C64: AuthenticationResponse Parse(String)
        public static AuthenticationResponse Parse(string) { return default; }
        #endregion

        #region Methods
        // 0x04C68000: Void initAsDigest()
        public void initAsDigest() { return default; }
        // 0x04C682C4: UInt32 get_NonceCount()
        public uint get_NonceCount() { return default; }
        // 0x04C682D4: String get_Cnonce()
        public string get_Cnonce() { return default; }
        // 0x04C68328: String get_Nc()
        public string get_Nc() { return default; }
        // 0x04C6837C: String get_Password()
        public string get_Password() { return default; }
        // 0x04C683D0: String get_Response()
        public string get_Response() { return default; }
        // 0x04C68424: String get_Uri()
        public string get_Uri() { return default; }
        // 0x04C68478: String get_UserName()
        public string get_UserName() { return default; }
        // 0x04C684CC: String createA1(String, String, String)
        public string createA1(String, String, String) { return default; }
        // 0x04C68530: String createA1(String, String, String, String, String)
        public string createA1(String, String, String, String, String) { return default; }
        // 0x04C685BC: String hash(String)
        public string hash(string) { return default; }
        // 0x04C686FC: String createA2(String, String)
        public string createA2(String, String) { return default; }
        // 0x04C68758: String createA2(String, String, String)
        public string createA2(String, String, String) { return default; }
        // 0x04C687C8: String CreateRequestDigest(NameValueCollection)
        public string CreateRequestDigest(NameValueCollection) { return default; }
        // 0x04C68EBC: NameValueCollection ParseBasicCredentials(String)
        public NameValueCollection ParseBasicCredentials(string) { return default; }
        // 0x04C69068: String ToBasicString()
        public string ToBasicString() { return default; }
        // 0x04C6919C: String ToDigestString()
        public string ToDigestString() { return default; }
        // 0x04C695B0: IIdentity ToIdentity()
        public IIdentity ToIdentity() { return default; }
        #endregion
    }
}
