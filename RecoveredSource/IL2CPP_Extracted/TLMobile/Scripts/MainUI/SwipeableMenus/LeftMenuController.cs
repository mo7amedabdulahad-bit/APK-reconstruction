// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.SwipeableMenus
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LeftMenuController : ViewModel
	{
		// Fields
		public Action<bool> OnInfoBoxToggled;
		[ObservableValue]
		private bool _unreadMessagesExpanded;
		[ObservableValue]
		private bool _infoboxesExpanded;
		[ObservableValue]
		private Building _embassy;
		[ObservableValue]
		private int _serverTimestamp;
		[ObservableValue]
		private int _localTimestamp;
		[ObservableValue]
		private string _serverName;
		private BootstrapData bootstrap;
		private OwnVillage village;
		private IVillageChangeService villageChangeService;
		private OwnVillage villageWithEmbassy;
	
		// Properties
		[ObservableValue]
		public bool unreadMessagesExpanded { get => default; set {} }
		[ObservableValue]
		public bool infoboxesExpanded { get => default; set {} }
		[ObservableValue]
		public Building embassy { get => default; set {} }
		[ObservableValue]
		public int serverTimestamp { get => default; set {} }
		[ObservableValue]
		public int localTimestamp { get => default; set {} }
		[ObservableValue]
		public string serverName { get => default; set {} }
	
		// Constructors
		public LeftMenuController() {}
	
		// Methods
		public new void Awake() {}
		protected void OnEnable() {}
		private void OnDisable() {}
		private void UpdateTime() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		[UICallable]
		public void ToggleInfoBox() {}
		[UICallable]
		public void ToggleUnreadMessagesBox() {}
		[UICallable]
		public void ShowEmbassyWindowAndChangeToVillage() {}
		private void AfterVillageChangedOnButtonClick(OwnVillage newVill) {}
		private void SearchForEmbassyBuilding() {}
	}
