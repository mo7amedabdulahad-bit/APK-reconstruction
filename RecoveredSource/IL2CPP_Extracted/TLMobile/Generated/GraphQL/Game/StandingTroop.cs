// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class StandingTroop : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private Village _originVillage;
		[ObservableValue]
		private Village _supplyVillage;
		[ObservableValue]
		private int? _tribeId;
		[ObservableValue]
		private int? _type;
		[ObservableValue]
		private int? _time;
		[ObservableValue]
		private int? _consumption;
		[ObservableValue]
		private int? _attackPower;
		[ObservableValue]
		private int? _defencePower;
		[ObservableValue]
		private Village _currentVillage;
		[ObservableValue]
		private UnitsAmount _units;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeIdEnum;
		[ObservableValue]
		private Type _typeEnum;
		[ObservableValue]
		private TroopAmounts _amounts;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public Village originVillage { get => default; set {} }
		[ObservableValue]
		public Village supplyVillage { get => default; set {} }
		[ObservableValue]
		public int? tribeId { get => default; set {} }
		[ObservableValue]
		public int? type { get => default; set {} }
		[ObservableValue]
		public int? time { get => default; set {} }
		[ObservableValue]
		public int? consumption { get => default; set {} }
		[ObservableValue]
		public int? attackPower { get => default; set {} }
		[ObservableValue]
		public int? defencePower { get => default; set {} }
		[ObservableValue]
		public Village currentVillage { get => default; set {} }
		[ObservableValue]
		public UnitsAmount units { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeIdEnum { get => default; set {} }
		[ObservableValue]
		public Type typeEnum { get => default; set {} }
		[ObservableValue]
		public TroopAmounts amounts { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum Type
		{
			StationaryTroopsInHomeVillage = 1,
			TroopsInAnotherVillageAsSupport = 2,
			TroopsOnTheWay = 3,
			TroopsCaptured = 4,
			TroopsForwarded = 7,
			TroopsWounded = 8,
			TroopsRevived = 9
		}
	
		// Constructors
		public StandingTroop() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(StandingTroopDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(StandingTroopDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
