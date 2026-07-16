// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BBCodesService : MonoBehaviour, IBBCodesService
	{
		// Fields
		public List<SpriteCfg> spriteConfigs;
		public BBCodesToolbox BbCodesToolbox;
		private Dictionary<string, List<string>> bbCodes;
	
		// Constructors
		public BBCodesService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public List<SpriteCfg> GetSpriteConfigs() => default;
		public List<string> GetAllCodesForKey(string key) => default;
		public string GetTranslationForTag(string bbTag) => default;
		public BBCodesToolbox GetBbCodesToolbox() => default;
		public void FillBBCodes(string csv) {}
		public static Dictionary<string, List<string>> GetMobileBBCodes() => default;
	}
