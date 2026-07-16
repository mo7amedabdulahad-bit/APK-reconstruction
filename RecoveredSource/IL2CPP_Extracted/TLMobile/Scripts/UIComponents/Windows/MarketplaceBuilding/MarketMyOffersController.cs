// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MarketMyOffersController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Marketplace _marketplace;
		private OwnVillage village;
	
		// Properties
		[ObservableValue]
		public Marketplace marketplace { get => default; set {} }
	
		// Constructors
		public MarketMyOffersController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void CurrentVillageChanged(OwnVillage newVill) {}
		[UICallable]
		public void DeleteOffer(MarketplaceOwnOffer offer) {}
	}
