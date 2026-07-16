// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RegionDTO
	{
		// Fields
		public int? id;
		public string name;
		public int? artefactSpawnTime;
		public JObject placeBonus;
		public int? vpPerDay;
		public bool? canBeSettled;
		public RegionStatus? status;
		public bool? isLocked;
		public int? topAlliancesPopulation;
		public int? populationNeeded;
		public int? topAlliancesVillages;
		public List<TerritorialControlDTO> territorialControl;
		public List<RegionDTO> neighboringRegions;
		public MapCellDTO regionCenter;
	
		// Constructors
		public RegionDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
