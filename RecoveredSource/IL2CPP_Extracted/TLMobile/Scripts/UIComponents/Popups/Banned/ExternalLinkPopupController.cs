// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.Banned
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ExternalLinkPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private string _linkTarget;
	
		// Properties
		[ObservableValue]
		public string linkTarget { get => default; set {} }
	
		// Constructors
		public ExternalLinkPopupController() {}
	
		// Methods
		public void Setup(string link) {}
		[UICallable]
		public void OpenLink() {}
		[UICallable]
		public void CopyToClipboard() {}
	}
