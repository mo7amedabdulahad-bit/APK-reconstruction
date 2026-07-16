// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldCalendarDetailsWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private CalendarEntry _calendarEntry;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Lobby.Gameworld _gameworld;
		[ObservableValue]
		private Avatar _avatar;
		[ObservableValue]
		private bool _hasStarted;
		[ObservableValue]
		private bool _canEnterGameworld;
		[ObservableValue]
		private bool _hasAlreadyJoinedGameworld;
		[ObservableValue]
		private bool _detailsAreStillComing;
		[ObservableValue]
		private bool _isLoggedIn;
		[ObservableValue]
		private bool _isLoggedInGameworld;
		private List<Avatar> allAvatars;
	
		// Properties
		[ObservableValue]
		public CalendarEntry calendarEntry { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Lobby.Gameworld gameworld { get => default; set {} }
		[ObservableValue]
		public Avatar avatar { get => default; set {} }
		[ObservableValue]
		public bool hasStarted { get => default; set {} }
		[ObservableValue]
		public bool canEnterGameworld { get => default; set {} }
		[ObservableValue]
		public bool hasAlreadyJoinedGameworld { get => default; set {} }
		[ObservableValue]
		public bool detailsAreStillComing { get => default; set {} }
		[ObservableValue]
		public bool isLoggedIn { get => default; set {} }
		[ObservableValue]
		public bool isLoggedInGameworld { get => default; set {} }
	
		// Constructors
		public GameworldCalendarDetailsWindowController() {}
	
		// Methods
		protected override void Awake() {}
		public void Setup(CalendarEntry calendarEntry) {}
		private bool DetailsAreStillComing() => default;
		[UICallable]
		public void PlayNow() {}
		[UICallable]
		public void JoinGameworld() {}
		[UICallable]
		public void GoToLogin() {}
	}
