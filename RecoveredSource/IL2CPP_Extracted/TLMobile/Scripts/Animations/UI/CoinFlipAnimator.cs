// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.UI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CoinFlipAnimator : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private RectTransform frontImage;
		[SerializeField]
		private RectTransform backImage;
		[SerializeField]
		private float flipDuration;
		[SerializeField]
		private float holdDuration;
		[SerializeField]
		private Ease flipEase;
		[SerializeField]
		private bool autoStart;
		private DG.Tweening.Sequence flipSequence;
	
		// Constructors
		public CoinFlipAnimator() {}
	
		// Methods
		private void OnEnable() {}
		private void OnDisable() {}
		[ContextMenu("Play")]
		public void Play() {}
		public void Stop() {}
	}
