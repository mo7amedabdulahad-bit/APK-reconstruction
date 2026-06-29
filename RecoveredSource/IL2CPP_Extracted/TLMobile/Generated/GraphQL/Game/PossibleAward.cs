// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PossibleAward : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _resetAt;
		[ObservableValue]
		private string _description;
		[ObservableValue]
		private GraphQLObservableList<SingleReward> _reward;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int resetAt { get => default; set {} }
		[ObservableValue]
		public string description { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<SingleReward> reward { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public PossibleAward() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PossibleAwardDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PossibleAwardDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListReward(GraphQLObservableList<SingleReward> to, List<SingleRewardDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _rewardNotify(object sender, PropertyChangedEventArgs args) {}
	}
