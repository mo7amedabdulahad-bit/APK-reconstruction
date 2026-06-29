// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsAccountCreatedPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<Avatar> _legacyAcatars;
		[ObservableValue]
		private OwnIdentity _ownIdentity;
		private System.Action callback;
	
		// Properties
		[ObservableValue]
		public ObservableList<Avatar> legacyAcatars { get => default; set {} }
		[ObservableValue]
		public OwnIdentity ownIdentity { get => default; set {} }
	
		// Constructors
		public CamsAccountCreatedPopupController() {}
	
		// Methods
		private void _legacyAcatarsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup() {}
	}
