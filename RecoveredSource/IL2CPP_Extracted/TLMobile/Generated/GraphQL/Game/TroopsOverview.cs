// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsOverview : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private TroopsPower _incomingAttacksRaidsPower;
		[ObservableValue]
		private TroopsPower _outgoingAttacksRaidsPower;
		[ObservableValue]
		private TroopsPower _returningPower;
		[ObservableValue]
		private TroopsPower _ownTroopsPower;
		[ObservableValue]
		private TroopsPower _foreignTroopsPower;
		[ObservableValue]
		private TroopsPower _standingOutOfTownPower;
		[ObservableValue]
		private TroopsPower _incomingReinforcementsPower;
		[ObservableValue]
		private TroopsPower _outgoingReinforcementsPower;
		[ObservableValue]
		private TroopsPower _forwardedTroopsPower;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public TroopsPower incomingAttacksRaidsPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower outgoingAttacksRaidsPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower returningPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower ownTroopsPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower foreignTroopsPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower standingOutOfTownPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower incomingReinforcementsPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower outgoingReinforcementsPower { get => default; set {} }
		[ObservableValue]
		public TroopsPower forwardedTroopsPower { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OwnVillageIncomingAttacksTroopOverview = 1
		}
	
		// Constructors
		public TroopsOverview() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TroopsOverviewDTO dtoValue) => default;
		private bool EqualToDTOOwnVillageIncomingAttacksTroopOverview(TroopsOverviewDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TroopsOverviewDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOwnVillageIncomingAttacksTroopOverview(TroopsOverviewDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
