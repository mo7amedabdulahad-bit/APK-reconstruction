// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceProfileTabController : AllianceProfileBaseController
	{
		// Fields
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		private OwnAlliance _alliance;
		[ObservableValue]
		private GraphQLFetchableList<OwnAllianceMember> _allianceMembers;
		[ObservableValue]
		private bool _areRegionsEnabled;
	
		// Properties
		[ObservableValue]
		[PollForUpdates(30f, 0, -1f)]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<OwnAllianceMember> allianceMembers { get => default; set {} }
		[ObservableValue]
		public bool areRegionsEnabled { get => default; set {} }
	
		// Constructors
		public OwnAllianceProfileTabController() {}
	
		// Methods
		private void _allianceMembersNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		public override void Init() {}
		private void UpdateAlliance() {}
		private void UpdateOwnAllianceMembers() {}
		[UICallable]
		public void OpenInvitePopup() {}
		public void InvitePlayerCallback(TLMobile.Generated.GraphQL.Game.Player player) {}
	}
