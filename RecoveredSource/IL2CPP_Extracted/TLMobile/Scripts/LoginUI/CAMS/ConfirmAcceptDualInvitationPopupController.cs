// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmAcceptDualInvitationPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private DualInvite _dualInvite;
		[ObservableValue]
		private GameworldDualInvites _gameworldDualInvites;
		private System.Action confirmAcceptInviteCallback;
	
		// Properties
		[ObservableValue]
		public DualInvite dualInvite { get => default; set {} }
		[ObservableValue]
		public GameworldDualInvites gameworldDualInvites { get => default; set {} }
	
		// Constructors
		public ConfirmAcceptDualInvitationPopupController() {}
	
		// Methods
		public void Setup(DualInvite dualInvite, GameworldDualInvites gameworldDualInvites, System.Action confirmCallback) {}
		[UICallable]
		public void ConfirmAcceptDualInvite() {}
	}
