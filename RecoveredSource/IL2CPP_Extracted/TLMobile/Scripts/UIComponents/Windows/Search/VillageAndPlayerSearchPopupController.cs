// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageAndPlayerSearchPopupController : DetailWindowController
	{
		// Fields
		public VillageSearchPopupController villageSearchPopupController;
		public PlayerSearchPopupController playerSearchPopupController;
		[ObservableValue]
		private SearchType _searchType;
		private Action<Village, TLMobile.Generated.GraphQL.Game.Player> callback;
	
		// Properties
		[ObservableValue]
		public SearchType searchType { get => default; set {} }
	
		// Nested types
		public enum SearchType
		{
			Village = 0,
			Player = 1
		}
	
		// Constructors
		public VillageAndPlayerSearchPopupController() {}
	
		// Methods
		protected override void Awake() {}
		public void Setup(Action<Village, TLMobile.Generated.GraphQL.Game.Player> callback) {}
		[UICallable]
		public void SetSearchType(SearchType searchType) {}
		[UICallable]
		public void CloseWindow() {}
	}
