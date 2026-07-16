// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmDeleteDualPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Avatar _avatar;
		[ObservableValue]
		private Dual _dual;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public Avatar avatar { get => default; set {} }
		[ObservableValue]
		public Dual dual { get => default; set {} }
	
		// Constructors
		public ConfirmDeleteDualPopupController() {}
	
		// Methods
		public void Setup(Avatar avatar, Dual dual, System.Action confirmCallback) {}
		[UICallable]
		public void ConfirmDeleteDual() {}
	}
