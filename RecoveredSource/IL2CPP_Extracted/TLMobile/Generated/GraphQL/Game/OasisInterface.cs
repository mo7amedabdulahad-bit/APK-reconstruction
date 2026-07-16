// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OasisInterface : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		protected int _id;
		[ObservableValue]
		protected int _x;
		[ObservableValue]
		protected int _y;
		[ObservableValue]
		protected int _type;
		[ObservableValue]
		protected ResourcesAmount _bonusResources;
		[ObservableValue]
		private ResourceTypes _mainBonusResourceType;
		[ObservableValue]
		private ResourceTypes _secondaryBonusResourceType;
		[ObservableValue]
		private ResourceAmounts _bonusAmounts;
		[ObservableValue]
		private OasisStatus _oasisStatus;
		[ObservableValue]
		private int _translatedType;
		[ObservableValue]
		private ObservableList<ResourceAmount> _bonus;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount bonusResources { get => default; set {} }
		[ObservableValue]
		public ResourceTypes mainBonusResourceType { get => default; set {} }
		[ObservableValue]
		public ResourceTypes secondaryBonusResourceType { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts bonusAmounts { get => default; set {} }
		[ObservableValue]
		public OasisStatus oasisStatus { get => default; set {} }
		[ObservableValue]
		public int translatedType { get => default; set {} }
		[ObservableValue]
		public ObservableList<ResourceAmount> bonus { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OasisStatus
		{
			FreeOasis = 1,
			OccupiedOasis = 2,
			FreeSlot = 3
		}
	
		// Constructors
		public OasisInterface() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OasisInterfaceDTO dtoValue) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OasisInterfaceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public static string GetInterfaceType(JObject dtoData) => default;
		public static OasisInterface CreateInstance(string typename) => default;
		public override bool CopyValuesFromDTO(object newValues, int query, bool beSilent) => default;
		public bool CopyValuesFromDTO(JObject newValues, Query query = Query.All, bool beSilent = false) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(JObject dtoValue, Query query = Query.All) => default;
		public new string ToString() => default;
		private void _bonusNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
