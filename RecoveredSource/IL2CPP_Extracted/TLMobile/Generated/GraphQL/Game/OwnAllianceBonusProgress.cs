// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceBonusProgress : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _donated;
		[ObservableValue]
		private int _currentLevel;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceBonusProgressLevel> _levels;
		[ObservableValue]
		private bool _isUpgrading;
		[ObservableValue]
		private int? _upgradeCompleteAt;
		[ObservableValue]
		private int _nextLevel;
		[ObservableValue]
		private int _resourceUntilNext;
		[ObservableValue]
		private float _percentToNext;
		[ObservableValue]
		private OwnAllianceBonusProgressLevel _maxLevelInfo;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int donated { get => default; set {} }
		[ObservableValue]
		public int currentLevel { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceBonusProgressLevel> levels { get => default; set {} }
		[ObservableValue]
		public bool isUpgrading { get => default; set {} }
		[ObservableValue]
		public int? upgradeCompleteAt { get => default; set {} }
		[ObservableValue]
		public int nextLevel { get => default; set {} }
		[ObservableValue]
		public int resourceUntilNext { get => default; set {} }
		[ObservableValue]
		public float percentToNext { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonusProgressLevel maxLevelInfo { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnAllianceBonusProgress() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceBonusProgressDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceBonusProgressDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListLevels(GraphQLObservableList<OwnAllianceBonusProgressLevel> to, List<OwnAllianceBonusProgressLevelDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _levelsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
