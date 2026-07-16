// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.HospitalWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HospitalWoundedTabController : UnitsTrainingTabController
	{
		// Fields
		[ObservableValue]
		private int _maxHealable;
		[ObservableValue]
		private int _allUnitsCount;
		private Hospital hospital;
		private int oldSelectedUnitId;
		private Building usedBuilding;
	
		// Properties
		[ObservableValue]
		public int maxHealable { get => default; set {} }
		[ObservableValue]
		public int allUnitsCount { get => default; set {} }
	
		// Constructors
		public HospitalWoundedTabController() {}
	
		// Methods
		protected override void CurrentVillageChanged(OwnVillage newVill) {}
		public override void SetupCurrentVillage() {}
		protected override void SetupTrainableUnits() {}
		[UICallable]
		public override void Fill() {}
		[UICallable]
		public override void Train() {}
	}
