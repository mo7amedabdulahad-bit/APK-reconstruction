// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.RateThisApp
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RTAService : MonoBehaviour, IRTAService
	{
		// Fields
		public const string TriggerLocationMainMenuSwitchToVillageView = "MM_SwitchToVillageView";
		public const string TriggerLocationHeroApplyAttribute = "HERO_AppliedAttribute";
		[SerializeField]
		private RTAConfig _IOSconfig;
		[SerializeField]
		private RTAConfig _AndroidConfig;
		[SerializeField]
		private RTAConfig _DebugConfig;
		private const string RtaConfigModeSavedKey = "RTA_CONFIG_MODE_SAVED_KEY";
		private bool hasInternetConnection;
		private IReviewManager reviewManager;
		private readonly string remoteConfigKey;
	
		// Properties
		public static RTAEditorConfigMode EditorConfigMode { get => default; set {} }
		public bool ShowRTAButton { get; private set; }
		public bool ShowIntermediatePopup { get => default; }
		public System.Action OnShowRTAButtonTriggered { get; set; }
		public Action<bool> OnShowRTAButtonStateChanged { get; set; }
		public Action<ePopUpCloseReason> OnIntermediatePopupClosed { get; set; }
		public RTAConfig.ConfigData Config { get; private set; }
	
		// Nested types
		public enum ePopUpCloseReason
		{
			Unset = 0,
			BackgroundDismiss = 1,
			CloseButton = 2,
			SendToCustomerSupport = 3,
			ShowNativePopup = 4,
			ShowNativePopup_FailedNullRTAService = 5,
			ShowNativePopup_FailedRequestStoreReview = 6
		}
	
		public enum RTAEditorConfigMode
		{
			Remote = 0,
			Local = 1,
			Debug = 2
		}
	
		// Constructors
		public RTAService() {}
	
		// Methods
		public void DebugResetRTAButton() {}
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private void OnDestroy() {}
		public void Initialize() {}
		public void LaunchReviewFlow() {}
		public bool CanTriggerAttributeLocation(string location, int currentPoints, int addedPoints) => default;
		public void TriggerLocation(string location) {}
		public void IntermediatePopupClosed(ePopUpCloseReason closeReason) {}
		private void InitRTATracking() {}
		private IPromise LoadConfigs() => default;
		private void ParseConfig(string json) {}
		private void LoadActiveButtonState() {}
		private void RefreshShowRTAButton() {}
		private void SubscribeToInternetConnectivity() {}
		private void OnInternetConnectionChanged(bool connected) {}
	}
