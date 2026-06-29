// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GameworldCalendarTab : DetailWindowTabController
	{
		// Fields
		private const int MinRefreshCooldown = 10;
		[ObservableValue]
		private ObservableList<CalendarEntry> _calendarEntries;
		[ObservableValue]
		private ObservableList<CalendarEntry> _newCalendarEntries;
		[ObservableValue]
		private ObservableList<CalendarMonth> _calendarMonths;
		[ObservableValue]
		private ObservableList<CalendarMonth> _newCalendarMonths;
		[ObservableValue]
		private long _nowUnix;
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Lobby.NotificationInterface> notifications;
		private List<CalendarEntry> _lastPastEntries;
		private int maxPastCalendarEntries;
		private int minPastCalendarDayShown;
	
		// Properties
		[ObservableValue]
		public ObservableList<CalendarEntry> calendarEntries { get => default; set {} }
		[ObservableValue]
		public ObservableList<CalendarEntry> newCalendarEntries { get => default; set {} }
		[ObservableValue]
		public ObservableList<CalendarMonth> calendarMonths { get => default; set {} }
		[ObservableValue]
		public ObservableList<CalendarMonth> newCalendarMonths { get => default; set {} }
		[ObservableValue]
		public long nowUnix { get => default; set {} }
	
		// Constructors
		public GameworldCalendarTab() {}
	
		// Methods
		private void _calendarEntriesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _newCalendarEntriesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _calendarMonthsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _newCalendarMonthsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		private void OnFetchRemoteCompleted(ConfigResponse configResponse) {}
		private void UpdateConfigData() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void FetchCalendarEntries() {}
		private void FilterNew(ObservableList<CalendarEntry> calendarEntries) {}
		private void UpdateCalendarInfo() {}
		private void UpdateCurrentInfo() {}
		[UICallable]
		public void OpenDetailedCalendarEntry(CalendarEntry calendarEntry) {}
		private void MarkNotificationsAsRead() {}
	}
