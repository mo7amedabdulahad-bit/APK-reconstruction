// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmDeleteMessagesPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private int _selectedMessages;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public int selectedMessages { get => default; set {} }
	
		// Constructors
		public ConfirmDeleteMessagesPopupController() {}
	
		// Methods
		public void Setup(System.Action confirmCallback, int selectedMessages) {}
		[UICallable]
		public void ConfirmDeleteMessages() {}
	}
