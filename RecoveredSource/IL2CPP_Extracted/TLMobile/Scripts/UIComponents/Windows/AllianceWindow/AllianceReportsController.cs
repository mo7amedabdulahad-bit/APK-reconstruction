// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceReportsController : DetailWindowTabControllerWithPagination<AllianceReport>
	{
		// Fields
		[ObservableValue]
		private int _activeFiltersCount;
	
		// Properties
		[ObservableValue]
		public int activeFiltersCount { get => default; set {} }
	
		// Constructors
		public AllianceReportsController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void Init() {}
		private void ApplyFilters(GraphQLObservableList<ReportIcon> filters) {}
		private void UpdateReports() {}
		[UICallable]
		public void OpenReport(AllianceReport report) {}
	}
