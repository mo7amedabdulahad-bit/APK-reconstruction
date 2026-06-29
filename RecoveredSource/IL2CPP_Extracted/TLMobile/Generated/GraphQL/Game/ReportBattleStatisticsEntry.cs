// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportBattleStatisticsEntry : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _strengthInt32;
		[ObservableValue]
		private int _supplyBeforeInt32;
		[ObservableValue]
		private int _supplyLostInt32;
		[ObservableValue]
		private int _resourcesLostInt32;
		[ObservableValue]
		private long _strength;
		[ObservableValue]
		private long _supplyBefore;
		[ObservableValue]
		private long _supplyLost;
		[ObservableValue]
		private long _resourcesLost;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int strengthInt32 { get => default; set {} }
		[ObservableValue]
		public int supplyBeforeInt32 { get => default; set {} }
		[ObservableValue]
		public int supplyLostInt32 { get => default; set {} }
		[ObservableValue]
		public int resourcesLostInt32 { get => default; set {} }
		[ObservableValue]
		public long strength { get => default; set {} }
		[ObservableValue]
		public long supplyBefore { get => default; set {} }
		[ObservableValue]
		public long supplyLost { get => default; set {} }
		[ObservableValue]
		public long resourcesLost { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ReportBattleStatisticsEntry() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ReportBattleStatisticsEntryDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ReportBattleStatisticsEntryDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
