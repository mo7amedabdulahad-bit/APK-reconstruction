// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AncientPower : PlaceBonusInterface
	{
		// Fields
		[ObservableValue]
		private Alliance _owner;
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private AncientPowerStatus? _status;
		[ObservableValue]
		private AncientPowerStatusMessage _statusMessage;
		[ObservableValue]
		private bool _increasedVpProduction;
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private int? _activationCost;
		[ObservableValue]
		private bool? _enoughPopulation;
		[ObservableValue]
		private bool? _autoReactivate;
		[ObservableValue]
		private int? _expireAt;
		[CanBeNull]
		[ObservableValue]
		private OwnVillage _village;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public Alliance owner { get => default; set {} }
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public AncientPowerStatus? status { get => default; set {} }
		[ObservableValue]
		public AncientPowerStatusMessage statusMessage { get => default; set {} }
		[ObservableValue]
		public bool increasedVpProduction { get => default; set {} }
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public int? activationCost { get => default; set {} }
		[ObservableValue]
		public bool? enoughPopulation { get => default; set {} }
		[ObservableValue]
		public bool? autoReactivate { get => default; set {} }
		[ObservableValue]
		public int? expireAt { get => default; set {} }
		[CanBeNull]
		[ObservableValue]
		public OwnVillage village { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyIdAndName = 1
		}
	
		// Constructors
		public AncientPower() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AncientPowerDTO dtoValue) => default;
		private bool EqualToDTOOnlyIdAndName(AncientPowerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AncientPowerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyIdAndName(AncientPowerDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
		public override void CalculateDistance(int x, int y) {}
	}
