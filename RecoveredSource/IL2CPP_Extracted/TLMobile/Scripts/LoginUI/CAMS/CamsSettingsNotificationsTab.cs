// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CamsSettingsNotificationsTab : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private bool _enablePushNotifications;
		[ObservableValue]
		private bool _enableGameworldStartNotifications;
		private IPushNotificationsService pushNotificationsService;
	
		// Properties
		[ObservableValue]
		public bool enablePushNotifications { get => default; set {} }
		[ObservableValue]
		public bool enableGameworldStartNotifications { get => default; set {} }
	
		// Constructors
		public CamsSettingsNotificationsTab() {}
	
		// Methods
		protected override void OnEnable() {}
		[UICallable]
		public void TogglePushNotifications() {}
		[UICallable]
		public void ToggleGameworldStartNotifications() {}
	}
