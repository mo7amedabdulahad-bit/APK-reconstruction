// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FireAndSmokeAnimationController : InjectableViewModel
	{
		// Fields
		public IntGameObjectDictionary animationPrefabs;
		[InjectableValue]
		[ObservableValue]
		private BuildingInfo _buildingInfo;
		private GameObject currentActiveAnimation;
		private Dictionary<int, GameObject> instantiatedPrefabs;
		public OwnVillage ownVillage;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public BuildingInfo buildingInfo { get => default; set {} }
	
		// Constructors
		public FireAndSmokeAnimationController() {}
	
		// Methods
		protected override void Awake() {}
		protected void OnEnable() {}
		private void OnDisable() {}
		public void Init() {}
		private void CurrentVillageChanged(OwnVillage village) {}
		public override void OnInjectedValueChanged() {}
		private void PlayAnimation() {}
	}
