// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Top10PlayersOfWeek : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<Top10Player> _attackers;
		[ObservableValue]
		private GraphQLObservableList<Top10Player> _defenders;
		[ObservableValue]
		private GraphQLObservableList<Top10Player> _pve;
		[ObservableValue]
		private GraphQLObservableList<Top10Player> _robbers;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<Top10Player> attackers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Top10Player> defenders { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Top10Player> pve { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Top10Player> robbers { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Top10PlayersOfWeek() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(Top10PlayersOfWeekDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(Top10PlayersOfWeekDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAttackers(GraphQLObservableList<Top10Player> to, List<Top10PlayerDTO> from, int query) => default;
		private bool CopyValuesFromDtoListDefenders(GraphQLObservableList<Top10Player> to, List<Top10PlayerDTO> from, int query) => default;
		private bool CopyValuesFromDtoListPve(GraphQLObservableList<Top10Player> to, List<Top10PlayerDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRobbers(GraphQLObservableList<Top10Player> to, List<Top10PlayerDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _attackersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _defendersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _pveNotify(object sender, PropertyChangedEventArgs args) {}
		private void _robbersNotify(object sender, PropertyChangedEventArgs args) {}
	}
