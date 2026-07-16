// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Interfaces.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public interface ILanguageService : IService
	{
		// Properties
		ObservableList<DropdownOption> LanguagesDropdownOptions { get; }
		bool LanguageIsRTL { get; }
		string DevLanguage { get; }
	
		// Events
		event Action<string> OnLocaleChanged;
		event System.Action RestartedAllTranslateComponents;
	
		// Methods
		Dictionary<string, string> GetLanguageDictionary();
		string GetTravianAnswersUrl(string answerId);
		List<LanguageObject> GetAvailableLanguages();
		string GetCurrentLanguage();
		void SetLanguage(string languageToUse);
		void SetSavedLanguage(string suffix, string setToLanguage = null, bool fallBackToLobby = false);
		string GetLanguageTranslationKey(string key);
		string GetCurrentLanguageTranslated();
		void PopulatePossibleLanguages();
		SystemLanguage GetCurrentSystemLanguage();
		SystemLanguage GetCurrentLanguageAsSystemLanguage();
		CultureInfo GetDeviceCulture();
		RegionInfo GetDeviceRegion();
	}
