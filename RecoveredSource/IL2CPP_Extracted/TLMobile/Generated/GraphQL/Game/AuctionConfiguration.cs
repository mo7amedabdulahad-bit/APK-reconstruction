// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionConfiguration : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _maxAuctionForSel;
		[ObservableValue]
		private int _rateGoldToSilver;
		[ObservableValue]
		private int _rateSilverToGold;
		[ObservableValue]
		private int _firstHorsePrice;
		[ObservableValue]
		private int _minAdventuresRequired;
		[ObservableValue]
		private int _maxDuration;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int maxAuctionForSel { get => default; set {} }
		[ObservableValue]
		public int rateGoldToSilver { get => default; set {} }
		[ObservableValue]
		public int rateSilverToGold { get => default; set {} }
		[ObservableValue]
		public int firstHorsePrice { get => default; set {} }
		[ObservableValue]
		public int minAdventuresRequired { get => default; set {} }
		[ObservableValue]
		public int maxDuration { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AuctionConfiguration() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AuctionConfigurationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AuctionConfigurationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
