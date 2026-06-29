// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StandingTroopDTO
	{
		// Fields
		public PlayerDTO player;
		public VillageDTO originVillage;
		public VillageDTO supplyVillage;
		public int? tribeId;
		public int? type;
		public int? time;
		public int? consumption;
		public int? attackPower;
		public int? defencePower;
		public VillageDTO currentVillage;
		public UnitsAmountDTO units;
	
		// Constructors
		public StandingTroopDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
