// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerSearchPopupController : GenericSearchPopupControllerWithRecentlySelectedObjects<TLMobile.Generated.GraphQL.Game.Player>
	{
		// Properties
		protected override string searchType { get => default; }
	
		// Constructors
		public PlayerSearchPopupController() {}
	
		// Methods
		protected override IPromise<TLMobile.Generated.GraphQL.Game.Player> GetPromise(int playerId, bool forceFetch = true) => default;
		protected override TLMobile.Generated.GraphQL.Game.Player Get(int playerId) => default;
		protected override int Id(TLMobile.Generated.GraphQL.Game.Player player) => default;
		protected override void DoBackendSearch() {}
	}
