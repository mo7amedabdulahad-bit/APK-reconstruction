// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DateFormatSettingsController : TLMViewModel
	{
		// Fields
		private static readonly Dictionary<DateFormat, string> DateFormatToTranslationMap;
		public ObservableList<DropdownOption> dateFormats;
		[ObservableValue]
		private string _selectedDateFormat;
		private DropdownOption selectedOptionDate;
	
		// Properties
		[ObservableValue]
		public string selectedDateFormat { get => default; set {} }
	
		// Constructors
		public DateFormatSettingsController() {}
		static DateFormatSettingsController() {}
	
		// Methods
		protected override void OnEnable() {}
		private static DateFormat? GetDateFormat(string translationKey) => default;
		private static string GetTranslationKey(DateFormat dateFormat) => default;
		private void SetupDateFormatOptions() {}
		private void SelectedDateFormatChangedDoNotifyAndToast(DropdownOption dropdownOption) {}
		private bool SelectedDateFormatChanged(DropdownOption dropdownOption) => default;
		[UICallable]
		public void OpenDropdownDateFormat() {}
	}
