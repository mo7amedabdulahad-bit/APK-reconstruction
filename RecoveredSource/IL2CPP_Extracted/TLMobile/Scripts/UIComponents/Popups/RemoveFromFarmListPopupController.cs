// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RemoveFromFarmListPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private bool _dontAskAgain;
		[ObservableValue]
		private string _targetName;
		[ObservableValue]
		private string _farmListCount;
		private Action<bool> onConfirm;
	
		// Properties
		[ObservableValue]
		public bool dontAskAgain { get => default; set {} }
		[ObservableValue]
		public string targetName { get => default; set {} }
		[ObservableValue]
		public string farmListCount { get => default; set {} }
	
		// Constructors
		public RemoveFromFarmListPopupController() {}
	
		// Methods
		public void Setup(Action<bool> onClosed, string locationName, string count) {}
		[UICallable]
		public void ToggleDontAskAgain() {}
		[UICallable]
		public override void Hide() {}
		[UICallable]
		public void Confirm() {}
	}
