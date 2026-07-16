// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerAvatarController : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private int _playerId;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public int playerId { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
	
		// Constructors
		public PlayerAvatarController() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
	}
