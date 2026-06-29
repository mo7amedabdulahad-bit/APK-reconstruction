// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VacationModeStartPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private int? _secondsUntilEmptyStorage;
		[ObservableValue]
		private int _vacationDaysRequested;
		[ObservableValue]
		private int _vacationModeCooldownInHours;
		[ObservableValue]
		private int _estimatedStarvationTimeBegin;
		[ObservableValue]
		private ObservableList<OwnVillage> _starvingVillages;
		private Action<bool> onClosed;
		private bool isConfirmed;
	
		// Properties
		[ObservableValue]
		public int? secondsUntilEmptyStorage { get => default; set {} }
		[ObservableValue]
		public int vacationDaysRequested { get => default; set {} }
		[ObservableValue]
		public int vacationModeCooldownInHours { get => default; set {} }
		[ObservableValue]
		public int estimatedStarvationTimeBegin { get => default; set {} }
		[ObservableValue]
		public ObservableList<OwnVillage> starvingVillages { get => default; set {} }
	
		// Constructors
		public VacationModeStartPopupController() {}
	
		// Methods
		private void _starvingVillagesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(Action<bool> popupClosedCallback, int vacationDaysRequested, int vacationModeCooldownInHours) {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void Confirm() {}
	}
