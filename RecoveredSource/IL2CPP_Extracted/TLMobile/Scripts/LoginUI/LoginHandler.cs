// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LoginHandler
	{
		// Fields
		private static readonly string lastCookiePlayerPrefKey;
		private static readonly string LastServerPlayerPrefKey;
		private static readonly string LastBootstrapKeyPrefKey;
	
		// Properties
		private static string LastCookiePlayerPrefKey { get => default; }
		public static string LastCookie { get => default; set {} }
		public static string LastServer { get => default; set {} }
	
		// Constructors
		public LoginHandler() {}
		static LoginHandler() {}
	
		// Methods
		public static void LoginSuccess(IAuthorizationService auth, string currentVersion, Action<System.Action> sceneLoadingMethod, System.Action sceneloadCallback = null, Action<Exception> catchCallback = null) {}
		private static void FinaliseLogin(string uuid, string currentVersion, string backendVersion, Action<System.Action> sceneLoadingMethod, System.Action sceneloadCallback = null, Action<Exception> catchCallback = null) {}
		private static void OnShutDown(WaitForBackendScreenController waitForBackendScreenController) {}
		public static void ResetSavedLoginTokens() {}
		public static void ResetLastPlayedGameworld() {}
		private static bool IsValidBootstrapDataToSave(BootstrapData bootstrapData) => default;
	}
