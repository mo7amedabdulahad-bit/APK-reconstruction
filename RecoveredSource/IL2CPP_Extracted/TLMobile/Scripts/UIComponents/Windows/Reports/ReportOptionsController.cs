// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportOptionsController : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private ReportInterface _report;
		[ObservableValue]
		private bool _isRepeatableReport;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public ReportInterface report { get => default; set {} }
		[ObservableValue]
		public bool isRepeatableReport { get => default; set {} }
	
		// Constructors
		public ReportOptionsController() {}
	
		// Methods
		public override void OnInjectedValueChanged() {}
		[UICallable]
		public void ArchiveReport() {}
		[UICallable]
		public void MarkAsUnread() {}
		[UICallable]
		public void DoRepeatAttack() {}
		[UICallable]
		public void AddToFarmlist() {}
		[UICallable]
		public void DeleteReport() {}
		private void AfterDeleteReportsConfirmed() {}
		private void OnReportActionSuccessful(string toastMessageTranslateKey) {}
	}
