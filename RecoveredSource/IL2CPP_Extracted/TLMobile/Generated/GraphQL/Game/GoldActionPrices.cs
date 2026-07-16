// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldActionPrices : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _allianceBonusDonation;
		[ObservableValue]
		private int _accountNameChange;
		[ObservableValue]
		private int _resourceBonusLumber;
		[ObservableValue]
		private int _resourceBonusClay;
		[ObservableValue]
		private int _resourceBonusIron;
		[ObservableValue]
		private int _resourceBonusCrop;
		[ObservableValue]
		private int _goldClub;
		[ObservableValue]
		private int _immediateConstruction;
		[ObservableValue]
		private int _demolishNow;
		[ObservableValue]
		private int _masterBuilder;
		[ObservableValue]
		private int _npcMerchant;
		[ObservableValue]
		private int _plus;
		[ObservableValue]
		private int _rearrangeBuildings;
		[ObservableValue]
		private int _vacationModeAbort;
		[ObservableValue]
		private int _waveBuilder;
		[ObservableValue]
		private ObservableDictionary<ResourceTypes, int> _resourcePricesById;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int allianceBonusDonation { get => default; set {} }
		[ObservableValue]
		public int accountNameChange { get => default; set {} }
		[ObservableValue]
		public int resourceBonusLumber { get => default; set {} }
		[ObservableValue]
		public int resourceBonusClay { get => default; set {} }
		[ObservableValue]
		public int resourceBonusIron { get => default; set {} }
		[ObservableValue]
		public int resourceBonusCrop { get => default; set {} }
		[ObservableValue]
		public int goldClub { get => default; set {} }
		[ObservableValue]
		public int immediateConstruction { get => default; set {} }
		[ObservableValue]
		public int demolishNow { get => default; set {} }
		[ObservableValue]
		public int masterBuilder { get => default; set {} }
		[ObservableValue]
		public int npcMerchant { get => default; set {} }
		[ObservableValue]
		public int plus { get => default; set {} }
		[ObservableValue]
		public int rearrangeBuildings { get => default; set {} }
		[ObservableValue]
		public int vacationModeAbort { get => default; set {} }
		[ObservableValue]
		public int waveBuilder { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<ResourceTypes, int> resourcePricesById { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public GoldActionPrices() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(GoldActionPricesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(GoldActionPricesDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _resourcePricesByIdNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
