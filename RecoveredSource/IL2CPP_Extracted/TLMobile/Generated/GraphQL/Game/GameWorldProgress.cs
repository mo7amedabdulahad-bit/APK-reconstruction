// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameWorldProgress : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _serverAge;
		[ObservableValue]
		private int _activatedPlayers;
		[ObservableValue]
		private GraphQLObservableList<GameWorldProgressStage> _stages;
		[ObservableValue]
		private GraphQLObservableList<TribeDistribution> _tribeDistribution;
		private static readonly string[] namesInNestedResponseFromStatisticsGameWorldProgress;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public GameWorldProgressSource Source { get; set; }
		[ObservableValue]
		public int serverAge { get => default; set {} }
		[ObservableValue]
		public int activatedPlayers { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<GameWorldProgressStage> stages { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TribeDistribution> tribeDistribution { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum GameWorldProgressSource
		{
			FromStatisticsGameWorldProgress = 0
		}
	
		// Constructors
		public GameWorldProgress() {}
		static GameWorldProgress() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(GameWorldProgressDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(GameWorldProgressDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListStages(GraphQLObservableList<GameWorldProgressStage> to, List<GameWorldProgressStageDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTribeDistribution(GraphQLObservableList<TribeDistribution> to, List<TribeDistributionDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<GameWorldProgress> PromiseGetFromStatisticsGameWorldProgress(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GameWorldProgress> PromiseGetFromStatisticsGameWorldProgress(out GameWorldProgress cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GameWorldProgress GetNoFetchFromStatisticsGameWorldProgress(Query query = Query.All) => default;
		public static GameWorldProgress GetFromStatisticsGameWorldProgress(bool forceRefresh, Query query = Query.All) => default;
		public static GameWorldProgress GetFromStatisticsGameWorldProgress(Query query = Query.All) => default;
		private static GameWorldProgress FetchFromStatisticsGameWorldProgress(GameWorldProgressSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromStatisticsGameWorldProgress(object dummy = null) => default;
		private void _stagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _tribeDistributionNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
