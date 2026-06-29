// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DualSearchPopupController : GenericSearchPopupController<TLMobile.Generated.GraphQL.Lobby.Identity>
	{
		// Fields
		[ObservableValue]
		private GraphQLFetchableList<TLMobile.Generated.GraphQL.Lobby.Identity> _duals;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Lobby.Identity> _selectedDuals;
		private Avatar avatar;
		private Action<ObservableList<TLMobile.Generated.GraphQL.Lobby.Identity>> callback;
	
		// Properties
		[ObservableValue]
		public GraphQLFetchableList<TLMobile.Generated.GraphQL.Lobby.Identity> duals { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Lobby.Identity> selectedDuals { get => default; set {} }
		protected override string searchType { get => default; }
	
		// Constructors
		public DualSearchPopupController() {}
	
		// Methods
		private void _dualsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _selectedDualsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(Action<ObservableList<TLMobile.Generated.GraphQL.Lobby.Identity>> callback, Avatar avatar) {}
		protected override void DoBackendSearch() {}
		[UICallable]
		public bool FilterAlreadySelectedDuals(TLMobile.Generated.GraphQL.Lobby.Identity i) => default;
		[UICallable]
		public override void SelectObject(TLMobile.Generated.GraphQL.Lobby.Identity identity) {}
		[UICallable]
		public void Unselect(TLMobile.Generated.GraphQL.Lobby.Identity identity) {}
		[UICallable]
		public virtual new void ConfirmSelection() {}
	}
