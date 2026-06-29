// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface IBBCodesService : IService
	{
		// Methods
		List<SpriteCfg> GetSpriteConfigs();
		List<string> GetAllCodesForKey(string key);
		string GetTranslationForTag(string bbTag);
		BBCodesToolbox GetBbCodesToolbox();
	}
