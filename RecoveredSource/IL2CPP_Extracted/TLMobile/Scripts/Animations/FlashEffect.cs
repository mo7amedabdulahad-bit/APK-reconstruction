// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class FlashEffect : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private UnityEngine.Color flashColor;
		[SerializeField]
		private float fadeInDuration;
		[SerializeField]
		private float fadeOutDuration;
		[SerializeField]
		private Ease flashEase;
		[SerializeField]
		private float flashFrequency;
		[SerializeField]
		private Renderer rend;
		private MaterialPropertyBlock propertyBlock;
		private Tween flashTween;
		private static readonly int FlashColorID;
		private static readonly int FlashAmountID;
		private static readonly int FlashFrequencyID;
	
		// Constructors
		public FlashEffect() {}
		static FlashEffect() {}
	
		// Methods
		private void OnDestroy() {}
		private void Awake() {}
		public void Setup(Renderer renderer) {}
		public void TriggerFlash(UnityEngine.Color? overrideColor = default, float? overrideFadeIn = default, float? overrideFrequency = default, Ease? overrideEase = default) {}
		public void StopFlash(float? overrideFadeOut = default, Ease? overrideEase = default) {}
	}
