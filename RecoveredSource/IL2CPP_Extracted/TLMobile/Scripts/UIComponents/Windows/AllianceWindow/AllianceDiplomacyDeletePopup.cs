// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceDiplomacyDeletePopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnAllianceDiplomacyRelation _diplomacyRelation;
		[ObservableValue]
		private OwnAllianceDiplomacyUnion _union;
		[ObservableValue]
		private OwnAllianceDiplomacyUnionProposal _unionProposal;
		[ObservableValue]
		private Alliance _otherAlliance;
		[ObservableValue]
		private Type _type;
		private OwnAlliance alliance;
	
		// Properties
		[ObservableValue]
		public OwnAllianceDiplomacyRelation diplomacyRelation { get => default; set {} }
		[ObservableValue]
		public OwnAllianceDiplomacyUnion union { get => default; set {} }
		[ObservableValue]
		public OwnAllianceDiplomacyUnionProposal unionProposal { get => default; set {} }
		[ObservableValue]
		public Alliance otherAlliance { get => default; set {} }
		[ObservableValue]
		public Type type { get => default; set {} }
	
		// Nested types
		public enum Type
		{
			RemoveRequest = 1,
			TerminateExisting = 2,
			QuitConfederacy = 3,
			RemoveConfederacyProposal = 4,
			ConfederacyKickVote = 5
		}
	
		// Constructors
		public AllianceDiplomacyDeletePopup() {}
	
		// Methods
		public void Setup(OwnAllianceDiplomacyRelation dipl) {}
		public void Setup(OwnAllianceDiplomacyUnion union) {}
		public void Setup(OwnAllianceDiplomacyUnionProposal unionProposal) {}
		public void Setup(Alliance otherAlliance) {}
		[UICallable]
		public void Confirm() {}
	}
