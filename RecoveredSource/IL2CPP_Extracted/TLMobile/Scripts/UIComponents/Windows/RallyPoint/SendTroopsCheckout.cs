// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendTroopsCheckout : TLMViewModel
	{
		// Fields
		private OwnPlayer currentPlayer;
		[ObservableValue]
		private SendTroopInfo _sendTroopInfo;
		[ObservableValue]
		private bool _confirmButtonEnabled;
		[ObservableValue]
		private string _sendTroopsResponseError;
		[ObservableValue]
		private string _warningMessage;
		[ObservableValue]
		private string _errorMessage;
		[ObservableValue]
		private TargetRelation _relationToTargetVillage;
		[ObservableValue]
		private bool _userMaySelectAttackType;
		[ObservableValue]
		private bool _changeHeroVillageSelected;
		[ObservableValue]
		private bool _destinationSummaryEnabled;
		[ObservableValue]
		private bool _enoughTroopsToCopyWave;
		[ObservableValue]
		private bool _hasAnyTroopsToSend;
		[ObservableValue]
		private bool _isSendingAnyCatapults;
		[ObservableValue]
		private bool _showOptionsBox;
		[ObservableValue]
		private bool _showNoPermissionsHint;
		[ObservableValue]
		private bool _permissibleTarget;
		[ObservableValue]
		private bool _reinforceableTarget;
		[ObservableValue]
		private Brewery _brewery;
		[ObservableValue]
		private Expansion _ownVillageExpansion;
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private bool _hasShips;
		[ObservableValue]
		private ObservableList<ShipAmount> _availableShipsList;
		[ObservableValue]
		private int _totalAvailableShips;
		public bool settlersCanChangeTribe;
		private Dictionary<ShipAmount.ShipId, int> availableShipCounts;
		private OwnVillage ownVillage;
		private int? settlerTribeId;
		private SendTroopsMainController sendTroopsMainController;
	
		// Properties
		[ObservableValue]
		public SendTroopInfo sendTroopInfo { get => default; set {} }
		[ObservableValue]
		public bool confirmButtonEnabled { get => default; set {} }
		[ObservableValue]
		public string sendTroopsResponseError { get => default; set {} }
		[ObservableValue]
		public string warningMessage { get => default; set {} }
		[ObservableValue]
		public string errorMessage { get => default; set {} }
		[ObservableValue]
		public TargetRelation relationToTargetVillage { get => default; set {} }
		[ObservableValue]
		public bool userMaySelectAttackType { get => default; set {} }
		[ObservableValue]
		public bool changeHeroVillageSelected { get => default; set {} }
		[ObservableValue]
		public bool destinationSummaryEnabled { get => default; set {} }
		[ObservableValue]
		public bool enoughTroopsToCopyWave { get => default; set {} }
		[ObservableValue]
		public bool hasAnyTroopsToSend { get => default; set {} }
		[ObservableValue]
		public bool isSendingAnyCatapults { get => default; set {} }
		[ObservableValue]
		public bool showOptionsBox { get => default; set {} }
		[ObservableValue]
		public bool showNoPermissionsHint { get => default; set {} }
		[ObservableValue]
		public bool permissibleTarget { get => default; set {} }
		[ObservableValue]
		public bool reinforceableTarget { get => default; set {} }
		[ObservableValue]
		public Brewery brewery { get => default; set {} }
		[ObservableValue]
		public Expansion ownVillageExpansion { get => default; set {} }
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public bool hasShips { get => default; set {} }
		[ObservableValue]
		public ObservableList<ShipAmount> availableShipsList { get => default; set {} }
		[ObservableValue]
		public int totalAvailableShips { get => default; set {} }
	
		// Constructors
		public SendTroopsCheckout() {}
	
		// Methods
		private void _availableShipsListNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		public void Init() {}
		public virtual void Setup(SendTroopInfo sendTroopInfo, SendTroopsMainController sendTroopsMainController) {}
		public void PrepareView() {}
		public virtual void UpdateInfo() {}
		public void SetSettlerTribeId(int tribeId) {}
		private void UpdateConfirmButtonState() {}
		public void UpdateRelation() {}
		public bool GetConfirmButtonEnabled() => default;
		private bool EnoughResourcesToSettle() => default;
		private void UpdateWarningAndError() {}
		private bool EnoughCulturalPointsForSettling() => default;
		private void UpdateUIElementsStatus() {}
		private void UpdateOptionBox() {}
		private void UpdateShipSelection() {}
		private void UpdateAvailableShips() {}
		private AttackType PreselectAttackType(bool hasPermissionSendRaids, bool hasPermissionSendReinforcement) => default;
		private void LogSendTroopsResponse(ApiResponse<SendTroopsResponseBody> response) {}
		private void LogSendTroopsApiError(Exception exception) {}
		private void ResetErrorState() {}
		[UICallable]
		public void SendTroops() {}
		private SendTroopsRequestBody.TroopTypeEnum GetTroopType() => default;
		[UICallable]
		public void SetAttackType(AttackType attackType, bool resetErrors = true) {}
		[UICallable]
		public void ToggleChangeHeroHomeVillage() {}
		[UICallable]
		public void SetWaveToEdit(int index) {}
		[UICallable]
		public void SetScoutingTargetResources(SelectedAmountWithSendInfo wave) {}
		[UICallable]
		public void SetScoutingTargetDefenses(SelectedAmountWithSendInfo wave) {}
		[UICallable]
		public void ToggleUseShips(int index) {}
	}
