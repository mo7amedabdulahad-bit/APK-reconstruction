// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DetailWindowTabController : ViewModelWithPolling
	{
		// Fields
		[HideInInspector]
		public DetailWindowController parentWindowController;
		[SerializeField]
		private bool waitForBackendFinished;
		[ObservableValue]
		private bool _backendFinished;
	
		// Properties
		[ObservableValue]
		public bool backendFinished { get => default; set {} }
	
		// Constructors
		public DetailWindowTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected virtual void BackendFinished() {}
		public virtual void OnOpen(int tabNumber) {}
	}
