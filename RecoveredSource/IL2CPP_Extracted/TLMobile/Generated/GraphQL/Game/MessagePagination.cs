// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessagePagination : GraphQLFetchable, IPaginatedObject<TLMobile.Generated.GraphQL.Game.Message>
	{
		// Fields
		[ObservableValue]
		private int _totalCount;
		[ObservableValue]
		private GraphQLObservableList<MessageEdge> _edges;
		[ObservableValue]
		private PageInfo _pageInfo;
		private int incomingFirstFromOwnPlayerMessagesIncoming;
		private string incomingAfterFromOwnPlayerMessagesIncoming;
		private SortOrder? incomingSortOrderFromOwnPlayerMessagesIncoming;
		private IncomingMessagesFilter incomingFilterFromOwnPlayerMessagesIncoming;
		private int sentFirstFromOwnPlayerMessagesSent;
		private string sentAfterFromOwnPlayerMessagesSent;
		private SortOrder? sentSortOrderFromOwnPlayerMessagesSent;
		private int archiveFirstFromOwnPlayerMessagesArchive;
		private string archiveAfterFromOwnPlayerMessagesArchive;
		private SortOrder? archiveSortOrderFromOwnPlayerMessagesArchive;
		private static readonly string[] namesInNestedResponseFromOwnPlayerMessagesIncoming;
		private static readonly string[] namesInNestedResponseFromOwnPlayerMessagesSent;
		private static readonly string[] namesInNestedResponseFromOwnPlayerMessagesArchive;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MessagePaginationSource Source { get; set; }
		[ObservableValue]
		public int totalCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MessageEdge> edges { get => default; set {} }
		[ObservableValue]
		public PageInfo pageInfo { get => default; set {} }
		public int? TotalCount { get => default; }
		public bool SupportsPlaceholders { get => default; }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MessagePaginationSource
		{
			FromOwnPlayerMessagesIncoming = 0,
			FromOwnPlayerMessagesSent = 1,
			FromOwnPlayerMessagesArchive = 2
		}
	
		// Constructors
		public MessagePagination() {}
		static MessagePagination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MessagePaginationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MessagePaginationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListEdges(GraphQLObservableList<MessageEdge> to, List<MessageEdgeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MessagePagination> PromiseGetFromOwnPlayerMessagesIncoming(int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MessagePagination> PromiseGetFromOwnPlayerMessagesIncoming(out MessagePagination cacheObject, int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MessagePagination GetNoFetchFromOwnPlayerMessagesIncoming(int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, Query query = Query.All) => default;
		public static MessagePagination GetFromOwnPlayerMessagesIncoming(bool forceRefresh, int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, Query query = Query.All) => default;
		public static MessagePagination GetFromOwnPlayerMessagesIncoming(int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, Query query = Query.All) => default;
		private static MessagePagination FetchFromOwnPlayerMessagesIncoming(MessagePaginationSource origin, int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<MessagePagination> PromiseGetFromOwnPlayerMessagesSent(int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MessagePagination> PromiseGetFromOwnPlayerMessagesSent(out MessagePagination cacheObject, int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MessagePagination GetNoFetchFromOwnPlayerMessagesSent(int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, Query query = Query.All) => default;
		public static MessagePagination GetFromOwnPlayerMessagesSent(bool forceRefresh, int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, Query query = Query.All) => default;
		public static MessagePagination GetFromOwnPlayerMessagesSent(int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, Query query = Query.All) => default;
		private static MessagePagination FetchFromOwnPlayerMessagesSent(MessagePaginationSource origin, int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static IPromise<MessagePagination> PromiseGetFromOwnPlayerMessagesArchive(int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MessagePagination> PromiseGetFromOwnPlayerMessagesArchive(out MessagePagination cacheObject, int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MessagePagination GetNoFetchFromOwnPlayerMessagesArchive(int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, Query query = Query.All) => default;
		public static MessagePagination GetFromOwnPlayerMessagesArchive(bool forceRefresh, int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, Query query = Query.All) => default;
		public static MessagePagination GetFromOwnPlayerMessagesArchive(int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, Query query = Query.All) => default;
		private static MessagePagination FetchFromOwnPlayerMessagesArchive(MessagePaginationSource origin, int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerMessagesIncoming(int incomingFirst = 10, string incomingAfter = null, SortOrder? incomingSortOrder = default, IncomingMessagesFilter incomingFilter = null, object dummy = null) => default;
		private static string GetRequestBodyPartFromOwnPlayerMessagesSent(int sentFirst = 10, string sentAfter = null, SortOrder? sentSortOrder = default, object dummy = null) => default;
		private static string GetRequestBodyPartFromOwnPlayerMessagesArchive(int archiveFirst = 10, string archiveAfter = null, SortOrder? archiveSortOrder = default, object dummy = null) => default;
		private void _edgesNotify(object sender, PropertyChangedEventArgs args) {}
		public PageInfo GetPageInfo() => default;
		public void Update() {}
		public List<TLMobile.Generated.GraphQL.Game.Message> CreateListItems() => default;
		public List<TLMobile.Generated.GraphQL.Game.Message> CreatePlaceHolders(int count) => default;
		void IPaginatedObject<Message>.ObserveWhole(System.Action callback, bool instantlyCallWhenFilled, bool deepObserve) {}
		void IPaginatedObject<Message>.ObserveOnce(Action<ServerObject> observer, bool onlyReactOnServerData) {}
	}
