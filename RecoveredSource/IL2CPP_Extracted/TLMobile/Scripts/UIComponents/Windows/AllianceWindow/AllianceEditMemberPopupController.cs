// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceEditMemberPopupController : DetailWindowController
	{
		// Fields
		private static readonly OwnAllianceMemberSpecialization[] ReferenceSortingRoles;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private OwnAllianceMemberSpecialization _role;
		[ObservableValue]
		private ObservableList<OwnAllianceMemberSpecialization> _roles;
		[ObservableValue]
		private OwnAlliance _ownAlliance;
		[ObservableValue]
		private string _playerNote;
		[ObservableValue]
		private OwnAllianceMember _currentAllianceMember;
		[ObservableValue]
		private string _title;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public OwnAllianceMemberSpecialization role { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnAllianceMemberSpecialization> roles { get => default; set {} }
		[ObservableValue]
		public OwnAlliance ownAlliance { get => default; set {} }
		[ObservableValue]
		public string playerNote { get => default; set {} }
		[ObservableValue]
		public OwnAllianceMember currentAllianceMember { get => default; set {} }
		[ObservableValue]
		public string title { get => default; set {} }
	
		// Constructors
		public AllianceEditMemberPopupController() {}
		static AllianceEditMemberPopupController() {}
	
		// Methods
		private void _rolesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Setup(TLMobile.Generated.GraphQL.Game.Player playerToEdit) {}
		[UICallable]
		public void SetRole(OwnAllianceMemberSpecialization role) {}
		[UICallable]
		public void Save() {}
	}
