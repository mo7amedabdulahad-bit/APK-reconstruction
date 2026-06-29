// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class FadedPanelController : ViewModel
	{
		// Fields
		[ObservableValue]
		protected bool _isOpen;
		[SerializeField]
		protected CanvasGroup menuCanvasGroup;
		[Help("The background image is optional.")]
		[SerializeField]
		protected UnityEngine.UI.Image backgroundImage;
		private UnityEngine.Color backgroundColorFull;
		private UnityEngine.Color backgroundColorTransparent;
		private DG.Tweening.Sequence mySequence;
	
		// Properties
		[ObservableValue]
		public bool isOpen { get; set; }
	
		// Constructors
		protected FadedPanelController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnDestroy() {}
		public virtual void Init(CanvasGroup canvasGroup, UnityEngine.UI.Image background) {}
		protected virtual void HandleOpening() {}
		protected virtual void HandleClosing() {}
		protected virtual void OnCompleteOpeningAnimation() {}
		protected virtual void OnCompleteClosingAnimation() {}
	}
