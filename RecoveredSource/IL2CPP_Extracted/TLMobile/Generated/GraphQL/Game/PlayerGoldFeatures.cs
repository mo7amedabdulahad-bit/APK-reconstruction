// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerGoldFeatures : GraphQLServerObject, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private SubscriptionFeature _lumberProductionBonus;
		[ObservableValue]
		private SubscriptionFeature _clayProductionBonus;
		[ObservableValue]
		private SubscriptionFeature _ironProductionBonus;
		[ObservableValue]
		private SubscriptionFeature _cropProductionBonus;
		[ObservableValue]
		private SubscriptionFeature _travianPlus;
		[ObservableValue]
		private bool _goldClub;
		[ObservableValue]
		private bool _troopEvasion;
		[ObservableValue]
		private ObservableList<SubscriptionFeature> _features;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public SubscriptionFeature lumberProductionBonus { get => default; set {} }
		[ObservableValue]
		public SubscriptionFeature clayProductionBonus { get => default; set {} }
		[ObservableValue]
		public SubscriptionFeature ironProductionBonus { get => default; set {} }
		[ObservableValue]
		public SubscriptionFeature cropProductionBonus { get => default; set {} }
		[ObservableValue]
		public SubscriptionFeature travianPlus { get => default; set {} }
		[ObservableValue]
		public bool goldClub { get => default; set {} }
		[ObservableValue]
		public bool troopEvasion { get => default; set {} }
		[ObservableValue]
		public ObservableList<SubscriptionFeature> features { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public PlayerGoldFeatures() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PlayerGoldFeaturesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PlayerGoldFeaturesDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _featuresNotify(object sender, PropertyChangedEventArgs args) {}
		public void Update(int query = 0) {}
		public override void AfterServerDataCallback(object data = null) {}
		public SubscriptionFeature GetFeatureForResource(ResourceTypes type) => default;
	}
