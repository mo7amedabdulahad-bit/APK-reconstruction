// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ExternalLogsService : MonoBehaviour, IExternalLogsService
	{
		// Properties
		public LogsBroadcast LogsBroadcast { get => default; }
	
		// Constructors
		public ExternalLogsService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		private static void ApplicationOnLogMessageReceived(string condition, string stacktrace, LogType type) {}
		private void LogUnhandledPromiseException(object sender, ExceptionEventArgs e) {}
	}
