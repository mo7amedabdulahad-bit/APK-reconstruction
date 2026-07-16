// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NewMessagePopupController : GenericPopupWithInsertInEditButton
	{
		// Fields
		public AdvancedInputField messageInputField;
		public SpriteCfg icons;
		[ObservableValue]
		private bool _isReply;
		[ObservableValue]
		private string _message;
		[ObservableValue]
		private bool _previewMode;
		[ObservableValue]
		private ObservableList<MessageRecipient> _recipients;
		[ObservableValue]
		private string _subject;
		[ObservableValue]
		private MessageTopic? _messageTopic;
		[ObservableValue]
		private bool _bannedInvalidReceiver;
		[ObservableValue]
		private string _recipientsString;
		private ObservableList<DropdownOption> options;
		private DropdownOption selectedOption;
		protected MessageTemplate template;
	
		// Properties
		[ObservableValue]
		public bool isReply { get => default; set {} }
		[ObservableValue]
		public string message { get => default; set {} }
		[ObservableValue]
		public bool previewMode { get => default; set {} }
		[ObservableValue]
		public ObservableList<MessageRecipient> recipients { get => default; set {} }
		[ObservableValue]
		public string subject { get => default; set {} }
		[ObservableValue]
		public MessageTopic? messageTopic { get => default; set {} }
		[ObservableValue]
		public bool bannedInvalidReceiver { get => default; set {} }
		[ObservableValue]
		public string recipientsString { get => default; set {} }
	
		// Constructors
		public NewMessagePopupController() {}
	
		// Methods
		private void _recipientsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnDestroy() {}
		private void OnRecipientsChanged() {}
		private void OnMessageInputFieldEndEdit(string arg0, EndEditReason arg1) {}
		public void Setup(TLMobile.Generated.GraphQL.Game.Player recipient = null) {}
		public void Setup(TLMobile.Generated.GraphQL.Game.Message message) {}
		public void Setup(string message) {}
		public void Setup(MessageTemplate template) {}
		private void SetupMessageTopicDropDownController() {}
		private DropdownOption GetDropDownOptionForTopics(MessageTopic? topic) => default;
		private void SelectedMessageTopicChanged(DropdownOption option) {}
		public static string AddReplySubjectPrefix(string subject) => default;
		[UICallable]
		public void SearchForRecipient() {}
		[UICallable]
		public void InsertPlayerLink() {}
		[UICallable]
		public void InsertAllianceLink() {}
		[UICallable]
		public void InsertReportLink() {}
		[UICallable]
		public void InsertVillageLink() {}
		[UICallable]
		public void TogglePreview() {}
		[UICallable]
		public void SendMessage() {}
		public static SendMessage.TopicEnum? MessageTopicToTopicEnum(MessageTopic? messageTopic) => default;
		[UICallable]
		public void ShowDiscardMessagesPopup() {}
		[UICallable]
		public void OpenDropdown() {}
		[UICallable]
		public void InsertIcons() {}
		[UICallable]
		public void InsertEmojis() {}
		[UICallable]
		public void ShowTemplatesPopup() {}
	}
