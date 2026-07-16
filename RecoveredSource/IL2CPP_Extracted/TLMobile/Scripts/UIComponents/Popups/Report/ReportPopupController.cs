// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Report
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class ReportPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		protected string _reasonText;
		[ObservableValue]
		protected bool _alsoBlockPlayer;
	
		// Properties
		[ObservableValue]
		public string reasonText { get; set; }
		[ObservableValue]
		public bool alsoBlockPlayer { get; set; }
	
		// Constructors
		protected ReportPopupController() {}
	
		// Methods
		protected void BlockPlayer(TLMobile.Generated.GraphQL.Game.Player playerToReport) {}
	}
