// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LanguageSettingsController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private string _selectedLanguage;
		[ObservableValue]
		private string _selectedLanguageName;
		[ObservableValue]
		private CountryFlagEnum _countryFlagEnum;
		[ObservableValue]
		private bool _isRTLLanguage;
		[ObservableValue]
		private bool _useEasternArabicNumerals;
		private DropdownOption selectedOptionLanguage;
	
		// Properties
		[ObservableValue]
		public string selectedLanguage { get => default; set {} }
		[ObservableValue]
		public string selectedLanguageName { get => default; set {} }
		[ObservableValue]
		public CountryFlagEnum countryFlagEnum { get => default; set {} }
		[ObservableValue]
		public bool isRTLLanguage { get => default; set {} }
		[ObservableValue]
		public bool useEasternArabicNumerals { get => default; set {} }
	
		// Constructors
		public LanguageSettingsController() {}
	
		// Methods
		protected override void OnEnable() {}
		private void TryGetFlagForLanguage() {}
		private void SelectedLanguageChangedDoNotifyAndToast(DropdownOption dropdownOption) {}
		private string SelectedLanguageChanged(DropdownOption dropdownOption) => default;
		[UICallable]
		public void OpenDropdownLanguage() {}
		[UICallable]
		public void ToggleUseEasternArabicNumerals() {}
	}
