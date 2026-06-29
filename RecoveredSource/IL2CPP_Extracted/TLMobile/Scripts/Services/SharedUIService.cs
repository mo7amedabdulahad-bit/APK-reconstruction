// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Services
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SharedUIService : MonoBehaviour, ISharedUIService
	{
		// Fields
		private DetailWindowsShowController _detailWindowsShowController;
		private BuildingRadialMenuController buildingRadialMenuController;
		private GameObject detailWindowsContainer;
		private MainUIStateController mainUIStateController;
		private INotificationController notificationController;
		private GameObject popupWindowsContainer;
		private SafeAreaAdapter safeAreaAdapter;
		private IToastMessageController toastMessageController;
		private WaitForBackendScreenController waitForBackendScreenController;
	
		// Properties
		public MainUIStateController MainUIStateController { get => default; set {} }
		public SafeAreaAdapter SafeAreaAdapter { get => default; set {} }
		public GameObject DetailWindowsContainer { get => default; set {} }
		public GameObject PopupWindowsContainer { get => default; set {} }
		public BuildingRadialMenuController BuildingRadialMenuController { get => default; set {} }
		public WaitForBackendScreenController WaitForBackendScreenController { get => default; set {} }
		public IToastMessageController ToastMessageController { get => default; set {} }
		public INotificationController NotificationController { get => default; set {} }
		public DetailWindowsShowController DetailWindowsShowController { get => default; set {} }
	
		// Constructors
		public SharedUIService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public virtual void OnChangeView(SceneStatus status) {}
	}
