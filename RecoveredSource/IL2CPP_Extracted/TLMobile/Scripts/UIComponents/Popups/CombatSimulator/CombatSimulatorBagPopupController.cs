// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorBagPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private string _title;
		[ObservableValue]
		private ObservableList<BagDropDownOption> _options;
		[ObservableValue]
		private BagDropDownOption _selectedOption;
		private Action<int, int> callback;
	
		// Properties
		[ObservableValue]
		public string title { get => default; set {} }
		[ObservableValue]
		public ObservableList<BagDropDownOption> options { get => default; set {} }
		[ObservableValue]
		public BagDropDownOption selectedOption { get => default; set {} }
	
		// Constructors
		public CombatSimulatorBagPopupController() {}
	
		// Methods
		private void _optionsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(SpriteByStringCfg itemIcons, DefaultInventoryItem[] bag, string title, int selectedId, int selectedValue, Action<int, int> callback) {}
		[UICallable]
		public void SelectItem(BagDropDownOption option) {}
		[UICallable]
		public void ChangeSelectedValue(int change) {}
		[UICallable]
		public void Save() {}
	}
