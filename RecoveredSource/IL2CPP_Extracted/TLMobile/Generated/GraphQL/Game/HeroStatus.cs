// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroStatus : GraphQLServerObject, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int? _status;
		[ObservableValue]
		private Village _inVillage;
		[ObservableValue]
		private OccupiedOasis _inOasis;
		[ObservableValue]
		private MapCell _onWayTo;
		[ObservableValue]
		private int? _arrivalAt;
		[ObservableValue]
		private int? _arrivalIn;
		[ObservableValue]
		private Adventure _adventure;
		[ObservableValue]
		private Status _statusEnum;
		[ObservableValue]
		private string _statusSuffix;
		[ObservableValue]
		private int _shownMapCellId;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int? status { get => default; set {} }
		[ObservableValue]
		public Village inVillage { get => default; set {} }
		[ObservableValue]
		public OccupiedOasis inOasis { get => default; set {} }
		[ObservableValue]
		public MapCell onWayTo { get => default; set {} }
		[ObservableValue]
		public int? arrivalAt { get => default; set {} }
		[ObservableValue]
		public int? arrivalIn { get => default; set {} }
		[ObservableValue]
		public Adventure adventure { get => default; set {} }
		[ObservableValue]
		public Status statusEnum { get => default; set {} }
		[ObservableValue]
		public string statusSuffix { get => default; set {} }
		[ObservableValue]
		public int shownMapCellId { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum Status
		{
			OnAttack = 3,
			OnRaid = 4,
			OnSupport = 5,
			OnWayBack = 9,
			OnEvasion = 40,
			OnAdventure = 50,
			Idle = 100,
			Dead = 101,
			Captured = 102,
			Defending = 103
		}
	
		// Constructors
		public HeroStatus() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroStatusDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroStatusDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
