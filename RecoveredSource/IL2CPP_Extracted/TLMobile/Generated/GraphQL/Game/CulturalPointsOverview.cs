// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CulturalPointsOverview : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _citiesCount;
		[ObservableValue]
		private int _usedSlots;
		[ObservableValue]
		private int _maxControllableVillages;
		[ObservableValue]
		private int _cpProduced;
		[ObservableValue]
		private int _nextVillageAvailableAt;
		[ObservableValue]
		private int _cpNeeded;
		[ObservableValue]
		private int _cpProducedForNextSlot;
		[ObservableValue]
		private int _cpNeededForNextSlot;
		[ObservableValue]
		private int _cpForMaxControllableVillages;
		[ObservableValue]
		private CpProductionBonus _cpProductionBonus;
		[ObservableValue]
		private int? _nextSlotAvailableAt;
		[ObservableValue]
		private int _cpProductionTotal;
		[ObservableValue]
		private int _producedForNextLevel;
		[ObservableValue]
		private int _diffNeededForNextLevel;
		[ObservableValue]
		private float _diffPercent;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int citiesCount { get => default; set {} }
		[ObservableValue]
		public int usedSlots { get => default; set {} }
		[ObservableValue]
		public int maxControllableVillages { get => default; set {} }
		[ObservableValue]
		public int cpProduced { get => default; set {} }
		[ObservableValue]
		public int nextVillageAvailableAt { get => default; set {} }
		[ObservableValue]
		public int cpNeeded { get => default; set {} }
		[ObservableValue]
		public int cpProducedForNextSlot { get => default; set {} }
		[ObservableValue]
		public int cpNeededForNextSlot { get => default; set {} }
		[ObservableValue]
		public int cpForMaxControllableVillages { get => default; set {} }
		[ObservableValue]
		public CpProductionBonus cpProductionBonus { get => default; set {} }
		[ObservableValue]
		public int? nextSlotAvailableAt { get => default; set {} }
		[ObservableValue]
		public int cpProductionTotal { get => default; set {} }
		[ObservableValue]
		public int producedForNextLevel { get => default; set {} }
		[ObservableValue]
		public int diffNeededForNextLevel { get => default; set {} }
		[ObservableValue]
		public float diffPercent { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public CulturalPointsOverview() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CulturalPointsOverviewDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CulturalPointsOverviewDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
