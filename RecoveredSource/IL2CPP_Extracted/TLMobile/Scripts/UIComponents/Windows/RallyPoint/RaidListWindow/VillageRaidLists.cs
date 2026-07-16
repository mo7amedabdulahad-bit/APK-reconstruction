// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageRaidLists : ObservableModel
	{
		// Fields
		[ObservableValue]
		private OwnVillage _village;
		[ObservableValue]
		private ObservableList<FarmList> _raidLists;
		[ObservableValue]
		private bool _expanded;
	
		// Properties
		[ObservableValue]
		public OwnVillage village { get => default; set {} }
		[ObservableValue]
		public ObservableList<FarmList> raidLists { get => default; set {} }
		[ObservableValue]
		public bool expanded { get => default; set {} }
	
		// Constructors
		public VillageRaidLists() {}
	
		// Methods
		private void _raidListsNotify(object sender, PropertyChangedEventArgs args) {}
	}
