// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TaskDTO
	{
		// Fields
		public string name;
		public string description;
		public float? percentageToComplete;
		public int? progressValue;
		public int? currentLevel;
		public int? nextLevelValue;
		public int? nextLevel;
		public int? progressTarget;
		public string type;
		public TaskScope? scope;
		public bool? alwaysOnTop;
		public TaskMetadataDTO metadata;
		public List<TaskLevelDTO> levels;
		public int? taskIndex;
	
		// Constructors
		public TaskDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
