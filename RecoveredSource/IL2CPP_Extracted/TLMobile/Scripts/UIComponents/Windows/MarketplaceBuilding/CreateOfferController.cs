// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CreateOfferController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ResourceTypes _offeringResourceType;
		[ObservableValue]
		private int _offeringResourceAmount;
		[ObservableValue]
		private int _offeringResourceMax;
		[ObservableValue]
		private ResourceTypes _searchingResourceType;
		[ObservableValue]
		private int _searchingResourceAmount;
		[ObservableValue]
		private int _searchingResourceMin;
		[ObservableValue]
		private int _searchingResourceMax;
		[ObservableValue]
		private string _ratioToShow;
		[ObservableValue]
		private int _ratioColor;
		[ObservableValue]
		private int _requiredMerchants;
		[ObservableValue]
		private bool _maxDurationEnabled;
		[ObservableValue]
		private int _maxDuration;
		[ObservableValue]
		private bool _ownAllianceOnly;
		[ObservableValue]
		private MerchantsInfo _merchantsInfo;
		[ObservableValue]
		private int _offeringSliderMax;
		[ObservableValue]
		private int _offeringSliderAmount;
		[ObservableValue]
		private int _searchingSliderMax;
		[ObservableValue]
		private int _searchingSliderAmount;
		[ObservableValue]
		private int _searchingSliderMin;
		private bool ignoreInputFieldCallbacks;
		private bool ignoreSliderCallbacks;
		private int oldOfferingAmount;
		private int oldOfferingSliderAmount;
		private int oldSearchingAmount;
		private OwnPlayer ownPlayer;
		private ResourceAmounts resourceAmountsInVillage;
		private OwnVillage village;
	
		// Properties
		[ObservableValue]
		public ResourceTypes offeringResourceType { get => default; set {} }
		[ObservableValue]
		public int offeringResourceAmount { get => default; set {} }
		[ObservableValue]
		public int offeringResourceMax { get => default; set {} }
		[ObservableValue]
		public ResourceTypes searchingResourceType { get => default; set {} }
		[ObservableValue]
		public int searchingResourceAmount { get => default; set {} }
		[ObservableValue]
		public int searchingResourceMin { get => default; set {} }
		[ObservableValue]
		public int searchingResourceMax { get => default; set {} }
		[ObservableValue]
		public string ratioToShow { get => default; set {} }
		[ObservableValue]
		public int ratioColor { get => default; set {} }
		[ObservableValue]
		public int requiredMerchants { get => default; set {} }
		[ObservableValue]
		public bool maxDurationEnabled { get => default; set {} }
		[ObservableValue]
		public int maxDuration { get => default; set {} }
		[ObservableValue]
		public bool ownAllianceOnly { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo merchantsInfo { get => default; set {} }
		[ObservableValue]
		public int offeringSliderMax { get => default; set {} }
		[ObservableValue]
		public int offeringSliderAmount { get => default; set {} }
		[ObservableValue]
		public int searchingSliderMax { get => default; set {} }
		[ObservableValue]
		public int searchingSliderAmount { get => default; set {} }
		[ObservableValue]
		public int searchingSliderMin { get => default; set {} }
	
		// Constructors
		public CreateOfferController() {}
	
		// Methods
		protected override void OnEnable() {}
		public void Init() {}
		private void UpdateMerchantInfo() {}
		private void SliderChanged() {}
		private void InputFieldChanged() {}
		private void OfferingResourcesChanged() {}
		[UICallable]
		public void SetOfferingResearchType(ResourceTypes newType) {}
		[UICallable]
		public void SetSearchingResearchType(ResourceTypes newType) {}
		[UICallable]
		public void ToggleMaxDurationEnabled() {}
		[UICallable]
		public void ToggleOwnAllianceOnly() {}
		[UICallable]
		public void CreateOffer() {}
	}
