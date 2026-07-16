// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RaidsFiltersController : DetailWindowController
	{
		// Fields
		public const string PlayerPrefsFilterKey = "filtersOptionKey";
		[ObservableValue]
		private FilterOption _filtersFlags;
		private Action<FilterOption> filtersUpdatedCallback;
	
		// Properties
		[ObservableValue]
		public FilterOption filtersFlags { get => default; set {} }
	
		// Nested types
		[Flags]
		public enum FilterOption
		{
			None = 0,
			Troops = 1,
			Population = 2,
			Distance = 4,
			LastRaid = 8,
			BountyAndResources = 16,
			All = 31
		}
	
		// Constructors
		public RaidsFiltersController() {}
	
		// Methods
		protected override void Awake() {}
		private void SetFiltersFlags() {}
		public virtual void Setup(Action<FilterOption> filtersUpdatedCallback) {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void ToggleFilter(FilterOption filterOption) {}
		public static FilterOption GetCurrentlySavedFilters() => default;
	}
