// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Config : ScriptableObject
	{
		// Fields
		private static Config instance;
		public static bool languageIsRTL;
		public static Dictionary<string, string> language;
		public static Dictionary<string, string> fallbackLanguage;
		[Help("Settings for code generation and Databindings")]
		[SerializeField]
		private string gameNamespace;
		[SerializeField]
		private System.Type gameAssemblyType;
		[SerializeField]
		private string pathForGeneratedClasses;
		[SerializeField]
		private string pathForProjectAssets;
		[Help("Enable if 2D colliders should react to clicks")]
		[SerializeField]
		private bool Enable2DRayCasting;
		[Help("Enable if 3D colliders should react to clicks")]
		[SerializeField]
		private bool Enable3DRayCasting;
		[Help("Enable if the text style should be forced to the current state of the text style configuration asset in the runtime for the TextStyle components")]
		[SerializeField]
		private bool ensureTexStyleInRuntimeOnAwake;
		[Help("Settings for the backend connection")]
		[SerializeField]
		private string baseUrl;
		[SerializeField]
		private bool useSSL;
		[SerializeField]
		private string backendApiRoute;
		[SerializeField]
		private string websocketRoute;
		[SerializeField]
		private int textFilterTimeOffsetSeconds;
	
		// Properties
		public static Config Instance { get => default; set {} }
		public string BaseUrl { get => default; set {} }
		public bool UseSSL { get => default; set {} }
		protected string hprotocol { get => default; }
		protected string sprotocol { get => default; }
		public static string ServerUrl { get => default; }
		public static string BackendApiUrl { get => default; }
		public static string WebsocketUrl { get => default; }
		public static string GameNamespace { get => default; }
		public static bool RayCasting3DEnabled { get => default; }
		public static bool RayCasting2DEnabled { get => default; }
		public static bool EnsureTexStyleInRuntimeOnAwake { get => default; }
		public static System.Type GameAssemblyType { get => default; set {} }
		public static string PathForGeneratedClasses { get => default; }
		public static string PathForProjectAssets { get => default; }
		public static int TextFilterTimeOffsetSeconds { get => default; set {} }
	
		// Constructors
		public Config() {}
		static Config() {}
	
		// Methods
		public static T Get<T>()
			where T : Config => default;
	}
