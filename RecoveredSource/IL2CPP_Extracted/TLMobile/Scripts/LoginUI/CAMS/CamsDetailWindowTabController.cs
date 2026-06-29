// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsDetailWindowTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		protected bool _isButtonDisabled;
		[ObservableValue]
		protected bool _attestationError;
		protected CamsWindowController camsWindowController;
	
		// Properties
		[ObservableValue]
		public bool isButtonDisabled { get => default; set {} }
		[ObservableValue]
		public bool attestationError { get => default; set {} }
	
		// Constructors
		public CamsDetailWindowTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		protected bool CheckAttestationError(ApiException api) => default;
	}
