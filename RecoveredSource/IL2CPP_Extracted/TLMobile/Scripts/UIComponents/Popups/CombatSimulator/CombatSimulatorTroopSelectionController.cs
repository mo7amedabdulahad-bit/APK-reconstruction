// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.CombatSimulator
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorTroopSelectionController : DetailWindowController
	{
		// Fields
		public GenericUnitsSelection UnitsSelection;
		[ObservableValue]
		private bool _defaultTroopsAvailable;
		private Action<ObservableList<SelectedTroopInfo>> confirmCallback;
		private TroopAmounts defaultTroops;
		private ObservableList<DropdownOption> sortDropdownOptions;
	
		// Properties
		[ObservableValue]
		public bool defaultTroopsAvailable { get => default; set {} }
	
		// Constructors
		public CombatSimulatorTroopSelectionController() {}
	
		// Methods
		public void Setup(SelectableAmounts copy, Action<ObservableList<SelectedTroopInfo>> confirmCallback, TroopAmounts villageDefault = null) {}
		[UICallable]
		public void ChangeLevel(int diff) {}
		[UICallable]
		public void Confirm() {}
		[UICallable]
		public void ResetToDefault() {}
		[UICallable]
		public void ResetToZero() {}
		[UICallable]
		public void SetSmithyLevel() {}
	}
