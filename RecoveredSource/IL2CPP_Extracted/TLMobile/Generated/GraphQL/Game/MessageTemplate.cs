// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageTemplate : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _subject;
		[ObservableValue]
		private string _message;
		[ObservableValue]
		private GraphQLObservableList<MessageRecipient> _recipients;
		[ObservableValue]
		private MessageTopic? _topic;
		private int messageTemplateId;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private string _subjectDecoded;
		[ObservableValue]
		private string _messageDecoded;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MessageTemplateSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string subject { get => default; set {} }
		[ObservableValue]
		public string message { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MessageRecipient> recipients { get => default; set {} }
		[ObservableValue]
		public MessageTopic? topic { get => default; set {} }
		[ObservableValue]
		public string subjectDecoded { get => default; set {} }
		[ObservableValue]
		public string messageDecoded { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MessageTemplateSource
		{
			RootLevel = 0
		}
	
		public enum MessageTemplateListSource
		{
			FromOwnPlayerMessageTemplates = 0
		}
	
		// Constructors
		public MessageTemplate() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MessageTemplateDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MessageTemplateDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListRecipients(GraphQLObservableList<MessageRecipient> to, List<MessageRecipientDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MessageTemplate> PromiseGet(int messageTemplateId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MessageTemplate> PromiseGet(out MessageTemplate cacheObject, int messageTemplateId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MessageTemplate GetNoFetch(int messageTemplateId, Query query = Query.All) => default;
		public static MessageTemplate Get(bool forceRefresh, int messageTemplateId, Query query = Query.All) => default;
		public static MessageTemplate Get(int messageTemplateId, Query query = Query.All) => default;
		private static MessageTemplate Fetch(MessageTemplateSource origin, int messageTemplateId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int messageTemplateId, object dummy = null) => default;
		public static GraphQLFetchableList<MessageTemplate> CollectionGetNoFetchFromOwnPlayerMessageTemplates(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<MessageTemplate>> PromiseCollectionGetFromOwnPlayerMessageTemplates(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<MessageTemplate>> PromiseCollectionGetFromOwnPlayerMessageTemplates(out GraphQLFetchableList<MessageTemplate> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<MessageTemplate> CollectionGetFromOwnPlayerMessageTemplates(Query query = Query.All) => default;
		public static GraphQLFetchableList<MessageTemplate> CollectionGetFromOwnPlayerMessageTemplates(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<MessageTemplate> CollectionFetchFromOwnPlayerMessageTemplates(MessageTemplateListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerMessageTemplates(object dummy = null) => default;
		private void _recipientsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
