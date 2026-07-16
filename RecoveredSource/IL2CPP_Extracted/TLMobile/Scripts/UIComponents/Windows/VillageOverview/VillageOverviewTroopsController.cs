// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewTroopsController : VillageOverviewTabController
	{
		// Fields
		[ObservableValue]
		private TroopAmounts _troopsSum;
		[ObservableValue]
		private SubTab _currentSubTab;
		[ObservableValue]
		private int _in5minTime;
		[ObservableValue]
		private ObservableList<Building.TypeId> _buildingsToShow;
	
		// Properties
		[ObservableValue]
		public TroopAmounts troopsSum { get => default; set {} }
		[ObservableValue]
		public SubTab currentSubTab { get => default; set {} }
		[ObservableValue]
		public int in5minTime { get => default; set {} }
		[ObservableValue]
		public ObservableList<Building.TypeId> buildingsToShow { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			Training = 1,
			Troops = 2,
			Smithy = 3,
			Hospital = 4
		}
	
		// Constructors
		public VillageOverviewTroopsController() {}
	
		// Methods
		private void _buildingsToShowNotify(object sender, PropertyChangedEventArgs args) {}
		public override void OnOpen(int tabNumber) {}
		protected override void GatherVillageInformation(bool forceFetch) {}
		private void SetTroopAmounts(TroopAmounts troopAmounts, int tribeId, int number, int? amount) {}
		private bool DoesVillageHaveBuilding(OwnVillage v, Building.TypeId type) => default;
		private void UpdateTime() {}
		[UICallable]
		public void SetSubTab(SubTab subTab) {}
	}
