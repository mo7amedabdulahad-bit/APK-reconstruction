// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Sitter : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _sittingId;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private AccessRights _sitterPermissions;
		[ObservableValue]
		private bool? _loggedIn;
		[ObservableValue]
		private bool? _loginIsPossible;
		[ObservableValue]
		private string _loginImpossibleError;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int sittingId { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public AccessRights sitterPermissions { get => default; set {} }
		[ObservableValue]
		public bool? loggedIn { get => default; set {} }
		[ObservableValue]
		public bool? loginIsPossible { get => default; set {} }
		[ObservableValue]
		public string loginImpossibleError { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum SitterListSource
		{
			FromAccountSitters = 0,
			FromAccountSittings = 1,
			FromOwnPlayerSitters = 2,
			FromOwnPlayerSittings = 3
		}
	
		// Constructors
		public Sitter() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SitterDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SitterDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<Sitter> CollectionGetNoFetchFromAccountSitters(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromAccountSitters(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromAccountSitters(out GraphQLFetchableList<Sitter> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Sitter> CollectionGetFromAccountSitters(Query query = Query.All) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetFromAccountSitters(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Sitter> CollectionFetchFromAccountSitters(SitterListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromAccountSitters(object dummy = null) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetNoFetchFromAccountSittings(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromAccountSittings(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromAccountSittings(out GraphQLFetchableList<Sitter> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Sitter> CollectionGetFromAccountSittings(Query query = Query.All) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetFromAccountSittings(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Sitter> CollectionFetchFromAccountSittings(SitterListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromAccountSittings(object dummy = null) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetNoFetchFromOwnPlayerSitters(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromOwnPlayerSitters(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromOwnPlayerSitters(out GraphQLFetchableList<Sitter> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Sitter> CollectionGetFromOwnPlayerSitters(Query query = Query.All) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetFromOwnPlayerSitters(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Sitter> CollectionFetchFromOwnPlayerSitters(SitterListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerSitters(object dummy = null) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetNoFetchFromOwnPlayerSittings(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromOwnPlayerSittings(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Sitter>> PromiseCollectionGetFromOwnPlayerSittings(out GraphQLFetchableList<Sitter> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Sitter> CollectionGetFromOwnPlayerSittings(Query query = Query.All) => default;
		public static GraphQLFetchableList<Sitter> CollectionGetFromOwnPlayerSittings(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Sitter> CollectionFetchFromOwnPlayerSittings(SitterListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerSittings(object dummy = null) => default;
	}
