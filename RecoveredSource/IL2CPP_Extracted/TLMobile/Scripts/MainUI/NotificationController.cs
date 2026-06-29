// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class NotificationController : ViewModel, INotificationController
	{
		// Fields
		private static readonly NotificationInterfaceType[] browserOnlyNotifications;
		private static readonly NotificationInterfaceType[] worldEndNotifications;
		public float poolNotificationInterval;
		public bool useCurrentDummyNotifications;
		[ObservableValue]
		private bool _mainUIHasOpenWindow;
		[ObservableValue]
		private ObservableList<TLMobile.Generated.GraphQL.Game.NotificationInterface> _notificationInterfaces;
		private TLMobile.Generated.GraphQL.Game.NotificationInterface displayedNotificationInterface;
		private float nextNotificationFetch;
		private TLMobile.Generated.GraphQL.Game.NotificationInterface worldEndNotification;
		private RootLevelObservables rootLevelObservables;
		private bool showShopPromotionNotificationWhenIdle;
		private CancellationTokenSource cancellationTokenSource;
	
		// Properties
		[ObservableValue]
		public bool mainUIHasOpenWindow { get => default; set {} }
		[ObservableValue]
		public ObservableList<TLMobile.Generated.GraphQL.Game.NotificationInterface> notificationInterfaces { get => default; set {} }
		private string LastSeenShopPromotionSaveKey { get => default; }
	
		// Constructors
		public NotificationController() {}
		static NotificationController() {}
	
		// Methods
		private void _notificationInterfacesNotify(object sender, PropertyChangedEventArgs args) {}
		public bool HasWorldEnded(bool showNotification = false) => default;
		protected override void Awake() {}
		private void Update() {}
		private void OnEnable() {}
		protected override void OnDestroy() {}
		public void ShowWorldEndNotification() {}
		private void Init() {}
		private void OnIdlingChanged(bool isIdeling) {}
		private void UpdateMainUIHasOpenWindow(bool mainUIHasOpenWindow) {}
		private void UpdateNextNotificationFetch() {}
		private void FetchNotifications() {}
		private void CheckForShopPromotionNotification() {}
		private void CheckForWorldEndNotification() {}
		private void CreateNotificationPopupsWhenNotInAction(TLMobile.Generated.GraphQL.Game.NotificationInterface notificationInterface = null) {}
		private void ShowShopPromotionNotification() {}
		private void OnBlockingUIStateChanged(bool isBlocked) {}
		private void CreateNotificationPopup(TLMobile.Generated.GraphQL.Game.NotificationInterface notificationInterface) {}
		private void HideNotificationDetailWindowController() {}
		private void CycleNotifications(TLMobile.Generated.GraphQL.Game.NotificationInterface notificationInterface) {}
		[ContextMenu("CreateAllDummyNotification")]
		public void CreateAllDummyNotification() {}
		[ContextMenu("CreateDummyNotificationInBackground")]
		public void CreateDummyNotificationInBackground() {}
		public void CreateDummyNotification(string notificationAcronyms = null) {}
		private static void CreateDummyBanner() {}
	}
