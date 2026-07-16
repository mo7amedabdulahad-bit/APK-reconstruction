// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyUnionDTO
	{
		// Fields
		public string id;
		public List<AllianceDTO> members;
		public List<OwnAllianceDiplomacyUnionProposalDTO> inviteProposals;
		public List<OwnAllianceDiplomacyUnionProposalDTO> kickOutProposals;
	
		// Constructors
		public OwnAllianceDiplomacyUnionDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
