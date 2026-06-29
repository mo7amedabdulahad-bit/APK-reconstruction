// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InputFieldHelper : InjectableViewModel
	{
		// Fields
		[SerializeField]
		private RectTransform rectTransformToRemainVisible;
		[SerializeField]
		private LayoutChangeListener layoutChangeListener;
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		private string _valueToEnforce;
		[ObservableValue]
		private bool _showPlaceHolder;
		[ObservableValue]
		private bool _isBeingEdited;
		private readonly Vector3[] corners;
		private AdvancedInputField inputField;
		private IDeviceFunctionsService deviceFunctionsService;
		private UnityEngine.Canvas rootCanvas;
		private ScrollRect scrollView;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public string valueToEnforce { get => default; set {} }
		[ObservableValue]
		public bool showPlaceHolder { get => default; set {} }
		[ObservableValue]
		public bool isBeingEdited { get => default; set {} }
	
		// Constructors
		public InputFieldHelper() {}
	
		// Methods
		protected override void Awake() {}
		private void OnEnable() {}
		private void OnDisable() {}
		public virtual void Init() {}
		private void EditStatusBegin(BeginEditReason reason) {}
		private void EditStatusEnd(string arg0, EndEditReason endEditReason) {}
		private void KeyboardHeightChanged(int unscaledKeyboardHeight) {}
		private void LayoutChanged() {}
		public void EnforceOnEditEnd() {}
		public void UpdateShowPlaceholder() {}
		private bool IsNullOrEmpty() => default;
		private void CheckForCover(int unscaledKeyboardHeight) {}
	}
