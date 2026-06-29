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
