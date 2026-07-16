// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReinforcementReport : ReportInterface
	{
		// Fields
		[ObservableValue]
		private int? _icon;
		[ObservableValue]
		private ReportParticipant _sender;
		[ObservableValue]
		private ReportParticipant _defender;
		[ObservableValue]
		private TroopInBattle _troop;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private int _consumption;
		[ObservableValue]
		private bool _failed;
		[ObservableValue]
		private int? _failureReason;
		[ObservableValue]
		private bool? _ship;
		[ObservableValue]
		private string _reinforcementShipIcon;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? icon { get => default; set {} }
		[ObservableValue]
		public ReportParticipant sender { get => default; set {} }
		[ObservableValue]
		public ReportParticipant defender { get => default; set {} }
		[ObservableValue]
		public TroopInBattle troop { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public int consumption { get => default; set {} }
		[ObservableValue]
		public bool failed { get => default; set {} }
		[ObservableValue]
		public int? failureReason { get => default; set {} }
		[ObservableValue]
		public bool? ship { get => default; set {} }
		[ObservableValue]
		public string reinforcementShipIcon { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ReinforcementReport() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ReinforcementReportDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ReinforcementReportDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
