// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildSettingsService : MonoBehaviour, IBuildSettingsService
	{
		// Fields
		public const string UseDevServersPrefsKey = "UseDevServersPrefsKey";
		public UnityEngine.TextAsset jsonSettingsFile;
		private BuildSettings buildSettings;
	
		// Properties
		public BuildSettings BuildSettings { get => default; set {} }
		public bool WasDevelopBuild { get; set; }
	
		// Constructors
		public BuildSettingsService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public void ImportSettings(string configFileContent) {}
		public string GetFormattedBuildVersion() => default;
	}
