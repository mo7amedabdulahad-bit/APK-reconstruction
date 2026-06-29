// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TruceNotification : TLMobile.Generated.GraphQL.Game.NotificationInterface
	{
		// Fields
		[ObservableValue]
		private int _startTime;
		[ObservableValue]
		private int _endTime;
		[ObservableValue]
		private int _starvationEnd;
		[ObservableValue]
		private TruceType _type;
		[ObservableValue]
		private string _notificationDescription;
		[ObservableValue]
		private string _notificationSubtitle;
		[ObservableValue]
		[Tooltip("0 Spring, 1 Summer, 2 Fall, 3 Winter")]
		private int _truceHeaderImageSpriteSeason;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int startTime { get => default; set {} }
		[ObservableValue]
		public int endTime { get => default; set {} }
		[ObservableValue]
		public int starvationEnd { get => default; set {} }
		[ObservableValue]
		public TruceType type { get => default; set {} }
		[ObservableValue]
		public string notificationDescription { get => default; set {} }
		[ObservableValue]
		public string notificationSubtitle { get => default; set {} }
		[ObservableValue]
		[Tooltip("0 Spring, 1 Summer, 2 Fall, 3 Winter")]
		public int truceHeaderImageSpriteSeason { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TruceNotification() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TruceNotificationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TruceNotificationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		[UICallable]
		public void OpenLearnMoreAboutTruce() {}
	}
