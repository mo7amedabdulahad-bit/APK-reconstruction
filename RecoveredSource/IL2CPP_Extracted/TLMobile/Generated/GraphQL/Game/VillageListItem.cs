// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageListItem : GraphQLServerObject
	{
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public string TypeName { get; }
		public VillageListVillage VillageListVillage { get; }
		public VillageListGroup VillageListGroup { get; }
		public override bool isFilled { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum VillageListItemListSource
		{
			FromOwnPlayerVillageList = 0
		}
	
		// Constructors
		public VillageListItem(VillageListVillage value) {}
		public VillageListItem(VillageListGroup value) {}
		public VillageListItem() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override bool EqualToDTO(object dtoValue, int query) => default;
		public static string GetUnionType(JObject jObject) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(JObject newValues, int query = 0, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public static VillageListItem CreateInstance(string typename) => default;
		public static string GetInterfaceType(JObject dtoValue) => default;
		public static GraphQLFetchableList<VillageListItem> CollectionGetNoFetchFromOwnPlayerVillageList(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<VillageListItem>> PromiseCollectionGetFromOwnPlayerVillageList(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<VillageListItem>> PromiseCollectionGetFromOwnPlayerVillageList(out GraphQLFetchableList<VillageListItem> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<VillageListItem> CollectionGetFromOwnPlayerVillageList(Query query = Query.All) => default;
		public static GraphQLFetchableList<VillageListItem> CollectionGetFromOwnPlayerVillageList(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<VillageListItem> CollectionFetchFromOwnPlayerVillageList(VillageListItemListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerVillageList(object dummy = null) => default;
		public static VillageListItem FromVillageListVillage(VillageListVillage value) => default;
		public static VillageListItem FromVillageListGroup(VillageListGroup value) => default;
		public bool Is<T>()
			where T : class => default;
		public bool Is<T>(out ref T value)
			where T : class {
			value = default;
			return default;
		}
		public T As<T>()
			where T : class => default;
		private object GetValue() => default;
		public int GetId() => default;
	}
