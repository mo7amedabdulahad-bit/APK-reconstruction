// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketMerchantsOverviewController : DetailWindowTabControllerWithPagination<OwnMerchantMovement>
	{
		// Fields
		public ScrollRect outgoingMerchantsScrollRect;
		[ObservableValue]
		private ObservableList<OwnMerchantMovement> _outgoingMerchants;
		[ObservableValue]
		private ObservableList<OwnMerchantMovement> _incomingMerchants;
		[ObservableValue]
		private Marketplace _marketplace;
		[ObservableValue]
		private MerchantsOverviewTab _subTab;
		[ObservableValue]
		private MerchantsInfo _merchantsInfo;
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private bool _harbours;
		[ObservableValue]
		private int _idleMerchants;
		[ObservableValue]
		private int _tradeShipCarryCapacity;
		private OwnVillage currentVillage;
		private DropdownOption selectedOption;
		[Testable]
		private ObservableList<DropdownOption> sortDropdownOptions;
	
		// Properties
		[ObservableValue]
		public ObservableList<OwnMerchantMovement> outgoingMerchants { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnMerchantMovement> incomingMerchants { get => default; set {} }
		[ObservableValue]
		public Marketplace marketplace { get => default; set {} }
		[ObservableValue]
		public MerchantsOverviewTab subTab { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo merchantsInfo { get => default; set {} }
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public bool harbours { get => default; set {} }
		[ObservableValue]
		public int idleMerchants { get => default; set {} }
		[ObservableValue]
		public int tradeShipCarryCapacity { get => default; set {} }
	
		// Constructors
		public MarketMerchantsOverviewController() {}
	
		// Methods
		private void _outgoingMerchantsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _incomingMerchantsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void CurrentVillageChanged(OwnVillage newVillage) {}
		private void StopObservingCurrentVillage() {}
		private void ObserveOnCurrentVillage() {}
		private void UpdateMarketPlace() {}
		public virtual void UpdateOverviewAfterResourceSent() {}
		private void UpdateOverview() {}
		[UICallable]
		public void ToggleSubCategory(MerchantsOverviewTab tab) {}
		[UICallable]
		public void OpenDropdown() {}
		[UICallable]
		public void CancelMerchant(int id) {}
	}
