// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ProductionBoost : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private int? _expireAt;
		[ObservableValue]
		private string _type;
		[ObservableValue]
		private int? _bonus;
		[ObservableValue]
		private bool _videoFeatureAvailable;
		[ObservableValue]
		private int _durationVideoFeature;
		[ObservableValue]
		private BoostType _boostType;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public int? expireAt { get => default; set {} }
		[ObservableValue]
		public string type { get => default; set {} }
		[ObservableValue]
		public int? bonus { get => default; set {} }
		[ObservableValue]
		public bool videoFeatureAvailable { get => default; set {} }
		[ObservableValue]
		public int durationVideoFeature { get => default; set {} }
		[ObservableValue]
		public BoostType boostType { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum BoostType
		{
			None = 0,
			Quest = 1,
			PremiumFeature = 2,
			VideoFeature = 3,
			Compensation = 4
		}
	
		// Constructors
		public ProductionBoost() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ProductionBoostDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ProductionBoostDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		public int GetRequiredUpdateTime() => default;
	}
