// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Notification : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _unreadCount;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Lobby.NotificationInterface> _list;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public NotificationSource Source { get; set; }
		[ObservableValue]
		public int unreadCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Lobby.NotificationInterface> list { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum NotificationSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public Notification() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(NotificationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(NotificationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListList(GraphQLObservableList<TLMobile.Generated.GraphQL.Lobby.NotificationInterface> to, List<JObject> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Notification> PromiseGet(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Notification> PromiseGet(out Notification cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Notification GetNoFetch(Query query = Query.All) => default;
		public static Notification Get(bool forceRefresh, Query query = Query.All) => default;
		public static Notification Get(Query query = Query.All) => default;
		private static Notification Fetch(NotificationSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(object dummy = null) => default;
		private void _listNotify(object sender, PropertyChangedEventArgs args) {}
	}
