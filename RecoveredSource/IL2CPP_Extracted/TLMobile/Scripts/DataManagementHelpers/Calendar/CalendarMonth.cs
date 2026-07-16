// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CalendarMonth : ObservableModel, IEquatable<CalendarMonth>
	{
		// Fields
		[ObservableValue]
		private string _month;
		[ObservableValue]
		private ObservableList<CalendarEntry> _newCalendarEntries;
	
		// Properties
		[ObservableValue]
		public string month { get => default; set {} }
		[ObservableValue]
		public ObservableList<CalendarEntry> newCalendarEntries { get => default; set {} }
	
		// Constructors
		public CalendarMonth() {}
		public CalendarMonth(string month, List<CalendarEntry> calendarEntries) {}
	
		// Methods
		public bool Equals(CalendarMonth other) => default;
		private void _newCalendarEntriesNotify(object sender, PropertyChangedEventArgs args) {}
	}
