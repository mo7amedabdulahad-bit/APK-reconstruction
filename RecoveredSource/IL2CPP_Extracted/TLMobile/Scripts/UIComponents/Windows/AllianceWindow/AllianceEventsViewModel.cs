// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceEventsViewModel : TLMViewModel
	{
		// Fields
		public const int MaxNews = 50;
		[ObservableValue]
		private AllianceEventPagination _allianceEvents;
	
		// Properties
		[ObservableValue]
		public AllianceEventPagination allianceEvents { get => default; set {} }
	
		// Constructors
		public AllianceEventsViewModel() {}
	
		// Methods
		public void Setup(int eventsToShow) {}
	}
