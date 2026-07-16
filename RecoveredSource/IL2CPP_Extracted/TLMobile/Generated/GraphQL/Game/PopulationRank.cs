// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PopulationRank : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _serverAge;
		[ObservableValue]
		private bool _hasAlliance;
		[ObservableValue]
		private int? _currentWorldPosition;
		[ObservableValue]
		private int? _currentAlliancePosition;
		[ObservableValue]
		private GraphQLObservableList<DailyRank> _worldRankPlot;
		[ObservableValue]
		private GraphQLObservableList<DailyRank> _allianceRankPlot;
		private static readonly string[] namesInNestedResponseFromStatisticsPopulationRank;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public PopulationRankSource Source { get; set; }
		[ObservableValue]
		public int serverAge { get => default; set {} }
		[ObservableValue]
		public bool hasAlliance { get => default; set {} }
		[ObservableValue]
		public int? currentWorldPosition { get => default; set {} }
		[ObservableValue]
		public int? currentAlliancePosition { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<DailyRank> worldRankPlot { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<DailyRank> allianceRankPlot { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum PopulationRankSource
		{
			FromStatisticsPopulationRank = 0
		}
	
		// Constructors
		public PopulationRank() {}
		static PopulationRank() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(PopulationRankDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(PopulationRankDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListWorldRankPlot(GraphQLObservableList<DailyRank> to, List<DailyRankDTO> from, int query) => default;
		private bool CopyValuesFromDtoListAllianceRankPlot(GraphQLObservableList<DailyRank> to, List<DailyRankDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<PopulationRank> PromiseGetFromStatisticsPopulationRank(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<PopulationRank> PromiseGetFromStatisticsPopulationRank(out PopulationRank cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static PopulationRank GetNoFetchFromStatisticsPopulationRank(Query query = Query.All) => default;
		public static PopulationRank GetFromStatisticsPopulationRank(bool forceRefresh, Query query = Query.All) => default;
		public static PopulationRank GetFromStatisticsPopulationRank(Query query = Query.All) => default;
		private static PopulationRank FetchFromStatisticsPopulationRank(PopulationRankSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsPopulationRank(object dummy = null) => default;
		private void _worldRankPlotNotify(object sender, PropertyChangedEventArgs args) {}
		private void _allianceRankPlotNotify(object sender, PropertyChangedEventArgs args) {}
	}
