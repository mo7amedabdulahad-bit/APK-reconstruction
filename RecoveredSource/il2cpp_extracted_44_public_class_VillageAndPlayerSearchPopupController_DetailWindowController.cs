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
