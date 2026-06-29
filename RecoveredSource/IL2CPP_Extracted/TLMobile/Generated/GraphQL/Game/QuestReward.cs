// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class QuestReward : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private int _points;
		[ObservableValue]
		private string _awardDescription;
		[ObservableValue]
		private bool _awardRedeemed;
		[ObservableValue]
		private GraphQLObservableList<PossibleAward> _possibleAwards;
		[ObservableValue]
		private float _percentFulfilled;
		[ObservableValue]
		private rewardType _showRewardIcon;
		[ObservableValue]
		private int _secondaryRewardIcon;
		[ObservableValue]
		private int _showRewardValue;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public int points { get => default; set {} }
		[ObservableValue]
		public string awardDescription { get => default; set {} }
		[ObservableValue]
		public bool awardRedeemed { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<PossibleAward> possibleAwards { get => default; set {} }
		[ObservableValue]
		public float percentFulfilled { get => default; set {} }
		[ObservableValue]
		public rewardType showRewardIcon { get => default; set {} }
		[ObservableValue]
		public int secondaryRewardIcon { get => default; set {} }
		[ObservableValue]
		public int showRewardValue { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public QuestReward() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(QuestRewardDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(QuestRewardDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListPossibleAwards(GraphQLObservableList<PossibleAward> to, List<PossibleAwardDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _possibleAwardsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
