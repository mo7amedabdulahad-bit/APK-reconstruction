// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageBuildingController : InjectableViewModel
	{
		// Fields
		public bool showAnimations;
		public SpriteRenderer dayImage;
		public SpriteRenderer nightImage;
		public FireAndSmokeAnimationController fireAndSmokeAnimation;
		public BuildingUpgradeAnimationController buildingUpgradeAnimation;
		public MonoBehaviour harbourShipsDay;
		public MonoBehaviour harbourShipsNight;
		[InjectableValue]
		[ObservableValue]
		private BuildingInfo _buildingInfo;
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private Wall _wallData;
		private BuildingInfo currentBuildingInfo;
		private BuildingUpgradeAnimationController currentBuildingUpgradeAnimation;
		[Testable]
		private FireAndSmokeAnimationController currentFireAndSmokeAnimation;
		private MonoBehaviour currentHarbourShipsDay;
		private MonoBehaviour currentHarbourShipsNight;
		private Smithy smithy;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public BuildingInfo buildingInfo { get => default; set {} }
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public Wall wallData { get => default; set {} }
	
		// Constructors
		public VillageBuildingController() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		private T InstantiateAnimation<T>(T prefab, Transform parent)
			where T : MonoBehaviour => default;
		private void CheckForInitAnimation<T>(ref ref T obj, T animation, Transform parent = null)
			where T : MonoBehaviour {}
		private void SetupBuildingExtension() {}
		private void SetupBuildingObserversAndAnimations() {}
		[Testable]
		private void UpdateFireAndSmokeAnimation() {}
		private void UpdateBuildingUpgradeAnimation() {}
		private void UpdateHarbour() {}
	}
