// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ProductionBoostInfoboxMessage : InfoboxMessageInterface
	{
		// Fields
		[ObservableValue]
		private ProductionBoostInfoboxMessageType _productionBoostMessageType;
		[ObservableValue]
		private int _expiresAt;
		[ObservableValue]
		private ResourceType _resourceType;
		[ObservableValue]
		private SimplifiedType _simplifiedType;
		[ObservableValue]
		private string _translationKey;
		[ObservableValue]
		private ResourceTypes _resourceTypeEnum;
		[ObservableValue]
		private int _percentageValue;
		[ObservableValue]
		private GoldAdvantage _goldAdvantage;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public ProductionBoostInfoboxMessageType productionBoostMessageType { get => default; set {} }
		[ObservableValue]
		public int expiresAt { get => default; set {} }
		[ObservableValue]
		public ResourceType resourceType { get => default; set {} }
		[ObservableValue]
		public SimplifiedType simplifiedType { get => default; set {} }
		[ObservableValue]
		public string translationKey { get => default; set {} }
		[ObservableValue]
		public ResourceTypes resourceTypeEnum { get => default; set {} }
		[ObservableValue]
		public int percentageValue { get => default; set {} }
		[ObservableValue]
		public GoldAdvantage goldAdvantage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum SimplifiedType
		{
			Expired = 0,
			AutoProlongationOn = 1,
			AutoProlongationOff = 2,
			VideoExpiring = 3
		}
	
		// Constructors
		public ProductionBoostInfoboxMessage() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ProductionBoostInfoboxMessageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ProductionBoostInfoboxMessageDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object serverObject = null) {}
	}
