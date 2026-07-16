// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Building : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _buildingTypeId;
		[ObservableValue]
		private int _slotId;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private int _levelUpdateTimestamp;
		[ObservableValue]
		private TypeId _typeIdEnum;
		[ObservableValue]
		private int? _rearrangedSlotId;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int buildingTypeId { get => default; set {} }
		[ObservableValue]
		public int slotId { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public int levelUpdateTimestamp { get => default; set {} }
		[ObservableValue]
		public TypeId typeIdEnum { get => default; set {} }
		[ObservableValue]
		public int? rearrangedSlotId { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			TrainingBatchAllBuilding = 1
		}
	
		public enum TypeId
		{
			Woodcutter = 1,
			ClayPit = 2,
			IronMine = 3,
			Cropland = 4,
			Sawmill = 5,
			Brickyard = 6,
			IronFoundry = 7,
			GrainMill = 8,
			Bakery = 9,
			Warehouse = 10,
			Granary = 11,
			Smithy = 13,
			TournamentSquare = 14,
			MainBuilding = 15,
			RallyPoint = 16,
			Marketplace = 17,
			Embassy = 18,
			Barracks = 19,
			Stable = 20,
			Workshop = 21,
			Academy = 22,
			Cranny = 23,
			TownHall = 24,
			Residence = 25,
			Palace = 26,
			Treasury = 27,
			TradeOffice = 28,
			GreatBarracks = 29,
			GreatStable = 30,
			CityWall = 31,
			EarthWall = 32,
			Palisade = 33,
			StonemasonsLodge = 34,
			Brewery = 35,
			Trapper = 36,
			HeroMansion = 37,
			GreatWarehouse = 38,
			GreatGranary = 39,
			WonderOfTheWorld = 40,
			HorseDrinkingTrough = 41,
			StoneWall = 42,
			MakeshiftWall = 43,
			CommandCenter = 44,
			Waterworks = 45,
			Hospital = 46,
			DefensiveWall = 47,
			Asclepeion = 48,
			Harbour = 49,
			Barricade = 50
		}
	
		// Constructors
		public Building() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BuildingDTO dtoValue) => default;
		private bool EqualToDTOTrainingBatchAllBuilding(BuildingDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BuildingDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOTrainingBatchAllBuilding(BuildingDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		public bool IsResourceField() => default;
		public bool IsWall() => default;
		public float GetLevelBonusFactor() => default;
		public bool HasResourceProduction() => default;
		public static bool IsResourceField(TypeId typeIdEnum) => default;
		public static bool IsWall(TypeId typeIdEnum) => default;
		public static TypeId? GetWallId(OwnPlayer.TribeId tribeId) => default;
		public static bool CanBeCompletedImmediately(TypeId typeIdEnum) => default;
		public static bool CanSpeedUp(TypeId typeIdEnum) => default;
		public static float GetLevelBonusFactor(int level) => default;
		public void UpdateRearrangedBuildingSlot() {}
	}
