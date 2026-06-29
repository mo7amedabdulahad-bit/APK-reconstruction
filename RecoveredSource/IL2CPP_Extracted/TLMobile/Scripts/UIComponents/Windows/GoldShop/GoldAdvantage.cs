// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.GoldShop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GoldAdvantage : ObservableModel
	{
		// Fields
		private const int TimeIsShortThreshold = 3600;
		[ObservableValue]
		private SetAutoProlongationRequestBody.FeatureEnum _type;
		[ObservableValue]
		private SubscriptionFeature _info;
		[ObservableValue]
		private int _extensionDuration;
		[ObservableValue]
		private int _extensionDurationPremium;
		[ObservableValue]
		private int _extensionDurationVideo;
		[ObservableValue]
		private int _goldCost;
		[ObservableValue]
		private string _backendName;
		[ObservableValue]
		private int _timeLeftIsShortTimestamp;
		[ObservableValue]
		private ProductionBoost _productionBoost;
		[ObservableValue]
		private BoostResourceType _resourceType;
	
		// Properties
		[ObservableValue]
		public SetAutoProlongationRequestBody.FeatureEnum type { get => default; set {} }
		[ObservableValue]
		public SubscriptionFeature info { get => default; set {} }
		[ObservableValue]
		public int extensionDuration { get => default; set {} }
		[ObservableValue]
		public int extensionDurationPremium { get => default; set {} }
		[ObservableValue]
		public int extensionDurationVideo { get => default; set {} }
		[ObservableValue]
		public int goldCost { get => default; set {} }
		[ObservableValue]
		public string backendName { get => default; set {} }
		[ObservableValue]
		public int timeLeftIsShortTimestamp { get => default; set {} }
		[ObservableValue]
		public ProductionBoost productionBoost { get => default; set {} }
		[ObservableValue]
		public BoostResourceType resourceType { get => default; set {} }
	
		// Constructors
		public GoldAdvantage() {}
		public GoldAdvantage(SetAutoProlongationRequestBody.FeatureEnum type) {}
	
		// Methods
		~GoldAdvantage() {}
		public void SetupInternalData() {}
	}
