// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ServerConfiguration : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _speed;
		[ObservableValue]
		private int? _blockWWAttacksUntil;
		[ObservableValue]
		private int? _ancientPowerCooldown;
		[ObservableValue]
		private GraphQLObservableList<string> _languages;
		[ObservableValue]
		private int _maxVillageGroupsAmount;
		[ObservableValue]
		private MapConfiguration _map;
		[ObservableValue]
		private GraphQLObservableList<TribeName> _tribeNames;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int speed { get => default; set {} }
		[ObservableValue]
		public int? blockWWAttacksUntil { get => default; set {} }
		[ObservableValue]
		public int? ancientPowerCooldown { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<string> languages { get => default; set {} }
		[ObservableValue]
		public int maxVillageGroupsAmount { get => default; set {} }
		[ObservableValue]
		public MapConfiguration map { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TribeName> tribeNames { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ServerConfiguration() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ServerConfigurationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ServerConfigurationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListLanguages(GraphQLObservableList<string> to, List<string> from, int query) => default;
		private bool CopyValuesFromDtoListTribeNames(GraphQLObservableList<TribeName> to, List<TribeName?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _languagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _tribeNamesNotify(object sender, PropertyChangedEventArgs args) {}
	}
