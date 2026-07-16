// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TrapperWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TrapperConstructTabController : UnitsTrainingTabController
	{
		// Fields
		[ObservableValue]
		private Trapper _trapper;
		[ObservableValue]
		private bool _maxTrapsBuilt;
	
		// Properties
		[ObservableValue]
		public Trapper trapper { get => default; set {} }
		[ObservableValue]
		public bool maxTrapsBuilt { get => default; set {} }
	
		// Constructors
		public TrapperConstructTabController() {}
	
		// Methods
		protected override void CurrentVillageChanged(OwnVillage newVill) {}
		public override void SetupCurrentVillage() {}
		protected override void SetupTrainableUnits() {}
		[UICallable]
		public override void Train() {}
	}
