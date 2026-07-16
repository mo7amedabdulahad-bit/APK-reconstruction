// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsEditDualsPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Avatar _avatar;
		[ObservableValue]
		private OwnIdentity _ownIdentity;
		private System.Action refreshAvatarsAndDualInvites;
	
		// Properties
		[ObservableValue]
		public Avatar avatar { get => default; set {} }
		[ObservableValue]
		public OwnIdentity ownIdentity { get => default; set {} }
	
		// Constructors
		public CamsEditDualsPopupController() {}
	
		// Methods
		public void Setup(Avatar avatar, System.Action refreshAvatarsAndDualInvites) {}
		[UICallable]
		public void AddDualPlayer() {}
		private void SelectIdentity(ObservableList<TLMobile.Generated.GraphQL.Lobby.Identity> identities) {}
		[UICallable]
		public void RemoveDualPlayer(Dual dual) {}
		private void RemoveDual(Dual dual) {}
	}
