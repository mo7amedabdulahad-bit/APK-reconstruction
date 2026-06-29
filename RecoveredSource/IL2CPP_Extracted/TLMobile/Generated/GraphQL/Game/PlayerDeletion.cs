// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerDeletion : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _timestamp;
		[ObservableValue]
		private bool _isPlayerCancellable;
		[ObservableValue]
		private bool _imminent;
		[ObservableValue]
		private int _reason;
		[ObservableValue]
		private ReasonType _reasonType;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int timestamp { get => default; set {} }
		[ObservableValue]
		public bool isPlayerCancellable { get => default; set {} }
		[ObservableValue]
		public bool imminent { get => default; set {} }
		[ObservableValue]
		public int reason { get => default; set {} }
		[ObservableValue]
		public ReasonType reasonType { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ReasonType
		{
			None = 0,
			General = 1,
			InactiveAuto = 2,
			Self = 3,
			ACP = 4,
			InactiveManual = 5,
			WorldEnd = 6,
			BotDetection = 7,
			Unknown = 8,
			GDPR = 9
		}
	
		// Constructors
		public PlayerDeletion() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PlayerDeletionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PlayerDeletionDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
