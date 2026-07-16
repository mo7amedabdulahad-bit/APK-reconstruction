// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers.Calendar
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InjectableCalendarEntry : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private CalendarEntry _calendarEntry;
	
		// Properties
		[InjectableValue(hasToBeSet = false)]
		[ObservableValue]
		public CalendarEntry calendarEntry { get => default; set {} }
	
		// Constructors
		public InjectableCalendarEntry() {}
	}
