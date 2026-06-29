// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.RateThisApp
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class RTATracking
	{
		// Fields
		private const string FirstLaunchDateKey = "FIRST_LAUNCH_DATE_KEY";
		private const string LastNativeReviewRequestDateKey = "LAST_NATIVE_REVIEW_REQUEST_DATE_KEY";
		private const string NumberOfSessionsSinceInstallKey = "NUMBER_OF_SESSIONS_SINCE_INSTALL_KEY";
		private const string IntermediateRedirectLastTriggeredKey = "INTERMEDIATE_REDIRECT_LAST_USED_KEY";
		private const string HasActiveRtaButtonKey = "HAS_ACTIVE_RTA_BUTTON_KEY";
		private const string RtaNotWorkingDataResetKey = "RTA_NOT_WORKING_DATA_RESET_KEY";
		private const string TriggerRtaOnNextValidLocationKey = "TRIGGER_RTA_ON_NEXT_VALID_LOCATION_KEY";
	
		// Properties
		public static int DaysSinceFirstLaunch { get; private set; }
		public static bool HasReviewedApp { get; }
		public static int NumberOfSessionsSinceInstall { get; private set; }
		public static bool HasUserRedirectedFromIntermediatePopup { get; private set; }
		public static bool HasActiveRTAButton { get; private set; }
		public static bool TriggerRTAOnNextValidLocation { get; set; }
		private static int DaysSinceLastNativeRequest { get; set; }
		private static bool IsFirstLaunch { get; set; }
	
		// Methods
		public static void OnAppLaunch() {}
		public static void ClearAllData() {}
		public static void NativeReviewRequestTriggered() {}
		public static void IntermediatePopupRedirectTriggered() {}
		public static void SetActiveButton(bool isActive) {}
		private static void CheckForDataReset() {}
		private static void CheckForForcedRTARequest() {}
		private static void UpdateOnLaunchData() {}
		private static void LoadFirstLaunchData() {}
		private static void LoadLastNativeRequestData() {}
		private static void LoadNumberOfSessionsSinceInstall() {}
		private static void LoadIntermediateRedirectData() {}
		private static void LoadActiveButtonData() {}
	}
