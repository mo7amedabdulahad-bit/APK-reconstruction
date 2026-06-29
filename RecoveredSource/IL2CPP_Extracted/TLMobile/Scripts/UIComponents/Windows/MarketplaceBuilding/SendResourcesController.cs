// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendResourcesController : DetailWindowController
	{
		// Fields
		[SerializeField]
		private SendPayoffAnimationController payoffAnimationController;
		[SerializeField]
		private SendResourcesRow[] sendResourcesRows;
		[ObservableValue]
		private Village _targetVillage;
		[ObservableValue]
		private Step _currentStep;
		[ObservableValue]
		private ResourceAmounts _selectedResources;
		[ObservableValue]
		private ResourceAmounts _maxResources;
		[ObservableValue]
		private ResourceAmounts _totalResources;
		[ObservableValue]
		private int _repeatAmount;
		[ObservableValue]
		private int _requiredMerchants;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private bool _resourceSelectionValid;
		[ObservableValue]
		private string _errorMessage;
		[ObservableValue]
		private MerchantsInfo _merchantsInfo;
		[ObservableValue]
		private Marketplace _market;
		[ObservableValue]
		private bool _useShips;
		[ObservableValue]
		private bool _harbours;
		[ObservableValue]
		private ObservableList<OwnMerchantMovement> _ownMerchantMovements;
		protected OwnVillage village;
	
		// Properties
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
		[ObservableValue]
		public Step currentStep { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts selectedResources { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts maxResources { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts totalResources { get => default; set {} }
		[ObservableValue]
		public int repeatAmount { get => default; set {} }
		[ObservableValue]
		public int requiredMerchants { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public bool resourceSelectionValid { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo merchantsInfo { get => default; set {} }
		[ObservableValue]
		public Marketplace market { get => default; set {} }
		[ObservableValue]
		public bool useShips { get => default; set {} }
		[ObservableValue]
		public bool harbours { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnMerchantMovement> ownMerchantMovements { get => default; set {} }
		protected virtual bool useTotalProductionInsteadOfStock { get => default; }
	
		// Nested types
		public enum Step
		{
			TargetSelection = 0,
			ResourceSelection = 1,
			Confirmation = 2,
			ResourceSent = 3
		}
	
		// Constructors
		public SendResourcesController() {}
	
		// Methods
		private void _ownMerchantMovementsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		private void OnSliderValueChanged(int index, float value) {}
		[UICallable]
		public void OnSliderPointerDown(int id) {}
		private SendResourcesRow GetSendResourcesRow(int index) => default;
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void SendAgain() {}
		public void InitForCurrentVillage(OwnVillage newVill) {}
		private void UpdateMerchantInfo() {}
		private void ResourcesChanged() {}
		protected virtual int GetSelectedResourceMax(int key) => default;
		protected virtual void UpdateResourceSelectionValid() {}
		public static bool UpdateResourceSelectionValid(int requiredMerchants, int maxMerchants, int selectedResourcesSum) => default;
		[UICallable]
		public void CancelMerchant(int id) {}
		[UICallable]
		public void SelectTarget(Village targetVillage) {}
		private void UpdateDuration(Village targetVillage) {}
		[UICallable]
		public void AddOneCapacityToResource(int resourceType) {}
		[UICallable]
		public void SetRepeatAmount(int newAmount) {}
		[UICallable]
		public void SetCurrentStep(Step newStep) {}
		[UICallable]
		public void ConfirmSend() {}
		private OwnMerchantMovement GetMerchantMovement(SendResourcesRequestBody value) => default;
		[UICallable]
		public void ToggleUseShips() {}
	}
