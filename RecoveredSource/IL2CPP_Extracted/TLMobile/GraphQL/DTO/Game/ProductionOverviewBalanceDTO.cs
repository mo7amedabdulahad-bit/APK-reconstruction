// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ProductionOverviewBalanceDTO
	{
		// Fields
		public int? totalProductionPerHour;
		public int? totalProductionPerHourBonus;
		public int? cropConsumptionsOfBuildingsInQueue;
		public int? heroProduction;
		public int? productionBoost;
		public int? productionBoostFactor;
		public bool? playerHasBoost;
		public OwnTroopsConsumptionDTO ownTroopsConsumption;
		public ForeignTroopsConsumptionDTO foreignTroopsConsumption;
		public int? compensationBoostFactor;
		public int? compensationBoostValue;
	
		// Constructors
		public ProductionOverviewBalanceDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
