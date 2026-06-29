// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.HarbourWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HarbourTrainingTabController : UnitsTrainingTabController
	{
		// Fields
		private const string NoStationedShipsKey = "harbour_noAvailableShips";
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private bool _maxShipsBuilt;
	
		// Properties
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public bool maxShipsBuilt { get => default; set {} }
	
		// Constructors
		public HarbourTrainingTabController() {}
	
		// Methods
		protected override void CurrentVillageChanged(OwnVillage newVill) {}
		public override void SetupCurrentVillage() {}
		protected override void SetupTrainableUnits() {}
		[UICallable]
		public override void Train() {}
		[UICallable]
		public void OpenDestroyShipPopup() {}
	}
