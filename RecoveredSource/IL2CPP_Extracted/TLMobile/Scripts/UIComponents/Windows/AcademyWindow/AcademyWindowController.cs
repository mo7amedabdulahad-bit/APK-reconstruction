// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AcademyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AcademyWindowController : BuildingDetailWindowController
	{
		// Fields
		[ObservableValue]
		private SelectableAmounts _researchableUnits;
		[ObservableValue]
		private SelectableAmounts _allUnits;
		private Academy academyInfo;
	
		// Properties
		[ObservableValue]
		public SelectableAmounts researchableUnits { get => default; set {} }
		[ObservableValue]
		public SelectableAmounts allUnits { get => default; set {} }
	
		// Constructors
		public AcademyWindowController() {}
	
		// Methods
		[Testable]
		protected override void UpdateBuildingData(OwnVillage village) {}
		private void UpdateResearchableTroops() {}
		private TroopAmounts GetResearchableUnits(bool ignoreResearchedUnits = true) => default;
	}
