// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Brewery : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private ResourcesAmount _celebrationCost;
		[ObservableValue]
		private OngoingCelebration _ongoingCelebration;
		private int ownVillageIdFromOwnVillageBrewery;
		private static readonly string[] namesInNestedResponseFromOwnVillageBrewery;
		[ObservableValue]
		private int _lastCelebrationTimestamp;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public BrewerySource Source { get; set; }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount celebrationCost { get => default; set {} }
		[ObservableValue]
		public OngoingCelebration ongoingCelebration { get => default; set {} }
		[ObservableValue]
		public int lastCelebrationTimestamp { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum BrewerySource
		{
			FromOwnVillageBrewery = 0
		}
	
		// Constructors
		public Brewery() {}
		static Brewery() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BreweryDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BreweryDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Brewery> PromiseGetFromOwnVillageBrewery(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Brewery> PromiseGetFromOwnVillageBrewery(out Brewery cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Brewery GetNoFetchFromOwnVillageBrewery(int ownVillageId, Query query = Query.All) => default;
		public static Brewery GetFromOwnVillageBrewery(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Brewery GetFromOwnVillageBrewery(int ownVillageId, Query query = Query.All) => default;
		private static Brewery FetchFromOwnVillageBrewery(BrewerySource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageBrewery(int ownVillageId, object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
