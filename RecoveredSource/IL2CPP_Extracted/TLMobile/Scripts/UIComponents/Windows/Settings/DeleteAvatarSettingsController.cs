// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class DeleteAvatarSettingsController : ViewModelWithPolling
	{
		// Fields
		private const string KeySuffix = "delete";
		[ObservableValue]
		[PollForUpdates(5f, 9, -1f)]
		private OwnPlayer _ownPlayer;
		[ObservableValue]
		private bool _isInDeletion;
	
		// Properties
		[ObservableValue]
		[PollForUpdates(5f, 9, -1f)]
		public OwnPlayer ownPlayer { get => default; set {} }
		[ObservableValue]
		public bool isInDeletion { get => default; set {} }
	
		// Constructors
		public DeleteAvatarSettingsController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void UpdateState() {}
		[UICallable]
		public void DeleteAvatar() {}
		[UICallable]
		public void CancelAvatarDeletion() {}
		[UICallable]
		public void ShowMoreInfo() {}
		private void StartAccountDeletionOrCancelIt(int? deletionValue = default) {}
	}
