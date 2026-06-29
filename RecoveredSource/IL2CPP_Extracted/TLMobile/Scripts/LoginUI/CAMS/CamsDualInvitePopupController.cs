// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsDualInvitePopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GameworldDualInvites _gameworldDualInvites;
		private System.Action refreshAvatarsAndDualInvites;
	
		// Properties
		[ObservableValue]
		public GameworldDualInvites gameworldDualInvites { get => default; set {} }
	
		// Constructors
		public CamsDualInvitePopupController() {}
	
		// Methods
		public void Setup(GameworldDualInvites gameworldDualInvites, System.Action refreshAvatarsAndDualInvites) {}
		[UICallable]
		public void AcceptOnlyInvite() {}
		[UICallable]
		public void AcceptInvite(DualInvite dualInvite) {}
		[UICallable]
		public void DeclineInvite(DualInvite dualInvite) {}
	}
