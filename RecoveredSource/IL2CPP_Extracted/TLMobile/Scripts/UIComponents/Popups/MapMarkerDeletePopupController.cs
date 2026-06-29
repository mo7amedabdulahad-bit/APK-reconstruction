// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class MapMarkerDeletePopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private MapMarker _marker;
		[ObservableValue]
		private MapFlag _flag;
		[ObservableValue]
		private bool _doNotShowAgain;
		private System.Action confirmDeleteCallback;
	
		// Properties
		[ObservableValue]
		public MapMarker marker { get => default; set {} }
		[ObservableValue]
		public MapFlag flag { get => default; set {} }
		[ObservableValue]
		public bool doNotShowAgain { get => default; set {} }
	
		// Constructors
		public MapMarkerDeletePopupController() {}
	
		// Methods
		public void Setup(System.Action onConfirmedCallback, MapMarker marker, MapFlag flag) {}
		[UICallable]
		public void OnConfirmClicked() {}
		[UICallable]
		public void DoNotShowAgain() {}
	}
