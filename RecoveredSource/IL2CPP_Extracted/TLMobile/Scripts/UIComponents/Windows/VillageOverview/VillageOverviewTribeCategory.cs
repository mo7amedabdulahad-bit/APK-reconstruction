// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageOverviewTribeCategory : ObservableModel
	{
		// Fields
		[ObservableValue]
		private bool _expandedView;
		[ObservableValue]
		private OwnPlayer.TribeId _tribeId;
		[ObservableValue]
		private ObservableList<OwnVillageWithOverviewInfos> _villages;
		[ObservableValue]
		private TroopAmounts _troopsSum;
	
		// Properties
		[ObservableValue]
		public bool expandedView { get => default; set {} }
		[ObservableValue]
		public OwnPlayer.TribeId tribeId { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnVillageWithOverviewInfos> villages { get => default; set {} }
		[ObservableValue]
		public TroopAmounts troopsSum { get => default; set {} }
	
		// Constructors
		public VillageOverviewTribeCategory() {}
		public VillageOverviewTribeCategory(bool expanded, OwnPlayer.TribeId id, ObservableList<OwnVillageWithOverviewInfos> villages) {}
	
		// Methods
		private void _villagesNotify(object sender, PropertyChangedEventArgs args) {}
		public void UpdateTroopsSum() {}
	}
