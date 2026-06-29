// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportsDeleteConfirmPopup : DetailWindowController
	{
		// Fields
		public const string ReportPopupConfirmationKey = "ReportPopupConfirmationKey";
		[ObservableValue]
		private int _selectedReports;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public int selectedReports { get => default; set {} }
	
		// Constructors
		public ReportsDeleteConfirmPopup() {}
	
		// Methods
		public void Setup(System.Action confirmCallback, int selectedReports) {}
		[UICallable]
		public void ConfirmDeleteReports() {}
		public void ToggleWarningPopup(bool toggled) {}
		public static bool ShouldShowDeleteConfirmPopup() => default;
	}
