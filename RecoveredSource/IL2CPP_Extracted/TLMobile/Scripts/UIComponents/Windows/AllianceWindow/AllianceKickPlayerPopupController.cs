// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceKickPlayerPopupController : DetailWindowController
	{
		// Fields
		public AdvancedInputField password;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private bool _hasError;
		[ObservableValue]
		private bool _confirmButtonDisabled;
		[ObservableValue]
		private string _errorMessage;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public bool hasError { get => default; set {} }
		[ObservableValue]
		public bool confirmButtonDisabled { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
	
		// Constructors
		public AllianceKickPlayerPopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Setup(TLMobile.Generated.GraphQL.Game.Player playerToKick) {}
		private void InputChanged(string input) {}
		[UICallable]
		public void KickPlayer() {}
	}
