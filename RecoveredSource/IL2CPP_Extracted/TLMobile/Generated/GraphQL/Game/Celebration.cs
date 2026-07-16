// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Celebration : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private CelebrationType _type;
		[ObservableValue]
		private ResourcesAmount _celebrationCost;
		[ObservableValue]
		private int _cp;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private bool _canBeStarted;
		[ObservableValue]
		private ResourceAmounts _costAmounts;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public CelebrationType type { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount celebrationCost { get => default; set {} }
		[ObservableValue]
		public int cp { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public bool canBeStarted { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts costAmounts { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Celebration() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CelebrationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CelebrationDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
