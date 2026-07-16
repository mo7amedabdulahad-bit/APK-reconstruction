// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ActivatedAncientPower : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private AncientPower _ancientPower;
		[ObservableValue]
		private bool _autoReactivate;
		[ObservableValue]
		private int _expireAt;
		[ObservableValue]
		private OwnVillage _village;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public AncientPower ancientPower { get => default; set {} }
		[ObservableValue]
		public bool autoReactivate { get => default; set {} }
		[ObservableValue]
		public int expireAt { get => default; set {} }
		[ObservableValue]
		public OwnVillage village { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ActivatedAncientPower() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ActivatedAncientPowerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ActivatedAncientPowerDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
	}
