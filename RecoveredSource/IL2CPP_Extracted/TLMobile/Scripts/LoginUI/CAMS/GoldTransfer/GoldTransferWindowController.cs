// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS.GoldTransfer
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldTransferWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ViewState _viewState;
		[ObservableValue]
		private AvatarGameworldInfo _selectedAvatar;
		[ObservableValue]
		private string _goldAmount;
		[ObservableValue]
		private string _ownIdentityName;
		[ObservableValue]
		private bool _isLoggedIn;
		private DetailWindows previousWindowType;
		private Dictionary<string, string> gameworldIdToName;
	
		// Properties
		[ObservableValue]
		public ViewState viewState { get => default; set {} }
		[ObservableValue]
		public AvatarGameworldInfo selectedAvatar { get => default; set {} }
		[ObservableValue]
		public string goldAmount { get => default; set {} }
		[ObservableValue]
		public string ownIdentityName { get => default; set {} }
		[ObservableValue]
		public bool isLoggedIn { get => default; set {} }
		public string GtlCode { get; private set; }
		public string VerifiedEmail { get; internal set; }
		public IReadOnlyDictionary<string, string> GameworldIdToName { get => default; }
	
		// Nested types
		public enum ViewState
		{
			VerifyEmail = 0,
			SearchAvatar = 1,
			SelectSearchResultGameworld = 2,
			ConfirmTransfer = 3,
			TransferComplete = 4
		}
	
		// Constructors
		public GoldTransferWindowController() {}
	
		// Methods
		public void Setup(DetailWindows previousWindowType, string gtlCode, bool isLoggedIn) {}
		[UICallable]
		public void ReturnToGame() {}
		[UICallable]
		public void TransitionToSearchAvatar() {}
		[UICallable]
		public void ConfirmTransfer() {}
		[UICallable]
		public void TransitionViewState(ViewState viewState) {}
	}
