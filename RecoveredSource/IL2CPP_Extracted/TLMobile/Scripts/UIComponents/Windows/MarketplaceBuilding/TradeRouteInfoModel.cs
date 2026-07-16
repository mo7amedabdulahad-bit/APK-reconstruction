// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TradeRouteInfoModel : ObservableModel
	{
		// Fields
		[ObservableValue]
		private Village _targetVillage;
		[ObservableValue]
		private bool _targetValid;
		[ObservableValue]
		private bool _timeIsStartTime;
		[ObservableValue]
		private int _hours;
		[ObservableValue]
		private int _minutes;
		[ObservableValue]
		private int _repeatEvery;
		[ObservableValue]
		private int _firstArrivalTime;
		[ObservableValue]
		private bool _timeIsPm;
		[ObservableValue]
		private bool _use12hClock;
	
		// Properties
		[ObservableValue]
		public Village targetVillage { get => default; set {} }
		[ObservableValue]
		public bool targetValid { get => default; set {} }
		[ObservableValue]
		public bool timeIsStartTime { get => default; set {} }
		[ObservableValue]
		public int hours { get => default; set {} }
		[ObservableValue]
		public int minutes { get => default; set {} }
		[ObservableValue]
		public int repeatEvery { get => default; set {} }
		[ObservableValue]
		public int firstArrivalTime { get => default; set {} }
		[ObservableValue]
		public bool timeIsPm { get => default; set {} }
		[ObservableValue]
		public bool use12hClock { get => default; set {} }
	
		// Constructors
		public TradeRouteInfoModel() {}
	
		// Methods
		public int Get24hHours() => default;
	}
