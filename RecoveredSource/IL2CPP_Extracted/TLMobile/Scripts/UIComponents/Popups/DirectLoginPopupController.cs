// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DirectLoginPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private bool _dontAskAgain;
	
		// Properties
		[ObservableValue]
		public bool dontAskAgain { get => default; set {} }
	
		// Constructors
		public DirectLoginPopupController() {}
	
		// Methods
		[UICallable]
		public void ToggleDontAskAgain() {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void EnableDirectLogin() {}
	}
