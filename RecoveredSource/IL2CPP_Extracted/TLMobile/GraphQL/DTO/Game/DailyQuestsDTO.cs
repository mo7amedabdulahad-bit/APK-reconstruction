// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DailyQuestsDTO
	{
		// Fields
		public int? day;
		public int? lastSeenAt;
		public int? achievedPoints;
		public int? resetAt;
		public List<QuestRewardDTO> rewards;
		public List<QuestDataDTO> quests;
	
		// Constructors
		public DailyQuestsDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
