// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CalendarInfo : ObservableModel, IEquatable<CalendarInfo>
	{
		// Fields
		[ObservableValue]
		private int _artefactsDate;
		[ObservableValue]
		private int _constructionPlansDate;
		[ObservableValue]
		private ObservableList<int> _tribes;
		[ObservableValue]
		private CalendarInfoServerConfiguration _serverConfiguration;
	
		// Properties
		[ObservableValue]
		public int artefactsDate { get => default; set {} }
		[ObservableValue]
		public int constructionPlansDate { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> tribes { get => default; set {} }
		[ObservableValue]
		public CalendarInfoServerConfiguration serverConfiguration { get => default; set {} }
	
		// Constructors
		public CalendarInfo() {}
		public CalendarInfo(ApiCalendarInfo apiCalendarInfo) {}
	
		// Methods
		public ApiCalendarInfo ToApiCalendarInfo() => default;
		public bool Equals(CalendarInfo other) => default;
		private void _tribesNotify(object sender, PropertyChangedEventArgs args) {}
	}
