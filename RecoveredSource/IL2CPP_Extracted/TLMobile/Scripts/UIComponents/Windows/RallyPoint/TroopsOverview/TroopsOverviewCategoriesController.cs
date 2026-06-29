// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsOverviewCategoriesController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private ObservableDictionary<RallyPointTroopsOverviewItem.Category, RallyPointTroopsOverviewItem> _rallyPointTroopsOverviewItems;
		private TroopsMovementOverview troopsMovementOverview;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<RallyPointTroopsOverviewItem.Category, RallyPointTroopsOverviewItem> rallyPointTroopsOverviewItems { get => default; set {} }
	
		// Constructors
		public TroopsOverviewCategoriesController() {}
	
		// Methods
		private void _rallyPointTroopsOverviewItemsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		public void SetTroopsInfoForCategories() {}
		private void AddStaticCategory(RallyPointTroopsOverviewItem.Category category, TroopsPower powerObject) {}
		private void AddMovingCategory(RallyPointTroopsOverviewItem.Category category) {}
		private RallyPointTroopsOverviewItem InitTroopsItem(RallyPointTroopsOverviewItem.Category troopOverviewItemCategory, TroopsPower powerObject, int firstArrivalTime) => default;
	}
