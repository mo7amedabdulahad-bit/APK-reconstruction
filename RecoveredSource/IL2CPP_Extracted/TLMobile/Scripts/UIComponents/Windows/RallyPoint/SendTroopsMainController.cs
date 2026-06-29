// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendTroopsMainController : DetailWindowTabController
	{
		// Fields
		public SendTroopsTargetSelection targetSelection;
		public GenericUnitsSelection unitsSelection;
		public SpriteCfg tribesIconCfg;
		public SendTroopsCheckout troopsCheckout;
		[ObservableValue]
		private SendTroopInfo _sendTroopInfo;
		[ObservableValue]
		private SendTroopsView _activeView;
		[ObservableValue]
		private bool _settlersCanChangeTribe;
		[ObservableValue]
		private int _settlersCanChangeTribeCount;
		[ObservableValue]
		private Tribe _selectedTribe;
		private ObservableList<DropdownOption> tribesForDropdown;
		private OwnPlayer currentPlayer;
		private SceneStatus openedFromScene;
	
		// Properties
		[ObservableValue]
		public SendTroopInfo sendTroopInfo { get => default; set {} }
		[ObservableValue]
		public SendTroopsView activeView { get => default; set {} }
		[ObservableValue]
		public bool settlersCanChangeTribe { get => default; set {} }
		[ObservableValue]
		public int settlersCanChangeTribeCount { get => default; set {} }
		[ObservableValue]
		public Tribe selectedTribe { get => default; set {} }
		public SceneStatus OpenedFromScene { get => default; }
	
		// Constructors
		public SendTroopsMainController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		public virtual void Init() {}
		public virtual void ResetState() {}
		public virtual void SetOpenedFromScene(SceneStatus status) {}
		[UICallable]
		public virtual void ShowTargetSelection() {}
		[UICallable]
		public virtual void ForwardTroops(TroopAmounts troopAmounts, int troopsCurrentMapId, int originVillageId, int troopsCurrentVillageId) {}
		[UICallable]
		public virtual void WithdrawTroops(TroopAmounts troopAmounts, int troopsCurrentMapId, int originVillageId, int troopsCurrentVillageId) {}
		[UICallable]
		public virtual void GoBackFromUnitSelectionPage() {}
		[UICallable]
		public virtual void ShowTargetSelectionWithPreselectedVillage() {}
		[UICallable]
		public virtual void ShowTroopSelection() {}
		public virtual void StartSendingTroopsWithPreselectedType(Village targetVillage, AttackType preselectedAttackType = AttackType.NoSelection, UnitType preselectAllOfUnit = UnitType.None, int preselectedAmount = -1, SendTroopsView viewToOpenImmediately = SendTroopsView.SelectUnits) {}
		public virtual void StartSendingTroopsWithPreselectedTroops(Village targetVillage, AttackType preselectedAttackType, TroopAmounts troopsToPreselect, SendTroopsView viewToOpenImmediately) {}
		public virtual void StartSendingTroopsWithPreselectedType(MapCell targetMapCell, AttackType preselectedAttackType = AttackType.NoSelection, UnitType preselectAllOfUnit = UnitType.None, int preselectedAmount = -1, SendTroopsView viewToOpenImmediately = SendTroopsView.SelectUnits) {}
		private void PrepareNextView(SendTroopsView viewToOpenImmediately) {}
		private SelectableAmounts PreselectUnits(UnitType preselectAllOfUnit = UnitType.None, int preselectedAmount = -1) => default;
		private SelectableAmounts PreselectUnits(TroopAmounts desiredSelection) => default;
		private void CalculateRemainingUnits(SelectableAmounts selectableAmounts) {}
		[UICallable]
		public virtual void ShowTroopSelectionWithPreselectedTroops() {}
		[UICallable]
		public virtual void Checkout() {}
		[UICallable]
		public void AddNewWave() {}
		[UICallable]
		public void CopyLastWave() {}
		[UICallable]
		public void DeleteWave(int index) {}
		[UICallable]
		public void EditWave(int index) {}
		[UICallable]
		public void SelectTribeForSettling() {}
		private void OnTribeSelectedForSettler() {}
		private void ChangeActiveView(SendTroopsView newView) {}
	}
