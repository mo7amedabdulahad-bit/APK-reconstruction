// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapBlocksManager : ViewModel
	{
		// Fields
		private const float TargetFrameRateWhileLoading = 15f;
		private const int MaxFrameSkippedForLoading = 10;
		[Help("How many blocks will be loaded outside of the camera view to the right and left of the camera")]
		[SerializeField]
		private int preloadBlocksHorizontal;
		[Help("How many blocks will be loaded outside of the camera view above and below the camera")]
		[SerializeField]
		private int preloadBlocksVertical;
		[Help("When should the switch to the low detailed map happen?")]
		[SerializeField]
		private int zoomedOutVisibleCells;
		private readonly Dictionary<int, Adventure> adventures;
		private readonly Dictionary<Vector2Int, BlockContainerLoading> loadingBlockContainers;
		private readonly Dictionary<Vector2Int, MapBlockContainer> visibleMapBlocks;
		[ObservableValue]
		private float _villageDirection;
		[ObservableValue]
		private float _villageDistance;
		[ObservableValue]
		private Vector3 _villagePosition;
		[ObservableValue]
		private Vector3? _currentSelectedTilePosition;
		private GraphQLFetchableList<Adventure> adventureCollection;
		private ICameraService cameraService;
		private float currentFPS;
		private BlockContainerLoading currentLoadingBlock;
		private Vector2Int mapSizeInBlocks;
		private RectInt oldVisibleArea;
		private int oldVisibleCells;
		private int overFlowHeight;
		private int overFlowWidth;
		private Transform parentForBlocks;
		private int skippedFrames;
	
		// Properties
		[ObservableValue]
		public float villageDirection { get => default; set {} }
		[ObservableValue]
		public float villageDistance { get => default; set {} }
		[ObservableValue]
		public Vector3 villagePosition { get => default; set {} }
		[ObservableValue]
		public Vector3? currentSelectedTilePosition { get => default; set {} }
		public bool IsInitialised { get; private set; }
		public Vector2Int WorldSizeInBlocks { get; private set; }
		public Vector2Int WorldSizeInCells { get; private set; }
		public MapBlockSize BlockSize { get; private set; }
	
		// Nested types
		public class BlockContainerLoading
		{
			// Fields
			private readonly Action<MapBlockContainer, Vector2Int, int> loadBlock;
			public readonly Vector2Int point;
			public MapBlockContainer block;
			public int currentVisibleCells;
			public int sortingOrder;
	
			// Properties
			public bool IsLoaded { get => default; }
	
			// Constructors
			public BlockContainerLoading() {} // Dummy constructor
			public BlockContainerLoading(MapBlockContainer block, Vector2Int point, int currentVisibleCells, Action<MapBlockContainer, Vector2Int, int> loadBlock) {}
	
			// Methods
			public void Load() {}
			public void Unload() {}
			public override bool Equals(object obj) => default;
			public override int GetHashCode() => default;
		}
	
		// Constructors
		public MapBlocksManager() {}
	
		// Methods
		private void Update() {}
		protected void OnEnable() {}
		private void OnDisable() {}
		protected override void OnDestroy() {}
		public void Init(Transform mapParent, Vector2Int mapSize, MapBlockSize blockSizeValue) {}
		public void RefreshVisibleMap() {}
		private void UpdateAdventures() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void OnCurrentSelectedTileChanged(Vector3? newValue) {}
		private void UpdateVisibility() {}
		private void SortLoadingBlocks(Vector2Int cameraPosition2D) {}
		private void LoadBlock(MapBlockContainer block, Vector2Int point, int currentVisibleCells) {}
		public Vector2Int GetRealBlockSize(Vector2Int blockId) => default;
		public Vector2Int BlockIdToNormalisedBlockId(Vector2Int blockId) => default;
		public Vector2Int GetMapWrappingOffset(Vector2Int blockId) => default;
		public Vector3 GetBlockWorldPosition(Vector2Int blockId) => default;
		public static Vector2 GetCellWorldPosition(Vector2Int cellCoordinates) => default;
		public Vector2Int GetCellsStartXY(Vector2Int blockId) => default;
		public Vector2Int GetContainingBlockId(Vector2Int cellPosition) => default;
		private RectInt GetVisibleArea(Vector2Int cameraPosition2D) => default;
		private int GetHorizontalVisibleCells() => default;
		private int GetVerticalVisibleCells() => default;
		[UICallable]
		public void CenterOnCurrentVillage() {}
	}
