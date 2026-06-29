// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Animations
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendPayoffAnimationController : MonoBehaviour
	{
		// Fields
		[Header("References")]
		[SerializeField]
		private ParticleSystem particles;
		[SerializeField]
		private UnityEngine.UI.Image blackBackgroundImage;
		[SerializeField]
		private UnityEngine.UI.Image goldenRingImage;
		[SerializeField]
		private UnityEngine.UI.Image mainImage;
		[SerializeField]
		private UnityEngine.UI.Image verticalGlowImage;
		[SerializeField]
		private UnityEngine.UI.Image horizontalGlowImage;
		[SerializeField]
		private UnityEngine.UI.Image spikyGlowImage;
		[SerializeField]
		private TextMeshProUGUI titleText;
		[Header("Animation Settings")]
		[SerializeField]
		private float animationDuration;
		[SerializeField]
		private float elementsEmergeDuration;
		[SerializeField]
		private float startDelay;
		private DG.Tweening.Sequence mainSequence;
		private Tween rotationTween;
	
		// Constructors
		public SendPayoffAnimationController() {}
	
		// Methods
		protected void OnDestroy() {}
		public void Stop() {}
		public void Play() {}
	}
