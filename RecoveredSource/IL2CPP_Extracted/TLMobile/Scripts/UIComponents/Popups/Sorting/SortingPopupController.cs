// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Sorting
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SortingPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> _options;
		[ObservableValue]
		private TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption _selectedOption;
		private Action<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> callback;
	
		// Properties
		[ObservableValue]
		public ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> options { get => default; set {} }
		[ObservableValue]
		public TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption selectedOption { get => default; set {} }
	
		// Constructors
		public SortingPopupController() {}
	
		// Methods
		private void _optionsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(ObservableList<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> options, Action<TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption> callback) {}
		public void PreSelectOption(TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption option) {}
		[UICallable]
		public virtual void SelectOption(TLMobile.Scripts.UIComponents.Popups.Sorting.SortingOption option) {}
		[UICallable]
		public virtual void CloseAndApply() {}
	}
