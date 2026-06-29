// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RegionSearchPopupController : GenericSearchPopupControllerWithRecentlySelectedObjects<Region>
	{
		// Fields
		[ObservableValue]
		private bool _isTerritory;
	
		// Properties
		[ObservableValue]
		public bool isTerritory { get => default; set {} }
		protected override string searchType { get => default; }
		protected override int requiredCharsForSearch { get => default; }
	
		// Constructors
		public RegionSearchPopupController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override IPromise<Region> GetPromise(int regionId, bool forceFetch = true) => default;
		protected override Region Get(int regionId) => default;
		protected override int Id(Region region) => default;
		protected override void DoBackendSearch() {}
	}
