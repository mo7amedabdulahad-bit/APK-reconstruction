// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OtherAllianceProfileController : AllianceProfileBaseController
	{
		// Fields
		[ObservableValue]
		private Alliance _alliance;
		[ObservableValue]
		private GraphQLFetchableList<AllianceMember> _allianceMembers;
		[ObservableValue]
		private bool _isOwnAlliance;
		[ObservableValue]
		private bool _isTerritoryEnabled;
	
		// Properties
		[ObservableValue]
		public Alliance alliance { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<AllianceMember> allianceMembers { get => default; set {} }
		[ObservableValue]
		public bool isOwnAlliance { get => default; set {} }
		[ObservableValue]
		public bool isTerritoryEnabled { get => default; set {} }
	
		// Constructors
		public OtherAllianceProfileController() {}
	
		// Methods
		private void _allianceMembersNotify(object sender, PropertyChangedEventArgs args) {}
		public override void Init() {}
		public void Setup(Alliance alliance) {}
	}
