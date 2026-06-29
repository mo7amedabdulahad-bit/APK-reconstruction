// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages.IconSelection
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class IconSelectionPopupController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private List<IconSelectionCategory> iconSelectionCategories;
		[SerializeField]
		private List<SpriteByStringCfg> spriteCfgs;
		[ObservableValue]
		private int _selectedCount;
		[ObservableValue]
		private ObservableList<IconSelectionCategory> _iconCfgCategories;
		private Action<string> callback;
		private string selectedIconsAsBBCode;
	
		// Properties
		[ObservableValue]
		public int selectedCount { get => default; set {} }
		[ObservableValue]
		public ObservableList<IconSelectionCategory> iconCfgCategories { get => default; set {} }
	
		// Constructors
		public IconSelectionPopupController() {}
	
		// Methods
		private void _iconCfgCategoriesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void Setup(Action<string> callback) {}
		private void CreateBBCodeString() {}
		[UICallable]
		public void SelectIcon() {}
		[UICallable]
		public void ToggleIcon(IconSelectionDataObject obj) {}
		private void UpdateSelectedCount() {}
		private void CheckForAvailableTribesOnly() {}
		private void CreateIconSelectionData() {}
	}
