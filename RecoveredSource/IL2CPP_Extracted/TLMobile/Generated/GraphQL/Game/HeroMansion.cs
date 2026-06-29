// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroMansion : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<OccupiedOasis> _annexedOases;
		[ObservableValue]
		private GraphQLObservableList<OasisInterface> _withinReachOases;
		private int ownVillageIdFromOwnVillageHeroMansion;
		private static readonly string[] namesInNestedResponseFromOwnVillageHeroMansion;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public HeroMansionSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<OccupiedOasis> annexedOases { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OasisInterface> withinReachOases { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum HeroMansionSource
		{
			FromOwnVillageHeroMansion = 0
		}
	
		// Constructors
		public HeroMansion() {}
		static HeroMansion() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroMansionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroMansionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAnnexedOases(GraphQLObservableList<OccupiedOasis> to, List<OccupiedOasisDTO> from, int query) => default;
		private bool CopyValuesFromDtoListWithinReachOases(GraphQLObservableList<OasisInterface> to, List<JObject> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<HeroMansion> PromiseGetFromOwnVillageHeroMansion(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<HeroMansion> PromiseGetFromOwnVillageHeroMansion(out HeroMansion cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static HeroMansion GetNoFetchFromOwnVillageHeroMansion(int ownVillageId, Query query = Query.All) => default;
		public static HeroMansion GetFromOwnVillageHeroMansion(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static HeroMansion GetFromOwnVillageHeroMansion(int ownVillageId, Query query = Query.All) => default;
		private static HeroMansion FetchFromOwnVillageHeroMansion(HeroMansionSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageHeroMansion(int ownVillageId, object dummy = null) => default;
		private void _annexedOasesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _withinReachOasesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
