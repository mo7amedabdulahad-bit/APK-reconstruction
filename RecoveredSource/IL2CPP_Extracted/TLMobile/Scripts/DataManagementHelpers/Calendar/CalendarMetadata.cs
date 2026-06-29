// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CalendarMetadata : ObservableModel, IEquatable<CalendarMetadata>
	{
		// Fields
		[ObservableValue]
		private string _type;
		[ObservableValue]
		private ObservableList<ApiCalendarMetadata.FilterEnum> _filter;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private string _subtitle;
		[ObservableValue]
		private string _mainpageBackground;
		[ObservableValue]
		private int _speed;
	
		// Properties
		[ObservableValue]
		public string type { get => default; set {} }
		[ObservableValue]
		public ObservableList<ApiCalendarMetadata.FilterEnum> filter { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public string subtitle { get => default; set {} }
		[ObservableValue]
		public string mainpageBackground { get => default; set {} }
		[ObservableValue]
		public int speed { get => default; set {} }
	
		// Constructors
		public CalendarMetadata() {}
		public CalendarMetadata(ApiCalendarMetadata apiCalendarMetadata) {}
	
		// Methods
		public bool Equals(CalendarMetadata other) => default;
		private void _filterNotify(object sender, PropertyChangedEventArgs args) {}
	}
