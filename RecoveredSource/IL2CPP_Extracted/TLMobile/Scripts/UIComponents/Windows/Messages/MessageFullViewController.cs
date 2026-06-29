// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageFullViewController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Message _message;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Message _prevMessage;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Message _nextMessage;
		[ObservableValue]
		private MessageViewEnum _currentView;
		[ObservableValue]
		private bool _mayWriteMessage;
		[ObservableValue]
		private bool _freshDeskMessage;
		[ObservableValue]
		private ProcessedMessage _processedMessage;
		private PaginatedListProvider<TLMobile.Generated.GraphQL.Game.Message> messagesPaginatedData;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Message message { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Message prevMessage { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Message nextMessage { get => default; set {} }
		[ObservableValue]
		public MessageViewEnum currentView { get => default; set {} }
		[ObservableValue]
		public bool mayWriteMessage { get => default; set {} }
		[ObservableValue]
		public bool freshDeskMessage { get => default; set {} }
		[ObservableValue]
		public ProcessedMessage processedMessage { get => default; set {} }
	
		// Constructors
		public MessageFullViewController() {}
	
		// Methods
		public void Setup(TLMobile.Generated.GraphQL.Game.Message messageToShow, MessageViewEnum currentView, PaginatedListProvider<TLMobile.Generated.GraphQL.Game.Message> paginatedData = null) {}
		private void SearchNeighboringMessages() {}
		public void RefreshPaginationData() {}
		[UICallable]
		public void OpenDifferentMessage(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void ShowConfirmDeleteMessagesPopup() {}
		private void DeleteMessage() {}
		[UICallable]
		public void ArchiveMessage(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void RecoverMessage(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void MarkAsUnread() {}
		[Testable]
		private void MarkAsRead() {}
		[UICallable]
		public void ToggleBlockPlayer() {}
		[UICallable]
		public void TryOpenReportPopup() {}
		[UICallable]
		public void OpenFreshDeskMessageInBrowser() {}
	}
