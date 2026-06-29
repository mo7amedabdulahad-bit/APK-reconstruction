// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.PlayerDetails
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PlayerPreviewDescriptionPopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private string _currentColumn1;
		[ObservableValue]
		private string _currentColumn2;
		private System.Action saveChangesCallback;
	
		// Properties
		[ObservableValue]
		public string currentColumn1 { get => default; set {} }
		[ObservableValue]
		public string currentColumn2 { get => default; set {} }
	
		// Constructors
		public PlayerPreviewDescriptionPopup() {}
	
		// Methods
		public void Setup(System.Action saveChangesCallback, string currentColumn1, string currentColumn2) {}
		[UICallable]
		public void SaveChanges() {}
		[UICallable]
		public void ContinueEdit() {}
	}
