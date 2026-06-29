// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsSettingsDefaultTab : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private OwnIdentity _identity;
		[ObservableValue]
		private int _selectedSubTabIndex;
	
		// Properties
		[ObservableValue]
		public OwnIdentity identity { get => default; set {} }
		[ObservableValue]
		public int selectedSubTabIndex { get => default; set {} }
	
		// Constructors
		public CamsSettingsDefaultTab() {}
	
		// Methods
		protected override void OnEnable() {}
		[UICallable]
		public void OpenDeleteLobbyAccountPopup() {}
		[UICallable]
		public void OpenChangePassword() {}
		[UICallable]
		public void OpenChangeAccountName() {}
		[UICallable]
		public void OnSubTabSelected(int index) {}
	}
