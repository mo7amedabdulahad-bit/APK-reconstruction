// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RallyPointMergeTroopsController : TLMViewModel
	{
		// Fields
		private const int TroopsResourceCostMultiplier = 2;
		public RallyPointTroopsOverviewNavigation rallyPointTroopsOverviewNavigation;
		public GenericUnitsSelection genericUnitsSelection;
		public FloatingResourcesController floatingResourcesController;
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private ResourceAmounts _mergeCosts;
		[ObservableValue]
		private int _maxAllowedGold;
		[ObservableValue]
		private int _mergeGoldCost;
		[ObservableValue]
		private LimitInfo _paymentState;
		[ObservableValue]
		private bool _enoughResources;
		[ObservableValue]
		private bool _canSpendGold;
		private BootstrapData bootstrapData;
		private OwnVillage currentVillage;
		private System.Action OnMergeSuccessfulCallback;
		private StandingTroop selectedStandingTroop;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts mergeCosts { get => default; set {} }
		[ObservableValue]
		public int maxAllowedGold { get => default; set {} }
		[ObservableValue]
		public int mergeGoldCost { get => default; set {} }
		[ObservableValue]
		public LimitInfo paymentState { get => default; set {} }
		[ObservableValue]
		public bool enoughResources { get => default; set {} }
		[ObservableValue]
		public bool canSpendGold { get => default; set {} }
	
		// Nested types
		public enum LimitInfo
		{
			ShowGoldLimitOnly = 0,
			ResourceAvailable = 1
		}
	
		// Constructors
		public RallyPointMergeTroopsController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		public virtual void Setup(StandingTroop standingTroop, System.Action onSuccessfulMerge = null) {}
		private void PrepareSelectableUnits() {}
		private void UpdateMergeData() {}
		private void CalculateResourcesCost() {}
		private void CalculateGoldCostForMerge() {}
		private void UpdatePaymentState() {}
		[UICallable]
		public virtual void MergeTroopsWithResources() {}
		[UICallable]
		public virtual void MergeTroopsWithGold() {}
		[UICallable]
		public virtual void EditTroops() {}
		[UICallable]
		public void OpenNPCTrader() {}
		private void OnMergeSuccess() {}
		private void OnMergeFailed(Exception e) {}
		private MergeTroopsRequestBody PrepareRequestBody() => default;
		private MergeTroopsRequestBodyTroops PrepareRequestBodyTroops() => default;
	}
