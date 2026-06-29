// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SingleInputController : TLMViewModel
	{
		// Fields
		private const float DelayDuration = 5f;
		[ObservableValue]
		private bool _hasStartedInput;
		[ObservableValue]
		private bool _displayInputError;
		[ObservableValue]
		private bool _hasError;
		[ObservableValue]
		private string _input;
		[ObservableValue]
		private string _inputErrorMessage;
		[ObservableValue]
		private bool _inputMissing;
		[ObservableValue]
		private int _characterCount;
		private Coroutine delayedEndEditNotification;
		private AdvancedInputField inputField;
		public Func<bool> OnInputError;
		public System.Action OnResetError;
		public Action<string> OnInputValueChanged;
	
		// Properties
		[ObservableValue]
		public bool hasStartedInput { get => default; set {} }
		[ObservableValue]
		public bool displayInputError { get => default; set {} }
		[ObservableValue]
		public bool hasError { get => default; set {} }
		[ObservableValue]
		public string input { get => default; set {} }
		[ObservableValue]
		public string inputErrorMessage { get => default; set {} }
		[ObservableValue]
		public bool inputMissing { get => default; set {} }
		[ObservableValue]
		public int characterCount { get => default; set {} }
		public string TrimmedInput { get => default; }
	
		// Constructors
		public SingleInputController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Setup(AdvancedInputField inputField) {}
		private void OnBeginEdit(BeginEditReason _ = BeginEditReason.USER_SELECT) {}
		private void OnEndEditWithoutReason(string input = null) {}
		public void OnValueChanged(string input = null) {}
		[IteratorStateMachine(typeof(_DelayedEndEndEditNotificationCoroutine_d__42))]
		private IEnumerator DelayedEndEndEditNotificationCoroutine() => default;
		public void SetIsEditing(bool isEditing) {}
		protected virtual void InitInputFields() {}
		private void ResetInput() {}
		public virtual void ResetErrors() {}
		public void SetInput(string input) {}
		[UICallable]
		public void UpdateInput() {}
		public bool HasInputError() => default;
	}
