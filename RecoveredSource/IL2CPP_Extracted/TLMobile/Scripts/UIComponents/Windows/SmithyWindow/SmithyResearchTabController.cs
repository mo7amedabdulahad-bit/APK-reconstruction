// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.SmithyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SmithyResearchTabController : GenericUnitsSelection
	{
		// Fields
		private const int QueueLimitPremium = 2;
		private const int QueueLimit = 1;
		public FloatingResourcesController floatingResourcesController;
		[ObservableValue]
		private bool _researchButtonDisabled;
		[ObservableValue]
		private GeneralErrorType _resourceError;
		[ObservableValue]
		private long _enoughResourcesTime;
		[ObservableValue]
		private Smithy _smithy;
		[ObservableValue]
		private int _nextLevelForSelectedUnit;
		[ObservableValue]
		private bool _canSpeedUp;
		private OwnVillage currentVillage;
		private Building smithyBuilding;
	
		// Properties
		[ObservableValue]
		public bool researchButtonDisabled { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType resourceError { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTime { get => default; set {} }
		[ObservableValue]
		public Smithy smithy { get => default; set {} }
		[ObservableValue]
		public int nextLevelForSelectedUnit { get => default; set {} }
		[ObservableValue]
		public bool canSpeedUp { get => default; set {} }
	
		// Constructors
		public SmithyResearchTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		public void Setup() {}
		private TroopAmounts GetResearchableUnits() => default;
		private void UpdateUIState() {}
		private void UpdateResearchButtonDisabled() {}
		private bool GetResearchButtonDisabled() => default;
		private void CheckResourceErrors() {}
		[UICallable]
		public override void SelectTroop(SelectedTroopInfo troopInfo) {}
		[UICallable]
		public void UpgradeUnit(string adSalesVrid = null) {}
		[UICallable]
		public override void PlayAdForBoost() {}
		public void UpdateNextLevelForSelectedUnit() {}
		private void UpdateUnitCosts() {}
		private TroopInfo CreateUpdatedTroopInfo(int id, int level, int nextLevel) => default;
		public int CountSameUnitsInResearch(int id) => default;
		private void UpdateAllView() {}
	}
