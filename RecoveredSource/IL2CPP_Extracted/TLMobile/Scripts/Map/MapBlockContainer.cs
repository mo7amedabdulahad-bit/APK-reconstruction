// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapBlockContainer : ViewModel, IPoolableOperations
	{
		// Fields
		private const float CloudOpacity = 1f;
		public GameObject cellsContainer;
		public BoxCollider2D blockCollider;
		public List<SpriteRenderer> cloudSprites;
		public float secondsForUpdate;
		public ColorCfg regionColorCfg;
		private Dictionary<int, Adventure> adventures;
		private List<MapCell> blockMapCells;
		private bool cloudAnimationPlayedOnce;
		private UnityEngine.Color cloudColor;
		private DG.Tweening.Sequence cloudsAnimation;
		private bool freshlyInitialized;
		private bool isPreInitialized;
		private bool isZoomedOut;
		private string lastBlockHash;
		private MapBlock mapBlockData;
		private List<MapCellRenderer> mapCells;
		private IPoolingService poolingService;
		private float timeNextUpdate;
	
		// Properties
		public bool IsInitialized { get; private set; }
		public bool IsVisible { get; private set; }
		public int CellCount { get => default; }
		public Vector2Int CellsInBlock { get; private set; }
		public Vector2Int BlockId { get; private set; }
		public Vector2Int CellsStartXY { get; private set; }
		public bool AreCellsDataUpdating { get; private set; }
		public int BlockSizeForWebRequest { get; private set; }
	
		// Constructors
		public MapBlockContainer() {}
	
		// Methods
		protected override void Awake() {}
		private void Update() {}
		private void OnEnable() {}
		public void DisablePooledObject() {}
		public void Init(Vector2Int blockId, Vector2Int blockSize, Vector2Int cellsStartXY, Transform blockContainer, Vector3 position, int blockSizeForNetworkRequest, Dictionary<int, Adventure> adventures) {}
		public void PreInitialize(Vector2Int blockId, Vector2Int blockSize, Vector2Int cellsStartXY, Transform blockContainer, Vector3 position, int blockSizeForNetworkRequest, Dictionary<int, Adventure> adventures) {}
		public void ShowCells() {}
		public void HideCells(bool addCellsToPool) {}
		private void DrawStaticData() {}
		public void PerformCellsDataUpdate() {}
		public void CurrentVillageChanged() {}
		public void UpdateZoom(bool newZoomedOut) {}
		public void UpdateCellsData() {}
		private void UpdateCellsDataCallback() {}
		private void CreateCells() {}
		private void PrepareCellsCreation() {}
		private void InstantiateCells() {}
		private void CreateSingleCell(MapCell mapCellData, Vector3 cellPosition) {}
		private Vector3 CalculateCellPosition(MapCell mapCellData) => default;
		private void FinalizeCellsCreation() {}
		[UICallable]
		public void Clicked() {}
		private void PlayCloudAnimation() {}
		private void StopCloudAnimation() {}
		private void OnCloudAnimationDone() {}
		private void SetCloudsAlpha(float alphaValue) {}
	}
