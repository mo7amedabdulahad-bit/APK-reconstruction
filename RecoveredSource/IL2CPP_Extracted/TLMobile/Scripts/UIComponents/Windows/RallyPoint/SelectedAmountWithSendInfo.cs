// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SelectedAmountWithSendInfo : ObservableModel
	{
		// Fields
		[ObservableValue]
		private SelectableAmounts _selectableAmounts;
		[ObservableValue]
		private bool _scoutingOptionsAvailable;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private int _arrivalTime;
		[ObservableValue]
		private bool _catapultsSelected;
		[ObservableValue]
		private bool _heroSelected;
		[ObservableValue]
		private TLMobile.Scripts.UIComponents.Windows.RallyPoint.ScoutingTarget _scoutingTarget;
		[ObservableValue]
		private int _selectedKata;
		[ObservableValue]
		private int _selectedKata2;
		[ObservableValue]
		private int _selectedKataAmount;
		[ObservableValue]
		private bool _useShips;
		[ObservableValue]
		private int? _selectedShipID;
		[ObservableValue]
		private string _timeSavedUsingShip;
		[ObservableValue]
		private string _shipTypeUsedTranslated;
		[ObservableValue]
		private float _useShipUIAlpha;
		private UnitsSetWithHero unitsSetWithHero;
		public string sendTroopsResponseError;
		public const string RecentTargetsSaveKey = "RecentCatapultTargets";
		private const int MaximumSavedRecentTargets = 4;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts selectableAmounts { get => default; set {} }
		[ObservableValue]
		public bool scoutingOptionsAvailable { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public int arrivalTime { get => default; set {} }
		[ObservableValue]
		public bool catapultsSelected { get => default; set {} }
		[ObservableValue]
		public bool heroSelected { get => default; set {} }
		[ObservableValue]
		public TLMobile.Scripts.UIComponents.Windows.RallyPoint.ScoutingTarget scoutingTarget { get => default; set {} }
		[ObservableValue]
		public int selectedKata { get => default; set {} }
		[ObservableValue]
		public int selectedKata2 { get => default; set {} }
		[ObservableValue]
		public int selectedKataAmount { get => default; set {} }
		[ObservableValue]
		public bool useShips { get => default; set {} }
		[ObservableValue]
		public int? selectedShipID { get => default; set {} }
		[ObservableValue]
		public string timeSavedUsingShip { get => default; set {} }
		[ObservableValue]
		public string shipTypeUsedTranslated { get => default; set {} }
		[ObservableValue]
		public float useShipUIAlpha { get => default; set {} }
		public List<int> RecentCatapultTargets { get; set; }
	
		// Constructors
		[Obsolete("Only for data binding purposes!")]
		public SelectedAmountWithSendInfo() {}
		public SelectedAmountWithSendInfo(SelectableAmounts amounts) {}
	
		// Methods
		public void UpdateInfos(SendTroopInfo info) {}
		public void SetScoutingMissionOptionsAvailable(AttackType preselectedAttackType, int tribeId) {}
		public void SetSelectedShipType(int? shipType) {}
		private void AddRecentCatapultTarget(int buildingId) {}
		public void AddRecentCatapultTargets() {}
		private void RecreateCatapultTargetList() {}
		public void FillRecentCatapultTargets(string serializedString) {}
		public void UpdateArrivalTime(int originVillageId, int fromMapId, int targetId, AttackType eventType = AttackType.Attack, bool? useShips = default) {}
		private void LogSendTroopsApiError(Exception exception) {}
		private void SetArrivalTimeValues(ApiResponse<DistanceSpeedAndDurationResponseBody> response) {}
		private void SetShipArrivalTimeValues(ApiResponse<DistanceSpeedAndDurationResponseBody> response, DistanceSpeedAndDurationRequestBody requestWithoutShips) {}
		private void SetTimeSavedWithShips(ApiResponse<DistanceSpeedAndDurationResponseBody> response) {}
	}
