// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.DropdownList
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DropdownListController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<DropdownOption> _options;
		[ObservableValue]
		private ObservableList<DropdownOption> _recentOptions;
		[ObservableValue]
		private DropdownOption _selectedOption;
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		private string _popupTitle;
		private Action<DropdownOption> callback;
	
		// Properties
		[ObservableValue]
		public ObservableList<DropdownOption> options { get => default; set {} }
		[ObservableValue]
		public ObservableList<DropdownOption> recentOptions { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption { get => default; set {} }
		[InjectableValue(acceptsConstant = true)]
		[ObservableValue]
		public string popupTitle { get => default; set {} }
	
		// Constructors
		public DropdownListController() {}
	
		// Methods
		private void _optionsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _recentOptionsNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void OnInjectedValueChanged() {}
		public void SetOptions(ObservableList<DropdownOption> dropdownOptions, string popupTitleTranslateKey, Action<DropdownOption> callback, ObservableList<DropdownOption> recentOptions = null) {}
		[UICallable]
		public virtual void CloseDropdown() {}
		[UICallable]
		public void SelectOption(DropdownOption option) {}
		public void PreSelectOption(DropdownOption option) {}
		public void SelectOptionWithValue(int value) {}
		public void SelectOptionWithValue(DropdownOption option) {}
		private void SelectOptionWithValue(int value, List<DropdownOption> optionsToSearch) {}
	}
