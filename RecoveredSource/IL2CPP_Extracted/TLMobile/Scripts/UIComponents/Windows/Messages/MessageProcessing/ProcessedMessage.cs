// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Messages.MessageProcessing
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ProcessedMessage : ObservableModel
	{
		// Fields
		[ObservableValue]
		private string _messageSubject;
		[ObservableValue]
		private string _messageContent;
		[ObservableValue]
		private ObservableList<ButtonInfo> _buttons;
	
		// Properties
		[ObservableValue]
		public string messageSubject { get => default; set {} }
		[ObservableValue]
		public string messageContent { get => default; set {} }
		[ObservableValue]
		public ObservableList<ButtonInfo> buttons { get => default; set {} }
	
		// Constructors
		public ProcessedMessage() {} // Dummy constructor
		public ProcessedMessage(string messageSubject, string messageContent) {}
	
		// Methods
		private void _buttonsNotify(object sender, PropertyChangedEventArgs args) {}
		public ButtonInfo AddButton(string locaKey, ColorCfg.Type color, System.Action onClickCallback, bool isDisabled = false) => default;
		[UICallable]
		public void ClickOnButton(int buttonIndex) {}
	}
