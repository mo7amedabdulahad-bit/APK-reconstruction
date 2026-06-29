// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.SimulatorOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TravelUnitSelectionPopupController : DetailWindowController
	{
		// Fields
		private const string SlowestUnitSortingKey = "TravelSimulatorSlowestUnitSorting";
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private SelectedTroopInfo _selectedUnitInfo;
		[ObservableValue]
		private TroopInfo _troopInfo;
		private UnitSortId unitSortId;
		private Action<SelectedTroopInfo> onCompleteAction;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public SelectedTroopInfo selectedUnitInfo { get => default; set {} }
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
	
		// Constructors
		public TravelUnitSelectionPopupController() {}
	
		// Methods
		public void Apply(OwnPlayer.TribeId tribeId, SelectedTroopInfo selectedTroopInfo = null, Action<SelectedTroopInfo> onComplete = null) {}
		[UICallable]
		public void OnConfirmClicked() {}
		[UICallable]
		public void OnSortClicked() {}
		[UICallable]
		public void OnTroopClicked(SelectedTroopInfo value) {}
		private string GetLocale(UnitSortId value) => default;
		private void SortSelectableUnits() {}
	}
