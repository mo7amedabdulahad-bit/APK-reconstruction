// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SubscriptionFeature : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private bool _isAutoProlonged;
		[ObservableValue]
		private int _expiresAt;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private int _daysRemaining;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public bool isAutoProlonged { get => default; set {} }
		[ObservableValue]
		public int expiresAt { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public int daysRemaining { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public SubscriptionFeature() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SubscriptionFeatureDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SubscriptionFeatureDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
