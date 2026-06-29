// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SurroundingReport : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private int _time;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int _cellId;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _activePlayer;
		[ObservableValue]
		private string _activePlayerName;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _passivePlayer;
		[ObservableValue]
		private string _passivePlayerName;
		[ObservableValue]
		private string _name1;
		[ObservableValue]
		private string _name2;
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private Alliance _alliance1;
		[ObservableValue]
		private Alliance _alliance2;
		private static readonly Dictionary<string, string> replacementsForTranslation;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private string _translatedText;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public int time { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int cellId { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player activePlayer { get => default; set {} }
		[ObservableValue]
		public string activePlayerName { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player passivePlayer { get => default; set {} }
		[ObservableValue]
		public string passivePlayerName { get => default; set {} }
		[ObservableValue]
		public string name1 { get => default; set {} }
		[ObservableValue]
		public string name2 { get => default; set {} }
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public Alliance alliance1 { get => default; set {} }
		[ObservableValue]
		public Alliance alliance2 { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public string translatedText { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public SurroundingReport() {}
		static SurroundingReport() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(SurroundingReportDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(SurroundingReportDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private string FilterRemovedIdAndDecode(string input) => default;
		public override void AfterServerDataCallback() {}
	}
