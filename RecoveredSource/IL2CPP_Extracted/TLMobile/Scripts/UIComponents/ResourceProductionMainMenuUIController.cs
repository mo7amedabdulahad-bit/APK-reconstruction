// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourceProductionMainMenuUIController : ViewModel
	{
		// Fields
		[Header("References")]
		[SerializeField]
		private CanvasGroup backgroundShineCanvasGroup;
		[SerializeField]
		private GameObject starParticles;
		[Header("Animation Settings")]
		[SerializeField]
		private float backgroundShineAnimationDuration;
		private Tween alphaTween;
		private Coroutine starParticlesCoroutine;
		private SceneStatus currentSceneStatus;
	
		// Constructors
		public ResourceProductionMainMenuUIController() {}
	
		// Methods
		[UICallable]
		public virtual void ShowAdvantagesShopTab() {}
		protected void OnEnable() {}
		protected override void OnDestroy() {}
		[IteratorStateMachine(typeof(_DeactivateAfterDuration_d__9))]
		private IEnumerator DeactivateAfterDuration(float duration) => default;
		private void StartStarAnimation() {}
		private void StartBackgroundShineAnimation() {}
	}
