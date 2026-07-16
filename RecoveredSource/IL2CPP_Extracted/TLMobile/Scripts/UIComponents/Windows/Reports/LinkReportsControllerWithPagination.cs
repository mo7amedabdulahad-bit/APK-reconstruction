// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LinkReportsControllerWithPagination : DetailWindowTabControllerWithPagination<ReportInterface>
	{
		// Fields
		[ObservableValue]
		private ReportInterface _selectedReport;
	
		// Properties
		[ObservableValue]
		public ReportInterface selectedReport { get => default; set {} }
	
		// Constructors
		public LinkReportsControllerWithPagination() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void UpdateReports() {}
		[UICallable]
		public void OpenReport(ReportInterface report) {}
		[UICallable]
		public void SelectObject(ReportInterface reportInterface) {}
		private void UpdateReportSelectionState(ReportInterface reportInterface) {}
	}
