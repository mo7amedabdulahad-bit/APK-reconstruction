// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.Backend.GraphQL.LogsHandling
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LogsBroadcast
	{
		// Fields
		private static LogsBroadcast instance;
		public Action<string> InterceptDebugLogMessage;
		public Action<string> InterceptLogMessage;
		public Action<string> InterceptWarningMessage;
		public Action<string> InterceptErrorMessage;
		public Action<Exception> InterceptExceptionMessage;
	
		// Properties
		public static LogsBroadcast Instance { get => default; }
	
		// Constructors
		private LogsBroadcast() {}
	
		// Methods
		public static bool IsInstanceNull() => default;
		public void RegisterLogException(Exception exception) {}
		public void RegisterError(string errorMessage) {}
		public void RegisterWarning(string message) {}
		public void RegisterLog(string message) {}
		public void RegisterDebugLog(string message) {}
		public static void ResetInstance(bool forceReset = false) {}
	}
