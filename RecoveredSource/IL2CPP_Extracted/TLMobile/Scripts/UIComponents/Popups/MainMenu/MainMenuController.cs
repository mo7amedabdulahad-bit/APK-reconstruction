// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.MainMenu
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MainMenuController : DetailWindowController
	{
		// Fields
		public RectTransform CloseButton;
		[ObservableValue]
		private ObservableList<Sitter> _sittersFor;
		[ObservableValue]
		private Account _account;
		[ObservableValue]
		private int _calendarNotificationCount;
		private bool isProcessingClick;
	
		// Properties
		[ObservableValue]
		public ObservableList<Sitter> sittersFor { get => default; set {} }
		[ObservableValue]
		public Account account { get => default; set {} }
		[ObservableValue]
		public int calendarNotificationCount { get => default; set {} }
	
		// Constructors
		public MainMenuController() {}
	
		// Methods
		private void _sittersForNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		private void UpdateSitters() {}
		private void SyncSitters() {}
		private void UpdateNewSitterSettings(ServerObject serverObject) {}
		private void RefreshNotificationCount() {}
		[UICallable]
		public void SwitchToSitter(Sitter sitter) {}
		[UICallable]
		public void SwitchToID(int id) {}
		[UICallable]
		public void Logout() {}
		[UICallable]
		public void OpenPlayerSurvey() {}
		[UICallable]
		public void OpenGameworldCalendar() {}
		[UICallable]
		public void OpenNews() {}
	}
