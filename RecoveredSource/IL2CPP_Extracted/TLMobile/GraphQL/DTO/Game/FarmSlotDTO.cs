// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FarmSlotDTO
	{
		// Fields
		public int? id;
		public VillageDTO target;
		public UnitsAmountDTO troop;
		public TribeDTO troopTribe;
		public float? distance;
		public bool? isActive;
		public bool? isRunning;
		public int? runningAttacks;
		public int? nextAttackAt;
		public LastRaidDTO lastRaid;
		public TotalBootyDTO totalBooty;
		public bool? isSpying;
	
		// Constructors
		public FarmSlotDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
