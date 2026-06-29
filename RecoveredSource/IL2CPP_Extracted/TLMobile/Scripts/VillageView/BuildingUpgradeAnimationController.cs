// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.VillageView
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingUpgradeAnimationController : InjectableViewModel
	{
		// Fields
		[SerializeField]
		private FlashEffect shaderControllerDay;
		[SerializeField]
		private FlashEffect shaderControllerNight;
		[SerializeField]
		private ParticleSystem particleSystem;
		[SerializeField]
		private GameObject levelUpText;
		[InjectableValue]
		[ObservableValue]
		private BuildingInfo _buildingInfo;
		private BuildingInfo currentBuildingInfo;
		private float lastVillageChange;
		private int level;
		private int oldBuildingId;
		private bool upgradeAnimationIsPlaying;
		private DG.Tweening.Sequence levelUpTextSequence;
		private Vector3 levelUpTextInitialPosition;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public BuildingInfo buildingInfo { get => default; set {} }
	
		// Constructors
		public BuildingUpgradeAnimationController() {}
	
		// Methods
		protected override void Awake() {}
		protected void OnEnable() {}
		protected void OnDisable() {}
		public void SetRenderTargets(Renderer day, Renderer night) {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		public override void OnInjectedValueChanged() {}
		private void SetUpgradeLoopAnimationState() {}
		private void TryPlayLevelUpAnimation() {}
		private void InitializeAnimations() {}
		private void CacheBuildingInfo() {}
	}
