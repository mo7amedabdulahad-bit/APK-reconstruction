// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.LobbyAccountDeletion
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LobbyAccountDeletionPopupController : DetailWindowController
	{
		// Fields
		private const string requestedWordKey = "admin.loeschen";
		[HideInInspector]
		public DatabindingReceiverFeeder myFeeder;
		[ObservableValue]
		private GraphQLFetchableList<Avatar> _ownAvatars;
		[ObservableValue]
		private bool _allAvatarsInDeletion;
		[ObservableValue]
		private bool _confirmationCorrect;
		[ObservableValue]
		private string _requiredWordToType;
		[InjectableValue]
		[ObservableValue]
		private string _playerInput;
		[ObservableValue]
		private bool _playerInputError;
		[ObservableValue]
		private int _ignoredAvatarCount;
	
		// Properties
		[ObservableValue]
		public GraphQLFetchableList<Avatar> ownAvatars { get => default; set {} }
		[ObservableValue]
		public bool allAvatarsInDeletion { get => default; set {} }
		[ObservableValue]
		public bool confirmationCorrect { get => default; set {} }
		[ObservableValue]
		public string requiredWordToType { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public string playerInput { get => default; set {} }
		[ObservableValue]
		public bool playerInputError { get => default; set {} }
		[ObservableValue]
		public int ignoredAvatarCount { get => default; set {} }
	
		// Constructors
		public LobbyAccountDeletionPopupController() {}
	
		// Methods
		private void _ownAvatarsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void OnInjectedValueChanged() {}
		private void ResetState() {}
		private void CheckAvatarInDeletion() {}
		private void CheckConfirmationInputMatches() {}
		[UICallable]
		public bool FilterIndexAvatar(Avatar avatar) => default;
		[UICallable]
		public void OnActionButtonClick() {}
	}
