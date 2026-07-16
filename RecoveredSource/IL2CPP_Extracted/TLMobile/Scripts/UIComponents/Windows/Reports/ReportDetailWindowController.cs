// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportDetailWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ReportInterface _report;
		[ObservableValue]
		private bool _showMoreOptions;
		[ObservableValue]
		private ReportInterface _prevReport;
		[ObservableValue]
		private ReportInterface _nextReport;
	
		// Properties
		[ObservableValue]
		public ReportInterface report { get => default; set {} }
		[ObservableValue]
		public bool showMoreOptions { get => default; set {} }
		[ObservableValue]
		public ReportInterface prevReport { get => default; set {} }
		[ObservableValue]
		public ReportInterface nextReport { get => default; set {} }
		public PaginatedListProvider<ReportInterface> ReportsPaginateData { get; private set; }
	
		// Constructors
		public ReportDetailWindowController() {}
	
		// Methods
		protected override void OnDisable() {}
		public void Setup(ReportInterface reportToShow, PaginatedListProvider<ReportInterface> paginatedData = null) {}
		[UICallable]
		public void ShowMoreOptions() {}
		private void SearchNeighboringReports() {}
		[UICallable]
		public void OpenDifferentReport(ReportInterface report) {}
		private void MarkAsRead() {}
	}
