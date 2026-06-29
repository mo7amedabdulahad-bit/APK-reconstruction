// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FavouriteTab : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private string _key;
		private string favouriteTabName;
		private string favouriteTabType;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public FavouriteTabSource Source { get; set; }
		[ObservableValue]
		public string key { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum FavouriteTabSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public FavouriteTab() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(FavouriteTabDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(FavouriteTabDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<FavouriteTab> PromiseGet(string favouriteTabName = null, string favouriteTabType = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<FavouriteTab> PromiseGet(out FavouriteTab cacheObject, string favouriteTabName = null, string favouriteTabType = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static FavouriteTab GetNoFetch(string favouriteTabName = null, string favouriteTabType = null, Query query = Query.All) => default;
		public static FavouriteTab Get(bool forceRefresh, string favouriteTabName = null, string favouriteTabType = null, Query query = Query.All) => default;
		public static FavouriteTab Get(string favouriteTabName = null, string favouriteTabType = null, Query query = Query.All) => default;
		private static FavouriteTab Fetch(FavouriteTabSource origin, string favouriteTabName = null, string favouriteTabType = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(string favouriteTabName = null, string favouriteTabType = null, object dummy = null) => default;
	}
