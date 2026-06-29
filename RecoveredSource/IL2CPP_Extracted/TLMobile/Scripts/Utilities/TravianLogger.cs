// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class TravianLogger
	{
		// Fields
		public static string GraphQLContext;
		public static string RestAPIContext;
		private const string RemoteConfigLogLevel = "logLevel";
		private static Level remoteConfigLogLevel;
		private static Level logLevel;
		private static bool? logsDisabled;
		private static bool isDevelopBuild;
	
		// Nested types
		public enum Level
		{
			UseRemoteConfig = -1,
			DebugLog = 0,
			Log = 3,
			Warning = 4,
			Error = 5
		}
	
		// Constructors
		static TravianLogger() {}
	
		// Methods
		public static void Setup(ITLMConfigService tLMConfigService) {}
		private static Action<string> OnLogError() => default;
		private static Action<string> OnLogWarning() => default;
		private static Action<string> OnLog() => default;
		private static void OnSettingsFetched(ConfigResponse configResponse) {}
		public static void LogError(string message, string context = "") {}
		public static void LogException(Exception exception) {}
		public static void LogWarning(string message, string context = "") {}
		public static void Log(string message, string context = "") {}
		public static void DebugLog(string message, string context = "") {}
		public static void LogUncaughtDebugError(string message, string context = "") {}
		private static void Log(string message, string context, Level level, bool skipDebugLogCall = false, Exception exception = null) {}
		private static void UpdateLogLevel() {}
	}
