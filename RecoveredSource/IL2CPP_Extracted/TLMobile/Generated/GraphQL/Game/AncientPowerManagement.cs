// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AncientPowerManagement : GraphQLFetchable, IBackendUpdateable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private bool _isFreeUsed;
		[ObservableValue]
		private int _nextFreeActivationAt;
		[ObservableValue]
		private GraphQLObservableList<SecuredAncientPower> _securedAncientPowers;
		private static readonly string[] namesInNestedResponseFromOwnPlayerAncientPowerManagement;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AncientPowerManagementSource Source { get; set; }
		[ObservableValue]
		public bool isFreeUsed { get => default; set {} }
		[ObservableValue]
		public int nextFreeActivationAt { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<SecuredAncientPower> securedAncientPowers { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AncientPowerManagementSource
		{
			FromOwnPlayerAncientPowerManagement = 0
		}
	
		// Constructors
		public AncientPowerManagement() {}
		static AncientPowerManagement() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AncientPowerManagementDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AncientPowerManagementDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListSecuredAncientPowers(GraphQLObservableList<SecuredAncientPower> to, List<SecuredAncientPowerDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AncientPowerManagement> PromiseGetFromOwnPlayerAncientPowerManagement(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AncientPowerManagement> PromiseGetFromOwnPlayerAncientPowerManagement(out AncientPowerManagement cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AncientPowerManagement GetNoFetchFromOwnPlayerAncientPowerManagement(Query query = Query.All) => default;
		public static AncientPowerManagement GetFromOwnPlayerAncientPowerManagement(bool forceRefresh, Query query = Query.All) => default;
		public static AncientPowerManagement GetFromOwnPlayerAncientPowerManagement(Query query = Query.All) => default;
		private static AncientPowerManagement FetchFromOwnPlayerAncientPowerManagement(AncientPowerManagementSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerAncientPowerManagement(object dummy = null) => default;
		private void _securedAncientPowersNotify(object sender, PropertyChangedEventArgs args) {}
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
