// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnVillageDTO
	{
		// Fields
		public int? id;
		public int? landDistribution;
		public int? tribeId;
		public int? mapId;
		public int? x;
		public int? y;
		public string name;
		public int? type;
		public int? population;
		public bool? isWW;
		public RegionDTO region;
		public string typeText;
		public string typeTitle;
		public bool? isShore;
		public bool? isCity;
		public string objectId;
		public OwnVillageDTO ownerVillage;
		public int? oasesCount;
		public List<BuildingDTO> buildings;
		public TroopsDTO troops;
		public TroopDTO troopsSummary;
		public ResourceDTO resources;
		public List<BuildEventDTO> buildEvents;
		public int? loyalty;
		public List<ResearchedUnitDTO> researchedUnits;
		public bool? waveBuilderIsActivated;
		public int? goldLeftToMergeTroops;
		public List<TrainingBatchDTO> trainingTroops;
		public TroopsOverviewDTO troopOverview;
		public bool? hasRallyPoint;
		public bool? hasHarbour;
		public int? cpProduction;
		public int? sortIndex;
		public StableDTO stable;
		public BarracksDTO barracks;
		public ResidenceDTO residence;
		public ProductionOverviewDTO productionOverview;
		public int? notCollectedTasks;
		[Obsolete("Please use \'troopsSummary\' as less ambiguous name")]
		public TroopDTO ownTroops;
		public WoWDTO wow;
		public int? upgradeToCityInProgressUntil;
		public float? distance;
		public bool? settlersCanChangeTribe;
	
		// Constructors
		public OwnVillageDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
