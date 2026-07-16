// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceStatistics : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceStatisticsStatEntity> _strength;
		[ObservableValue]
		private GraphQLObservableList<OwnAllianceStatisticsStatEntity> _fightingPoints;
		[ObservableValue]
		private int _attackersOfWeekPoints;
		[ObservableValue]
		private int _defendersOfWeekPoints;
		[ObservableValue]
		private int _climbersOfWeekPoints;
		[ObservableValue]
		private int _robbersOfWeekPoints;
		[ObservableValue]
		private Top10PlayersOfWeek _top10PlayersOfWeek;
		private static readonly string[] namesInNestedResponseFromOwnAllianceStatistics;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnAllianceStatisticsSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceStatisticsStatEntity> strength { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OwnAllianceStatisticsStatEntity> fightingPoints { get => default; set {} }
		[ObservableValue]
		public int attackersOfWeekPoints { get => default; set {} }
		[ObservableValue]
		public int defendersOfWeekPoints { get => default; set {} }
		[ObservableValue]
		public int climbersOfWeekPoints { get => default; set {} }
		[ObservableValue]
		public int robbersOfWeekPoints { get => default; set {} }
		[ObservableValue]
		public Top10PlayersOfWeek top10PlayersOfWeek { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum OwnAllianceStatisticsSource
		{
			FromOwnAllianceStatistics = 0
		}
	
		// Constructors
		public OwnAllianceStatistics() {}
		static OwnAllianceStatistics() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnAllianceStatisticsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnAllianceStatisticsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListStrength(GraphQLObservableList<OwnAllianceStatisticsStatEntity> to, List<OwnAllianceStatisticsStatEntityDTO> from, int query) => default;
		private bool CopyValuesFromDtoListFightingPoints(GraphQLObservableList<OwnAllianceStatisticsStatEntity> to, List<OwnAllianceStatisticsStatEntityDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<OwnAllianceStatistics> PromiseGetFromOwnAllianceStatistics(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnAllianceStatistics> PromiseGetFromOwnAllianceStatistics(out OwnAllianceStatistics cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnAllianceStatistics GetNoFetchFromOwnAllianceStatistics(Query query = Query.All) => default;
		public static OwnAllianceStatistics GetFromOwnAllianceStatistics(bool forceRefresh, Query query = Query.All) => default;
		public static OwnAllianceStatistics GetFromOwnAllianceStatistics(Query query = Query.All) => default;
		private static OwnAllianceStatistics FetchFromOwnAllianceStatistics(OwnAllianceStatisticsSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnAllianceStatistics(object dummy = null) => default;
		private void _strengthNotify(object sender, PropertyChangedEventArgs args) {}
		private void _fightingPointsNotify(object sender, PropertyChangedEventArgs args) {}
	}
