// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.GraphQL.DTO.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceDTO
	{
		// Fields
		public string objectId;
		public int? id;
		public string name;
		public string tag;
		public string description1;
		public string description2;
		public int? rank;
		public float? points;
		public int? membersCount;
		public AllianceBannerDTO banner;
		public List<AllianceMedalDTO> medals;
		public AllianceDiplomacyDTO allianceDiplomacy;
		public List<RegionalTop5DTO> regionalTop5;
		public int? victoryPoints;
		public int? victoryPointsPerDay;
		public int? attackerRank;
		public int? attackerPoints;
		public int? defenderRank;
		public int? defenderPoints;
	
		// Constructors
		public AllianceDTO() {}
	
		// Methods
		[OnError]
		internal void OnError(StreamingContext context, ErrorContext errorContext) {}
	}
