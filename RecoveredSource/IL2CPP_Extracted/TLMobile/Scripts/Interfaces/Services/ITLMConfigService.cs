// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ITLMConfigService : IService
	{
		// Properties
		bool FetchRemoteCompleted { get; }
		Action<ConfigResponse> OnFetchRemoteCompleted { get; set; }
		ConfigResponse LastFetchedConfigResponse { get; }
	
		// Methods
		string GetLocalConfigValue(string key);
	}
