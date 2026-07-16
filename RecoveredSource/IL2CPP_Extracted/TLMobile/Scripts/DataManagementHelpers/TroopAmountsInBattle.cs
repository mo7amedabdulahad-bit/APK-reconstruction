// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopAmountsInBattle : TroopAmounts
	{
		// Fields
		[ObservableValue]
		private ObservableDictionary<int, long> _casualties;
		[ObservableValue]
		private ObservableDictionary<int, long> _trapped;
		[ObservableValue]
		private ObservableDictionary<int, long> _wounded;
		[ObservableValue]
		private ObservableDictionary<int, long> _revived;
		[ObservableValue]
		private ObservableDictionary<int, long> _survived;
		[ObservableValue]
		private long _totalRevived;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<int, long> casualties { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, long> trapped { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, long> wounded { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, long> revived { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, long> survived { get => default; set {} }
		[ObservableValue]
		public long totalRevived { get => default; set {} }
	
		// Constructors
		public TroopAmountsInBattle() {} // Dummy constructor
		public TroopAmountsInBattle(UnitsAmount unitsAmount, int tribeId = 0, bool filterZero = true, bool includeHero = true, bool allowUnknown = false) {}
	
		// Methods
		private void FillWithUnitsAmount(UnitsAmount unitsAmount, ObservableDictionary<int, long> toFill) {}
		public void SetCasualties(UnitsAmount amount) {}
		public void SetTrapped(UnitsAmount amount) {}
		public void SetWounded(UnitsAmount amount) {}
		public void SetSurvived() {}
		public void SetRevived(UnitsAmount amount) {}
		private void _casualtiesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _trappedNotify(object sender, PropertyChangedEventArgs args) {}
		private void _woundedNotify(object sender, PropertyChangedEventArgs args) {}
		private void _revivedNotify(object sender, PropertyChangedEventArgs args) {}
		private void _survivedNotify(object sender, PropertyChangedEventArgs args) {}
	}
