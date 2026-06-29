// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Auctions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SilverToGoldExchangePopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private SubTab _currentExchangeType;
		[ObservableValue]
		private int _goldToSilverExchangeRate;
		[ObservableValue]
		private int _silverToGoldDivider;
		[ObservableValue]
		private int _goldInput;
		[ObservableValue]
		private int _silverOutput;
		[ObservableValue]
		private int _silverInput;
		[ObservableValue]
		private int _goldOutput;
		[ObservableValue]
		private int _newGold;
		[ObservableValue]
		private int _newSilver;
		[ObservableValue]
		private int _silverTiedInAuctions;
		[ObservableValue]
		private int _availableSilver;
		[ObservableValue]
		private int _totalSilverInWallet;
		[ObservableValue]
		private bool _insufficientGoldError;
		[ObservableValue]
		private bool _insufficientSilverError;
		private SilverAccounting silverAccounting;
		private Wallet wallet;
	
		// Properties
		[ObservableValue]
		public SubTab currentExchangeType { get => default; set {} }
		[ObservableValue]
		public int goldToSilverExchangeRate { get => default; set {} }
		[ObservableValue]
		public int silverToGoldDivider { get => default; set {} }
		[ObservableValue]
		public int goldInput { get => default; set {} }
		[ObservableValue]
		public int silverOutput { get => default; set {} }
		[ObservableValue]
		public int silverInput { get => default; set {} }
		[ObservableValue]
		public int goldOutput { get => default; set {} }
		[ObservableValue]
		public int newGold { get => default; set {} }
		[ObservableValue]
		public int newSilver { get => default; set {} }
		[ObservableValue]
		public int silverTiedInAuctions { get => default; set {} }
		[ObservableValue]
		public int availableSilver { get => default; set {} }
		[ObservableValue]
		public int totalSilverInWallet { get => default; set {} }
		[ObservableValue]
		public bool insufficientGoldError { get => default; set {} }
		[ObservableValue]
		public bool insufficientSilverError { get => default; set {} }
	
		// Nested types
		public enum SubTab
		{
			GoldToSilver = 0,
			SilverToGold = 1
		}
	
		// Constructors
		public SilverToGoldExchangePopupController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		private void CalculateGoldOutput() {}
		private void CalculateSilverOutput() {}
		[UICallable]
		public void SwitchExchangeType() {}
		private void ChangeExchangeType(SubTab newType) {}
		private void RefreshWallet() {}
		[UICallable]
		public void ExchangeGoldToSilver() {}
		[UICallable]
		public void ConvertSilverToGold() {}
		private void OnConversionComplete() {}
		private void UpdateEstimates() {}
	}
