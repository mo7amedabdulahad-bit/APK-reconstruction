// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Punishment : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private bool _excludeWWVillages;
		[ObservableValue]
		private bool _removeResources;
		[ObservableValue]
		private bool _removeTroops;
		[ObservableValue]
		private int? _removeBuildingLevelsPercents;
		[ObservableValue]
		private int? _messagesBan;
		[ObservableValue]
		private int? _profileBan;
		[ObservableValue]
		private bool _warning;
		[ObservableValue]
		private bool _banCancellation;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool excludeWWVillages { get => default; set {} }
		[ObservableValue]
		public bool removeResources { get => default; set {} }
		[ObservableValue]
		public bool removeTroops { get => default; set {} }
		[ObservableValue]
		public int? removeBuildingLevelsPercents { get => default; set {} }
		[ObservableValue]
		public int? messagesBan { get => default; set {} }
		[ObservableValue]
		public int? profileBan { get => default; set {} }
		[ObservableValue]
		public bool warning { get => default; set {} }
		[ObservableValue]
		public bool banCancellation { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Punishment() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PunishmentDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PunishmentDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
