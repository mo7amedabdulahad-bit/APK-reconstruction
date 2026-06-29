// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopEvent : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private MapCell _cellFrom;
		[ObservableValue]
		private MapCell _cellTo;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int? _markStatus;
		[ObservableValue]
		private int _arrivalTime;
		[ObservableValue]
		private TypeEnum _typeEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public MapCell cellFrom { get => default; set {} }
		[ObservableValue]
		public MapCell cellTo { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int? markStatus { get => default; set {} }
		[ObservableValue]
		public int arrivalTime { get => default; set {} }
		[ObservableValue]
		public TypeEnum typeEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			MovingTroopMovingTroopEdgeMovingTroopConnectionOnlyTimeEdgesNodeTroopEvent = 1
		}
	
		public enum TypeEnum
		{
			Attack = 3,
			Raid = 4,
			Supply = 5,
			SpyAttack = 6,
			ReturnTroop = 9,
			NewVillage = 10,
			TroopEscape = 40,
			HeroAdventure = 50,
			TroopAdventureReward = 60,
			ReturnReinforcementsAfterBanning = 67,
			TroopForward = 72
		}
	
		// Constructors
		public TroopEvent() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TroopEventDTO dtoValue) => default;
		private bool EqualToDTOMovingTroopMovingTroopEdgeMovingTroopConnectionOnlyTimeEdgesNodeTroopEvent(TroopEventDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TroopEventDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOMovingTroopMovingTroopEdgeMovingTroopConnectionOnlyTimeEdgesNodeTroopEvent(TroopEventDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
