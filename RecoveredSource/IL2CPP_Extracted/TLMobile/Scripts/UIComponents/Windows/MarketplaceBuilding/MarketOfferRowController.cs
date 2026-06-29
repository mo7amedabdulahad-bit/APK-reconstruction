// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketOfferRowController : InjectableViewModel
	{
		// Fields
		[ObservableValue]
		private bool _canAcceptOffer;
		[InjectableValue]
		[ObservableValue]
		private MarketplaceOffer _marketplaceOffer;
		[ObservableValue]
		private int _neededMerchants;
		[ObservableValue]
		private int _ratioColor;
		[ObservableValue]
		private string _ratioToShow;
		private MerchantsInfo merchantsInfo;
		private OwnVillage village;
	
		// Properties
		[ObservableValue]
		public bool canAcceptOffer { get => default; set {} }
		[InjectableValue]
		[ObservableValue]
		public MarketplaceOffer marketplaceOffer { get => default; set {} }
		[ObservableValue]
		public int neededMerchants { get => default; set {} }
		[ObservableValue]
		public int ratioColor { get => default; set {} }
		[ObservableValue]
		public string ratioToShow { get => default; set {} }
	
		// Constructors
		public MarketOfferRowController() {}
	
		// Methods
		public new void OnInjectedValueChanged() {}
		private void UpdateMerchantInfo() {}
		private bool CanAcceptOffer() => default;
	}
