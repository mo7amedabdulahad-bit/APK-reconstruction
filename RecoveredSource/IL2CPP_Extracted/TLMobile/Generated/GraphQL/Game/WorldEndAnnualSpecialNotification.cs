// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class WorldEndAnnualSpecialNotification : TLMobile.Generated.GraphQL.Game.NotificationInterface
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
		private GraphQLObservableList<Alliance> _topAlliances;
		[ObservableValue]
		private int _victoryPointsTop1;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Game.AllianceBanner> _topAllianceBanners;
		[ObservableValue]
		private ObservableList<int> _topAlliancesIds;
		[ObservableValue]
		private ObservableList<int> _topAlliancesVictoryPoints;
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
		public GraphQLObservableList<Alliance> topAlliances { get => default; set {} }
		[ObservableValue]
		public int victoryPointsTop1 { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Game.AllianceBanner> topAllianceBanners { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> topAlliancesIds { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> topAlliancesVictoryPoints { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> topPlayersIds { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public WorldEndAnnualSpecialNotification() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(WorldEndAnnualSpecialNotificationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(WorldEndAnnualSpecialNotificationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTopPlayers(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Player> to, List<PlayerDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTopAlliances(GraphQLObservableList<Alliance> to, List<AllianceDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _topPlayersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _topAlliancesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _topAllianceBannersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _topAlliancesIdsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _topAlliancesVictoryPointsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _topPlayersIdsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
