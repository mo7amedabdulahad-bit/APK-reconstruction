// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LanguageService : MonoBehaviour, ILanguageService
	{
		// Fields
		public LanguageCfg languageCfg;
		public const string LanguagePlayerPrefKey = "lang";
		private const string DateFormatPlayerPrefKey = "dateFormat";
		private const string devLanguageTranslation = "Dev language";
		private static readonly Dictionary<string, string> Txt;
		private static LanguageService instance;
		private static SystemLanguage systemLanguage;
		private static string currentlyUsedLanguage;
		public static readonly string devLanguage;
		private static readonly CultureInfo deviceCulture;
		private static readonly RegionInfo deviceRegion;
		private static CultureInfo currentlyUsedCultureInfo;
		private static DateTimeFormatInfo currentlyUsedDateTimeFormatInfo;
		private List<LanguageObject> possibleLanguages;
		private static AsyncOperationHandle<UnityEngine.TextAsset>? currentLanguageLoadHandle;
		private static AsyncOperationHandle<UnityEngine.TextAsset>? currentMobileLanguageHandle;
		public static System.Action OnFirstLanguageLibraryLoaded;
	
		// Properties
		public static LanguageService Instance { get => default; }
		public static bool HasTranslations { get => default; }
		public static bool IsInstanceNull { get => default; }
		public bool LanguageIsRTL { get => default; }
		public string DevLanguage { get => default; }
		public ObservableList<DropdownOption> LanguagesDropdownOptions { get; private set; }
	
		// Events
		public event Action<string> OnLocaleChanged;
		public event Action<bool> OnIsRTLChanged;
		public event System.Action RestartedAllTranslateComponents;
	
		// Constructors
		public LanguageService() {}
		static LanguageService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private static void HandleOnIsRTLChanged(bool isRTL) {}
		private static Func<string> GetNoInternetTranslation() => default;
		private void OnDestroy() {}
		public void PopulatePossibleLanguages() {}
		public Dictionary<string, string> GetLanguageDictionary() => default;
		public string GetLanguageTranslationKey(string key) => default;
		public string GetTravianAnswersUrl(string answerId) => default;
		public List<LanguageObject> GetAvailableLanguages() => default;
		public string GetCurrentLanguage() => default;
		public string GetCurrentLanguageTranslated() => default;
		public SystemLanguage GetCurrentSystemLanguage() => default;
		public SystemLanguage GetCurrentLanguageAsSystemLanguage() => default;
		public CultureInfo GetDeviceCulture() => default;
		public RegionInfo GetDeviceRegion() => default;
		public void SetLanguage(string languageToUse = null) {}
		public void SetSavedLanguage(string suffix, string setToLanguage = null, bool fallBackToLobby = false) {}
		[Testable]
		private void Init() {}
		public static DateFormat? GetCurrentDateFormat() => default;
		public static DateTimeFormatInfo GetDateTimeFormatInfo(DateFormat dateFormat) => default;
		private static void SwitchLanguage(string languageToUse = null, string serverSuffix = "", bool fallBackToLobby = false) {}
		private static string GetSystemLanguage() => default;
		private static void UpdateLanguage() {}
		private void UpdateCultureAndDateFormat(string languageToUse) {}
		public static void SetDateFormat(DateFormat dateFormatToUse) {}
		private static void OnBrowserLanguageAssetLoaded(AsyncOperationHandle<UnityEngine.TextAsset> languageAsset) {}
		private static void OnMobileLanguageAssetLoaded(AsyncOperationHandle<UnityEngine.TextAsset> languageAsset) {}
		private static void AddTranslationFileToDictionary(string fileContent) {}
		private static void RestartAllTranslateComponents() {}
		public static void AddKeyValuePairToDictionary(string languageFileLine) {}
		public void SetupLanguageOptions() {}
		public static Dictionary<string, string> GetMobileTranslationValues() => default;
		private static void AddMobileTranslationStrings() {}
	}
