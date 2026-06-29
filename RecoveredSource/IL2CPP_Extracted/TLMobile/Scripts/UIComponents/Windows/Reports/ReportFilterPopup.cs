// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportFilterPopup : MultiSelectableListControllerWithPersistedState<ReportIcon>
	{
		// Fields
		public SpriteCfg spriteCfg;
	
		// Properties
		protected override string StatePlayerPrefsKey { get => default; }
	
		// Nested types
		public enum ReportFilterMainCategory
		{
			None = -1,
			Offensive = 400,
			Defensive = 401,
			Scouting = 402,
			Other = 403
		}
	
		// Constructors
		public ReportFilterPopup() {}
	
		// Methods
		protected override ObservableList<DropdownOption> SetupOptions() => default;
		private DropdownOption GetMainCategoryOption(ReportFilterMainCategory category, string translateKey, int iconIndex) => default;
		private DropdownOption GetSubCategoryOption(ReportIcon reportCat) => default;
	}
