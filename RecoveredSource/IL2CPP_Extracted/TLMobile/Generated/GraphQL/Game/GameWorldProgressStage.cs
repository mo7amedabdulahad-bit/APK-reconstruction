// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameWorldProgressStage : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private GameWorldStageStatus _status;
		[ObservableValue]
		private int? _time;
		[ObservableValue]
		private string _playerName;
		[ObservableValue]
		private int? _tribeId;
		[ObservableValue]
		private StageType _idEnum;
		[ObservableValue]
		private string _spriteName;
		[ObservableValue]
		private string _translateKey;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public GameWorldStageStatus status { get => default; set {} }
		[ObservableValue]
		public int? time { get => default; set {} }
		[ObservableValue]
		public string playerName { get => default; set {} }
		[ObservableValue]
		public int? tribeId { get => default; set {} }
		[ObservableValue]
		public StageType idEnum { get => default; set {} }
		[ObservableValue]
		public string spriteName { get => default; set {} }
		[ObservableValue]
		public string translateKey { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum StageType
		{
			Start = 0,
			SecondVillage = 1,
			Artifacts = 2,
			ConstructionPlans = 3,
			FirstWWLevelOne = 4,
			ServerEnd = 5,
			ServerProgress30 = 6,
			ServerProgress60 = 7,
			Error = 99
		}
	
		// Constructors
		public GameWorldProgressStage() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(GameWorldProgressStageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(GameWorldProgressStageDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
