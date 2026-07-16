// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class KnowledgeBaseArticleURLs : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private string _url;
		private List<string> knowledgeBaseArticlesIdsListFromExternalURLsKnowledgeBaseArticles;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public string url { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum KnowledgeBaseArticleURLsListSource
		{
			FromExternalURLsKnowledgeBaseArticles = 0
		}
	
		// Constructors
		public KnowledgeBaseArticleURLs() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(KnowledgeBaseArticleURLsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(KnowledgeBaseArticleURLsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<KnowledgeBaseArticleURLs> CollectionGetNoFetchFromExternalURLsKnowledgeBaseArticles(List<string> knowledgeBaseArticlesIds, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<KnowledgeBaseArticleURLs>> PromiseCollectionGetFromExternalURLsKnowledgeBaseArticles(List<string> knowledgeBaseArticlesIds, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<KnowledgeBaseArticleURLs>> PromiseCollectionGetFromExternalURLsKnowledgeBaseArticles(out GraphQLFetchableList<KnowledgeBaseArticleURLs> cacheObject, List<string> knowledgeBaseArticlesIds, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<KnowledgeBaseArticleURLs> CollectionGetFromExternalURLsKnowledgeBaseArticles(List<string> knowledgeBaseArticlesIds, Query query = Query.All) => default;
		public static GraphQLFetchableList<KnowledgeBaseArticleURLs> CollectionGetFromExternalURLsKnowledgeBaseArticles(bool forceRefresh, List<string> knowledgeBaseArticlesIds, Query query = Query.All) => default;
		private static GraphQLFetchableList<KnowledgeBaseArticleURLs> CollectionFetchFromExternalURLsKnowledgeBaseArticles(KnowledgeBaseArticleURLsListSource origin, List<string> knowledgeBaseArticlesIds, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetArgumentValue_knowledgeBaseArticlesIds(List<string> ids) => default;
		private static string GetRequestBodyPartFromExternalURLsKnowledgeBaseArticles(List<string> knowledgeBaseArticlesIds, object dummy = null) => default;
	}
