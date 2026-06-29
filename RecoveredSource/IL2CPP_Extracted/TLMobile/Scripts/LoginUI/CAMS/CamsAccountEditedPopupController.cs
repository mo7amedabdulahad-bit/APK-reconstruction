// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsAccountEditedPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private string _popupTitle;
		[ObservableValue]
		private string _popupMessage;
	
		// Properties
		[ObservableValue]
		public string popupTitle { get => default; set {} }
		[ObservableValue]
		public string popupMessage { get => default; set {} }
	
		// Constructors
		public CamsAccountEditedPopupController() {}
	
		// Methods
		public void Setup(string popupTitle, string popupMessage, System.Action onClose = null) {}
	}
