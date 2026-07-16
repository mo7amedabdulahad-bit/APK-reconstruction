// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class QuestData : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private bool _isEnabled;
		[ObservableValue]
		private int _maxTimes;
		[ObservableValue]
		private int _completedTimesToday;
		[ObservableValue]
		private int _pointsPerTask;
		[ObservableValue]
		private int _pointsAchieved;
		[ObservableValue]
		private int _amountNeeded;
		[ObservableValue]
		private nextContribution _nextContribution;
		private static readonly int[] questIdForAnnualSpecialQuests;
		[ObservableValue]
		private int _totalAchievablePoints;
		[ObservableValue]
		private int _questId;
		[ObservableValue]
		private string _questIdTwoDigits;
		[ObservableValue]
		private string _translatedName;
		[ObservableValue]
		private string _translatedDescription;
		[ObservableValue]
		private string _additionalInformation;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public bool isEnabled { get => default; set {} }
		[ObservableValue]
		public int maxTimes { get => default; set {} }
		[ObservableValue]
		public int completedTimesToday { get => default; set {} }
		[ObservableValue]
		public int pointsPerTask { get => default; set {} }
		[ObservableValue]
		public int pointsAchieved { get => default; set {} }
		[ObservableValue]
		public int amountNeeded { get => default; set {} }
		[ObservableValue]
		public nextContribution nextContribution { get => default; set {} }
		[ObservableValue]
		public int totalAchievablePoints { get => default; set {} }
		[ObservableValue]
		public int questId { get => default; set {} }
		[ObservableValue]
		public string questIdTwoDigits { get => default; set {} }
		[ObservableValue]
		public string translatedName { get => default; set {} }
		[ObservableValue]
		public string translatedDescription { get => default; set {} }
		[ObservableValue]
		public string additionalInformation { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public QuestData() {}
		static QuestData() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(QuestDataDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(QuestDataDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
