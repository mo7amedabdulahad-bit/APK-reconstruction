// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IBuildSettingsService : IService
	{
		// Properties
		BuildSettings BuildSettings { get; set; }
		bool WasDevelopBuild { get; set; }
	
		// Methods
		void ImportSettings(string configFileContent);
		string GetFormattedBuildVersion();
	}
