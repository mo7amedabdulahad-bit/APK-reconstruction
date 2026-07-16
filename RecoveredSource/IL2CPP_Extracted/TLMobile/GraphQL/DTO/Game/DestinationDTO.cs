// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DestinationDTO
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
		public List<OccupiedOasisDTO> occupiedOases;
		public RegionDTO region;
		public string typeText;
		public string typeTitle;
		public bool? isShore;
		public bool? isCity;
		public VillageDTO ownerVillage;
		public PlayerDTO player;
		public int? victoryPoints;
		public float? victoryPointsPerDay;
		public bool? cropOnly;
		public int? travelTime;
	
		// Constructors
		public DestinationDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
