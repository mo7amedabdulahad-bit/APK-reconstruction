// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapReports : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<SurroundingReport> _surroundingReports;
		[ObservableValue]
		private GraphQLObservableList<ReportInterface> _mapCellReports;
		private TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates;
		private int? mapReportsCount;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MapReportsSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<SurroundingReport> surroundingReports { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ReportInterface> mapCellReports { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum MapReportsSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public MapReports() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MapReportsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MapReportsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListSurroundingReports(GraphQLObservableList<SurroundingReport> to, List<SurroundingReportDTO> from, int query) => default;
		private bool CopyValuesFromDtoListMapCellReports(GraphQLObservableList<ReportInterface> to, List<JObject> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MapReports> PromiseGet(TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MapReports> PromiseGet(out MapReports cacheObject, TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MapReports GetNoFetch(TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, Query query = Query.All) => default;
		public static MapReports Get(bool forceRefresh, TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, Query query = Query.All) => default;
		public static MapReports Get(TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, Query query = Query.All) => default;
		private static MapReports Fetch(MapReportsSource origin, TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(TLMobile.Generated.GraphQL.Game.Coordinate mapReportsCoordinates, int? mapReportsCount = default, object dummy = null) => default;
		private void _surroundingReportsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _mapCellReportsNotify(object sender, PropertyChangedEventArgs args) {}
	}
