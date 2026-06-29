// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnitDTO
	{
		// Fields
		[JsonProperty("id")]
		public string idString;
		public int? baseTrainingDuration;
		public int? attackPower;
		public int? defencePowerAgainstInfantry;
		public int? defencePowerAgainstCavalry;
		public int? velocity;
		public int? carry;
		public int? upkeepCost;
		public List<int?> trainedAt;
		public List<List<RequiredBuildingDTO>> requiredBuildings;
		public ResourcesAmountDTO researchingCost;
		public int? researchDuration;
		public ResourcesAmountDTO trainingCost;
		public ResourcesAmountDTO upgradingCost;
		public List<ExtraPropertyDTO> extraProperties;
	
		// Constructors
		public UnitDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
