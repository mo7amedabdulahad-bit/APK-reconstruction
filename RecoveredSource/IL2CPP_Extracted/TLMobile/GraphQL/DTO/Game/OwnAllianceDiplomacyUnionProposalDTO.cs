// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyUnionProposalDTO
	{
		// Fields
		public string type;
		public string unionId;
		public AllianceDTO initiator;
		public AllianceDTO subject;
		public List<AllianceDTO> approvedBy;
	
		// Constructors
		public OwnAllianceDiplomacyUnionProposalDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
