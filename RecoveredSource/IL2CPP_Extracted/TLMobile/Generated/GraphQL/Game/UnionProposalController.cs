// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnionProposalController : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private OwnAllianceDiplomacyUnionProposal _ownAllianceDiplomacyUnionProposal;
		[ObservableValue]
		private bool _canCancel;
		[ObservableValue]
		private bool _canAccept;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public OwnAllianceDiplomacyUnionProposal ownAllianceDiplomacyUnionProposal { get => default; set {} }
		[ObservableValue]
		public bool canCancel { get => default; set {} }
		[ObservableValue]
		public bool canAccept { get => default; set {} }
	
		// Constructors
		public UnionProposalController() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		[UICallable]
		public bool FilterAlreadyApproved(Alliance a) => default;
		private bool MayApproveProposal(int allianceId) => default;
	}
