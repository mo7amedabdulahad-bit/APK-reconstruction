// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DeviceFunctionsService : MonoBehaviour, IDeviceFunctionsService
	{
		// Fields
		private int keyboardHeight;
	
		// Constructors
		public DeviceFunctionsService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnKeyboardHeightChangedHandler(int h) {}
		public int GetKeyboardHeight() => default;
		public void OpenURL(string url) {}
		public IPromise<string> GetDeviceVerificationToken(string serverChallenge, string username) => default;
		private IPromise<string> GetTokenAndroid(string serverChallenge, string username) => default;
	}
