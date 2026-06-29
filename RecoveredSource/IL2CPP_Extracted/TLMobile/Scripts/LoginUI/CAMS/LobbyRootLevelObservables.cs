// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class LobbyRootLevelObservables : ViewModelWithPolling
	{
		// Fields
		[ObservableValue]
		[PollForUpdates(5f, 1, -1f)]
		private OwnIdentity _ownIdentity;
		[ObservableValue]
		private int _currentTimestamp;
	
		// Properties
		[ObservableValue]
		[PollForUpdates(5f, 1, -1f)]
		public OwnIdentity ownIdentity { get => default; set {} }
		[ObservableValue]
		public int currentTimestamp { get => default; set {} }
	
		// Constructors
		public LobbyRootLevelObservables() {}
	
		// Methods
		protected void Start() {}
		protected override void OnEnable() {}
		private void CheckDeletionState() {}
	}
