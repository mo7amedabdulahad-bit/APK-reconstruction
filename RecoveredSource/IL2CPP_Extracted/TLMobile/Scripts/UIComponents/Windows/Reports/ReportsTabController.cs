// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class ReportsTabController : DetailWindowTabControllerWithPagination<ReportInterface>
	{
		// Fields
		[ObservableValue]
		private int _selectedReports;
	
		// Properties
		[ObservableValue]
		public int selectedReports { get; set; }
	
		// Constructors
		protected ReportsTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		public abstract void Init();
		private void UpdateReports() {}
		[UICallable]
		public override bool Refresh() => default;
		[UICallable]
		public void ToggleItemSelection(ServerObject item) {}
		[UICallable]
		public void OpenReport(ReportInterface report) {}
		[UICallable]
		public void DeleteReports() {}
		private void AfterDeleteReportsConfirmed() {}
		protected abstract void DeleteAllReports(IReportsApi reportsApi);
		private void DeleteSelectedReports(IReportsApi reportsApi) {}
		protected void CheckSelectedAfterRefresh() {}
	}
