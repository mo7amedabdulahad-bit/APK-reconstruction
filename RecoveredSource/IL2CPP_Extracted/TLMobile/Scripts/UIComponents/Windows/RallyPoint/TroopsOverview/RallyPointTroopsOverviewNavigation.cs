// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointTroopsOverviewNavigation : DetailWindowTabController
	{
		// Fields
		public RallyPointTroopsOverviewDetailsController troopsOverviewDetailsController;
		[ObservableValue]
		private TroopsOverviewPageState _currentState;
	
		// Properties
		[ObservableValue]
		public TroopsOverviewPageState currentState { get => default; set {} }
	
		// Constructors
		public RallyPointTroopsOverviewNavigation() {}
	
		// Methods
		protected override void OnEnable() {}
		[UICallable]
		public virtual void GoToPage(TroopsOverviewPageState state) {}
		public virtual void OpenDetailsOnCategory(RallyPointTroopsOverviewItem.Category category) {}
	}
