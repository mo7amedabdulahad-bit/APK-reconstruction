// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WorldEndNatarsWonNotification : TLMobile.Generated.GraphQL.Game.NotificationInterface
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Player> _topPlayers;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _topAttacker;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _topDefender;
		[ObservableValue]
		private int _worldEndTime;
		[ObservableValue]
		private ObservableList<int> _topPlayersIds;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Player> topPlayers { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player topAttacker { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player topDefender { get => default; set {} }
		[ObservableValue]
		public int worldEndTime { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> topPlayersIds { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public WorldEndNatarsWonNotification() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(WorldEndNatarsWonNotificationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(WorldEndNatarsWonNotificationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTopPlayers(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Player> to, List<PlayerDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _topPlayersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _topPlayersIdsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
