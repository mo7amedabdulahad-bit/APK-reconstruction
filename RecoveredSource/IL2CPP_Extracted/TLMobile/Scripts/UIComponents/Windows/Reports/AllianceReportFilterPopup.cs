// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceReportFilterPopup : ReportFilterPopup
	{
		// Fields
		private const string HideSmallAttacksPrefsKey = "AllianceReportsHideSmallAttacks";
		[ObservableValue]
		private bool _hideSmallAttacks;
	
		// Properties
		[ObservableValue]
		public bool hideSmallAttacks { get => default; set {} }
		protected override string StatePlayerPrefsKey { get => default; }
	
		// Constructors
		public AllianceReportFilterPopup() {}
	
		// Methods
		protected override ObservableList<DropdownOption> SetupOptions() => default;
		[UICallable]
		public void ToggleHideAttacks() {}
		protected override List<int> CountSelectedFilters() => default;
		protected override void LoadStateFromPlayerPrefs() {}
		protected override void PersistFiltersState() {}
		protected override void DisableEveryFilterOption() {}
	}
