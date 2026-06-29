// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IDeviceFunctionsService : IService
	{
		// Methods
		void OpenURL(string url);
		int GetKeyboardHeight();
		IPromise<string> GetDeviceVerificationToken(string serverChallenge, string username);
	}
