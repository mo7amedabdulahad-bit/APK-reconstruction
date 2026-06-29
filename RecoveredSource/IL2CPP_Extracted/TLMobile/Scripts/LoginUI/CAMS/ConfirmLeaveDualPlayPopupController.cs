// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmLeaveDualPlayPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Avatar _avatar;
		private System.Action confirmAcceptInviteCallback;
	
		// Properties
		[ObservableValue]
		public Avatar avatar { get => default; set {} }
	
		// Constructors
		public ConfirmLeaveDualPlayPopupController() {}
	
		// Methods
		public void Setup(Avatar avatar, System.Action confirmCallback) {}
		[UICallable]
		public void ConfirmLeaveDualPlay() {}
	}
