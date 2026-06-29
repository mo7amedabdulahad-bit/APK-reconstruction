// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AdventureReportDTO
	{
		// Fields
		public string objectId;
		public int? time;
		public int? readStatus;
		public string title;
		public int? ownerId;
		public VillageDTO sourceVillage;
		public AdventureDTO adventure;
		public AdventureResultDTO result;
		public int? silver;
		public AdventureDroppedUnitDTO unit;
		public AdventureDroppedItemDTO item;
		public ResourcesAmountDTO addedResources;
	
		// Constructors
		public AdventureReportDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
