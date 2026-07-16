// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceAmount : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private ResourceType _resourceType;
		[ObservableValue]
		private float _amount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public ResourceType resourceType { get => default; set {} }
		[ObservableValue]
		public float amount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ResourceAmountListSource
		{
			FromOwnPlayerHeroProduction = 0,
			FromOwnPlayerHeroProductionTypes = 1
		}
	
		// Constructors
		public ResourceAmount() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ResourceAmountDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ResourceAmountDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<ResourceAmount> CollectionGetNoFetchFromOwnPlayerHeroProduction(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<ResourceAmount>> PromiseCollectionGetFromOwnPlayerHeroProduction(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<ResourceAmount>> PromiseCollectionGetFromOwnPlayerHeroProduction(out GraphQLFetchableList<ResourceAmount> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<ResourceAmount> CollectionGetFromOwnPlayerHeroProduction(Query query = Query.All) => default;
		public static GraphQLFetchableList<ResourceAmount> CollectionGetFromOwnPlayerHeroProduction(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<ResourceAmount> CollectionFetchFromOwnPlayerHeroProduction(ResourceAmountListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerHeroProduction(object dummy = null) => default;
		public static GraphQLFetchableList<ResourceAmount> CollectionGetNoFetchFromOwnPlayerHeroProductionTypes(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<ResourceAmount>> PromiseCollectionGetFromOwnPlayerHeroProductionTypes(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<ResourceAmount>> PromiseCollectionGetFromOwnPlayerHeroProductionTypes(out GraphQLFetchableList<ResourceAmount> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<ResourceAmount> CollectionGetFromOwnPlayerHeroProductionTypes(Query query = Query.All) => default;
		public static GraphQLFetchableList<ResourceAmount> CollectionGetFromOwnPlayerHeroProductionTypes(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<ResourceAmount> CollectionFetchFromOwnPlayerHeroProductionTypes(ResourceAmountListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerHeroProductionTypes(object dummy = null) => default;
	}
