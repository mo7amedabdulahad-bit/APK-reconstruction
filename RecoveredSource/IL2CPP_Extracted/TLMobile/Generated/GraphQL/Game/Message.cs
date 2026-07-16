// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Message : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private RemovablePlayer _senderData;
		[ObservableValue]
		private SenderType _senderType;
		[ObservableValue]
		private RemovablePlayer _recipientData;
		[ObservableValue]
		private MessageState? _state;
		[ObservableValue]
		private string _subject;
		[ObservableValue]
		private MessageType _type;
		[ObservableValue]
		[Obsolete("Is part of metadata now")]
		private MessageTopic? _topic;
		[ObservableValue]
		private int _sentAt;
		[ObservableValue]
		private string _message;
		[ObservableValue]
		private GraphQLObservableList<NameValueContainer> _metadata;
		[ObservableValue]
		private bool _isSpam;
		[ObservableValue]
		private string _spamReason;
		[ObservableValue]
		[Obsolete("Freshdesk specific functionality that is no longer in use")]
		private int? _ticketId;
		private int messageId;
		private static readonly string[] namesInNestedResponse;
		private static readonly Dictionary<MessageTopic, string> TopicsToTranslationMap;
		[ObservableValue]
		private string _messageDecoded;
		[ObservableValue]
		private string _subjectDecoded;
		[ObservableValue]
		private bool _selected;
		[ObservableValue]
		private string _nonPlayerSenderTranslationKey;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MessageSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public RemovablePlayer senderData { get => default; set {} }
		[ObservableValue]
		public SenderType senderType { get => default; set {} }
		[ObservableValue]
		public RemovablePlayer recipientData { get => default; set {} }
		[ObservableValue]
		public MessageState? state { get => default; set {} }
		[ObservableValue]
		public string subject { get => default; set {} }
		[ObservableValue]
		public MessageType type { get => default; set {} }
		[ObservableValue]
		[Obsolete("Is part of metadata now")]
		public MessageTopic? topic { get => default; set {} }
		[ObservableValue]
		public int sentAt { get => default; set {} }
		[ObservableValue]
		public string message { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<NameValueContainer> metadata { get => default; set {} }
		[ObservableValue]
		public bool isSpam { get => default; set {} }
		[ObservableValue]
		public string spamReason { get => default; set {} }
		[ObservableValue]
		[Obsolete("Freshdesk specific functionality that is no longer in use")]
		public int? ticketId { get => default; set {} }
		[ObservableValue]
		public string messageDecoded { get => default; set {} }
		[ObservableValue]
		public string subjectDecoded { get => default; set {} }
		[ObservableValue]
		public bool selected { get => default; set {} }
		[ObservableValue]
		public string nonPlayerSenderTranslationKey { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MessageSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public Message() {}
		static Message() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MessageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MessageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListMetadata(GraphQLObservableList<NameValueContainer> to, List<NameValueContainerDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static Message GetById(object dtoObject) => default;
		public static IPromise<Message> PromiseGet(int messageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Message> PromiseGet(out Message cacheObject, int messageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Message GetNoFetch(int messageId, Query query = Query.All) => default;
		public static Message Get(bool forceRefresh, int messageId, Query query = Query.All) => default;
		public static Message Get(int messageId, Query query = Query.All) => default;
		private static Message Fetch(MessageSource origin, int messageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int messageId, object dummy = null) => default;
		private void _metadataNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
		public static string GetTranslationKey(MessageTopic? topic) => default;
		public static MessageTopic? GetTopic(string translationKey) => default;
	}
