// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Barracks
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnitsTrainingTabController : GenericUnitsSelection
	{
		// Fields
		public FloatingResourcesController floatingResourcesController;
		[ObservableValue]
		private int _timeToTrain;
		[ObservableValue]
		private ResourceAmounts _resourcesToTrainCosts;
		[ObservableValue]
		private int _freeCropCost;
		[ObservableValue]
		private bool _trainingInProgress;
		[ObservableValue]
		private long _enoughResourcesTimestamp;
		[ObservableValue]
		private GeneralErrorType _generalErrorType;
		private Building building;
		protected TrainingBonus trainingBonus;
		private bool isGreatBuilding;
		protected OwnVillage currentVillage;
		protected int possibleAmount;
	
		// Properties
		[ObservableValue]
		public int timeToTrain { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourcesToTrainCosts { get => default; set {} }
		[ObservableValue]
		public int freeCropCost { get => default; set {} }
		[ObservableValue]
		public bool trainingInProgress { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTimestamp { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType generalErrorType { get => default; set {} }
		protected int previouslySelected { get => default; set {} }
	
		// Constructors
		public UnitsTrainingTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		protected virtual void CurrentVillageChanged(OwnVillage newVill) {}
		public virtual void SetupCurrentVillage() {}
		private SelectedTroopInfo PreselectTroop() => default;
		private void UpdateTrainingList() {}
		protected virtual void SetupTrainableUnits() {}
		public virtual int CalculateAvailableToBuild(TLMobile.Generated.GraphQL.Game.Resource currentResources, TLMobile.Generated.GraphQL.Game.Unit unit, ResourceAmounts blockedResources, float costMultiplicator = 1f, int maxAmount = 2147483647) => default;
		protected void SetTrainingTime() {}
		protected override void SetAmount() {}
		[UICallable]
		public override void SelectTroop(SelectedTroopInfo troopInfo) {}
		private void UpdateResearchRequirements() {}
		[UICallable]
		public virtual void Fill() {}
		[UICallable]
		public virtual void Train() {}
		protected TroopAmounts GetTroopAmountsToRequest() => default;
		[UICallable]
		public virtual void Destroy() {}
	}
