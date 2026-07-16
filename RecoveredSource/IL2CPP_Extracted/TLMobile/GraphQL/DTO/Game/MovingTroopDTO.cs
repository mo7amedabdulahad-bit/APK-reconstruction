// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MovingTroopDTO
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
		public int? id;
		public int? lumber;
		public int? clay;
		public int? iron;
		public int? crop;
		public int? catapultTarget1;
		public int? catapultTarget2;
		public TLMobile.Generated.GraphQL.Game.ScoutingTarget? scoutingTarget;
		public int? sourceUid;
		public int? sourceDid;
		public int? sourceKid;
		public TroopEventDTO troopEvent;
		public UnitsAmountDTO units;
		public TroopFlag? flag;
		public string ship;
	
		// Constructors
		public MovingTroopDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
