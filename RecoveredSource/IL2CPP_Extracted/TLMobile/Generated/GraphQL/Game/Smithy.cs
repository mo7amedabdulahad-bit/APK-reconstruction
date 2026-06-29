// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Smithy : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<UnitInDevelopment> _unitsUnderResearch;
		private int ownVillageIdFromOwnVillageSmithy;
		private static readonly string[] namesInNestedResponseFromOwnVillageSmithy;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public SmithySource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<UnitInDevelopment> unitsUnderResearch { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum SmithySource
		{
			FromOwnVillageSmithy = 0
		}
	
		// Constructors
		public Smithy() {}
		static Smithy() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SmithyDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SmithyDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListUnitsUnderResearch(GraphQLObservableList<UnitInDevelopment> to, List<UnitInDevelopmentDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Smithy> PromiseGetFromOwnVillageSmithy(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Smithy> PromiseGetFromOwnVillageSmithy(out Smithy cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Smithy GetNoFetchFromOwnVillageSmithy(int ownVillageId, Query query = Query.All) => default;
		public static Smithy GetFromOwnVillageSmithy(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Smithy GetFromOwnVillageSmithy(int ownVillageId, Query query = Query.All) => default;
		private static Smithy FetchFromOwnVillageSmithy(SmithySource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageSmithy(int ownVillageId, object dummy = null) => default;
		private void _unitsUnderResearchNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
