// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LobbyJoinNewGameworldInviteCodePopupController : DetailWindowController
	{
		// Fields
		private const int MaxCharacterCount = 22;
		private const string characterCountMissmatchTranslationKey = "cams_lobby_gameworld_inviteCodeErrorCharacterCount";
		private const string placeholderTextTranslationKey = "cams_lobby_gameworld_inviteCodePlaceholder";
		[SerializeField]
		private AdvancedInputField inputField;
		[ObservableValue]
		private int _maxCharacterCount;
		[ObservableValue]
		private string _placeholderTextTranslated;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _gameworld;
		[ObservableValue]
		private long _blockedUntil;
		[ObservableValue]
		private SingleInputController _inviteCodeInputController;
		private string backendError;
		private DateTime blockedUntilDate;
	
		// Properties
		[ObservableValue]
		public int maxCharacterCount { get => default; set {} }
		[ObservableValue]
		public string placeholderTextTranslated { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld { get => default; set {} }
		[ObservableValue]
		public long blockedUntil { get => default; set {} }
		[ObservableValue]
		public SingleInputController inviteCodeInputController { get => default; set {} }
	
		// Constructors
		public LobbyJoinNewGameworldInviteCodePopupController() {}
	
		// Methods
		private void Update() {}
		public void Setup(TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld) {}
		[UICallable]
		public void OpenAvatarCreation() {}
		private void CalculateTimeLeft() {}
		private bool HasInputError() => default;
		private void OnResetError() {}
	}
