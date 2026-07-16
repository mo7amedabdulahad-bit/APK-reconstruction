// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CalendarInfoServerConfiguration : ObservableModel, IEquatable<CalendarInfoServerConfiguration>
	{
		// Fields
		[ObservableValue]
		private ObservableList<string> _languages;
		[ObservableValue]
		private ObservableList<CountryFlagEnum> _languageFlagIcons;
	
		// Properties
		[ObservableValue]
		public ObservableList<string> languages { get => default; set {} }
		[ObservableValue]
		public ObservableList<CountryFlagEnum> languageFlagIcons { get => default; set {} }
	
		// Constructors
		public CalendarInfoServerConfiguration() {}
		public CalendarInfoServerConfiguration(ApiCalendarInfoServerConfiguration apiCalendarInfoServerConfiguration) {}
	
		// Methods
		public ApiCalendarInfoServerConfiguration ToApiCalendarInfoServerConfiguration() => default;
		public bool Equals(CalendarInfoServerConfiguration other) => default;
		private void _languagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _languageFlagIconsNotify(object sender, PropertyChangedEventArgs args) {}
	}
