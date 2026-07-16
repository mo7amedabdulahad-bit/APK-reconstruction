// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Report.ReportMessage
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportMessagePopupController : ReportPopupController
	{
		// Fields
		[ObservableValue]
		private SpamReport.SpamReasonEnum _selectedReason;
		private TLMobile.Generated.GraphQL.Game.Message messageToReport;
	
		// Properties
		[ObservableValue]
		public SpamReport.SpamReasonEnum selectedReason { get => default; set {} }
	
		// Constructors
		public ReportMessagePopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Setup(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void ToggleAlsoBlock() {}
		[UICallable]
		public void ReportMessage() {}
		[UICallable]
		public void SelectReason(SpamReport.SpamReasonEnum reasonEnum) {}
	}
