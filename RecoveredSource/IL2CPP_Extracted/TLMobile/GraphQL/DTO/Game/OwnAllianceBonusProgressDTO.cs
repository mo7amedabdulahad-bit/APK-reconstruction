// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceBonusProgressDTO
	{
		// Fields
		public int? donated;
		public int? currentLevel;
		public List<OwnAllianceBonusProgressLevelDTO> levels;
		public bool? isUpgrading;
		public int? upgradeCompleteAt;
	
		// Constructors
		public OwnAllianceBonusProgressDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
