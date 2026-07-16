// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ConfirmRemoveSitterPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
	
		// Constructors
		public ConfirmRemoveSitterPopupController() {}
	
		// Methods
		public void Setup(Sitter sitter, System.Action confirmCallback) {}
		[UICallable]
		public void Remove() {}
	}
