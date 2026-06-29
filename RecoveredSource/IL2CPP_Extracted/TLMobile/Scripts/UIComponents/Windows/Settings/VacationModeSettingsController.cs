// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VacationModeSettingsController : TLMViewModel
	{
		// Fields
		[ObservableValue]
		private bool _conditionsFoldout;
		[ObservableValue]
		private int _conditionsMetCount;
		[ObservableValue]
		private int _conditionsTotalCount;
		[ObservableValue]
		private int _daysRequested;
		[ObservableValue]
		private int _vacationUntilPreview;
		[ObservableValue]
		private int _abortableAt;
		[ObservableValue]
		private int _nextVacationModeStartAt;
		[ObservableValue]
		private bool _vacationModeOnCooldown;
		[ObservableValue]
		private bool _vacationModeActive;
		[ObservableValue]
		private bool _canAbortVacationMode;
		[ObservableValue]
		private int _daysRemainingToVacationMode;
		[ObservableValue]
		private OwnPlayer _ownPlayer;
		private bool hasInitializedData;
		private int vacationCooldownInHours;
	
		// Properties
		[ObservableValue]
		public bool conditionsFoldout { get => default; set {} }
		[ObservableValue]
		public int conditionsMetCount { get => default; set {} }
		[ObservableValue]
		public int conditionsTotalCount { get => default; set {} }
		[ObservableValue]
		public int daysRequested { get => default; set {} }
		[ObservableValue]
		public int vacationUntilPreview { get => default; set {} }
		[ObservableValue]
		public int abortableAt { get => default; set {} }
		[ObservableValue]
		public int nextVacationModeStartAt { get => default; set {} }
		[ObservableValue]
		public bool vacationModeOnCooldown { get => default; set {} }
		[ObservableValue]
		public bool vacationModeActive { get => default; set {} }
		[ObservableValue]
		public bool canAbortVacationMode { get => default; set {} }
		[ObservableValue]
		public int daysRemainingToVacationMode { get => default; set {} }
		[ObservableValue]
		public OwnPlayer ownPlayer { get => default; set {} }
	
		// Constructors
		public VacationModeSettingsController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void RecalculateData() {}
		private void UpdateData() {}
		private void CalculateVacationUntilPreview() {}
		private void OnConfirmAbortion() {}
		[UICallable]
		public void ToggleConditionsFoldout() {}
		[UICallable]
		public void StartVacationMode() {}
		private void OnVacationModeStartPopupClosed(bool startVacationMode) {}
		[UICallable]
		public void StopVacationMode() {}
		[UICallable]
		public void ChangeNumberOfDaysRequested(int diff) {}
	}
