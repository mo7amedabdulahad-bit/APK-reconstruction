// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.GoldClubActivation
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldClubActivationController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GoldClubPopupItem _currentFeature;
		[ObservableValue]
		private int _goldClubActivationPrice;
		[ObservableValue]
		private ObservableDictionary<GoldClubFeature, GoldClubPopupItem> _goldClubPopupItems;
	
		// Properties
		[ObservableValue]
		public GoldClubPopupItem currentFeature { get => default; set {} }
		[ObservableValue]
		public int goldClubActivationPrice { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<GoldClubFeature, GoldClubPopupItem> goldClubPopupItems { get => default; set {} }
	
		// Constructors
		public GoldClubActivationController() {}
	
		// Methods
		private void _goldClubPopupItemsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public virtual void Init(GoldActionPrices actionPrices) {}
		public virtual void Setup(GoldClubFeature topFeature) {}
		private void AddFeatures() {}
		[UICallable]
		public void ActivateGoldClub() {}
	}
