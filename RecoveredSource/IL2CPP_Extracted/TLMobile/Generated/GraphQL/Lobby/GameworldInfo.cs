// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Lobby
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldInfo : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _ageInDays;
		[ObservableValue]
		private int _playersCount;
		[ObservableValue]
		private int? _artefactsDate;
		[ObservableValue]
		private int? _artefactsInDays;
		[ObservableValue]
		private int? _constructionPlansDate;
		[ObservableValue]
		private int? _constructionPlansInDays;
		[ObservableValue]
		private int? _wwLevel;
		[ObservableValue]
		private int? _wwTribeId;
		[ObservableValue]
		private GraphQLObservableList<GameworldInfoTribe> _tribes;
		[ObservableValue]
		private GameworldInfoMap _mapConfiguration;
		[ObservableValue]
		private GameworldInfoFeatures _serverSupportedFeatures;
		[ObservableValue]
		private GameworldInfoConfiguration _serverConfiguration;
		[ObservableValue]
		private GraphQLObservableList<GameworldInfoTribe> _playableTribes;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int ageInDays { get => default; set {} }
		[ObservableValue]
		public int playersCount { get => default; set {} }
		[ObservableValue]
		public int? artefactsDate { get => default; set {} }
		[ObservableValue]
		public int? artefactsInDays { get => default; set {} }
		[ObservableValue]
		public int? constructionPlansDate { get => default; set {} }
		[ObservableValue]
		public int? constructionPlansInDays { get => default; set {} }
		[ObservableValue]
		public int? wwLevel { get => default; set {} }
		[ObservableValue]
		public int? wwTribeId { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<GameworldInfoTribe> tribes { get => default; set {} }
		[ObservableValue]
		public GameworldInfoMap mapConfiguration { get => default; set {} }
		[ObservableValue]
		public GameworldInfoFeatures serverSupportedFeatures { get => default; set {} }
		[ObservableValue]
		public GameworldInfoConfiguration serverConfiguration { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<GameworldInfoTribe> playableTribes { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public GameworldInfo() {}
		public GameworldInfo(ApiCalendarInfo source, int start) {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(GameworldInfoDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(GameworldInfoDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTribes(GraphQLObservableList<GameworldInfoTribe> to, List<GameworldInfoTribeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _tribesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _playableTribesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
