// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Report.ReportPlayer
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportPlayerPopupController : ReportPopupController
	{
		// Fields
		[ObservableValue]
		private AccusePlayer.ReasonEnum _selectedReason;
		[ObservableValue]
		private DropdownOption _selectedOption;
		private ObservableList<DropdownOption> options;
		private TLMobile.Generated.GraphQL.Game.Player playerToReport;
	
		// Properties
		[ObservableValue]
		public AccusePlayer.ReasonEnum selectedReason { get => default; set {} }
		[ObservableValue]
		public DropdownOption selectedOption { get => default; set {} }
	
		// Constructors
		public ReportPlayerPopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Setup(TLMobile.Generated.GraphQL.Game.Player player) {}
		private void ReasonChanged(DropdownOption option) {}
		[UICallable]
		public void OpenDropdown() {}
		[UICallable]
		public void ToggleAlsoBlock() {}
		[UICallable]
		public void ReportPlayer() {}
	}
