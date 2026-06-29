// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldMetadata : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _url;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _type;
		[ObservableValue]
		private string _subtitle;
		[ObservableValue]
		private GraphQLObservableList<string> _recommended;
		[ObservableValue]
		private string _mainpageBackground;
		[ObservableValue]
		private GraphQLObservableList<string> _mainpageGroups;
		[ObservableValue]
		private GraphQLObservableList<string> _filter;
		[ObservableValue]
		private GameworldType _typeEnum;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string url { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string type { get => default; set {} }
		[ObservableValue]
		public string subtitle { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<string> recommended { get => default; set {} }
		[ObservableValue]
		public string mainpageBackground { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<string> mainpageGroups { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<string> filter { get => default; set {} }
		[ObservableValue]
		public GameworldType typeEnum { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyUrlAndName = 1
		}
	
		// Constructors
		public GameworldMetadata() {}
		public GameworldMetadata(ApiMetadataMetadata source) {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(GameworldMetadataDTO dtoValue) => default;
		private bool EqualToDTOOnlyUrlAndName(GameworldMetadataDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(GameworldMetadataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyUrlAndName(GameworldMetadataDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListRecommended(GraphQLObservableList<string> to, List<string> from, int query) => default;
		private bool CopyValuesFromDtoListMainpageGroups(GraphQLObservableList<string> to, List<string> from, int query) => default;
		private bool CopyValuesFromDtoListFilter(GraphQLObservableList<string> to, List<string> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _recommendedNotify(object sender, PropertyChangedEventArgs args) {}
		private void _mainpageGroupsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _filterNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
