// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SelectableAmounts : ObservableModel
	{
		// Fields
		[ObservableValue]
		private ObservableList<SelectedTroopInfo> _selectableUnits;
		[ObservableValue]
		private long _totalSelectedAmount;
		[ObservableValue]
		private int _individualTravelTime;
	
		// Properties
		[ObservableValue]
		public ObservableList<SelectedTroopInfo> selectableUnits { get => default; set {} }
		[ObservableValue]
		public long totalSelectedAmount { get => default; set {} }
		[ObservableValue]
		public int individualTravelTime { get => default; set {} }
	
		// Constructors
		public SelectableAmounts() {}
		public SelectableAmounts(SelectableAmounts original) {}
		public SelectableAmounts(TroopAmounts troopAmounts) {}
	
		// Methods
		public void SetAvailableAmountForAllUnits(int amount) {}
		public void SetAvailableAmount(int tid, int amount) {}
		public void SetUnitSelectedAmount(int tid, int amount) {}
		public void SetAvailableAsSelectedForAllUnits() {}
		public void SetAvailableAsSelectedAmounts(int tid) {}
		public SelectedTroopInfo TryGetUnit(int uidForTroop) => default;
		public SelectedTroopInfo GetUnit(int tid) => default;
		public int GetUnitAvailableAmount(int tid) => default;
		public int GetUnitSelectedAmount(int tid) => default;
		public SelectedTroopInfo GetFirstAvailableUnit() => default;
		public SelectedTroopInfo GetFirstUnitWithCondition(Func<SelectedTroopInfo, bool> condition) => default;
		public long GetTotalSelectedUnits() => default;
		public int GetSelectableUnitsCount() => default;
		public void NotifySelectableUnitsObservers() {}
		public UnitsSet GetUnitSet() => default;
		private void UpdateTotalSelectedAmount() {}
		public void EnsureTroopTypeIsSelectable(int tribeId, int type) {}
		public void AddUnitInfo(TroopInfo info) {}
		private void _selectableUnitsNotify(object sender, PropertyChangedEventArgs args) {}
	}
