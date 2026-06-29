// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketOffersController : DetailWindowTabControllerWithPagination<MarketplaceOffer>
	{
		// Fields
		[ObservableValue]
		private OfferRation _filterRatio;
		[ObservableValue]
		private ResourceTypes _filterOffering;
		[ObservableValue]
		private ResourceTypes _filterSearching;
		[ObservableValue]
		private Marketplace _marketplace;
		[ObservableValue]
		private MarketplaceOffersFilter _currentFilter;
		[ObservableValue]
		private bool _ownAllianceOnly;
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private bool _harbours;
		private bool ratioToggle;
		private OwnVillage village;
	
		// Properties
		[ObservableValue]
		public OfferRation filterRatio { get => default; set {} }
		[ObservableValue]
		public ResourceTypes filterOffering { get => default; set {} }
		[ObservableValue]
		public ResourceTypes filterSearching { get => default; set {} }
		[ObservableValue]
		public Marketplace marketplace { get => default; set {} }
		[ObservableValue]
		public MarketplaceOffersFilter currentFilter { get => default; set {} }
		[ObservableValue]
		public bool ownAllianceOnly { get => default; set {} }
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public bool harbours { get => default; set {} }
	
		// Constructors
		public MarketOffersController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		[Testable]
		private void CurrentVillageChanged(OwnVillage newVillage) {}
		private void ResetUIFilters() {}
		private void BuildFilterAndUpdateList() {}
		[UICallable]
		public void ToggleGoodRatioOnly() {}
		[UICallable]
		public void SetOfferingFilter(ResourceTypes type) {}
		[UICallable]
		public void SetSearchingFilter(ResourceTypes type) {}
		[UICallable]
		public void ToggleOwnAllianceOnly() {}
		[UICallable]
		public void AcceptOffer(MarketplaceOffer offer) {}
		private TLMobile.Generated.GraphQL.Game.ResourceEnum GetResourceEnum(ResourceTypes type) => default;
	}
