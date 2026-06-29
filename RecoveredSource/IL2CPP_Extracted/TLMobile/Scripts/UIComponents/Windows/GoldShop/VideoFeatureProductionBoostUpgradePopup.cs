// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.GoldShop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VideoFeatureProductionBoostUpgradePopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private bool _dontAskAgain;
		[ObservableValue]
		private GoldAdvantage _selectedAdvantage;
		private System.Action onClosed;
	
		// Properties
		[ObservableValue]
		public bool dontAskAgain { get => default; set {} }
		[ObservableValue]
		public GoldAdvantage selectedAdvantage { get => default; set {} }
		[ObservableValue]
		public int PremiumFeatureBonusPercent { get => default; }
	
		// Constructors
		public VideoFeatureProductionBoostUpgradePopup() {}
	
		// Methods
		public void Setup(GoldAdvantage advantage, System.Action closeAction) {}
		[UICallable]
		public void ToggleDontAskAgain() {}
		[UICallable]
		public void Confirm() {}
	}
