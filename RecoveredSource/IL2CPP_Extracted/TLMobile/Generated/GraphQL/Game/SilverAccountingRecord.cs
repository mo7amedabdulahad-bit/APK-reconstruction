// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SilverAccountingRecord : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int? _time;
		[ObservableValue]
		private SilverAccountingReason? _reason;
		[ObservableValue]
		private int _silverChange;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Item _item;
		[ObservableValue]
		private int? _itemAmount;
		[ObservableValue]
		private int _runningBalance;
		[ObservableValue]
		private string _reasonTranslationKey;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? time { get => default; set {} }
		[ObservableValue]
		public SilverAccountingReason? reason { get => default; set {} }
		[ObservableValue]
		public int silverChange { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Item item { get => default; set {} }
		[ObservableValue]
		public int? itemAmount { get => default; set {} }
		[ObservableValue]
		public int runningBalance { get => default; set {} }
		[ObservableValue]
		public string reasonTranslationKey { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public SilverAccountingRecord() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SilverAccountingRecordDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SilverAccountingRecordDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
