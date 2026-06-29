// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapBlock : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _xMin;
		[ObservableValue]
		private int _yMin;
		[ObservableValue]
		private int _xMax;
		[ObservableValue]
		private int _yMax;
		[ObservableValue]
		private string _hash;
		[ObservableValue]
		private GraphQLObservableList<MapPlayerData> _playerData;
		[ObservableValue]
		private GraphQLObservableList<Village> _villages;
		[ObservableValue]
		private GraphQLObservableList<OasisInterface> _oases;
		private int mapBlockXMin;
		private int mapBlockYMin;
		private int mapBlockXMax;
		private int mapBlockYMax;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MapBlockSource Source { get; set; }
		[ObservableValue]
		public int xMin { get => default; set {} }
		[ObservableValue]
		public int yMin { get => default; set {} }
		[ObservableValue]
		public int xMax { get => default; set {} }
		[ObservableValue]
		public int yMax { get => default; set {} }
		[ObservableValue]
		public string hash { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MapPlayerData> playerData { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Village> villages { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OasisInterface> oases { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Hash = 1,
			PlayerData = 2
		}
	
		public enum MapBlockSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public MapBlock() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MapBlockDTO dtoValue) => default;
		private bool EqualToDTOHash(MapBlockDTO dtoValue) => default;
		private bool EqualToDTOPlayerData(MapBlockDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MapBlockDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOHash(MapBlockDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOPlayerData(MapBlockDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListPlayerData(GraphQLObservableList<MapPlayerData> to, List<MapPlayerDataDTO> from, int query) => default;
		private bool CopyValuesFromDtoListVillages(GraphQLObservableList<Village> to, List<VillageDTO> from, int query) => default;
		private bool CopyValuesFromDtoListOases(GraphQLObservableList<OasisInterface> to, List<JObject> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static MapBlock GetById(object dtoObject) => default;
		public static IPromise<MapBlock> PromiseGet(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MapBlock> PromiseGet(out MapBlock cacheObject, int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MapBlock GetNoFetch(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All) => default;
		public static MapBlock Get(bool forceRefresh, int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All) => default;
		public static MapBlock Get(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All) => default;
		private static MapBlock Fetch(MapBlockSource origin, int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, object dummy = null) => default;
		private void _playerDataNotify(object sender, PropertyChangedEventArgs args) {}
		private void _villagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _oasesNotify(object sender, PropertyChangedEventArgs args) {}
	}
