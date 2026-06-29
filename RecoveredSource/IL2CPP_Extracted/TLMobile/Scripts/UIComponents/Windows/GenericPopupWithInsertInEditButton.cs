// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericPopupWithInsertInEditButton : DetailWindowController
	{
		// Fields
		private const float ButtonVisibleAfterKeyboard = 0.5f;
		public List<AdvancedInputField> inputFields;
		[ObservableValue]
		private bool _showButton;
		private int lastCaretPosition;
		private AdvancedInputField lastFocused;
		private float timeSinceKeyboardCollapsed;
	
		// Properties
		[ObservableValue]
		public bool showButton { get => default; set {} }
	
		// Constructors
		public GenericPopupWithInsertInEditButton() {}
	
		// Methods
		private void Update() {}
		protected override void OnEnable() {}
		protected void InsertInActiveInputField(string text) {}
		protected void ReselectInputField() {}
	}
