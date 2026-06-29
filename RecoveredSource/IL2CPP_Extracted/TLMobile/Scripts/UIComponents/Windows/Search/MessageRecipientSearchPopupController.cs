// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Search
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageRecipientSearchPopupController : GenericSearchPopupController<TLMobile.Generated.GraphQL.Game.Player>
	{
		// Fields
		[ObservableValue]
		private ObservableList<MessageRecipient> _allianceRecipients;
		[ObservableValue]
		private ObservableList<MessageRecipient> _selectedObjects;
		private Action<ObservableList<MessageRecipient>> callback;
	
		// Properties
		[ObservableValue]
		public ObservableList<MessageRecipient> allianceRecipients { get => default; set {} }
		[ObservableValue]
		public ObservableList<MessageRecipient> selectedObjects { get => default; set {} }
		protected override string searchType { get => default; }
	
		// Constructors
		public MessageRecipientSearchPopupController() {}
	
		// Methods
		private void _allianceRecipientsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _selectedObjectsNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(ObservableList<MessageRecipient> selectedObjectList, Action<ObservableList<MessageRecipient>> callback) {}
		protected override void DoBackendSearch() {}
		[UICallable]
		public bool FilterAlreadySelectedSpecials(MessageRecipient p) => default;
		[UICallable]
		public bool FilterAlreadySelectedPlayers(TLMobile.Generated.GraphQL.Game.Player p) => default;
		[UICallable]
		public override void SelectObject(TLMobile.Generated.GraphQL.Game.Player p) {}
		[UICallable]
		public void SelectSpecialObject(MessageRecipient recipient) {}
		[UICallable]
		public void Unselect(MessageRecipient recipient) {}
		[UICallable]
		public void RemoveAll() {}
		[UICallable]
		public virtual new void ConfirmSelection() {}
	}
