// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceEditPermissionsPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnAllianceMember _currentAllianceMember;
		[ObservableValue]
		private int _numbersOfMembersWithAssignToPositionRights;
		private OwnAllianceMember backendAllianceMember;
		private TLMobile.Generated.GraphQL.Game.Player currentPlayer;
	
		// Properties
		[ObservableValue]
		public OwnAllianceMember currentAllianceMember { get => default; set {} }
		[ObservableValue]
		public int numbersOfMembersWithAssignToPositionRights { get => default; set {} }
	
		// Nested types
		public enum AlliancePermission
		{
			AssignToPosition = 0,
			KickPlayer = 1,
			ChangeAlliance = 2,
			Diplomacy = 3,
			Igm = 4,
			InviteToAlliance = 5,
			ManageForums = 6,
			ManageMap = 7,
			ManageSpecialization = 8
		}
	
		// Constructors
		public AllianceEditPermissionsPopupController() {}
	
		// Methods
		public void Setup(TLMobile.Generated.GraphQL.Game.Player playerToEdit) {}
		private void CopyAllianceMemberValuesForChanges() {}
		[UICallable]
		public void SwitchPermissionValue(AlliancePermission permission) {}
		[UICallable]
		public void Save() {}
	}
