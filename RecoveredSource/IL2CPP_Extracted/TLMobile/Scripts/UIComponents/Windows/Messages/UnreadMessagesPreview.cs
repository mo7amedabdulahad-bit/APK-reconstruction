// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UnreadMessagesPreview : DetailWindowTabControllerWithPagination<TLMobile.Generated.GraphQL.Game.Message>
	{
		// Fields
		private readonly IncomingMessagesFilter unreadMessagesFilter;
		[ObservableValue]
		private bool _isExpanded;
		[ObservableValue]
		private Generated.GraphQL.Game.Messages _messages;
	
		// Properties
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public Generated.GraphQL.Game.Messages messages { get => default; set {} }
	
		// Constructors
		public UnreadMessagesPreview() {}
	
		// Methods
		private void Start() {}
		private void UpdateUnreadMessages() {}
	}
