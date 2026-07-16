// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapCell : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int _groundType;
		[ObservableValue]
		private int? _regionId;
		[ObservableValue]
		private int _landDistribution;
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private OasisInterface _oasis;
		[ObservableValue]
		private GraphQLObservableList<MapShape> _shapes;
		private TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates;
		private static readonly string[] namesInNestedResponse;
		private int mapBlockXMinListFromMapBlockCells;
		private int mapBlockYMinListFromMapBlockCells;
		private int mapBlockXMaxListFromMapBlockCells;
		private int mapBlockYMaxListFromMapBlockCells;
		[ObservableValue]
		private Type _typeEnum;
		[ObservableValue]
		private GroundType _groundTypeEnum;
		[ObservableValue]
		private int _neighborRegionInfo;
		[ObservableValue]
		private string _sameGroundTypeInDirections;
		[ObservableValue]
		private string _sameRegionDirections;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public MapCellSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int groundType { get => default; set {} }
		[ObservableValue]
		public int? regionId { get => default; set {} }
		[ObservableValue]
		public int landDistribution { get => default; set {} }
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public OasisInterface oasis { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<MapShape> shapes { get => default; set {} }
		[ObservableValue]
		public Type typeEnum { get => default; set {} }
		[ObservableValue]
		public GroundType groundTypeEnum { get => default; set {} }
		[ObservableValue]
		public int neighborRegionInfo { get => default; set {} }
		[ObservableValue]
		public string sameGroundTypeInDirections { get => default; set {} }
		[ObservableValue]
		public string sameRegionDirections { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Stub = 1
		}
	
		public enum MapCellSource
		{
			RootLevel = 0
		}
	
		public enum MapCellListSource
		{
			FromMapBlockCells = 0
		}
	
		public enum GroundType
		{
			Initial = 1,
			Hill = 2,
			Lake = 3,
			Grassland = 4,
			Clay = 5,
			Forest = 6,
			Volcano = 7,
			Sea = 8,
			Desert = 9,
			DesertWild = 10,
			GrasslandNoStartPoint = 11
		}
	
		public enum Type
		{
			Village = 1,
			Valley = 2,
			FreeOasis = 3,
			OccupiedOasis = 4,
			Wilderness = 5
		}
	
		// Constructors
		public MapCell() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(MapCellDTO dtoValue) => default;
		private bool EqualToDTOStub(MapCellDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(MapCellDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOStub(MapCellDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListShapes(GraphQLObservableList<MapShape> to, List<MapShapeDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<MapCell> PromiseGet(TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<MapCell> PromiseGet(out MapCell cacheObject, TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static MapCell GetNoFetch(TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, Query query = Query.All) => default;
		public static MapCell Get(bool forceRefresh, TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, Query query = Query.All) => default;
		public static MapCell Get(TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, Query query = Query.All) => default;
		private static MapCell Fetch(MapCellSource origin, TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(TLMobile.Generated.GraphQL.Game.Coordinate mapCellCoordinates, object dummy = null) => default;
		public static GraphQLFetchableList<MapCell> CollectionGetNoFetchFromMapBlockCells(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<MapCell>> PromiseCollectionGetFromMapBlockCells(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<MapCell>> PromiseCollectionGetFromMapBlockCells(out GraphQLFetchableList<MapCell> cacheObject, int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<MapCell> CollectionGetFromMapBlockCells(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All) => default;
		public static GraphQLFetchableList<MapCell> CollectionGetFromMapBlockCells(bool forceRefresh, int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All) => default;
		private static GraphQLFetchableList<MapCell> CollectionFetchFromMapBlockCells(MapCellListSource origin, int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromMapBlockCells(int mapBlockXMin, int mapBlockYMin, int mapBlockXMax, int mapBlockYMax, object dummy = null) => default;
		private void _shapesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public void FillCalculatedValues() {}
		public string MapCellTypeName() => default;
	}
