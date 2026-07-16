// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private SubTab _subTab;
		[ObservableValue]
		private ObservableList<OwnAllianceDiplomacyRelation> _napAndWarOffers;
		[ObservableValue]
		private ObservableList<OwnAllianceDiplomacyRelation> _confederacyOffers;
		[ObservableValue]
		private int _confederacyMembers;
		[ObservableValue]
		private int _maxUnionMembers;
		[ObservableValue]
		private bool _unionFeature;
	
		// Properties
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public SubTab subTab { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnAllianceDiplomacyRelation> napAndWarOffers { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnAllianceDiplomacyRelation> confederacyOffers { get => default; set {} }
		[ObservableValue]
		public int confederacyMembers { get => default; set {} }
		[ObservableValue]
		public int maxUnionMembers { get => default; set {} }
		[ObservableValue]
		public bool unionFeature { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			Overview = 1,
			Union = 2
		}
	
		// Constructors
		public OwnAllianceDiplomacyTabController() {}
	
		// Methods
		private void _napAndWarOffersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _confederacyOffersNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		public void Init() {}
		private void SplitConfederacyFromOtherOffers() {}
		[UICallable]
		public void CancelDiplomacy(OwnAllianceDiplomacyRelation diplObj) {}
		[UICallable]
		public void CancelProposal(OwnAllianceDiplomacyUnionProposal proposal) {}
		[UICallable]
		public void LeaveUnion() {}
		[UICallable]
		public void AcceptDiplomacy(OwnAllianceDiplomacyRelation diplObj) {}
		[UICallable]
		public void StartKickVote(Alliance otherAlliance) {}
		[UICallable]
		public void AcceptProposal(OwnAllianceDiplomacyUnionProposal diplObj) {}
		[UICallable]
		public void SetSubTab(SubTab tab) {}
		[UICallable]
		public bool FilterForSubTab(OwnAllianceDiplomacyRelation diplObj) => default;
		[UICallable]
		public bool FilterOutOwnAlliance(Alliance allianceObject) => default;
		[UICallable]
		public void AddUnionRequest() {}
	}
