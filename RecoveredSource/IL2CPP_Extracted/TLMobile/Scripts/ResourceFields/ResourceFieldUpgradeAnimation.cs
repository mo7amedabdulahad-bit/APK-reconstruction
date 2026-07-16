// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.ResourceFields
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceFieldUpgradeAnimation : TLMViewModel
	{
		// Fields
		private FlashEffect flashEffect;
		public int slotId;
		public int landDistribution;
		[ObservableValue]
		private bool _isUpgrading;
		private int level;
		private Vector3 levelIndicatorPosition;
		private GameObject levelUpAnimationObject;
		private MeshFilter meshFilter;
		private MeshRenderer meshRenderer;
		private OwnVillage ownVillage;
		private PolygonCollider2D polygonCollider2D;
		private ResourceFieldsController resourceFieldsController;
		private GameObject upgradingAnimationObject;
		private ResourceFiledAnimationReferencer resourceFieldAnimationReferencer;
		private bool wasUpgrading;
	
		// Properties
		[ObservableValue]
		public bool isUpgrading { get => default; set {} }
	
		// Constructors
		public ResourceFieldUpgradeAnimation() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void Init() {}
		private void CurrentVillageChanged(OwnVillage curVillage) {}
		private void CacheResourceFieldLevel() {}
		public void TryPlayAnimations() {}
		private void TryPlayLevelUpAnimation() {}
		private void PlayLevelUpAnimation(int newLevel) {}
		private void InitializeLevelUpAnimation() {}
		private void TryPlayUpgradingAnimation() {}
		private void StopUpgradeAnimation(bool forceStop = false) {}
		private void InitializeUpgradingAnimation() {}
	}
