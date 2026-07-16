// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldCalendarWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnIdentity _ownIdentity;
		[ObservableValue]
		private bool _isLoggedIn;
		private DetailWindows? previousWindowType;
		private int previousTabIndex;
		private bool isInGame;
	
		// Properties
		[ObservableValue]
		public OwnIdentity ownIdentity { get => default; set {} }
		[ObservableValue]
		public bool isLoggedIn { get => default; set {} }
	
		// Constructors
		public GameworldCalendarWindowController() {}
	
		// Methods
		public void Setup(DetailWindows? previousWindowType = default, int? previousTabIndex = default) {}
		public void SetupInGame() {}
		protected override void OnEnable() {}
		[UICallable]
		public void Back() {}
		[UICallable]
		public void OpenMenu() {}
		[UICallable]
		public void ShareLink() {}
	}
