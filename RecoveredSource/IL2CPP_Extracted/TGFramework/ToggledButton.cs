// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ToggledButton : ViewModel, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		// Fields
		[ObservableValue]
		[SerializeField]
		private bool _blockDisabledRequests;
		private bool isOver;
		private bool isDown;
		[ObservableValue]
		[SerializeField]
		private bool _isToggled;
		[ObservableValue]
		[SerializeField]
		private bool _isDisabled;
		[ObservableValue]
		private State _currentState;
		private State lastState;
		public UnityEngine.UI.Image targetImage;
		public UnityEngine.UI.Image[] targetImages;
		public TextMeshProUGUI[] targetTexts;
		public Transition transition;
		public ToggledButton masterColors;
		public Sprite[] sprites;
		public UnityEngine.Color[] colors;
		public float fadeDuration;
		[ObservableValue]
		[SerializeField]
		public bool allowClicksWhileDisabled;
		public bool useOriginalColor;
		private float startFadeTime;
		private UnityEngine.Color?[] initialColor;
		private UnityEngine.Color[] startFadeColor;
		private UnityEngine.Color[] destFadeColor;
		private bool updateLoopInitialized;
		private bool shouldDoUpdateLoop;
	
		// Properties
		[ObservableValue]
		public bool isToggled { get => default; set {} }
		[ObservableValue]
		public bool isDisabled { get => default; set {} }
		[ObservableValue]
		public State currentState { get => default; set {} }
		[ObservableValue]
		public bool blockDisabledRequests { get => default; set {} }
		[ObservableValue]
		public bool AllowClicksWhileDisabled { get => default; set {} }
	
		// Nested types
		public enum Transition
		{
			ColorTint = 0,
			SpriteSwap = 1,
			None = 2,
			ColorTintText = 3,
			ColorTintArray = 4
		}
	
		public enum State
		{
			Normal = 0,
			Hover = 1,
			Pressed = 2,
			Toggled = 3,
			Disabled = 4
		}
	
		// Constructors
		public ToggledButton() {}
	
		// Methods
		protected void Start() {}
		public State GetStateToUse() => default;
		public void UpdateImage() {}
		private void UpdateTextSprites(TextMeshProUGUI textMeshProUGUI, UnityEngine.Color color) {}
		protected void DoUpdate() {}
		public void OnDisable() {}
		public void OnEnable() {}
		public void OnPointerEnter(PointerEventData eventData) {}
		public void OnPointerExit(PointerEventData eventData) {}
		public void OnPointerDown(PointerEventData eventData) {}
		public void OnPointerUp(PointerEventData eventData) {}
		public bool TryChangeIsDisabled(bool value) => default;
	}
