// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Preferences : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<PreferencesItem> _all;
		[ObservableValue]
		private TimezonePreferences _timezonePreferences;
		[ObservableValue]
		private bool _reportPerformanceMode;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<PreferencesItem> all { get => default; set {} }
		[ObservableValue]
		public TimezonePreferences timezonePreferences { get => default; set {} }
		[ObservableValue]
		public bool reportPerformanceMode { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Preferences() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PreferencesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PreferencesDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAll(GraphQLObservableList<PreferencesItem> to, List<PreferencesItemDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _allNotify(object sender, PropertyChangedEventArgs args) {}
	}
