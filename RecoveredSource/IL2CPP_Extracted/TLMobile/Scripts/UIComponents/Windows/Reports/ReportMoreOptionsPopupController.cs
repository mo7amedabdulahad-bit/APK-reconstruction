// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportMoreOptionsPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ReportInterface _report;
		[ObservableValue]
		private bool _enableRepeatAttack;
		[ObservableValue]
		private bool _isCombatSimulatorValidReport;
	
		// Properties
		[ObservableValue]
		public ReportInterface report { get => default; set {} }
		[ObservableValue]
		public bool enableRepeatAttack { get => default; set {} }
		[ObservableValue]
		public bool isCombatSimulatorValidReport { get => default; set {} }
	
		// Constructors
		public ReportMoreOptionsPopupController() {}
	
		// Methods
		public void Setup(ReportInterface reportToShow) {}
		private bool CheckEnableRepeatAttack(ReportInterface report) => default;
		[UICallable]
		public void ShareReport() {}
		[UICallable]
		public void OpenCombatSimulator() {}
	}
