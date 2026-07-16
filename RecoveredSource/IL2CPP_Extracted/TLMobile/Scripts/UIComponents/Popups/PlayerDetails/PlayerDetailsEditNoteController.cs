// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.PlayerDetails
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerDetailsEditNoteController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private string _playerNote;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public string playerNote { get => default; set {} }
	
		// Constructors
		public PlayerDetailsEditNoteController() {}
	
		// Methods
		public void Init(TLMobile.Generated.GraphQL.Game.Player player) {}
		[UICallable]
		public void Save() {}
	}
