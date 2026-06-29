// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageSearchPopupController : GenericSearchPopupControllerWithRecentlySelectedObjects<Village>
	{
		// Fields
		[ObservableValue]
		private GraphQLFetchableList<Village> _ownVillages;
	
		// Properties
		[ObservableValue]
		public GraphQLFetchableList<Village> ownVillages { get => default; set {} }
		protected override string searchType { get => default; }
	
		// Constructors
		public VillageSearchPopupController() {}
	
		// Methods
		private void _ownVillagesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override IPromise<Village> GetPromise(int villageId, bool forceFetch = true) => default;
		protected override Village Get(int villageId) => default;
		protected override int Id(Village village) => default;
		protected override void DoBackendSearch() {}
	}
