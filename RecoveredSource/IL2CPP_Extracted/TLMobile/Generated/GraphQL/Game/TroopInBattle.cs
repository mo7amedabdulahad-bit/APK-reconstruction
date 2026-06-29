// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopInBattle : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private UnitsAmount _units;
		[ObservableValue]
		private UnitsAmount _casualties;
		[ObservableValue]
		private UnitsAmount _trapped;
		[ObservableValue]
		private UnitsAmount _wounded;
		[ObservableValue]
		private TroopAmountsInBattle _amounts;
		[ObservableValue]
		private bool _hasRemainingTroops;
		[ObservableValue]
		private float _remainingPercentage;
		[ObservableValue]
		private ObservableList<ReportInformationItem> _combatSimulatorResultReinforcementsInformation;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public UnitsAmount units { get => default; set {} }
		[ObservableValue]
		public UnitsAmount casualties { get => default; set {} }
		[ObservableValue]
		public UnitsAmount trapped { get => default; set {} }
		[ObservableValue]
		public UnitsAmount wounded { get => default; set {} }
		[ObservableValue]
		public TroopAmountsInBattle amounts { get => default; set {} }
		[ObservableValue]
		public bool hasRemainingTroops { get => default; set {} }
		[ObservableValue]
		public float remainingPercentage { get => default; set {} }
		[ObservableValue]
		public ObservableList<ReportInformationItem> combatSimulatorResultReinforcementsInformation { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TroopInBattle() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TroopInBattleDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TroopInBattleDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _combatSimulatorResultReinforcementsInformationNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		private void UpdateRemainingTroops() {}
	}
