// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Booty : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private ResourcesAmount _resources;
		[ObservableValue]
		private ResourcesAmount _extraResources;
		[ObservableValue]
		private int _carryMax;
		[ObservableValue]
		private BountyStatus _bountyStatus;
		[ObservableValue]
		private ResourceAmounts _normalResourceAmounts;
		[ObservableValue]
		private ResourceAmounts _additionalResourceAmounts;
		[ObservableValue]
		private int _carrySum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public ResourcesAmount resources { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount extraResources { get => default; set {} }
		[ObservableValue]
		public int carryMax { get => default; set {} }
		[ObservableValue]
		public BountyStatus bountyStatus { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts normalResourceAmounts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts additionalResourceAmounts { get => default; set {} }
		[ObservableValue]
		public int carrySum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum BountyStatus
		{
			None = 0,
			Empty = 1,
			WithBounty = 2,
			Full = 3
		}
	
		// Constructors
		public Booty() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(BootyDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(BootyDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		private BountyStatus GetBountyStatus() => default;
	}
