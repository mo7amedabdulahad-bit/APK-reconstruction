// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AdvancedTroopMovementFilterPopup : MultiSelectableListControllerWithPersistedState<TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption>
	{
		// Fields
		public SpriteCfg spritesCfg;
	
		// Properties
		protected override string StatePlayerPrefsKey { get => default; }
	
		// Constructors
		public AdvancedTroopMovementFilterPopup() {}
	
		// Methods
		protected override ObservableList<DropdownOption> SetupOptions() => default;
		private string GetTranslationKey(TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption option) => default;
		public static int[] MapFilterOptionsToMovingTroopsTypes(IEnumerable<TLMobile.Scripts.UIComponents.Windows.RallyPoint.TroopsOverview.FilterOption> filterOptions) => default;
	}
