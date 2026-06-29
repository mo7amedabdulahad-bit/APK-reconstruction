// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapCellDataFetcherService : MonoBehaviour, IMapCellDataFetcherService
	{
		// Fields
		private const int BytesPerCell = 8;
		private readonly StringBuilder nwseBuilder;
		private readonly List<MapShape> staticShapes;
		private BootstrapData bootstrapData;
		private Dictionary<int, Dictionary<int, MapCell>> staticCells;
		private byte[] staticMapBytes;
	
		// Constructors
		public MapCellDataFetcherService() {}
	
		// Methods
		public IPromise Init(object[] args = null) => default;
		public IPromise BootInstance(object[] args = null) => default;
		public List<MapCell> GetStaticBlock(int xStart, int yStart, int width, int height) => default;
		public MapBlock GetCellBlock(int xStart, int yStart, int width, int height, bool forceRefresh = true) => default;
		public IPromise<MapBlock> GetPromiseCellBlock(int xStart, int yStart, int width, int height, bool forceRefresh = true) => default;
		public MapBlock GetBlockHash(int xStart, int yStart, int width, int height, bool forceRefresh = true) => default;
		public IPromise<MapBlock> GetPromiseBlockHash(int xStart, int yStart, int width, int height, bool forceRefresh = true) => default;
		public MapBlock GetBlockPlayerData(int xStart, int yStart, int width, int height, bool forceRefresh = true) => default;
		public IPromise<MapBlock> GetPromiseBlockPlayerData(int xStart, int yStart, int width, int height, bool forceRefresh = true) => default;
		public TLMobile.Generated.GraphQL.Game.Player GetMapCellOwner(int playerId) => default;
		public Village GetMapCellVillage(int villageId) => default;
		private IPromise<MapBlock> QueryForPromiseMapBlock(int xStart, int yStart, int width, int height, bool forceRefresh, MapBlock.Query query) => default;
		private MapBlock QueryForMapBlock(int xStart, int yStart, int width, int height, bool forceRefresh, MapBlock.Query query) => default;
		private MapCell GetStaticCellOnCoords(int x, int y, bool sanitize = true) => default;
		private int GetIndexForPosition(int x, int y) => default;
		private Vector2Int GetPositionForIndex(int i) => default;
		private MapCell DecodeCellAtIndex(int i) => default;
		private void DecodeStaticMapData(byte[] bytes) {}
	}
