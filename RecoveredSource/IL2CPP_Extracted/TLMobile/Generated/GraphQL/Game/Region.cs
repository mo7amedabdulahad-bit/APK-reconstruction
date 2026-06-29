// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Region : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private int? _artefactSpawnTime;
		[ObservableValue]
		private PlaceBonusInterface _placeBonus;
		[ObservableValue]
		private int? _vpPerDay;
		[ObservableValue]
		private bool? _canBeSettled;
		[ObservableValue]
		private RegionStatus? _status;
		[ObservableValue]
		private bool? _isLocked;
		[ObservableValue]
		private int? _topAlliancesPopulation;
		[ObservableValue]
		private int? _populationNeeded;
		[ObservableValue]
		private int? _topAlliancesVillages;
		[ObservableValue]
		private GraphQLObservableList<TerritorialControl> _territorialControl;
		[ObservableValue]
		private GraphQLObservableList<Region> _neighboringRegions;
		[ObservableValue]
		private MapCell _regionCenter;
		private int regionId;
		private static readonly string[] namesInNestedResponse;
		private int ownVillageIdListFromOwnVillageNearbyRegions;
		private string findRegionsByNameNameListByFindRegionsByName;
		private ArtefactSize regionsTypeListByRegions;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public RegionSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int? artefactSpawnTime { get => default; set {} }
		[ObservableValue]
		public PlaceBonusInterface placeBonus { get => default; set {} }
		[ObservableValue]
		public int? vpPerDay { get => default; set {} }
		[ObservableValue]
		public bool? canBeSettled { get => default; set {} }
		[ObservableValue]
		public RegionStatus? status { get => default; set {} }
		[ObservableValue]
		public bool? isLocked { get => default; set {} }
		[ObservableValue]
		public int? topAlliancesPopulation { get => default; set {} }
		[ObservableValue]
		public int? populationNeeded { get => default; set {} }
		[ObservableValue]
		public int? topAlliancesVillages { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TerritorialControl> territorialControl { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Region> neighboringRegions { get => default; set {} }
		[ObservableValue]
		public MapCell regionCenter { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyIdAndName = 1,
			OnlyForAncientPower = 2,
			MapCellInfo = 3,
			SearchResults = 4
		}
	
		public enum RegionSource
		{
			RootLevel = 0
		}
	
		public enum RegionListSource
		{
			FromOwnVillageNearbyRegions = 0,
			RootLevelByFindRegionsByName = 1,
			RootLevelByRegions = 2
		}
	
		// Constructors
		public Region() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(RegionDTO dtoValue) => default;
		private bool EqualToDTOOnlyIdAndName(RegionDTO dtoValue) => default;
		private bool EqualToDTOOnlyForAncientPower(RegionDTO dtoValue) => default;
		private bool EqualToDTOMapCellInfo(RegionDTO dtoValue) => default;
		private bool EqualToDTOSearchResults(RegionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(RegionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyIdAndName(RegionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyForAncientPower(RegionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOMapCellInfo(RegionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOSearchResults(RegionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTerritorialControl(GraphQLObservableList<TerritorialControl> to, List<TerritorialControlDTO> from, int query) => default;
		private bool CopyValuesFromDtoListNeighboringRegions(GraphQLObservableList<Region> to, List<RegionDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Region> PromiseGet(int regionId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Region> PromiseGet(out Region cacheObject, int regionId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Region GetNoFetch(int regionId, Query query = Query.All) => default;
		public static Region Get(bool forceRefresh, int regionId, Query query = Query.All) => default;
		public static Region Get(int regionId, Query query = Query.All) => default;
		private static Region Fetch(RegionSource origin, int regionId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int regionId, object dummy = null) => default;
		public static GraphQLFetchableList<Region> CollectionGetNoFetchFromOwnVillageNearbyRegions(int ownVillageId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Region>> PromiseCollectionGetFromOwnVillageNearbyRegions(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Region>> PromiseCollectionGetFromOwnVillageNearbyRegions(out GraphQLFetchableList<Region> cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Region> CollectionGetFromOwnVillageNearbyRegions(int ownVillageId, Query query = Query.All) => default;
		public static GraphQLFetchableList<Region> CollectionGetFromOwnVillageNearbyRegions(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		private static GraphQLFetchableList<Region> CollectionFetchFromOwnVillageNearbyRegions(RegionListSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnVillageNearbyRegions(int ownVillageId, object dummy = null) => default;
		public static GraphQLFetchableList<Region> CollectionGetNoFetchByFindRegionsByName(string findRegionsByNameName, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Region>> PromiseCollectionGetByFindRegionsByName(string findRegionsByNameName, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Region>> PromiseCollectionGetByFindRegionsByName(out GraphQLFetchableList<Region> cacheObject, string findRegionsByNameName, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Region> CollectionGetByFindRegionsByName(string findRegionsByNameName, Query query = Query.All) => default;
		public static GraphQLFetchableList<Region> CollectionGetByFindRegionsByName(bool forceRefresh, string findRegionsByNameName, Query query = Query.All) => default;
		private static GraphQLFetchableList<Region> CollectionFetchByFindRegionsByName(RegionListSource origin, string findRegionsByNameName, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByFindRegionsByName(string findRegionsByNameName, object dummy = null) => default;
		public static GraphQLFetchableList<Region> CollectionGetNoFetchByRegions(ArtefactSize regionsType, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Region>> PromiseCollectionGetByRegions(ArtefactSize regionsType, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Region>> PromiseCollectionGetByRegions(out GraphQLFetchableList<Region> cacheObject, ArtefactSize regionsType, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Region> CollectionGetByRegions(ArtefactSize regionsType, Query query = Query.All) => default;
		public static GraphQLFetchableList<Region> CollectionGetByRegions(bool forceRefresh, ArtefactSize regionsType, Query query = Query.All) => default;
		private static GraphQLFetchableList<Region> CollectionFetchByRegions(RegionListSource origin, ArtefactSize regionsType, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByRegions(ArtefactSize regionsType, object dummy = null) => default;
		private void _territorialControlNotify(object sender, PropertyChangedEventArgs args) {}
		private void _neighboringRegionsNotify(object sender, PropertyChangedEventArgs args) {}
	}
