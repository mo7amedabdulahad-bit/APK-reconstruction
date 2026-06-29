// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ScreenInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private float _inch;
		[ObservableValue]
		private int _width;
		[ObservableValue]
		private int _height;
		[ObservableValue]
		private bool _isTouch;
		[ObservableValue]
		private int _cameraMoved;
		[ObservableValue]
		private bool _isMobile;
		public static ScreenInfo instance;
		public bool maySwitchToMobile;
	
		// Properties
		[ObservableValue]
		public float inch { get => default; set {} }
		[ObservableValue]
		public int width { get => default; set {} }
		[ObservableValue]
		public int height { get => default; set {} }
		[ObservableValue]
		public bool isTouch { get => default; set {} }
		[ObservableValue]
		public int cameraMoved { get => default; set {} }
		[ObservableValue]
		public bool isMobile { get => default; set {} }
	
		// Events
		public event System.Action OnResolutionChanged;
	
		// Constructors
		static ScreenInfo() {}
		public ScreenInfo() {}
	
		// Methods
		public void update() {}
	}
