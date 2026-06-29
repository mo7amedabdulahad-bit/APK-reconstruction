// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Reports
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NotificationDetailWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.NotificationInterface _notification;
		[ObservableValue]
		private bool _buttonVisible;
		[ObservableValue]
		private string _buttonActionTranslationKey;
	
		// Properties
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.NotificationInterface notification { get => default; set {} }
		[ObservableValue]
		public bool buttonVisible { get => default; set {} }
		[ObservableValue]
		public string buttonActionTranslationKey { get => default; set {} }
	
		// Constructors
		public NotificationDetailWindowController() {}
	
		// Methods
		public void Setup(TLMobile.Generated.GraphQL.Game.NotificationInterface notificationInterface) {}
		[UICallable]
		public void OnButtonAction() {}
	}
