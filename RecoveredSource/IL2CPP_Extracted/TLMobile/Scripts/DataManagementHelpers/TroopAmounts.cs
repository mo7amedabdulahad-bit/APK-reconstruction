// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopAmounts : ObservableModel, IEquatable<TroopAmounts>
	{
		// Fields
		private readonly bool includeHero;
		[ObservableValue]
		private ObservableDictionary<int, TroopInfo> _infos;
		[ObservableValue]
		private long _totalAmount;
		public bool allowUnknownUnits;
		public bool filterOutZeroTroops;
		public int tribeId;
	
		// Properties
		[ObservableValue]
		public ObservableDictionary<int, TroopInfo> infos { get => default; set {} }
		[ObservableValue]
		public long totalAmount { get => default; set {} }
	
		// Constructors
		public TroopAmounts() {}
		public TroopAmounts(int tribeId, bool filterZero = true, bool includeHero = true) {}
		public TroopAmounts(UnitsAmount unitsAmount, int tribeId, bool filterZero = true, bool includeHero = true, bool allowUnknown = false) {}
	
		// Methods
		public bool Equals(TroopAmounts other) => default;
		public void UpdateWithUnitsAmount(UnitsAmount unitsAmount) {}
		public void AddTroop(TroopInfo info, bool force = false) {}
		public void Add(TroopAmounts other, bool force = false) {}
		public TroopInfo GetUnit(int number, int tribeId = -1) => default;
		public int GetUnitAmount(UnitType type) => default;
		public int GetUnitAmount(int number) => default;
		public void SetUnitAmount(int tribeId, int number, int amount) {}
		public int GetTotalAmount() => default;
		public UnitsSet GetUnitSet() => default;
		public ShipsSet GetShipSet() => default;
		public bool ContainsFully(TroopAmounts other) => default;
		public void Clear(bool setEverythingToZero = false) {}
		public void ChangeTribe(int tribe) {}
		public void SetMinimumTo(int minimum) {}
		private void _infosNotify(object sender, PropertyChangedEventArgs args) {}
	}
