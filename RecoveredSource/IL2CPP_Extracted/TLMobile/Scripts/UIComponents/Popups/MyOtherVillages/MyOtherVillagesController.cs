// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.MyOtherVillages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MyOtherVillagesController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<VillageWithDistance> _villagesWithDistances;
		[ObservableValue]
		private int _lockedVillageId;
		private Action<OwnVillage> callback;
		private OwnPlayer ownPlayer;
	
		// Properties
		[ObservableValue]
		public ObservableList<VillageWithDistance> villagesWithDistances { get => default; set {} }
		[ObservableValue]
		public int lockedVillageId { get => default; set {} }
	
		// Constructors
		public MyOtherVillagesController() {}
	
		// Methods
		private void _villagesWithDistancesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(Action<OwnVillage> callback, int blockVillageId = -1) {}
		private void UpdateVillageList() {}
		[UICallable]
		public void SelectVillage(OwnVillage village) {}
	}
