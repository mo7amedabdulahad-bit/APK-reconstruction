// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class QuestRewardDTO
	{
		// Fields
		public string id;
		public int? points;
		public string awardDescription;
		public bool? awardRedeemed;
		public List<PossibleAwardDTO> possibleAwards;
	
		// Constructors
		public QuestRewardDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
