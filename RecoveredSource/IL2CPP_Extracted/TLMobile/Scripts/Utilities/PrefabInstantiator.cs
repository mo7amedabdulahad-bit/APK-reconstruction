// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PrefabInstantiator : InjectableViewModel
	{
		// Fields
		public IntGameObjectDictionary prefabs;
		private readonly Dictionary<int, GameObject> oldInstantiatedPrefabs;
		[InjectableValue]
		[ObservableValue]
		private int _chosenPrefabNumber;
		private int oldPrefabNumber;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public int chosenPrefabNumber { get => default; set {} }
		public GameObject InstantiatedPrefab { get; private set; }
	
		// Constructors
		public PrefabInstantiator() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
	}
