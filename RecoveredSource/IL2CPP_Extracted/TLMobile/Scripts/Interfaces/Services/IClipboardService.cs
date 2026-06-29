// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IClipboardService : IService
	{
		// Methods
		void Copy<T>(T data);
		T Paste<T>();
		bool Check<T>();
		void ClearClipboard();
	}
