// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LazyRenderingObject : InjectableViewModel
	{
		// Fields
		public static Dictionary<GameObject, List<GameObject>> instancePool;
		public InstantiationType instantiationType;
		public GameObject singlePrefab;
		public IntGameObjectDictionary prefabs;
		public bool preventCleanup;
		public bool watchForPrefabNumberChanges;
		[InjectableValue]
		[ObservableValue]
		private int _chosenPrefabNumber;
		[ObservableValue]
		private bool _isOrWasVisible;
		[ObservableValue]
		private bool _isVisible;
		[ObservableValue]
		private bool _fullyVisible;
		private bool didSetHeightOnDisable;
		public KeyValuePair<GameObject, GameObject> instantiatedPrefab;
		private LayoutElement layoutElement;
		private LazyRenderingParent scrollParent;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public int chosenPrefabNumber { get => default; set {} }
		[ObservableValue]
		public bool isOrWasVisible { get => default; set {} }
		[ObservableValue]
		public bool isVisible { get => default; set {} }
		[ObservableValue]
		public bool fullyVisible { get => default; set {} }
	
		// Nested types
		public enum InstantiationType
		{
			TakeChild = 0,
			SinglePrefab = 1,
			MultipleChoice = 2,
			Nothing = 3
		}
	
		// Constructors
		public LazyRenderingObject() {}
		static LazyRenderingObject() {}
	
		// Methods
		protected override void Awake() {}
		protected void OnEnable() {}
		protected void OnDisable() {}
		public bool UpdateVisibleCorners(int visibleCorners) => default;
		private void SetVisible() {}
		public void ForceRecreate() {}
		private GameObject CreateInstanceOf(GameObject prefab) => default;
		private void SetInvisible() {}
	}
