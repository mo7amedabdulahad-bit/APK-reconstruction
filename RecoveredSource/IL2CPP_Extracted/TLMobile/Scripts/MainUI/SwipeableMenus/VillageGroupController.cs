// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.SwipeableMenus
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageGroupController : InjectableViewModel
	{
		// Fields
		private static readonly string GroupExpandedKey;
		[InjectableValue]
		[ObservableValue]
		private VillageListItem _villageListItem;
		[ObservableValue]
		private VillageListGroup _villageListGroup;
		[ObservableValue]
		private VillageListVillage _villageListVillage;
		[ObservableValue]
		private OwnVillage _currentVillage;
		[ObservableValue]
		private bool _editingName;
		[ObservableValue]
		private string _currentName;
		public GameObject colorEditorPrefab;
		public Transform colorEditorParent;
		private GameObject _colorEditorInstance;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public VillageListItem villageListItem { get => default; set {} }
		[ObservableValue]
		public VillageListGroup villageListGroup { get => default; set {} }
		[ObservableValue]
		public VillageListVillage villageListVillage { get => default; set {} }
		[ObservableValue]
		public OwnVillage currentVillage { get => default; set {} }
		[ObservableValue]
		public bool editingName { get => default; set {} }
		[ObservableValue]
		public string currentName { get => default; set {} }
	
		// Constructors
		public VillageGroupController() {}
		static VillageGroupController() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		private void UpdateGroupName() {}
		protected override void Awake() {}
		protected override void OnDestroy() {}
		private void OnClickedSomewhere(GameObject go) {}
		[UICallable]
		public void ToggleGroupExpanded() {}
		[UICallable]
		public void DeleteGroup() {}
		private void OnConfirmDelete() {}
		[UICallable]
		public void ToggleColorEditor() {}
		[UICallable]
		public void PickColor(int colorIndex) {}
		public void OnInputFieldFocused() {}
		[UICallable]
		public void CancelRename() {}
		[UICallable]
		public void ApplyNewName() {}
	}
