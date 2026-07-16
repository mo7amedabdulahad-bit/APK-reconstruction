// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CalendarEntry : ObservableModel, IEquatable<CalendarEntry>
	{
		// Fields
		[ObservableValue]
		private string _id;
		[ObservableValue]
		private string _uuid;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _domain;
		[ObservableValue]
		private int _start;
		[ObservableValue]
		private int _end;
		[ObservableValue]
		private CalendarMetadata _metadata;
		[ObservableValue]
		private CalendarFlags _flags;
		[ObservableValue]
		private CalendarInfo _info;
		[ObservableValue]
		private DateTime _startDate;
		[ObservableValue]
		private string _calendarStartDate;
		[ObservableValue]
		private string _calendarStartDay;
		[ObservableValue]
		private string _calendarStartWeekDay;
		[ObservableValue]
		private string _xSpeed;
		[ObservableValue]
		private string _displayName;
		[ObservableValue]
		private CalendarHighlight _calendarHighlight;
		[ObservableValue]
		private bool _current;
		[ObservableValue]
		private bool _isLocaServer;
		[ObservableValue]
		private bool _isMobileOnly;
		[ObservableValue]
		private bool _isSpecial;
		[ObservableValue]
		private bool _isNewOrChangedEntry;
	
		// Properties
		[ObservableValue]
		public string id { get => default; set {} }
		[ObservableValue]
		public string uuid { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string domain { get => default; set {} }
		[ObservableValue]
		public int start { get => default; set {} }
		[ObservableValue]
		public int end { get => default; set {} }
		[ObservableValue]
		public CalendarMetadata metadata { get => default; set {} }
		[ObservableValue]
		public CalendarFlags flags { get => default; set {} }
		[ObservableValue]
		public CalendarInfo info { get => default; set {} }
		[ObservableValue]
		public DateTime startDate { get => default; set {} }
		[ObservableValue]
		public string calendarStartDate { get => default; set {} }
		[ObservableValue]
		public string calendarStartDay { get => default; set {} }
		[ObservableValue]
		public string calendarStartWeekDay { get => default; set {} }
		[ObservableValue]
		public string xSpeed { get => default; set {} }
		[ObservableValue]
		public string displayName { get => default; set {} }
		[ObservableValue]
		public CalendarHighlight calendarHighlight { get => default; set {} }
		[ObservableValue]
		public bool current { get => default; set {} }
		[ObservableValue]
		public bool isLocaServer { get => default; set {} }
		[ObservableValue]
		public bool isMobileOnly { get => default; set {} }
		[ObservableValue]
		public bool isSpecial { get => default; set {} }
		[ObservableValue]
		public bool isNewOrChangedEntry { get => default; set {} }
	
		// Nested types
		public enum CalendarHighlight
		{
			None = 0,
			Restricted = 1,
			Special = 2,
			MobileOnly = 3
		}
	
		// Constructors
		public CalendarEntry() {}
		public CalendarEntry(InlineResponse20010 inlineResponse20010) {}
	
		// Methods
		public bool Equals(CalendarEntry other) => default;
		private string FormatWeekday(DateTime date) => default;
	}
