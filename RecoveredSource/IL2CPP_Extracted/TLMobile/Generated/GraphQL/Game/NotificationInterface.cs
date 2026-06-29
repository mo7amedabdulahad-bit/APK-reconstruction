// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NotificationInterface : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		protected int _id;
		protected string thisTypeName;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private bool _backendFinished;
		[ObservableValue]
		private bool _toDestroy;
		[ObservableValue]
		private string _notificationTitle;
		[ObservableValue]
		private NotificationInterfaceType _notificationType;
		[ObservableValue]
		private int? _time;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeIdEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public NotificationInterfaceSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public bool backendFinished { get => default; set {} }
		[ObservableValue]
		public bool toDestroy { get => default; set {} }
		[ObservableValue]
		public string notificationTitle { get => default; set {} }
		[ObservableValue]
		public NotificationInterfaceType notificationType { get => default; set {} }
		[ObservableValue]
		public int? time { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeIdEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum NotificationInterfaceSource
		{
			RootLevel = 0
		}
	
		public enum NotificationInterfaceListSource
		{
			RootLevelByNotifications = 0
		}
	
		// Constructors
		public NotificationInterface() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TLMobile.GraphQL.DTO.Game.NotificationInterfaceDTO dtoValue) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TLMobile.GraphQL.DTO.Game.NotificationInterfaceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public static string GetInterfaceType(JObject dtoData) => default;
		public static NotificationInterface CreateInstance(string typename) => default;
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent) => default;
		public bool CopyValuesFromDTO(JObject newValues, Query query = Query.All, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(JObject dtoValue, Query query = Query.All) => default;
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<NotificationInterface> PromiseGet(Query query = Query.All, bool forceFetch = true) => default;
		public static NotificationInterface GetNoFetch(string typeName, Query query = Query.All) => default;
		private static NotificationInterface Fetch(string typeName, NotificationInterfaceSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(object dummy = null) => default;
		public static GraphQLFetchableList<NotificationInterface> CollectionGetNoFetchByNotifications(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<NotificationInterface>> PromiseCollectionGetByNotifications(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<NotificationInterface>> PromiseCollectionGetByNotifications(out GraphQLFetchableList<NotificationInterface> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<NotificationInterface> CollectionGetByNotifications(Query query = Query.All) => default;
		public static GraphQLFetchableList<NotificationInterface> CollectionGetByNotifications(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<NotificationInterface> CollectionFetchByNotifications(NotificationInterfaceListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByNotifications(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
	}
