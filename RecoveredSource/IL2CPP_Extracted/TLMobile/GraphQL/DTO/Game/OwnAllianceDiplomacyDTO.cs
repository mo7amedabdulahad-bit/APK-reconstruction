// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceDiplomacyDTO
	{
		// Fields
		public List<OwnAllianceDiplomacyRelationDTO> ownOffers;
		public List<OwnAllianceDiplomacyRelationDTO> incomingOffers;
		public List<OwnAllianceDiplomacyRelationDTO> existingRelations;
		public List<OwnAllianceDiplomacyUnionProposalDTO> invitationsToUnion;
		public OwnAllianceDiplomacyUnionDTO union;
	
		// Constructors
		public OwnAllianceDiplomacyDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
