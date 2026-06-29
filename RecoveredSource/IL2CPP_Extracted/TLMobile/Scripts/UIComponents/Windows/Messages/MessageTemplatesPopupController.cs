// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MessageTemplatesPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private GraphQLFetchableList<MessageTemplate> _templates;
		[ObservableValue]
		private bool _haveValuesToCreateTemplate;
		private Action<MessageTemplate> callback;
		private NewMessagePopupController parentControllerToCopyFrom;
	
		// Properties
		[ObservableValue]
		public GraphQLFetchableList<MessageTemplate> templates { get => default; set {} }
		[ObservableValue]
		public bool haveValuesToCreateTemplate { get => default; set {} }
	
		// Constructors
		public MessageTemplatesPopupController() {}
	
		// Methods
		private void _templatesNotify(object sender, PropertyChangedEventArgs args) {}
		public void Setup(NewMessagePopupController parentController, Action<MessageTemplate> callback) {}
		[UICallable]
		public void CreateNewTemplate() {}
		[UICallable]
		public void EditTemplate(MessageTemplate template) {}
		[UICallable]
		public void SelectTemplate(MessageTemplate template) {}
	}
