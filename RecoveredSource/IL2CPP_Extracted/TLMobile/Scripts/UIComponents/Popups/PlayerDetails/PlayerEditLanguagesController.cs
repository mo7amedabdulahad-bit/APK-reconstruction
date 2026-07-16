// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.PlayerDetails
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerEditLanguagesController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<PlayerLanguage> _selectedLanguages;
		[ObservableValue]
		private ObservableList<PlayerLanguage> _availableLanguages;
		[ObservableValue]
		private string _languageFilter;
		private Action<ObservableList<CountryFlagEnum>> onCloseCallback;
		private Dictionary<string, ProfileLanguageStruct> parsedLanguages;
	
		// Properties
		[ObservableValue]
		public ObservableList<PlayerLanguage> selectedLanguages { get => default; set {} }
		[ObservableValue]
		public ObservableList<PlayerLanguage> availableLanguages { get => default; set {} }
		[ObservableValue]
		public string languageFilter { get => default; set {} }
		public ObservableList<PlayerLanguage> AllLanguages { get; private set; }
	
		// Constructors
		public PlayerEditLanguagesController() {}
	
		// Methods
		private void _selectedLanguagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _availableLanguagesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(ObservableList<CountryFlagEnum> playerLanguages = null, Action<ObservableList<CountryFlagEnum>> onCloseCallback = null) {}
		[UICallable]
		public void RemoveLanguage(PlayerLanguage lang) {}
		[UICallable]
		public void AddLanguage(PlayerLanguage lang) {}
		[UICallable]
		public override void Hide() {}
		private void UpdateLanguageLists() {}
	}
