// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessagePaginationTabController : DetailWindowTabControllerWithPagination<TLMobile.Generated.GraphQL.Game.Message>
	{
		// Fields
		[SerializeField]
		private MessageViewEnum selectedTab;
		[ObservableValue]
		private int _selectedMessages;
		[Testable]
		protected IPaginatedDataQuery<TLMobile.Generated.GraphQL.Game.Message> query;
	
		// Properties
		[ObservableValue]
		public int selectedMessages { get => default; set {} }
	
		// Constructors
		public MessagePaginationTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		public void Init() {}
		[UICallable]
		public void ShowConfirmDeleteMessagesPopup(int selectedMessages) {}
		[UICallable]
		public void DeleteSelected() {}
		[UICallable]
		public void MarkSelectedAsRead() {}
		[UICallable]
		public void ArchiveSelected() {}
		[UICallable]
		public void RecoverSelected() {}
		private void DeselectSelectedMessages(List<TLMobile.Generated.GraphQL.Game.Message> messages) {}
		[UICallable]
		public void ShowMessageFullView(TLMobile.Generated.GraphQL.Game.Message message) {}
		[UICallable]
		public void RefreshMessages() {}
		[UICallable]
		public void ToggleSelection(TLMobile.Generated.GraphQL.Game.Message message) {}
		protected void CheckSelectedAfterRefresh() {}
	}
