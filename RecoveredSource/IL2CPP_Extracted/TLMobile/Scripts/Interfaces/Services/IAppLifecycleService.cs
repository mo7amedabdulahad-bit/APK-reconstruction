// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IAppLifecycleService : IService
	{
		// Properties
		bool IsPaused { get; }
		bool IsFocused { get; }
		bool IsQuitting { get; }
	
		// Events
		event Action<bool> FocusChanged;
		event Action<bool> PauseChanged;
		event System.Action ApplicationQuit;
	}
