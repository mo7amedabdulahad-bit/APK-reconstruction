// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceMemberPermissions : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private bool _assignToPosition;
		[ObservableValue]
		private bool _kickPlayer;
		[ObservableValue]
		private bool _changeAlliance;
		[ObservableValue]
		private bool _diplomacy;
		[ObservableValue]
		private bool _IGM;
		[ObservableValue]
		private bool _inviteToAlliance;
		[ObservableValue]
		private bool _manageForums;
		[ObservableValue]
		private bool _manageMap;
		[ObservableValue]
		private bool _manageSpecialization;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool assignToPosition { get => default; set {} }
		[ObservableValue]
		public bool kickPlayer { get => default; set {} }
		[ObservableValue]
		public bool changeAlliance { get => default; set {} }
		[ObservableValue]
		public bool diplomacy { get => default; set {} }
		[ObservableValue]
		public bool IGM { get => default; set {} }
		[ObservableValue]
		public bool inviteToAlliance { get => default; set {} }
		[ObservableValue]
		public bool manageForums { get => default; set {} }
		[ObservableValue]
		public bool manageMap { get => default; set {} }
		[ObservableValue]
		public bool manageSpecialization { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AllianceMemberPermissions() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceMemberPermissionsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceMemberPermissionsDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
