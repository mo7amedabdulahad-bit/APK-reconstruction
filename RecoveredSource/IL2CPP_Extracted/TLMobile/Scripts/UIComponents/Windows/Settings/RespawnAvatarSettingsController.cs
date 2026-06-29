// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Settings
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RespawnAvatarSettingsController : ViewModelWithPolling
	{
		// Fields
		private const string KeySuffix = "respawn";
		[ObservableValue]
		private bool _isDual;
		[ObservableValue]
		private string _backendError;
	
		// Properties
		[ObservableValue]
		public bool isDual { get => default; set {} }
		[ObservableValue]
		public string backendError { get => default; set {} }
	
		// Constructors
		public RespawnAvatarSettingsController() {}
	
		// Methods
		protected override void Awake() {}
		[UICallable]
		public void RespawnAvatar() {}
		private void StartAvatarRespawn() {}
		private void OnAvatarRespawnError(ApiException error) {}
	}
