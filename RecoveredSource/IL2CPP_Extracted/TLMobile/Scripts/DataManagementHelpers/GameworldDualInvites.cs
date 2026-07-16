// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldDualInvites : ObservableModel, IEquatable<GameworldDualInvites>
	{
		// Fields
		[ObservableValue]
		private ObservableList<DualInvite> _dualInvites;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _gameworld;
		[ObservableValue]
		private string _avatarNameInDeletion;
	
		// Properties
		[ObservableValue]
		public ObservableList<DualInvite> dualInvites { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld { get => default; set {} }
		[ObservableValue]
		public string avatarNameInDeletion { get => default; set {} }
	
		// Constructors
		public GameworldDualInvites() {}
	
		// Methods
		public bool Equals(GameworldDualInvites other) => default;
		private void _dualInvitesNotify(object sender, PropertyChangedEventArgs args) {}
	}
