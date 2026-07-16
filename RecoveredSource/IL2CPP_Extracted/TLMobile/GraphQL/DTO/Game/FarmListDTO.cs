// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FarmListDTO
	{
		// Fields
		public int? id;
		public string name;
		public OwnVillageDTO ownerVillage;
		public UnitsAmountDTO defaultTroop;
		public int? slotsAmount;
		public int? runningRaidsAmount;
		public bool? isExpanded;
		public int? sortIndex;
		public int? lastStartedTime;
		public string sortField;
		public string sortDirection;
		public bool? useShip;
		public bool? onlyLosses;
	
		// Constructors
		public FarmListDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
