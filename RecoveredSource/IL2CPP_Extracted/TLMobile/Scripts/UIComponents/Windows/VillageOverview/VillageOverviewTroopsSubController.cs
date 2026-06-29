// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewTroopsSubController : DetailWindowTabController
	{
		// Fields
		public VillageOverviewMainController mainController;
		[ObservableValue]
		private bool _keepTribeIdOnConquerFlag;
		[ObservableValue]
		private ObservableList<VillageOverviewTribeCategory> _tribeCategories;
	
		// Properties
		[ObservableValue]
		public bool keepTribeIdOnConquerFlag { get => default; set {} }
		[ObservableValue]
		public ObservableList<VillageOverviewTribeCategory> tribeCategories { get => default; set {} }
	
		// Constructors
		public VillageOverviewTroopsSubController() {}
	
		// Methods
		private void _tribeCategoriesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void VillageListChanged() {}
		[UICallable]
		public void SwitchExpandedView(OwnPlayer.TribeId tribeId) {}
	}
