// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ClipboardService : MonoBehaviour, IClipboardService
	{
		// Fields
		private readonly Dictionary<System.Type, object> clipboardData;
	
		// Constructors
		public ClipboardService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void Copy<T>(T data) {}
		public T Paste<T>() => default;
		public bool Check<T>() => default;
		public void ClearClipboard() {}
	}
