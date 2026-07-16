// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Map
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapAxesController : ViewModel
	{
		// Fields
		[Help("When should the switch to the low detailed map happen?")]
		[SerializeField]
		private int zoomedMiddleVisibleCells;
		[SerializeField]
		private int zoomedOutVisibleCells;
		[SerializeField]
		private float cameraVisibleX;
		[ObservableValue]
		private int _visibleCellsHorizontal;
		[ObservableValue]
		private int _visibleCellsVertical;
		[ObservableValue]
		private int _firstCellHorizontal;
		[ObservableValue]
		private int _firstCellVertical;
		[ObservableValue]
		private int _cellMultiply;
		[ObservableValue]
		private float _axisScaling;
		[ObservableValue]
		private float _firstFractionX;
		[ObservableValue]
		private float _firstFractionY;
		[SerializeField]
		private RectTransform canvasRect;
		private ICameraService cameraService;
	
		// Properties
		[ObservableValue]
		public int visibleCellsHorizontal { get => default; set {} }
		[ObservableValue]
		public int visibleCellsVertical { get => default; set {} }
		[ObservableValue]
		public int firstCellHorizontal { get => default; set {} }
		[ObservableValue]
		public int firstCellVertical { get => default; set {} }
		[ObservableValue]
		public int cellMultiply { get => default; set {} }
		[ObservableValue]
		public float axisScaling { get => default; set {} }
		[ObservableValue]
		public float firstFractionX { get => default; set {} }
		[ObservableValue]
		public float firstFractionY { get => default; set {} }
	
		// Constructors
		public MapAxesController() {}
	
		// Methods
		private void LateUpdate() {}
		public void Init() {}
	}
