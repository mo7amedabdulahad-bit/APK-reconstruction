// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ScoutingReport : ReportInterface
	{
		// Fields
		[ObservableValue]
		private string _authKey;
		[ObservableValue]
		private int? _icon;
		[ObservableValue]
		private ReportParticipant _attacker;
		[ObservableValue]
		private TroopInBattle _attackerTroop;
		[ObservableValue]
		private GraphQLObservableList<ReportInformationItem> _attackerInformation;
		[ObservableValue]
		private ReportParticipant _defender;
		[ObservableValue]
		private TroopInBattle _defenderTroop;
		[ObservableValue]
		private GraphQLObservableList<TroopInBattle> _reinforcements;
		[ObservableValue]
		private ResourcesAmount _scoutedResources;
		[ObservableValue]
		private int? _crannyCapacity;
		[ObservableValue]
		private GraphQLObservableList<RequiredBuilding> _buildings;
		[ObservableValue]
		private bool? _ship;
		[ObservableValue]
		private bool _attackerDidWin;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private int _raidableTotalResources;
		[ObservableValue]
		private int _crannyIconIndex;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string authKey { get => default; set {} }
		[ObservableValue]
		public int? icon { get => default; set {} }
		[ObservableValue]
		public ReportParticipant attacker { get => default; set {} }
		[ObservableValue]
		public TroopInBattle attackerTroop { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ReportInformationItem> attackerInformation { get => default; set {} }
		[ObservableValue]
		public ReportParticipant defender { get => default; set {} }
		[ObservableValue]
		public TroopInBattle defenderTroop { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TroopInBattle> reinforcements { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount scoutedResources { get => default; set {} }
		[ObservableValue]
		public int? crannyCapacity { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RequiredBuilding> buildings { get => default; set {} }
		[ObservableValue]
		public bool? ship { get => default; set {} }
		[ObservableValue]
		public bool attackerDidWin { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public int raidableTotalResources { get => default; set {} }
		[ObservableValue]
		public int crannyIconIndex { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ScoutingReport() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ScoutingReportDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ScoutingReportDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAttackerInformation(GraphQLObservableList<ReportInformationItem> to, List<ReportInformationItemDTO> from, int query) => default;
		private bool CopyValuesFromDtoListReinforcements(GraphQLObservableList<TroopInBattle> to, List<TroopInBattleDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBuildings(GraphQLObservableList<RequiredBuilding> to, List<RequiredBuildingDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _attackerInformationNotify(object sender, PropertyChangedEventArgs args) {}
		private void _reinforcementsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildingsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
