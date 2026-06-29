// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Animations.UI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UIBumpAnimator : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private RectTransform target;
		[SerializeField]
		private float bumpDistance;
		[SerializeField]
		private float bumpDuration;
		[SerializeField]
		private Ease bumpEase;
		[SerializeField]
		private bool loop;
		[SerializeField]
		private bool autoStart;
		[SerializeField]
		private LoopType loopType;
		private DG.Tweening.Sequence bumpSequence;
		private Vector3 initialPosition;
	
		// Constructors
		public UIBumpAnimator() {}
	
		// Methods
		private void Awake() {}
		private void OnEnable() {}
		private void OnDisable() {}
		[ContextMenu("Play")]
		public void Play() {}
		public void Stop() {}
	}
