// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PluginsLogHandler : MonoBehaviour, IBootable
	{
		// Constructors
		public PluginsLogHandler() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void Subscribe(LogsBroadcast logsBroadcast) {}
		private void OnDebugLog(string message) {}
		private void OnLog(string message) {}
		private void OnWarning(string message) {}
		private void OnErrorHappened(string errorMessage) {}
		private void OnException(Exception exception) {}
	}
