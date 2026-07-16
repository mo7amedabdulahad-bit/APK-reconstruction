// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public abstract class VillageOverviewTabController : DetailWindowTabController
	{
		// Fields
		private int lastRefresh;
		protected VillageOverviewMainController mainController;
	
		// Constructors
		protected VillageOverviewTabController() {}
	
		// Methods
		protected override void OnDisable() {}
		public override void OnOpen(int tabNumber) {}
		private void VillageListChanged() {}
		protected abstract void GatherVillageInformation(bool forceFetch);
	}
