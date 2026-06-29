// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceStatistics : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<RankedAlliance> _top10WeekAttackers;
		[ObservableValue]
		private GraphQLObservableList<RankedAlliance> _top10WeekDefenders;
		[ObservableValue]
		private GraphQLObservableList<RankedAlliance> _top10WeekClimbers;
		[ObservableValue]
		private GraphQLObservableList<RankedAlliance> _top10WeekRobbers;
		private static readonly string[] namesInNestedResponseFromStatisticsAlliancesRank;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public AllianceStatisticsSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<RankedAlliance> top10WeekAttackers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedAlliance> top10WeekDefenders { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedAlliance> top10WeekClimbers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<RankedAlliance> top10WeekRobbers { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AllianceStatisticsSource
		{
			FromStatisticsAlliancesRank = 0
		}
	
		// Constructors
		public AllianceStatistics() {}
		static AllianceStatistics() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceStatisticsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceStatisticsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListTop10WeekAttackers(GraphQLObservableList<RankedAlliance> to, List<RankedAllianceDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTop10WeekDefenders(GraphQLObservableList<RankedAlliance> to, List<RankedAllianceDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTop10WeekClimbers(GraphQLObservableList<RankedAlliance> to, List<RankedAllianceDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTop10WeekRobbers(GraphQLObservableList<RankedAlliance> to, List<RankedAllianceDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<AllianceStatistics> PromiseGetFromStatisticsAlliancesRank(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<AllianceStatistics> PromiseGetFromStatisticsAlliancesRank(out AllianceStatistics cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static AllianceStatistics GetNoFetchFromStatisticsAlliancesRank(Query query = Query.All) => default;
		public static AllianceStatistics GetFromStatisticsAlliancesRank(bool forceRefresh, Query query = Query.All) => default;
		public static AllianceStatistics GetFromStatisticsAlliancesRank(Query query = Query.All) => default;
		private static AllianceStatistics FetchFromStatisticsAlliancesRank(AllianceStatisticsSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsAlliancesRank(object dummy = null) => default;
		private void _top10WeekAttackersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _top10WeekDefendersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _top10WeekClimbersNotify(object sender, PropertyChangedEventArgs args) {}
		private void _top10WeekRobbersNotify(object sender, PropertyChangedEventArgs args) {}
	}
