// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Sorting
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SortingOption : ObservableModel
	{
		// Fields
		[ObservableValue]
		private int _value;
		[ObservableValue]
		private string _titleKey;
		[ObservableValue]
		private SortOrder _sortOrder;
		[ObservableValue]
		private Sprite _leftSideIcon;
	
		// Properties
		[ObservableValue]
		public int value { get => default; set {} }
		[ObservableValue]
		public string titleKey { get => default; set {} }
		[ObservableValue]
		public SortOrder sortOrder { get => default; set {} }
		[ObservableValue]
		public Sprite leftSideIcon { get => default; set {} }
	
		// Constructors
		public SortingOption() {}
		public SortingOption(int value, string titleKey = "", SortOrder sortOrder = SortOrder.ASC) {}
	
		// Methods
		public SortingOption SetIcon(Sprite icon) => default;
	}
