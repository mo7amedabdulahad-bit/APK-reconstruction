// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AcademyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AcademyResearchTabController : GenericUnitsSelection
	{
		// Fields
		public FloatingResourcesController floatingResourcesController;
		[ObservableValue]
		private bool _researchButtonDisabled;
		[ObservableValue]
		private GeneralErrorType _resourceError;
		[ObservableValue]
		private long _enoughResourcesTime;
		[ObservableValue]
		private Academy _academyInfo;
		[ObservableValue]
		private bool _errorMessageVisible;
		[ObservableValue]
		private bool _durationVisible;
		private AcademyWindowController academyWindowController;
		private OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public bool researchButtonDisabled { get => default; set {} }
		[ObservableValue]
		public GeneralErrorType resourceError { get => default; set {} }
		[ObservableValue]
		public long enoughResourcesTime { get => default; set {} }
		[ObservableValue]
		public Academy academyInfo { get => default; set {} }
		[ObservableValue]
		public bool errorMessageVisible { get => default; set {} }
		[ObservableValue]
		public bool durationVisible { get => default; set {} }
	
		// Constructors
		public AcademyResearchTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void SelectFirstUnit() {}
		public void Setup() {}
		private void UpdateUIState() {}
		private void UpdateResearchButtonDisabled() {}
		private bool GetResearchButtonDisabled() => default;
		[Testable]
		private bool GetDurationVisible() => default;
		[Testable]
		private bool GetErrorMessageVisible() => default;
		private void CheckResourceErrors() {}
		[UICallable]
		public override void SelectTroop(SelectedTroopInfo troopInfo) {}
		[UICallable]
		public void ResearchUnit(string adSalesVrid = null) {}
		[UICallable]
		public override void PlayAdForBoost() {}
	}
