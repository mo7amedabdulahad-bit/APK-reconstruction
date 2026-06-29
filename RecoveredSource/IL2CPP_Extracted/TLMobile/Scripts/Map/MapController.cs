// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapController : ViewModel
	{
		// Fields
		private static readonly List<DetailWindows> MapContainerWindows;
		private const int TileScaleFactor = 25;
		private static Vector3? _currentSelectedTilePosition;
		[ObservableValue]
		private bool _detailWindowsOpen;
		[Header("Pools setup")]
		[SerializeField]
		private MapBlockContainer mapBlockPrefab;
		[SerializeField]
		private MapCellRenderer mapCellPrefab;
		[SerializeField]
		private SpriteRenderer mapShapePrefab;
		[SerializeField]
		private Transform blockPoolParent;
		[SerializeField]
		private Transform cellPoolParent;
		[SerializeField]
		private Transform shapePoolParent;
		[SerializeField]
		private int startingPooledBlocksCell;
		[SerializeField]
		private int startingPooledShapes;
		[SerializeField]
		private MapBlocksManager mapBlocksManager;
		public MapAxesController mapAxesController;
		private int currentBlockSize;
		private IWindowsService windowsService;
		private ICameraService cameraService;
		private static RenderTexture cameraRenderTexture;
		public static GraphQLObservableList<MapFlag> MapFlags;
		public static GraphQLObservableList<MapMarker> MapMarkers;
	
		// Properties
		[ObservableValue]
		public bool detailWindowsOpen { get => default; set {} }
		public static Vector3? CurrentSelectedTilePosition { get => default; set {} }
		public MapBlockSize BlockSize { get; private set; }
		public static RenderTexture CameraRenderTexture { get => default; }
		public static Vector2Int MapXLimits { get; private set; }
		public static Vector2Int MapYLimits { get; private set; }
		public static MapConfiguration MapConfiguration { get; private set; }
		public static ServerSupportedFeatures ServerSupportedFeatures { get; private set; }
		public static bool TriggerMapRefresh { get; set; }
		public static MapSettings CurrentMapSettings { get; private set; }
	
		// Events
		public static event Action<Vector3?> OnCurrentSelectedTileChanged;
	
		// Nested types
		[Flags]
		public enum MapSettings
		{
			FilterVisibleUser = 1,
			FilterVisibleAlliance = 2,
			Default = 3
		}
	
		// Constructors
		public MapController() {}
		static MapController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnDestroy() {}
		private void Update() {}
		private void MapConfigurationLoaded(MapConfiguration mapConfiguration, ServerSupportedFeatures serverSupportedFeatures) {}
		public void Init(MapConfiguration mapConfigurationData, MapBlockSize blockSize, MapBlockContainer blockPrefab, MapBlocksManager mapBlocksManagerReference, Transform blockPoolParentTransform, Transform cellPoolParentTransform, Transform shapePoolParentTransform, MapCellRenderer cellPrefab, SpriteRenderer shapePrefab, int startingPooledBlocks = 30, int startPooledShapes = 100) {}
		public static void RefreshMapSettings(Action<bool> refreshAction) {}
		public static void RefreshMapMarkers(System.Action refreshAction) {}
		public static bool ShowFlag(int id) => default;
		private IScreenConfiguration GetScreenConfigurationForMap(bool travelOverTheWorldEdge) => default;
		private void CleanupRenderTexture() {}
	}
