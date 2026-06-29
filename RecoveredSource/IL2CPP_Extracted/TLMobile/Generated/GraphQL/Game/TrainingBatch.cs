// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TrainingBatch : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _eventId;
		[ObservableValue]
		private Building _building;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Unit _unit;
		[ObservableValue]
		private int? _unitsLeft;
		[ObservableValue]
		private int? _timePerUnit;
		[ObservableValue]
		private int? _nextUnitReadyAt;
		[ObservableValue]
		private int? _lastUnitReadyAt;
		[ObservableValue]
		private int? _cancellableUntil;
		private const long OneDaySeconds = 86400;
		[ObservableValue]
		private TroopInfo _troopInfo;
		[ObservableValue]
		private bool _isRepairing;
		[ObservableValue]
		private bool _displayLastUnitDate;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int eventId { get => default; set {} }
		[ObservableValue]
		public Building building { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Unit unit { get => default; set {} }
		[ObservableValue]
		public int? unitsLeft { get => default; set {} }
		[ObservableValue]
		public int? timePerUnit { get => default; set {} }
		[ObservableValue]
		public int? nextUnitReadyAt { get => default; set {} }
		[ObservableValue]
		public int? lastUnitReadyAt { get => default; set {} }
		[ObservableValue]
		public int? cancellableUntil { get => default; set {} }
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
		[ObservableValue]
		public bool isRepairing { get => default; set {} }
		[ObservableValue]
		public bool displayLastUnitDate { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TrainingBatch() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TrainingBatchDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TrainingBatchDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
		public void UpdateDisplayLastUnitDate() {}
	}
