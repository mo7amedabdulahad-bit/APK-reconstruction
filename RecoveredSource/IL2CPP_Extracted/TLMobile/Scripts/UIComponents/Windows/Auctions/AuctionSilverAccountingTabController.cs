// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AuctionSilverAccountingTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private SilverAccounting _silverAccounting;
		[ObservableValue]
		private bool _showTiedSilverDetails;
	
		// Properties
		[ObservableValue]
		public SilverAccounting silverAccounting { get => default; set {} }
		[ObservableValue]
		public bool showTiedSilverDetails { get => default; set {} }
	
		// Constructors
		public AuctionSilverAccountingTabController() {}
	
		// Methods
		protected override void OnEnable() {}
		private void BalanceChanged() {}
		[UICallable]
		public void ToggleShowTiedSilverDetails() {}
	}
