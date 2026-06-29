// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericUnitsSelection : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private SelectedTroopInfo _selectedUnit;
		[ObservableValue]
		private TroopInfo _selectedUnitInfo;
		[ObservableValue]
		private bool _confirmButtonEnabled;
		[ObservableValue]
		private int _heroUid;
		[ObservableValue]
		private int _selectedAmount;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public SelectedTroopInfo selectedUnit { get => default; set {} }
		[ObservableValue]
		public TroopInfo selectedUnitInfo { get => default; set {} }
		[ObservableValue]
		public bool confirmButtonEnabled { get => default; set {} }
		[ObservableValue]
		public int heroUid { get => default; set {} }
		[ObservableValue]
		public int selectedAmount { get => default; set {} }
	
		// Constructors
		public GenericUnitsSelection() {}
	
		// Methods
		protected override void Awake() {}
		public virtual void Init() {}
		public virtual void Setup(SelectableAmounts selectableAmounts, OwnVillage originVillage, bool overrideNonResearchedUnitLevel = false, bool overrideSelectUnit = false) {}
		[UICallable]
		public virtual void SelectTroop(SelectedTroopInfo troopInfo) {}
		[UICallable]
		public void FillTroops(SelectedTroopInfo troopInfo) {}
		[UICallable]
		public void ChangeAmount(int change) {}
		public void SetConfirmButtonEnabledValue() {}
		protected virtual void SetAmount() {}
		protected void SetUnitLevels(OwnVillage originVillage, bool overrideNonResearchedUnitLevel = false) {}
		[UICallable]
		public virtual void PlayAdForBoost() {}
	}
