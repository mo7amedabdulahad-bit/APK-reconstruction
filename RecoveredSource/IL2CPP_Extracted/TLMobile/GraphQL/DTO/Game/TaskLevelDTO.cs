// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TaskLevelDTO
	{
		// Fields
		public string title;
		public TaskMetadataDTO metadata;
		public bool? wasCollected;
		public bool? readyToBeCollected;
		public int? levelValue;
		public int? level;
		public TaskRewardDTO rewardValues;
		public bool? wasTakenOver;
		public string questId;
	
		// Constructors
		public TaskLevelDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
