// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsInVillage : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private UnitsAmount _units;
		[ObservableValue]
		private int _attackPower;
		[ObservableValue]
		private int _defencePower;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeIdEnum;
		[ObservableValue]
		private TroopAmounts _amounts;
		[ObservableValue]
		private TroopAmounts _amountsWithHero;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public UnitsAmount units { get => default; set {} }
		[ObservableValue]
		public int attackPower { get => default; set {} }
		[ObservableValue]
		public int defencePower { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeIdEnum { get => default; set {} }
		[ObservableValue]
		public TroopAmounts amounts { get => default; set {} }
		[ObservableValue]
		public TroopAmounts amountsWithHero { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TroopsInVillage() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TroopsInVillageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TroopsInVillageDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
