// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.DropdownList
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DropdownOption : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Sprite _icon;
		[ObservableValue]
		private Material _material;
		[ObservableValue]
		private int _value;
		[ObservableValue]
		private string _titleTranslateKey;
		[ObservableValue]
		private ObservableList<DropdownOption> _subOptions;
		[ObservableValue]
		private int _indentedSubOptionsAmount;
		[ObservableValue]
		private bool _expanded;
		[ObservableValue]
		private bool _expandedNotToggleable;
		[ObservableValue]
		private bool _ignoreTranslate;
		[ObservableValue]
		private bool _isCategoryTitle;
		[ObservableValue]
		private Sprite _rightSideIcon;
		[ObservableValue]
		private string _rightSideText;
		[ObservableValue]
		private DropdownPrefabs _dropdownPrefabType;
	
		// Properties
		[ObservableValue]
		public Sprite icon { get => default; set {} }
		[ObservableValue]
		public Material material { get => default; set {} }
		[ObservableValue]
		public int value { get => default; set {} }
		[ObservableValue]
		public string titleTranslateKey { get => default; set {} }
		[ObservableValue]
		public ObservableList<DropdownOption> subOptions { get => default; set {} }
		[ObservableValue]
		public int indentedSubOptionsAmount { get => default; set {} }
		[ObservableValue]
		public bool expanded { get => default; set {} }
		[ObservableValue]
		public bool expandedNotToggleable { get => default; set {} }
		[ObservableValue]
		public bool ignoreTranslate { get => default; set {} }
		[ObservableValue]
		public bool isCategoryTitle { get => default; set {} }
		[ObservableValue]
		public Sprite rightSideIcon { get => default; set {} }
		[ObservableValue]
		public string rightSideText { get => default; set {} }
		[ObservableValue]
		public DropdownPrefabs dropdownPrefabType { get => default; set {} }
	
		// Constructors
		public DropdownOption() {}
		public DropdownOption(int value, string titleTranslateKey, bool ignoreTranslate = false) {}
	
		// Methods
		private void _subOptionsNotify(object sender, PropertyChangedEventArgs args) {}
		public DropdownOption AddSubOption(int value, string titleTranslateKey) => default;
		public void AddSubOption(DropdownOption newSubOption) {}
		public DropdownOption SetIndentedAmount(int value) => default;
		public DropdownOption SetIcon(Sprite icon) => default;
		public DropdownOption SetMaterial(Material material) => default;
		public DropdownOption SetValue(int value) => default;
		public DropdownOption SetTitleTranslateKey(string titleTranslateKey) => default;
		public DropdownOption SetSubOptions(ObservableList<DropdownOption> subOptions) => default;
		public DropdownOption SetExpanded(bool expanded) => default;
		public DropdownOption SetExpandedNotToggleable(bool expandedNotToggleable) => default;
		public DropdownOption SetIgnoreTranslate(bool ignoreTranslate) => default;
		public DropdownOption SetIsCategoryTitle(bool isCategoryTitle) => default;
		public DropdownOption SetRightSideIcon(Sprite rightSideIcon) => default;
		public DropdownOption SetRightSideText(string rightSideText) => default;
	}
